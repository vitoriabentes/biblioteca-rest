using Microsoft.AspNetCore.Mvc.Filters;

namespace Biblioteca_REST_API.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);

    }
}
