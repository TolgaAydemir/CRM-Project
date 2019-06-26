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
    public partial class Form2 : Form
    {
        Student student = new Student();
        Form1 form1;
        public Form2(Form1 sender)
        {
            InitializeComponent();
            this.form1 = sender;
        }
        public Form2(Form1 sender, Student student)
        {
            InitializeComponent();
            this.student = student;
            this.form1 = sender;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (student.studentId > 0)
            {
                nameTextbox.Text = student.name;
                surnameTextbox.Text = student.surname;
                phoneTextbox.Text = student.phone;
                emailTextbox.Text = student.email;
                gradeTextbox.Text = student.grade.ToString();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            student.name = nameTextbox.Text;
            student.surname = surnameTextbox.Text;
            student.phone = phoneTextbox.Text;
            student.email = emailTextbox.Text;
            int grade = 0;
            int.TryParse(gradeTextbox.Text, out grade);
            student.grade = grade;
            if (student.studentId == 0)
            {
                form1.insertStudent(student);
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (student.studentId > 0)
            {
                form1.deleteStudent(student);
            }
            this.Close();
        }
    }
}
