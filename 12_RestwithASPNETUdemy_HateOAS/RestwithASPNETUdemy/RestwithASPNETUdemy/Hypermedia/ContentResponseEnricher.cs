using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using RestwithASPNETUdemy.Hypermedia.Abstract;
using System.Collections.Concurrent;

namespace RestwithASPNETUdemy.Hypermedia
{
    public abstract class ContentResponseEnricher<T> : IResponseEnricher where T : ISupportHypermedia
    {
        public ContentResponseEnricher() { }
        public bool CanEnrich(Type contentType)
        {
            return contentType == typeof(T) || contentType == typeof(List<T>);
        }

        protected abstract Task EnrichModel(T content, IUrlHelper urlhelper);

        bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
        {
            if (response.Result is OkObjectResult okObjectResult)
            {
                return CanEnrich(okObjectResult.Value.GetType());
            }
            return false;
        }


        public async Task Enrich(ResultExecutingContext response)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
            if (response.Result is OkObjectResult okObjectResult)
            {
                if (okObjectResult.Value is T Model)
                {
                    await EnrichModel(Model, urlHelper);
                }
                else if (okObjectResult.Value is List<T> collection)
                {
                    ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
                    Parallel.ForEach(bag, (element) =>
                    {
                        EnrichModel(element, urlHelper);
                    });
                }
            }
            await Task.FromResult<object>(null);
        }
    }
}
