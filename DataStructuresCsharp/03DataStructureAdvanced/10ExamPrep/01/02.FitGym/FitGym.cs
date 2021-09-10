namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;

    public class FitGym : IGym
    {
        private HashSet<Member> members;
        private HashSet<Trainer> trainers;
        private Dictionary<int, Trainer> trainersById;
        private Dictionary<int, Member> memberById;

        public FitGym()
        {
            this.members  = new HashSet<Member>();
            this.trainers = new HashSet<Trainer>();
            this.trainersById = new Dictionary<int, Trainer>();
            this.memberById = new Dictionary<int, Member>();
            
        }

        public void AddMember(Member member)
        {
            if (this.members.Contains(member))
            {
                throw new ArgumentException();
            }
            this.memberById.Add(member.Id,member);
            this.members.Add(member);
        }

        public void HireTrainer(Trainer trainer)
        {
            if (this.trainers.Contains(trainer))
            {
                throw new ArgumentException();
            }

            this.trainersById.Add(trainer.Id, trainer);

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

            this.trainersById.Remove(id);
            this.trainers.Remove(toRemove);

            return toRemove;
        }

        public Member RemoveMember(int id)
        {
            if (!this.memberById.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            Member toRemove = this.memberById[id];

            this.memberById.Remove(id);

            return toRemove;
        }

        public int MemberCount
        {
            get => this.MemberCount;
        }
        public int TrainerCount { get=>this.trainers.Count; }

        public IEnumerable<Member>
            GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member>
            GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member>
            GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Trainer, HashSet<Member>>
            GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
        {
            throw new NotImplementedException();
        }
    }
}