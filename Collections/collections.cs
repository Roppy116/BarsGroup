using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }


        public static Dictionary<int, List<Entity>> Method(List<Entity> list)
        {
            if (list.Count == 0)
                throw new Exception("List is empty");
            var dict = list.GroupBy(x => x.ParentId).ToDictionary(ParentId => ParentId.Key, x => x.ToList());

            foreach (var item in dict)
                Console.WriteLine($"Key = {item.Key}, Value = List {string.Join(" ", item.Value)}");

            return dict;

        }

    }

    class collections
    {
        static void Main(string[] args)
        {

            List<Entity> list = new List<Entity>
            {
                new Entity { Id= 1,  ParentId = 0,Name = "Root entity"},
                new Entity { Id= 2,  ParentId = 1,Name = "Child of 1 entity" },
                new Entity { Id= 3,  ParentId = 1,Name = "Child of 1 entity" },
                new Entity { Id= 4,  ParentId = 2,Name = "Child of 2 entity" },
                new Entity { Id= 5,  ParentId = 4,Name = "Child of 4 entity" }
            };

            Entity.Method(list);

        }
    }
}
