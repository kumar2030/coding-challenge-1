using System;
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
            _shirts = shirts ?? throw new ArgumentNullException(nameof(shirts));
        }


        public SearchResults Search(SearchOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var shirts = _shirts.FindAll(o => (!options.Sizes.Any() || options.Sizes.Contains(o.Size)) && (!options.Colors.Any() || options.Colors.Contains(o.Color)))
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
            return Size.All.Select(o => new SizeCount() {Size = o, Count = shirts.Count(r => r.Size.Id == o.Id)}).ToList();
        }

        private static List<ColorCount> ColorCounts(List<Shirt> shirts)
        {
            return Color.All.Select(o =>
                new ColorCount() {Color = o, Count = shirts.Count(r => r.Color.Id == o.Id)}).ToList();
        }
    }
}