﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using X2Tools;
using X2TheThreatRETool.UI.Displays;

namespace X2TheThreatRETool
{
    public partial class X2Tool : Form
    {
        GameHook m_GameHook;
        public X2Tool()
        {
            InitializeComponent();
            var process = Process.GetProcessesByName("X2")[0];
            m_GameHook = new GameHook(process);
        }

        private void btnLoadPlayerShip_Click(object sender, EventArgs e)
        {
            var display = new SectorObjectDisplay(m_GameHook);
            display.LoadSectorObject(m_GameHook.SectorObjectManager.GetPlayerShip());
            display.Show();
        }
    }
}
