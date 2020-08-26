﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Common.UI
{
    public partial class Vector3Display : UserControl
    {
        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Increment
        {
            get => numericUpDown1.Increment;
            set
            {
                numericUpDown1.Increment = value;
                numericUpDown2.Increment = value;
                numericUpDown3.Increment = value;
            }
        }

        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int DecimalPlaces
        {
            get => numericUpDown1.DecimalPlaces;
            set
            {
                numericUpDown1.DecimalPlaces = value;
                numericUpDown2.DecimalPlaces = value;
                numericUpDown3.DecimalPlaces = value;
            }
        }
        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get => numericUpDown1.ReadOnly;
            set
            {
                numericUpDown1.ReadOnly = value;
                numericUpDown2.ReadOnly = value;
                numericUpDown3.ReadOnly = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => groupBox1.Text;
            set => groupBox1.Text = value;
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal X
        {
            get => numericUpDown1.Value;
            set => numericUpDown1.Value = value;
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Y
        {
            get => numericUpDown2.Value;
            set => numericUpDown2.Value = value;
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Z
        {
            get => numericUpDown3.Value;
            set => numericUpDown3.Value = value;
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Minimum
        {
            get => numericUpDown1.Minimum;
            set
            {
                numericUpDown1.Minimum = value;
                numericUpDown2.Minimum = value;
                numericUpDown3.Minimum = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public decimal Maximum
        {
            get => numericUpDown1.Maximum;
            set
            {
                numericUpDown1.Maximum = value;
                numericUpDown2.Maximum = value;
                numericUpDown3.Maximum = value;
            }
        }

        public Vector.Vector3 Vector
        {
            get => new Vector.Vector3(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Z));
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        public Vector3Display()
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
