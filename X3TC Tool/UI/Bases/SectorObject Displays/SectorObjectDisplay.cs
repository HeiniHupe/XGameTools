﻿using Common.Memory;
using System;
using System.Windows.Forms;
using X3TC_Tool.UI.Bases.StoryBase_Displays.Scripting;
using X3TCTools;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.AP;
using X3TCTools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC;
using X3TCTools.Generics;
using X3TCTools.Sector_Objects;

namespace X3TC_Tool.UI.Displays
{
    public partial class SectorObjectDisplay : Form
    {
        private SectorObject m_SectorObject;
        public SectorObjectDisplay()
        {
            InitializeComponent();
            for (int i = 0; i < SectorObject.MAIN_TYPE_COUNT; i++)
            {
                ChildTypeSelectionBox.Items.Add(((SectorObject.Main_Type)i).ToString());
            }
        }


        private void LoadTree(int autoLoadID = 0, SectorObject baseSectorObject = null)
        {
            // If base is null, assume it to be space.
            if (baseSectorObject == null)
            {
                baseSectorObject = GameHook.sectorObjectManager.GetSpace();
            }

            treeView1.Nodes.Clear();
            TreeNode selectedNode;
            treeView1.Nodes.Add(GenerateTreeNode(baseSectorObject, autoLoadID, out selectedNode));
            if (selectedNode != null)
            {
                treeView1.SelectedNode = selectedNode;
                selectedNode.Expand();
            }

        }
        private TreeNode GenerateTreeNode(SectorObject baseSectorObject, int selectedID, out TreeNode selectedNode)
        {
            string sectorObjectName;
            switch (baseSectorObject.ObjectType.MainTypeEnum)
            {
                case SectorObject.Main_Type.Gate:
                    IScriptMemoryObject_Gate gateScriptMemoryObject;
                    switch (GameHook.GameVersion)
                    {
                        case GameHook.GameVersions.X3AP:
                            gateScriptMemoryObject = baseSectorObject.EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Gate>();
                            break;
                        case GameHook.GameVersions.X3TC:
                            gateScriptMemoryObject = baseSectorObject.EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Gate>();
                            break;
                        default: throw new Exception();
                    }
                    sectorObjectName = string.Format("{0} ({1})", baseSectorObject.GetSubTypeAsString(), GameHook.gateSystemObject.GetSectorName(gateScriptMemoryObject.DestSectorX, gateScriptMemoryObject.DestSectorY));
                    break;
                default: sectorObjectName = baseSectorObject.GetSubTypeAsString(); break;
            }

            TreeNode newNode = new TreeNode(sectorObjectName)
            {
                //Add tag
                Tag = baseSectorObject
            };

            // If sectorObject is selected object, set selectedNode
            selectedNode = (baseSectorObject.ObjectID == selectedID) ? newNode : null;


            // Give node a color based on it's owning race.
            newNode.BackColor = GameHook.GetRaceColor(baseSectorObject.RaceID);

            // Append children to the tree.
            for (int mainType = 0; mainType < SectorObject.MAIN_TYPE_COUNT; mainType++)
            {
                SectorObject[] children = baseSectorObject.GetAllChildrenWithType(mainType);

                // Sort children
                Array.Sort(children);
                Array.Reverse(children);

                if (children.Length > 0) // Check if node will have contents, if so continue.
                {
                    TreeNode childNode = newNode.Nodes.Add(string.Format("Type {0} ({1})", ((SectorObject.Main_Type)mainType).ToString(), children.Length));

                    foreach (SectorObject child in children)
                    {
                        TreeNode childSelectedNode;
                        childNode.Nodes.Add(GenerateTreeNode(child, selectedID, out childSelectedNode));
                        if (childSelectedNode != null)
                        {
                            selectedNode = childSelectedNode;
                        }
                    }
                }
            }

            return newNode;
        }

