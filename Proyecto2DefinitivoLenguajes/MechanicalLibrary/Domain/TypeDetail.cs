using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicalLibrary.Domain
{
   public class TypeDetail
    {
        int idTypeDetail;
        String description;

        public int IdTypeDetail { get => idTypeDetail; set => idTypeDetail = value; }
        public string Description { get => description; set => description = value; }

        public TypeDetail(int idTypeDetail, string description)
        {
            this.IdTypeDetail = idTypeDetail;
            this.Description = description;
        }

        public TypeDetail()
        {
        }
    }
}
