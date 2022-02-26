using System.Collections.Generic;
using System.Linq;
using ConstructionLine.CodingChallenge.ExtensionMethods;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts ?? new List<Shirt>();
        }


        public SearchResults Search(SearchOptions options)
        {
            var shirts = _shirts.FindAll(o => options.Sizes.Contains(o.Size) || options.Colors.Contains(o.Color))
                .DistinctBy(o => o.Id).ToList();

            return new SearchResults
            {
                Shirts = shirts,
                ColorCounts = ColorCounts(shirts),
                SizeCounts = SizeCounts(shirts)
            };
        }

        private static List<SizeCount> SizeCounts(List<Shirt> shirts)
        {
            var sizeCounts = new List<SizeCount>();
            Size.All.ForEach(o =>
            {
                sizeCounts.Add(new SizeCount() {Size = o, Count = shirts.Count(r => r.Size.Id == o.Id)});
            });
            return sizeCounts;
        }

        private static List<ColorCount> ColorCounts(List<Shirt> shirts)
        {
            var colorCounts = new List<ColorCount>();
            Color.All.ForEach(o =>
            {
                colorCounts.Add(new ColorCount() {Color = o, Count = shirts.Count(r => r.Color.Id == o.Id)});
            });
            return colorCounts;
        }
    }
}