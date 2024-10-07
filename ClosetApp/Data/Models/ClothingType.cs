using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ClothingType
    {
        public int TypeId { get; set; }
        public string Name { get; set; }
        public ClothingType(int typeId, string name)
        {
            TypeId = typeId;
            Name = name;
        }
    }
}
