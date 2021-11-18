﻿using System.Windows.Forms;
using XCommonLib.RAM.Bases.Story.Scripting;

namespace XRAMTool.Bases.Story
{
    public partial class ScriptInstance_Display : Form
    {
        private ScriptInstance m_ScriptInstance;
        public ScriptInstance_Display()
        {
            InitializeComponent();
            scriptInstanceView1.ReferenceGameHook = Program.GameHook;
        }
        public void LoadObject(ScriptInstance obj)
        {
            m_ScriptInstance = obj;
            scriptInstanceView1.LoadObject(obj);
        }
    }
}
