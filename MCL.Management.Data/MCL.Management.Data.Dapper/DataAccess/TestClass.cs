using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class User
    {
        public string UserId { get; set; }
        public string Nickname { get; set; }
    }

    public class BasicType
    {
        public string Value { get; set; }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }

    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
