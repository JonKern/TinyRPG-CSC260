using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyRPG
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void lblStartScreenTitle_Click(object sender, EventArgs e)
        {

        }

        private void LoadGame(object sender, EventArgs e)
        {
            this.Hide();
            TinyRPG gameWindow = new TinyRPG();
            gameWindow.ShowDialog();
            this.Close();
        }
    }
}
