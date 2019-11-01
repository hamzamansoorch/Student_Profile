using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileManager
{
    class Student
    {
        private int studentID;
        private string StudentName;
        private string Semester;
        private double CGPA;
        private string Department;
        private string University;
        private int Attendance;


        public Student()
        { 

        }

        public int student_ID
        {
            get { return studentID; }

            set { studentID = value; }
        }

        public string Student_Name
        {
            get { return StudentName; }

            set
            {
                StudentName = value;
            }
        }
        public string s_semester
        {
            get { return Semester; }

            set { Semester = value; }
        }
        public double s_GPA
        {
            get { return CGPA; }

            set { CGPA = value; }
        }
        public string s_department
        {
            get { return Department; }

            set { Department = value; }
        }
        public string s_university
        {
            get { return University; }

            set { University = value; }
        }
        public int s_attendance
        {
            get { return Attendance; }
            set { Attendance = value; }
        }
        
        public void Display()
        {
            
            Console.WriteLine(student_ID.ToString() + '\t' + '\t'+ StudentName + '\t' + '\t'+ CGPA + '\t' + '\t'+ Department + '\t' + '\t'+ Semester + '\t' + '\t'+ University);
            Console.WriteLine("\n\n");
        }

        public void Att_Display()
        {
            string atten;
            if(Attendance == 0)
            {
                atten = "Absent";
            }
            else
            {
                atten = "Present";
            }
            Console.WriteLine(student_ID.ToString() + '\n' + StudentName + '\n' + atten);
        }

        public void WriteonFile()
        {
            using (StreamWriter sw = File.AppendText(@"C:\Users\Hamza_PC\source\repos\ProfileManager\Test.txt"))
            {
                sw.WriteLine(student_ID);
                sw.WriteLine(StudentName);
                sw.WriteLine(CGPA);
                sw.WriteLine(Semester);
                sw.WriteLine(Department);
                sw.WriteLine(University);
                sw.WriteLine(Attendance);
            }
        }
    }
}
