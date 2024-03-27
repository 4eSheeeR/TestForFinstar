using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Item: Entity
    {
        public Item(int code, string value)
        {
            Code = code;
            Value = value;
        }

        public int Code { get; set; }
        public string Value { get; set; }
    }
}
