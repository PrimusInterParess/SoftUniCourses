namespace _02.FitGym
{
    using System;

    public class Member : IComparable<Member>
    {
        public Member(int id, string name, DateTime registrationDate, int visits)
        {
            this.Id = id;
            this.Name = name;
            this.RegistrationDate = registrationDate;
            this.Visits = visits;
            this.Trainer = null;
        }

        public Trainer Trainer { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Visits { get; set; }

        public int CompareTo(Member other)
        {
            return this.Id.CompareTo(other.Id);
        }

    }
}