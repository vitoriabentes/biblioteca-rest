using Biblioteca_REST_API.Data.VO;
using Biblioteca_REST_API.Hypermedia.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Biblioteca_REST_API.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/person";
            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink() 
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.Self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link.Substring(0, link.LastIndexOf('/')),
                Rel = RelationType.Self,
                Type = ResponseTypeFormat.DefaultPut
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.Self,
                Type = "int"
            });

            return Task.CompletedTask;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock(this)
            {
                var url = new { controller = path, id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%20", "/").ToString();
            }
        }
    }
}
