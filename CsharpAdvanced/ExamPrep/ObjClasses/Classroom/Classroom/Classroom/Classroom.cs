using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private int capacity;
        private List<Student> students;
        private int count;

        public Classroom(int capacity)
        {
            this.capacity = capacity;
            this.students = new List<Student>();
        }

        

        public int Count { get => this.count; }

        public string RegisterStudent(Student student)
        {
            if (this.capacity > this.count)
            {
                this.students.Add(student);
                this.count += 1;

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return $"No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
           

            foreach (var student in this.students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    this.students.Remove(student);
                    this.count -= 1;
                    return $"Dismissed student {firstName} {lastName}";
                }
            }

            return "Student not found";
        }

        public string GetStudent(string firstName, string lastName)
        {
            string getStudent = "";

            foreach (var student in this.students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    getStudent = student.ToString();
                }
            }

            return getStudent;
        }

        public string GetSubjectInfo(string subject)
        {
            var filtered = students.Where(s => s.Subject == subject).ToList();

            if (filtered.Count == 0)
            {
                return $"No students enrolled for the subject";
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");

                foreach (var student in filtered)
                {
                    sb.AppendLine(student.ToString());
                }

                return sb.ToString().TrimEnd();
            }
        }

        public int GetStudentsCount()
        {
            return this.count;
        }
    }

}
