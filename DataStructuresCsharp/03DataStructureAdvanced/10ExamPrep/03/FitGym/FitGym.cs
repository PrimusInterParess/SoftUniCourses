using System.Linq;

namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;

    public class FitGym : IGym
    {
        private class OrderedTrainersComparer : IComparer<Trainer>
        {
            public int Compare(Trainer x, Trainer y)
            {
                int comp = x.Members.Count.CompareTo(y.Members.Count);

                if (comp == 0)
                {
                    x.Popularity.CompareTo(y.Popularity);
                }

                if (comp == 0)
                {
                    return 1;
                }

                return comp;
            }
        }

        private SortedSet<Member> members;
        private SortedSet<Trainer> trainers;

        private Dictionary<int, Trainer> byIdTrainers;
        private Dictionary<int, Member> byIdMembers;

        private Dictionary<Trainer, HashSet<Member>> trainerAndMembers;

        private SortedDictionary<int, Trainer> byPopularity;

        public FitGym()
        {
            this.byIdTrainers = new Dictionary<int, Trainer>();
            this.members = new SortedSet<Member>();
            this.trainers = new SortedSet<Trainer>();
            this.byIdMembers = new Dictionary<int, Member>();
            this.byPopularity = new SortedDictionary<int, Trainer>();
            this.trainerAndMembers = new Dictionary<Trainer, HashSet<Member>>();
        }


        public void AddMember(Member member)
        {
            if (this.byIdMembers.ContainsKey(member.Id))
            {
                throw new ArgumentException();
            }

            this.byIdMembers.Add(member.Id, member);
            this.members.Add(member);
        }

        public void HireTrainer(Trainer trainer)
        {
            if (this.byIdTrainers.ContainsKey(trainer.Id))
            {
                throw new ArgumentException();
            }

            this.trainerAndMembers.Add(trainer,new HashSet<Member>());
            this.byIdTrainers.Add(trainer.Id, trainer);
            this.byPopularity.Add(trainer.Popularity, trainer);
            this.trainers.Add(trainer);
        }

        public void Add(Trainer trainer, Member member)
        {
            if (!this.byIdTrainers.ContainsKey(trainer.Id))
            {
                throw new ArgumentException();
            }

            if (!this.byIdMembers.ContainsKey(member.Id))
            {
                this.members.Add(member);
                this.byIdMembers.Add(member.Id, member);

            }

            if (trainer.Members.Contains(member) || member.Trainer != null)
            {
                throw new ArgumentException();
            }

            trainer.Members.Add(member);
            this.byPopularity[trainer.Popularity].Members.Add(member);
            this.trainerAndMembers[trainer].Add(member);
            member.Trainer = trainer;

        }

        public bool Contains(Member member)
        {
            return this.byIdMembers.ContainsKey(member.Id);
        }

        public bool Contains(Trainer trainer)
        {
            return this.byIdTrainers.ContainsKey(trainer.Id);
        }

        public Trainer FireTrainer(int id)
        {
            if (!this.byIdTrainers.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            Trainer toReturn = this.byIdTrainers[id];

            this.byIdTrainers.Remove(id);
            this.trainers.Remove(toReturn);
            this.byPopularity.Remove(toReturn.Popularity);
            this.trainerAndMembers.Remove(toReturn);

            return toReturn;
        }

        public Member RemoveMember(int id)
        {
            if (!this.byIdMembers.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            Member toReturn = this.byIdMembers[id];

            this.members.Remove(toReturn);
            this.byIdMembers.Remove(id);


            return toReturn;

        }

        public int MemberCount { get => this.members.Count; }
        public int TrainerCount { get => this.trainers.Count; }

        public IEnumerable<Member>
            GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
        {
            if (this.members.Count == 0)
            {
                return new List<Member>();
            }

            return this.members;
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

            return trainer.Members; //.OrderBy(m=>m.RegistrationDate).ThenBy(m=>m.Name);
        }

        public IEnumerable<Member>
            GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
        {
            List<Member> toReturn = new List<Member>();

            foreach (var keValue in byPopularity)
            {
                if (keValue.Key >= lo && keValue.Key <= hi)
                {
                    toReturn.AddRange(keValue.Value.Members);

                }
            }

            return toReturn.OrderBy(m => m.Visits).ThenBy(m => m.Name);
        }

        public Dictionary<Trainer, HashSet<Member>>
            GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
        {
            return this.trainerAndMembers.OrderBy(t => t.Value.Count).ThenBy(t => t.Key.Popularity)
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}