using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicalLibrary.Domain
{
   public class Condition
    {
        int idCondition;
        String description;

        public int IdCondition { get => idCondition; set => idCondition = value; }
        public string Description { get => description; set => description = value; }

        public Condition(int idCondition, string description)
        {
            this.IdCondition = idCondition;
            this.Description = description;
        }

        public Condition()
        {
        }
    }
}
