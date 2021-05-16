using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicImplementation;
using System.Threading;

namespace ProgramGUI
{
    public partial class Form1 : Form
    {
        Logic logic = new Logic();

        public Form1()
        {
            InitializeComponent();

            logic.UpdateParameters();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void enableTransparencyButton_Click(object sender, EventArgs e)
        {
            logic.SetTaskbarInvalid();
        }

        private void gradientButton_Click(object sender, EventArgs e)
        {
            logic.SetTaskBarGradient();
        }

        private void transparentGradientButton_Click(object sender, EventArgs e)
        {
            logic.SetTaskBarTransparentGradient();
        }

        private void disabledButton_Click(object sender, EventArgs e)
        {
            logic.SetTaskBarDisabled();
        }

        private void blurButton_Click(object sender, EventArgs e)
        {
            logic.SetTaskBarBlur();
        }
    }
}
