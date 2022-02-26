using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class Size
    {
        public Guid Id { get; }

        public string Name { get; }

        private Size(Guid id, string name)
        {
            Id = id;
            Name = name;
        }


        public static Size Small = new Size(Guid.NewGuid(), Constants.Size.Small);
        public static Size Medium = new Size(Guid.NewGuid(), Constants.Size.Medium);
        public static Size Large = new Size(Guid.NewGuid(), Constants.Size.Large);


        public static List<Size> All = 
            new List<Size>
            {
                Small,
                Medium,
                Large
            };
    }
}