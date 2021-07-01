using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string subject;

        public Student(string firstName, string lastName, string subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
        }

        public string FirstName
        {
            get => this.firstName;
            private set => firstName = value;
        }
        public string LastName
        {
            get => this.lastName;
            private set => lastName = value;
        }
        public string Subject
        {
            get => this.subject;
            private set => subject = value;
        }

        public override string ToString()
        {
            return $"Student: First Name = {FirstName}, Last Name = {LastName}, Subject = {Subject}";
        }
    }
}
