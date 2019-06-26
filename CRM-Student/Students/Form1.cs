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
        int sortedColumn = -1;

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



            fillStateComboBox();

            averagelabel.Text = "Average : " + students.Average(x => x.grade);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var studentId = (int)dataGridView1.CurrentRow.Cells[0].Value;
                var student = (Student)students.Find(x => x.studentId == studentId);
                var form2 = new Form2(this, student);
                form2.Show();
            }
        }

        public void insertStudent(Student student)
        {
            student.studentId = students.Count + 1;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (textSearch.Text.Length == 0)
            {
                dataGridView1.DataSource = students;
            }
            else
            {
                var searchStudents = students.FindAll(x => x.name.ToLower().Contains(textSearch.Text) || x.surname.ToLower().Contains(textSearch.Text));

                dataGridView1.DataSource = searchStudents;
            }
        }
        private void fillStateComboBox()
        {

            var state = students.GroupBy(x => x.state).Select(x => x.First())
                     .OrderBy(x => x.state).ToList();
            var s = new Student();
            state.Insert(0, s);
            stateComboBox.DataSource = state;
            stateComboBox.DisplayMember = "State";
            stateComboBox.ValueMember = "State";




        }

        private void stateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stateComboBox.SelectedIndex == 0)
            {
                dataGridView1.DataSource = students;
            }
            else
            {
                var seacrhedStudents = students.FindAll(x => x.state == stateComboBox.SelectedValue.ToString());
                dataGridView1.DataSource = seacrhedStudents;
            }

        }

        private void averagebutton_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (sortedColumn == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.studentId).ToList();
                        sortedColumn = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.studentId).ToList();
                        sortedColumn = e.ColumnIndex;
                    }
                    
                    break;
                
                case 1:
                    if (sortedColumn == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.name).ToList();
                        sortedColumn = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.name).ToList();
                        sortedColumn = e.ColumnIndex;
                    }

                    break;
                case 2:
                    if (sortedColumn == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.surname).ToList();
                        sortedColumn = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.surname).ToList();
                        sortedColumn = e.ColumnIndex;
                    }

                    break;
                case 3:
                    if (sortedColumn == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.phone).ToList();
                        sortedColumn = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.phone).ToList();
                        sortedColumn = e.ColumnIndex;
                    }

                    break;
                case 4:
                    if (sortedColumn == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.email).ToList();
                        sortedColumn = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.email).ToList();
                        sortedColumn = e.ColumnIndex;
                    }

                    break;
                case 5:
                    if (sortedColumn == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.state).ToList();
                        sortedColumn = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.state).ToList();
                        sortedColumn = e.ColumnIndex;
                    }

                    break;
                case 6:
                    if (sortedColumn == e.ColumnIndex)
                    {
                        dataGridView1.DataSource = students.OrderByDescending(x => x.grade).ToList();
                        sortedColumn = -1;
                    }
                    else
                    {
                        dataGridView1.DataSource = students.OrderBy(x => x.grade).ToList();
                        sortedColumn = e.ColumnIndex;
                    }

                    break;
                default:
                    break;


            }
        }
    }
}
