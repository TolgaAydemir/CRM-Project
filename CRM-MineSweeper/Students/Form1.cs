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
    public partial class Form1 : Form
    {
        List<Student> students = new List<Student>();
        int sortedColumnIndex = -1;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form2 = new Form2(this);
            form2.Show();
        }

        private void generateStudents()
        {
            var student = new Student();
            for (int i = 1; i <= 100; i++)
            {
                students.Add(student.generateStudent(i));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(800, 600);

            generateStudents();
            dataGridView1.DataSource = students;
            dataGridView1.Columns[0].HeaderText = "Student ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Surname";
            dataGridView1.Columns[3].HeaderText = "Phone";
            dataGridView1.Columns[4].HeaderText = "Email";
            dataGridView1.Columns[5].HeaderText = "State";
            dataGridView1.Columns[6].HeaderText = "Grade";
            
            fillStateCombobox();
            calculateAverage();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
        /// <summary>
        /// Adds student to the grid.
        /// </summary>
        /// <param name="student">Ogrenci</param>
        public void insertStudent(Student student)
        {
            student.studentId = students.Count+1;
            students.Add(student);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }
        public void deleteStudent(Student student)
        {
            students.Remove(student);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Length == 0)
            {
                dataGridView1.DataSource = students;
            }
            else
            {
                var searchedStudents = students.FindAll(x => x.name.ToLower()
                .Contains(searchTextBox.Text.ToLower()) 
                || x.surname.ToLower().Contains(searchTextBox.Text.ToLower()));
                dataGridView1.DataSource = searchedStudents;
            }
        }
        private void fillStateCombobox()
        {
            var states = students.GroupBy(x => x.state)
                   .Select(grp => grp.First())
                   .OrderBy(x => x.state)
                   .ToList();
            var s = new Student();
            s.state = "ALL";
            //states.Insert(0, s);
            stateCombobox.DataSource = states;
            stateCombobox.DisplayMember = "state";
            stateCombobox.ValueMember = "state";
            
        }

        private void stateCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stateCombobox.SelectedIndex == 0)
            {
                dataGridView1.DataSource = students;
            }
            else
            {
                var searchedStudents = students
                    .FindAll(x => x.state == stateCombobox.SelectedValue.ToString());
                dataGridView1.DataSource = searchedStudents;
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            switch (e.ColumnIndex)
            {
                case 0:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.studentId).ToList();
                        sortedColumnIndex = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.studentId).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 1:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.name).ToList();
                        sortedColumnIndex = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.name).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 2:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.surname).ToList();
                        sortedColumnIndex = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.surname).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 3:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.phone).ToList();
                        sortedColumnIndex = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.phone).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 4:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.email).ToList();
                        sortedColumnIndex = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.email).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 5:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.state).ToList();
                        sortedColumnIndex = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.state).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                case 6:
                    if (sortedColumnIndex == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.grade).ToList();
                        sortedColumnIndex = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.grade).ToList();
                        sortedColumnIndex = e.ColumnIndex;
                    }
                    break;
                default:
                    break;
            }

            
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            //var p = this.dataGridView1.PointToClient(Cursor.Position);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var studentId = (int)dataGridView1.CurrentRow.Cells[0].Value;
                var student = (Student)students.Find(x => x.studentId == studentId);
                var form2 = new Form2(this, student);
                form2.Show();
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                {
                    cell.Style.BackColor = Color.Yellow;
                }
            }
            
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }
        }
        private void calculateAverage()
        {
            averageLabel.Text = "Average : " + students.Average(x => x.grade).ToString();
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var browser = new Browser();
            browser.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var calc = new Calculator();
            calc.Show();
        }

        private void mineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fieldGate = new FieldGate(this);
            fieldGate.Show();
        }
    }
}
