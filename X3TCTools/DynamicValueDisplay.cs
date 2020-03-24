﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using X3TCTools;
using X3TCTools.Bases;
using X3TCTools.Bases.Scripting;


namespace X3TCTools
{
    public partial class DynamicValueDisplay : UserControl
    {
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return groupBox1.Text;
            }
            set
            {
                groupBox1.Text = value;
            }
        }

        private DynamicValue m_DynamicValue;
        
        public DynamicValue Value
        {
            get
            {
                return m_DynamicValue;
            }
            set
            {
                m_DynamicValue = value != null ? value : new DynamicValue();
                Reload();
            }
        }

        private void Reload()
        {
            if((int)m_DynamicValue.Flag < DynamicValue.FlagCount)
                FlagBox.SelectedIndex = (int)m_DynamicValue.Flag;
            else
            {
                FlagBox.Items.Add(m_DynamicValue.Flag);
                FlagBox.SelectedIndex = DynamicValue.FlagCount;
            }
            ValueBox.Text = m_DynamicValue.Value.ToString("X");
        }

        public DynamicValueDisplay()
        {
            InitializeComponent();
            for(int i = 0; i < DynamicValue.FlagCount; i++)
            {
                FlagBox.Items.Add((DynamicValue.FlagType)i);
            }
        }

        private void FlagBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_DynamicValue.Flag = (DynamicValue.FlagType)FlagBox.SelectedIndex;
        }

        private void ValueBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                m_DynamicValue.Value = int.Parse(ValueBox.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                m_DynamicValue.Value = 0;
            }
        }
    }
}
