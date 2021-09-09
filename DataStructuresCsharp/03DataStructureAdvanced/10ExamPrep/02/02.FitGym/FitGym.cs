namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;

    public class FitGym : IGym
    {
        public void AddMember(Member member)
        {
            throw new NotImplementedException();
        }

        public void HireTrainer(Trainer trainer)
        {
            throw new NotImplementedException();
        }

        public void Add(Trainer trainer, Member member)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Member member)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Trainer trainer)
        {
            throw new NotImplementedException();
        }

        public Trainer FireTrainer(int id)
        {
            throw new NotImplementedException();
        }

        public Member RemoveMember(int id)
        {
            throw new NotImplementedException();
        }

        public int MemberCount { get; }
        public int TrainerCount { get; }

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