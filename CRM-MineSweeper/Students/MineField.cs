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
    public partial class MineField : Form
    {
        public enum GameType { Easy, Medium, Hard }
        GameType gameType = GameType.Easy;
        List<int> mines = new List<int>();
        List<Button> fields = new List<Button>();
        Random rnd = new Random();
        int score = 0;
        Form1 form1;

        public MineField()
        {
            InitializeComponent();
        }
        public MineField(Form1 sender, GameType gameType)
        {
            InitializeComponent();
            this.form1 = sender;
            this.gameType = gameType;
        }
        private void MineField_Load(object sender, EventArgs e)
        {
            this.Size = new Size(700, 700);
            CreateMineField(30, 30);
            CreateMines(30 * 30);
        }
        public void CreateMineField(int width, int height)
        {
            int bs = 20;
            int margin = 1;
            for (int row=0; row<height; row++)
            {
                for (int col=0; col<width; col++)
                {
                    var field = new Button();
                    field.FlatStyle = FlatStyle.Popup;
                    field.Size = new Size(bs, bs);
                    field.Top = (row * bs) + (row * margin);
                    field.Left = (col * bs) + (col * margin);
                    field.Tag = (row + 1) * col;
                    field.Click += new System.EventHandler(this.fieldButton_Click);
                    this.Controls.Add(field);
                    fields.Add(field);
                }
            }
        }

        
        private void CreateMines(int fieldCount)
        {
            int mineCount = 0;
            switch (gameType)
            {
                case GameType.Easy:
                    mineCount = Convert.ToInt16(fieldCount * 0.1);
                    break;
                case GameType.Medium:
                    mineCount = Convert.ToInt16(fieldCount * 0.25);
                    break;
                case GameType.Hard:
                    mineCount = Convert.ToInt16(fieldCount * 0.5);
                    break;
            }
            
            for (int i=0; i<mineCount; i++)
            {
                mines.Add(CreateMine(fieldCount));
            }
        }
        private int CreateMine(int fieldCount)
        {
            int m = rnd.Next(0, fieldCount);
            if (mines.Contains(m))
            {
                return CreateMine(fieldCount);
            }
            else
            {
                return m;
            }
            
        }
        void fieldButton_Click(object sender, EventArgs e)
        {
            var fieldButton = (Button)sender;
            if (mines.Contains(Convert.ToInt16(fieldButton.Tag)))
            {
                fieldButton.BackColor = Color.Red;
                foreach (int mine in mines)
                {
                    var b = fields[mine];
                    if (b != fieldButton)
                    {
                        b.BackColor = Color.Black;
                    }
                    
                }
                GameOver();
            }
            else
            {
                fieldButton.BackColor = Color.Green;
                switch (gameType)
                {
                    case GameType.Easy:
                        score += 1;
                        break;
                    case GameType.Medium:
                        score += 5;
                        break;
                    case GameType.Hard:
                        score += 10;
                        break;
                }
                scoreLabel.Text = "Score:" + score.ToString();
            }
        }
        private void GameOver()
        {
            var result = MessageBox.Show("Score" + score.ToString(), "Game Over", MessageBoxButtons.OK);
            var student = new Student();
            student = student.generateStudent(0);
            student.grade = score;
            form1.insertStudent(student);
            this.Close();
        }
    }
}
