using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ProfileManager
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string loop = "";

            List<Student> one = new List<Student>();

            Program thisClass = new Program();

            one.AddRange(thisClass.ReadonLoad());

            Student temp = new Student();

            while (loop != "n")
            {
                //Console.Clear();
                Console.WriteLine("Enter a option\n");
                Console.WriteLine("1. Create Profile\n");
                Console.WriteLine("2. Search Student\n");
                Console.WriteLine("3. Remove Student\n");
                Console.WriteLine("4. View Top 3 Students\n");
                Console.WriteLine("5. Mark Attendance\n");
                Console.WriteLine("6. Press 6 to view attendance\n");
                Console.WriteLine("Press n to exit");

                loop = Console.ReadLine();
                Console.Clear();

                switch (loop)
                {
                    case "1":
                        {
                            string addloop = "";
                            while (addloop != "n")
                            {
                                one.Add(thisClass.addProfile(temp));
                                Console.WriteLine("Do you want to add more student records?\n Press y for yes and n fo no");
                                addloop = Console.ReadLine();
                            }
                            break;
                        }

                    case "2":
                        {
                            int Id;
                            int choice;
                            string inloop = " ";
                            while (inloop != "n")
                            {
                                string sName;
                                Console.Write("Press 1 to search by ID\n\nPress 2 to search by name\n\nPress 3 to display all students\n");
                                choice = Convert.ToInt32(Console.ReadLine());
                                if (choice == 1)
                                {
                                    Console.WriteLine("Enter ID to be searched:\n");
                                    Id = Convert.ToInt32(Console.ReadLine());
                                    List<Student> check = one.FindAll(x => x.student_ID.Equals(Id));
                                   

                                    if (check.Count == 0)
                                    {
                                        Console.WriteLine("FILE IS EMPTY\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Student ID" + '\t' + "Student Name" + '\t' + "CGPA" + '\t' + '\t' + "Department" + '\t' + "Semester" + '\t' + "University\n");
                                        foreach (Student item in check)
                                        {
                                            item.Display();
                                        }
                                        
                                    }
                                    
                                }
                                else if (choice == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter name to be searched:");
                                    sName = Console.ReadLine();
                                    List<Student> N = one.FindAll(y => y.Student_Name.Equals(sName));
                                   

                                    if (N.Count == 0)
                                    {
                                        Console.WriteLine("FILE IS EMPTY\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Student ID" + '\t' + "Student Name" + '\t' + "CGPA" + '\t' + '\t' + "Department" + '\t' + "Semester" + '\t' + "University\n");
                                        foreach (Student item in N)
                                        {
                                            item.Display();
                                        }
                                    }
                                    
                                    
                                    //Console.Clear();
                                }
                                else if (choice == 3)
                                {
                                    
                                    if (one.Count == 0)
                                    {
                                        Console.WriteLine("FILE IS EMPTY");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Student ID" + '\t' + "Student Name" + '\t' + "CGPA" + '\t' + '\t' + "Department" + '\t' + "Semester" + '\t' + "University\n");
                                        foreach (Student item in one)
                                        {
                                            item.Display();
                                        }
                                    }
                                    
                                }

                                Console.WriteLine("Want to perfrom another action?\n\n Press y for yes and n for no\n");
                                inloop = Console.ReadLine();
                                Console.Clear();
                            }


                            break;
                        }

                    case "3":
                        {
                            int ID;
                            Console.WriteLine("Enter Id of student to be removed:");
                            ID = Convert.ToInt32(Console.ReadLine());
                            List<Student> c = one.FindAll(x => x.student_ID.Equals(ID));
                            if (c.Count == 0)
                            {
                                Console.WriteLine("FILE IS EMPTY\n\n");
                            }

                            else
                            {
                                foreach (Student item in c)
                                {

                                    if (ID == item.student_ID)
                                    {

                                        int deleteIndex = one.FindIndex(y => y.student_ID.Equals(ID));
                                        Console.WriteLine("Student Record removed");
                                        one.RemoveAt(deleteIndex);
                                                

                                    }
                                    else
                                    {

                                        Console.WriteLine("Invalid ID");

                                    }
                                    thisClass.updateFile(one);
                                }
                                //thisClass.displayGPA(one);
                            }
                            break;
                        }
                    case "4":
                        { 
                            one = thisClass.topThree(one);
                            bool isEmpty = !one.Any();
                            if (one.Count<3)
                            {
                                Console.WriteLine("File does not have needed entries");
                            }
                            else
                            {
                                Console.WriteLine("Student ID" + '\t' + "Student Name" + '\t' + "CGPA" + '\t' + '\t' + "Department" + '\t' + "Semester" + '\t' + "University");
                                for (int i = one.Count - 1; i > one.Count - 4; i--)
                                {
                                    one[i].Display();
                                }


                                thisClass.updateFile(one);
                            }
                            Console.WriteLine("Press any key to go to menu");
                            Console.ReadLine();

                        break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Marking attendance\nPress 1 for Present and 0 for Absent");
                            foreach (Student item in one)
                            {
                                Console.WriteLine("ID = " + item.student_ID.ToString() + "\n");
                                Console.WriteLine("Name = " + item.Student_Name + "\n");
                                Console.WriteLine("Attendance = ");
                                item.s_attendance = Convert.ToInt32(Console.ReadLine());
                            }
                            thisClass.updateFile(one);
                            Console.WriteLine("Press any key to go to menu");
                            break;
                          
                        }
                    case "6":
                        {
                            Console.Clear();
                            if (one.Count == 0)
                            {
                                Console.WriteLine("FILE IS EMPTY\n");
                            }
                            else
                            {
                                foreach (Student item in one)
                                {
                                    item.Att_Display();
                                }
                            }
                            Console.WriteLine("PRESS ANY KEY TO GO TO MENU\n");
                            Console.ReadLine();
                            break;

                        }
                    default:
                        break;

                }

                

            }
            Console.WriteLine("\nThankyou for Response :)");
            Console.ReadLine();
        }

        Student addProfile(Student temp)
        {
            temp = new Student(); 
            Console.WriteLine("Enter Student unique ID");
            temp.student_ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student name");
            temp.Student_Name = Console.ReadLine();
            Console.WriteLine("Enter Student GPA");
            temp.s_GPA = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Student current semester");
            temp.s_semester = Console.ReadLine();
            Console.WriteLine("Enter Student Department");
            temp.s_department = Console.ReadLine();
            Console.WriteLine("Enter Student University");
            temp.s_university = Console.ReadLine();
            temp.s_attendance = 0;
            
            temp.WriteonFile();
            return temp;
        }

        List<Student> ReadonLoad()
        {
            List<Student> load = new List<Student>();
            Student temp = new Student();
            string fileName = @"C:\Users\Hamza_PC\source\repos\ProfileManager\Test.txt";
            using (StreamReader sr = new StreamReader(@"C:\Users\Hamza_PC\source\repos\ProfileManager\Test.txt"))
            {

                if (new FileInfo(fileName).Length == 0)
                {
                    Console.WriteLine("FILE IS EMPTY\n");
                    
                }
                else
                {
                    while (!sr.EndOfStream)
                    {
                        temp = new Student();
                        temp.student_ID = int.Parse(sr.ReadLine());
                        temp.Student_Name = sr.ReadLine();
                        temp.s_GPA = Convert.ToDouble(sr.ReadLine());
                        temp.s_semester = sr.ReadLine();
                        temp.s_department = sr.ReadLine();
                        temp.s_university = sr.ReadLine();
                        temp.s_attendance = Convert.ToInt32(sr.ReadLine());
                        load.Add(temp);
                    }
                }
                return load;
            }
        }

        List<Student> topThree(List<Student> mainList)
        {
            mainList = mainList.OrderBy(o => o.s_GPA).ToList();
            return mainList;
        }

        public void updateFile(List<Student> mainList)
        {
            File.WriteAllText(@"C:\Users\Hamza_PC\source\repos\ProfileManager\Test.txt", String.Empty);
            foreach ( Student item in mainList)
            {                
                item.WriteonFile();
            }
        }
        //List<Student> displayGPA(List<Student> one)
        //{
           
           
        //    return one;
            
        //}
            


        //


        //for (int j = 0; j < 2; j++)
        //{
        //    one[j].Display();
        //}


        //one.Find(List<Student>;


        //.ReadLine();

    }
}

