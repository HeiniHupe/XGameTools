﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common.Memory;
using X3TCTools;
using X3TCTools.SectorObjects;

namespace X3TC_Tool.UI.Displays
{
    public partial class SectorObjectDataDisplay : Form
    {
        private GameHook m_GameHook;
        private SectorObjectData m_SectorObjectData;
        public SectorObjectDataDisplay(GameHook gameHook)
        {
            m_GameHook = gameHook;
            InitializeComponent();
        }

        public void LoadData(SectorObjectData sectorObjectData)
        {
            m_SectorObjectData = sectorObjectData;
            Reload();
        }

        public void LoadData(IntPtr pSectorObjectData)
        {
            m_SectorObjectData = new SectorObjectData();
            m_SectorObjectData.SetLocation(m_GameHook.hProcess, pSectorObjectData);
            Reload();
        }

        public void Reload()
        {
            AddressBox.Text = m_SectorObjectData.pThis.ToString("X");

            ScaleBox.Vector = m_SectorObjectData.ComponentPositionMult;

            // Relations
            NextButton.Enabled = m_SectorObjectData.pNext.IsValid;
            PreviousButton.Enabled = m_SectorObjectData.pPrevious.IsValid;
            FirstChildButton.Enabled = m_SectorObjectData.pFirstChild.IsValid;
            LastChildButton.Enabled = m_SectorObjectData.pLastChild.IsValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData((IntPtr)int.Parse(AddressBox.Text, System.Globalization.NumberStyles.HexNumber));
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadData(m_SectorObjectData.pNext.obj);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            LoadData(m_SectorObjectData.pPrevious.obj);
        }

        private void FirstChildButton_Click(object sender, EventArgs e)
        {
            LoadData(m_SectorObjectData.pFirstChild.obj);
        }

        private void LastChildButton_Click(object sender, EventArgs e)
        {
            LoadData(m_SectorObjectData.pLastChild.obj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_SectorObjectData.ComponentPositionMult = ScaleBox.Vector;
            m_SectorObjectData.Save();
        }
    }
}
