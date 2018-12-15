using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JupiterSIPClient1;

namespace JupiterSIPClient1
{
    public partial class sipClientMin : Form
    {
        main main = new main();
        public sipClientMin()
        {
            InitializeComponent();
        }

        private void sipClientMin_Load(object sender, EventArgs e)
        {
            this.Location = new Point(main.getStartPosition(this.Width), 900);
        }
        
        private void openForm(Form obj) {
            obj.TopMost = true;
            obj.BringToFront();
            obj.Focus();
            obj.Show();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {            
            this.Hide();
            /*sipClient.Controls["nameOfControl"].Show();
            JupiterSIPClient1.sipClient.Focus();
            JupiterSIPClient1.sipClient.BringToFront();*/

        }
    }
}
