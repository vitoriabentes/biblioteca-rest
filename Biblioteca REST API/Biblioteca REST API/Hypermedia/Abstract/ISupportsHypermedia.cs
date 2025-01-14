namespace Biblioteca_REST_API.Hypermedia.Abstract
{
    public interface ISupportsHypermedia
    {
        List<HyperMediaLink> Links {  get; set; }
    }
}