        public void LoadObject(int ID)
        {
            SectorObjectManager sectorObjectManager = GameHook.sectorObjectManager;
            HashTable<SectorObject> hashtable = sectorObjectManager.pObjectHashTable.obj;
            SectorObject obj;
            try
            {
                obj = hashtable.GetObject(ID);
            }
            catch (Exception)
            {
                txtAddress.Text = "Not Found!";
                return;
            }
            LoadObject(obj);
        }

        public void LoadObject(SectorObject sectorObject)
        {
            m_SectorObject = sectorObject;
            Reload();
        }

        public void Reload()
        {

            // Sector Info
            SectorObject sector = GameHook.sectorObjectManager.GetSpace();
            try
            {
                IScriptMemoryObject_Sector sectorScriptVariables;
                switch (GameHook.GameVersion)
                {
                    case GameHook.GameVersions.X3TC:
                        sectorScriptVariables = sector.EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_TC_Sector>();
                        break;
                    case GameHook.GameVersions.X3AP:
                        sectorScriptVariables = sector.EventObject.GetScriptVariableArrayAsObject<ScriptMemoryObject_AP_Sector>();
                        break;
                    default:
                        goto ObjectInfo;
                }
                string sectorName = GameHook.gateSystemObject.GetSectorName((byte)sectorScriptVariables.SectorX, (byte)sectorScriptVariables.SectorY);
                labelSectorInfo.Text = string.Format("Sector: {0} | {1},{2}", sectorName, sectorScriptVariables.SectorX, sectorScriptVariables.SectorY);
            }
            catch (Exception)
            {
                labelSectorInfo.Text = "Sector: Invalid ScriptObject";
            }

        ObjectInfo:
            // Reload from memory to ensure it is up to date.
            m_SectorObject.ReloadFromMemory();
            // Load tree if not auto reloading
            if (!AutoReloadCheckBox.Checked)
            {
                LoadTree(m_SectorObject.ObjectID);
            }

            txtAddress.Text = m_SectorObject.pThis.ToString("X");
            txtDefaultName.Text = GameHook.storyBase.GetParsedText(GameHook.systemBase.Language, MemoryControl.ReadNullTerminatedString(GameHook.hProcess, m_SectorObject.pDefaultName));
            nudSectorObjectID.Value = m_SectorObject.ObjectID;
            v3dPosition.Vector = m_SectorObject.Position_Copy;
            v3dPositionKm.X = ((decimal)m_SectorObject.Position_Copy.X) / 500000;
            v3dPositionKm.Y = ((decimal)m_SectorObject.Position_Copy.Y) / 500000;
            v3dPositionKm.Z = ((decimal)m_SectorObject.Position_Copy.Z) / 500000;
            v3dRotation.Vector = m_SectorObject.EulerRotationCopy;
            eventObjectPannel1.EventObject = m_SectorObject.EventObject;
            txtType.Text = string.Format("{0} - {1} // {2} - {3}", m_SectorObject.ObjectType.MainTypeEnum.ToString(), m_SectorObject.GetSubTypeAsString(), (int)m_SectorObject.ObjectType.MainTypeEnum, m_SectorObject.ObjectType.SubType);

            SpeedBox.Value = m_SectorObject.Speed;
            TargetSpeedBox.Value = m_SectorObject.TargetSpeed;
            nudMass.Value = m_SectorObject.Mass;

            txtRace.Text = m_SectorObject.RaceID.ToString();

            ModelCollectionIDBox.Text = m_SectorObject.ModelCollectionID.ToString();


            // Object relation
            // If auto reloading, disable buttons
            btnGoNext.Enabled = m_SectorObject.pNext.IsValid && m_SectorObject.pNext.obj.IsValid && !AutoReloadCheckBox.Enabled;
            btnGoPrevious.Enabled = m_SectorObject.pPrevious.IsValid && m_SectorObject.pPrevious.obj.IsValid && !AutoReloadCheckBox.Enabled;
            btnGoParent.Enabled = m_SectorObject.pParent.IsValid && m_SectorObject.pParent.obj.IsValid && !AutoReloadCheckBox.Enabled;
            

            ReloadChildren();

        }

