using System;
using System.Collections.Generic;

namespace lab7
{
    class Student
    {
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }

        public Student()
        {
            UniqueId = Guid.NewGuid().ToString();
            Name = "";
            Gender = 'm';
        }

        public Student(string uniqueId, string name, char gender) : this()
        {
            UniqueId = uniqueId;
            Name = name;
            Gender = gender;
        }

        public override string ToString()
        {
            return "UniqueID:\t" + UniqueId + "\nName:\t\t" + Name + "\nGender:\t\t" + Gender;
        }
    }


    class ClassRoom
    {
        private string Crn { get; set; }
        private string LecturerName { get; set; }
        public List<Student> StudentList { get; set; }

        public ClassRoom(string crn, string lectureName)
        {
            Crn = crn;
            LecturerName = lectureName;
            StudentList = new List<Student>();
        }

        public void AddStudent(Student toAddStudent)
        {
            foreach (Student student in StudentList)
            {
                if (student.UniqueId.Equals(toAddStudent.UniqueId))
                {
                    throw new Exception("Cannot add two Students with the same ID");
                }
            }
            StudentList.Add(toAddStudent);
        }

        public Student this[int i]
        {
            get
            {
                if (StudentList != null)
                    return StudentList[0];
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set { AddStudent(value); }
        }

        public Student this[string studentId]
        {
            get
            {
                bool found = false;
                Student toReturnStudent = new Student();

                foreach (Student student in StudentList)
                {
                    if (student.UniqueId.Equals(studentId))
                    {
                        found = true;
                        toReturnStudent = student;
                    }
                }

                if (found)
                {
                    return toReturnStudent;
                }
                else
                    throw new Exception("Student ID: " + studentId + " not found");
            }
        }

        public override string ToString()
        {
            string toReturnString = "Class Room Number:\t" + Crn + "\nLecturer:\t\t" + LecturerName + "\n\n=========Students=========\n\n";

            foreach (Student studentToReturn in StudentList)
            {
                toReturnString += studentToReturn + "\n\n";
            }
            return toReturnString;
        }
    }

    class Program
    {
        private static void Main()
        {
            Student student = new Student("1234", "John", 'm');
            Student student2 = new Student("5678", "Alice", 'f');
            Student student3 = new Student("9101112", "Fred", 'm');
            Student student4 = new Student("13141516", "Suzy", 'f');

            ClassRoom classR = new ClassRoom("1234", "John");

            try
            {
                classR[0] = student;
                classR[1] = student2;
                classR[2] = student3;
                classR[3] = student4;

                Console.WriteLine(classR);

                Console.ReadKey();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}

