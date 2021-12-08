using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Exeptions;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = GetState(state);
        }

        private State GetState(string stateStr)
        {
            State state;

            bool parsed = Enum.TryParse(stateStr, out state);

            if (!parsed)
            {
                throw new InvalidStateExeption();
            }

            return state;
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCopletionException();
            }

            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}
