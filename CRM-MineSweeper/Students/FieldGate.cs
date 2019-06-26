using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    public partial class FieldGate : Form
    {
        Form1 form1;
        MineField.GameType gameType = MineField.GameType.Easy;
        public FieldGate()
        {
            InitializeComponent();
        }

        public FieldGate(Form1 sender)
        {
            InitializeComponent();
            this.form1 = sender;
        }
        private void easyButton_Click(object sender, EventArgs e)
        {
            gameType = MineField.GameType.Easy;
            easyButton.BackColor = Color.DarkOrange;
            mediumButton.BackColor = Color.Orange;
            hardButton.BackColor = Color.Orange;
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            gameType = MineField.GameType.Medium;
            easyButton.BackColor = Color.Orange;
            mediumButton.BackColor = Color.DarkOrange;
            hardButton.BackColor = Color.Orange;
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            gameType = MineField.GameType.Hard;
            easyButton.BackColor = Color.Orange;
            mediumButton.BackColor = Color.Orange;
            hardButton.BackColor = Color.DarkOrange;
        }
        

        private void startButton_Click(object sender, EventArgs e)
        {
            var mineField = new MineField(form1, gameType);
            mineField.Show();
        }
    }
}
