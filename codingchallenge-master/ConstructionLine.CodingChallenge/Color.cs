using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class Color
    {
        public Guid Id { get; }

        public string Name { get; }

        private Color(Guid id, string name)
        {
            Id = id;
            Name = name;
        }


        public static Color Red = new Color(Guid.NewGuid(), Constants.Color.Red);
        public static Color Blue = new Color(Guid.NewGuid(), Constants.Color.Blue);
        public static Color Yellow = new Color(Guid.NewGuid(), Constants.Color.Yellow);
        public static Color White = new Color(Guid.NewGuid(), Constants.Color.White);
        public static Color Black = new Color(Guid.NewGuid(), Constants.Color.Black);


        public static List<Color> All =
            new List<Color>
            {
                Red,
                Blue,
                Yellow,
                White,
                Black
            };
    }
}