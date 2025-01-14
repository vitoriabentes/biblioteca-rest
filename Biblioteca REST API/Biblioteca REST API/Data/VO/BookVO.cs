using Biblioteca_REST_API.Hypermedia;
using Biblioteca_REST_API.Hypermedia.Abstract;

namespace Biblioteca_REST_API.Data.VO
{
    public class BookVO : ISupportsHypermedia
    {
        public long Id { get; set; }
        public string Author { get; set; }

        public DateTime LaunchDate { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
