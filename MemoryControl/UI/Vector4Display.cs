﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.UI
{
    public partial class Vector4Display: UserControl
    {
        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get
            {
                return numericUpDown1.ReadOnly;
            }
            set
            {
                numericUpDown1.ReadOnly = value;
                numericUpDown2.ReadOnly = value;
                numericUpDown3.ReadOnly = value;
                numericUpDown4.ReadOnly = value;
            }
        }
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
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal X
        {
            get
            {
                return numericUpDown1.Value;
            }
            set
            {
                numericUpDown1.Value = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Y
        {
            get
            {
                return numericUpDown2.Value;
            }
            set
            {
                numericUpDown2.Value = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Z
        {
            get
            {
                return numericUpDown3.Value;
            }
            set
            {
                numericUpDown3.Value = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal W
        {
            get
            {
                return numericUpDown4.Value;
            }
            set
            {
                numericUpDown4.Value = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Minimum
        {
            get
            {
                return numericUpDown1.Minimum;
            }
            set
            {
                numericUpDown1.Minimum = value;
                numericUpDown2.Minimum = value;
                numericUpDown3.Minimum = value;
                numericUpDown4.Minimum = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Maximum
        {
            get
            {
                return numericUpDown1.Maximum;
            }
            set
            {
                numericUpDown1.Maximum = value;
                numericUpDown2.Maximum = value;
                numericUpDown3.Maximum = value;
                numericUpDown4.Maximum = value;
            }
        }

        public Common.Vector.Vector4 Vector
        {
            get
            {
                return new Common.Vector.Vector4(Convert.ToInt32(X),Convert.ToInt32(Y),Convert.ToInt32(Z), Convert.ToInt32(W));
            }
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
                W = value.W;
            }
        }

        public Vector4Display()
        {
            InitializeComponent();
        }

        private void Vector3Display_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
