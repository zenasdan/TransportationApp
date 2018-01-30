using MVCBlank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MVCBlank.Controllers.Api
{
    [RoutePrefix("api/Transportations")]
    public class TransportationController : ApiController
    {
        public string ReturnStr { get; set; }
        public Dictionary<string, Transportation> TransportationDictionary { get; set; }

        public TransportationController()
        { 
            ReturnStr = "isSuccessful";
            TransportationDictionary = new Dictionary<string, Transportation>();
        }

        [Route(), HttpPost]
        public HttpResponseMessage AddTransportation(Transportation transportation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                TransportationDictionary = (Dictionary<string, Transportation>)HttpContext.Current.Application["Dictionary"];
                if(TransportationDictionary == null)
                {
                    TransportationDictionary = new Dictionary<string, Transportation>();
                    TransportationDictionary.Add(transportation.Name, transportation);
                    HttpContext.Current.Application["Dictionary"] = TransportationDictionary;
                    return Request.CreateResponse(HttpStatusCode.OK, ReturnStr);
                }
                else
                {
                    TransportationDictionary = (Dictionary<string, Transportation>)HttpContext.Current.Application["Dictionary"];
                    if (TransportationDictionary.ContainsKey(transportation.Name))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "There is already a transport here.");
                    }
                    else
                    {
                        TransportationDictionary.Add(transportation.Name, transportation);
                        HttpContext.Current.Application["Dictionary"] = TransportationDictionary;
                        return Request.CreateResponse(HttpStatusCode.OK, ReturnStr);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{name}"), HttpPut]
        public HttpResponseMessage UpdateTransportation(Transportation transportation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                TransportationDictionary = (Dictionary<string, Transportation>)HttpContext.Current.Application["Dictionary"];
                if (TransportationDictionary == null)
                {
                    TransportationDictionary = new Dictionary<string, Transportation>();
                    return Request.CreateResponse(HttpStatusCode.OK, "There is nothing to update here.");
                }
                else
                {
                    TransportationDictionary = (Dictionary<string, Transportation>)HttpContext.Current.Application["Dictionary"];
                    TransportationDictionary[transportation.Name] = transportation;
                    HttpContext.Current.Application["Dictionary"] = TransportationDictionary;
                    return Request.CreateResponse(HttpStatusCode.OK, ReturnStr);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{name}"), HttpDelete]
        public HttpResponseMessage DeleteTransportation(string name)
        {
            try
            {
                TransportationDictionary = (Dictionary<string, Transportation>)HttpContext.Current.Application["Dictionary"];
                if (TransportationDictionary == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Nothing to Delete");
                }
                else
                {
                    TransportationDictionary = (Dictionary<string, Transportation>)HttpContext.Current.Application["Dictionary"];
                    TransportationDictionary.Remove(name);
                    HttpContext.Current.Application["Dictionary"] = TransportationDictionary;
                    return Request.CreateResponse(HttpStatusCode.OK, ReturnStr);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route(), HttpGet]
        public HttpResponseMessage GetAllTransportations()
        {
            try
            {
                if (HttpContext.Current.Application["Dictionary"] == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new List<Transportation>());
                }
                else
                {
                    TransportationDictionary = (Dictionary<string, Transportation>)HttpContext.Current.Application["Dictionary"];
                    List<Transportation> response = TransportationDictionary.Select(d => d.Value).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}