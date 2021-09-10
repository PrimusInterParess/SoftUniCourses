using System.Linq;

namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;

    public class FitGym : IGym
    {
       

        private HashSet<Trainer> trainers;
        private HashSet<Member> members;

        private Dictionary<int, Member> membersById;
        private Dictionary<int, Trainer> trainersById;

        SortedDictionary<Trainer, HashSet<Member>> trainersMembers;

        public FitGym()
        {
            this.trainers = new HashSet<Trainer>();
            this.members = new HashSet<Member>();
            this.trainersById = new Dictionary<int, Trainer>();
            this.membersById = new Dictionary<int, Member>();
            this.trainersMembers = new SortedDictionary<Trainer, HashSet<Member>>();

        }

        public void AddMember(Member member)
        {
            if (this.members.Contains(member))
            {
                throw new ArgumentException();
            }

            this.members.Add(member);
            this.membersById[member.Id] = member;

        }

        public void HireTrainer(Trainer trainer)
        {
            if (this.trainers.Contains(trainer))
            {
                throw new ArgumentException();
            }


            this.trainersMembers[trainer] = new HashSet<Member>();
            this.trainersById[trainer.Id] = trainer;
            this.trainers.Add(trainer);
        }

        public void Add(Trainer trainer, Member member)
        {
            if (!this.trainers.Contains(trainer))
            {
                throw new ArgumentException();
            }

            if (!this.members.Contains(member))
            {
                this.members.Add(member);
                this.membersById[member.Id] = member;
            }

            if (member.Trainer != null || trainer.Members.Contains(member))
            {
                throw new ArgumentException();
            }

            member.Trainer = trainer;
            trainer.Members.Add(member);
        }

        public bool Contains(Member member)
        {
            return this.members.Contains(member);
        }

        public bool Contains(Trainer trainer)
        {
            return this.trainers.Contains(trainer);
        }

        public Trainer FireTrainer(int id)
        {
            if (!this.trainersById.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            Trainer toRemove = this.trainersById[id];

            this.trainers.Remove(toRemove);
            this.trainersById.Remove(id);
            this.trainersMembers.Remove(toRemove);

            return toRemove;
        }

        public Member RemoveMember(int id)
        {
            if (!this.membersById.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            Member toRemove = this.membersById[id];

            this.members.Remove(toRemove);
            this.membersById.Remove(id);

            return toRemove;
        }

        public int MemberCount
        {
            get => this.members.Count;
        }
        public int TrainerCount { get => this.trainers.Count; }

        public IEnumerable<Member>
            GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
        {
            if (this.members.Count == 0)
            {
                return new List<Member>();
            }

            return this.members
                .OrderBy(m => m.RegistrationDate)
                .ThenByDescending(n => n.Name);
        }

        public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
        {
            if (this.trainers.Count == 0)
            {
                return new List<Trainer>();
            }

            return this.trainers.OrderBy(t => t.Popularity);
        }

        public IEnumerable<Member>
            GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
        {
            if (trainer.Members.Count == 0)
            {
                return new List<Member>();
            }

            return trainer.Members.OrderBy(m => m.RegistrationDate).ThenBy(m => m.Name);
        }

        public IEnumerable<Member>
            GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
        {
            List<Member> toReturn = new List<Member>();

            foreach (var trainer in trainers)
            {
                if (trainer.Popularity >= lo && trainer.Popularity <= hi)
                {

                    toReturn.AddRange(trainer.Members);
                }
            }

            return toReturn.OrderBy(m => m.Visits).ThenBy(m => m.Name);
        }

        public Dictionary<Trainer, HashSet<Member>>
            GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
        {
            return new Dictionary<Trainer, HashSet<Member>>(this.trainersMembers).OrderBy(t => t.Key.Members.Count)
                .ThenBy(t => t.Key.Popularity).ToDictionary(t => t.Key, m => m.Value);
        }

    }
}