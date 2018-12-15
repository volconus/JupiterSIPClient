using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JupiterSIPClient1
{
    public partial class agentReports : Form
    {
        public agentReports()
        {
            InitializeComponent();
        }

        private void agentReports_Load(object sender, EventArgs e)
        {
            Screen myScreen = Screen.PrimaryScreen;
            this.Height = myScreen.WorkingArea.Height;
            this.Width = myScreen.WorkingArea.Width;
            this.Location = new Point(0, 0);
        }
    }
}
