﻿using Microsoft.AspNetCore.Mvc;
using RestwithASPNETUdemy.Data.VO;
using RestwithASPNETUdemy.Hypermedia.Constants;
using System.Text;

namespace RestwithASPNETUdemy.Hypermedia.Enricher
{
    public class PersonEnricher : ContentResponseEnricher<PersonVO>
    {
        protected override Task EnrichModel(PersonVO content, IUrlHelper iurlhelper)
        {
            var path = "api/person/";
            string link = getLink(content.Id, iurlhelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PATCH,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPatch
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });
            return Task.CompletedTask;
        }

        private string getLink(long id, IUrlHelper urlhelper, string path)
        {
            lock (this)
            {
                var url = new { Controller = path, id };
                return new StringBuilder(urlhelper.Link("Defaultapi", url)).Replace("%2F", "/").ToString();
            };
        }
    }
}
