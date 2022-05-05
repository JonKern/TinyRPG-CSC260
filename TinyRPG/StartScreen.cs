using System;
using System.Windows.Forms;

namespace TinyRPG
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }      

        private void btnStartGame(object sender, EventArgs e)
        {
            this.Hide();
            TinyRPG gameWindow = new TinyRPG();
            gameWindow.ShowDialog();
            this.Close();
        }
    }
}
