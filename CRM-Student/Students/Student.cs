using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Student
    {
        public int studentId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public int grade { get; set; }

        private Random rnd = new Random();
        public Student(int studentId, string name, string surname, string phone, string email, string state, int grade)
        {
            this.studentId = studentId;
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.email = email;
            this.state = state;
            this.grade = grade;
        }
        public Student()
        {

        }
        public Student generateStudent(int studentId)
        {
            return new Student(studentId, FakeData.NameData.GetFirstName(),
                FakeData.NameData.GetSurname(), 
                FakeData.PhoneNumberData.GetPhoneNumber(),
                FakeData.NetworkData.GetEmail(), FakeData.PlaceData.GetState(), rnd.Next(0, 100));
        }
    }
}