        public void ReloadChildren()
        {
            if (ChildTypeSelectionBox.SelectedIndex < 0)
            {
                goto failed;
            }

            X3TCTools.Sector_Objects.Meta.ISectorObjectMeta meta = m_SectorObject.GetMeta();
            if (meta == null || meta.GetFirstChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex) == null || meta.GetLastChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex) == null)
            {
                goto failed;
            }

            FirstChildButton.Enabled = true;
            LastChildButton.Enabled = true;
            return;

        failed:
            FirstChildButton.Enabled = false;
            LastChildButton.Enabled = false;
            return;
        }

        private void LoadIDButton_Click(object sender, EventArgs e)
        {
            LoadObject(Convert.ToInt32(nudSectorObjectID.Value));
        }

        private void AutoReloader_Tick(object sender, EventArgs e)
        {
            if (m_SectorObject.IsValid)
            {
                Reload();
            }
            else
            {
                m_SectorObject = null;
                txtAddress.Text = "Object Destroyed.";
                AutoReloadCheckBox.Checked = false;
            }
        }

        private void AutoReloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoReloader.Enabled = AutoReloadCheckBox.Checked;
            treeView1.Enabled =
                groupBox6.Enabled =
                !AutoReloadCheckBox.Checked;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_SectorObject.pNext.obj);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_SectorObject.pPrevious.obj);
        }

        private void ParentButton_Click(object sender, EventArgs e)
        {
            LoadObject(m_SectorObject.pParent.obj);
        }

        private void ChildTypeSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadChildren();
        }

        private void FirstChildButton_Click(object sender, EventArgs e)
        {
            X3TCTools.Sector_Objects.Meta.ISectorObjectMeta meta = m_SectorObject.GetMeta();
            SectorObject child = meta.GetFirstChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex);
            if (child != null)
            {
                LoadObject(child);
            }
        }

        private void LastChildButton_Click(object sender, EventArgs e)
        {
            X3TCTools.Sector_Objects.Meta.ISectorObjectMeta meta = m_SectorObject.GetMeta();
            SectorObject child = meta.GetLastChild((SectorObject.Main_Type)ChildTypeSelectionBox.SelectedIndex);
            if (child != null)
            {
                LoadObject(child);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RenderObjectDisplay display = new RenderObjectDisplay();
            display.LoadData(m_SectorObject.pData.obj);
            display.Show();
        }

        private void typeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeDataDisplay display = new TypeDataDisplay();
            display.LoadTypeData((int)m_SectorObject.ObjectType.MainTypeEnum, m_SectorObject.ObjectType.SubType);
            display.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Tag == null)
            {
                return;
            }

            SectorObject newSO = (SectorObject)e.Node.Tag;
            if (m_SectorObject == newSO)
            {
                return;
            }

            LoadObject(newSO);
        }

        private void sectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadObject(GameHook.sectorObjectManager.GetSpace());
        }

        private void playerShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadObject(GameHook.sectorObjectManager.GetPlayerObject());
        }

        private void SectorObjectDisplay_Load(object sender, EventArgs e)
        {

        }

        private void spawnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeSelectDialog selector = new TypeSelectDialog();
            selector.ShowDialog();
            if (selector.Done)
            {
                GameHook.gameCodeRunner.CreateSectorObject(selector.MainType, selector.SubType, GameHook.sectorObjectManager.GetSpace());
            }
        }

        private void btnLoadEventObject_Click(object sender, EventArgs e)
        {
            ScriptingObjectDisplay display = new ScriptingObjectDisplay();
            display.LoadObject(m_SectorObject.EventObjectID);
            display.Show();
        }
    }
}
