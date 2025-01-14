using Biblioteca_REST_API.Hypermedia;
using Biblioteca_REST_API.Hypermedia.Abstract;

namespace Biblioteca_REST_API.Data.VO
{
    public class PersonVO : ISupportsHypermedia
    {
        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
