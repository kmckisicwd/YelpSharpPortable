using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;
using RestSharp.Portable.HttpClient;
using YelpSharpPortable.Data;
using YelpSharpPortable.Data.Options;

namespace YelpSharpPortable
{
    /// <summary>
    /// 
    /// </summary>
    public class Yelp
    {
        //--------------------------------------------------------------------------
        //
        //	Variables
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// Root url for the Yelp REST API.
        /// </summary>
        protected const string RootUri = "http://api.yelp.com/v2/";

        /// <summary>
        /// Authentication options for the connection.
        /// </summary>
        protected Options Options { get; set; }

        //--------------------------------------------------------------------------
        //
        //	Constructors
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// Driver for the Yelp API
        /// </summary>
        /// <param name="options">OAuth options for using the Yelp API</param>
        public Yelp(Options options)
        {
            this.Options = options;
        }


        //--------------------------------------------------------------------------
        //
        //	Public Methods
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// Simple search method to look for a term in a given plain text address
        /// </summary>
        /// <param name="term">what to look for (ex: coffee)</param>
        /// <param name="location">where to look for it (ex: seattle)</param>
        /// <returns>a strongly typed result</returns>
        public Task<SearchResults> Search(string term, string location)
        {
            var result = MakeRequest<SearchResults>("search", null, new Dictionary<string, string>
                {
                    { "term", term },
                    { "location", location }
                });

            return result;
        }

        /// <summary>
        /// advanced search based on search options object
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<SearchResults> Search(SearchOptions options)
        {
            var result = MakeRequest<SearchResults>("search", null, options.GetParameters());
            return result;
        }

        /// <summary>
        /// search the list of business based on name
        /// </summary>
        /// <param name="name">name of the business you want to get information on</param>
        /// <returns>Business details</returns>
        public Task<Business> GetBusiness(string name)
        {
            var result = MakeRequest<Business>("business", name, null);
            return result;
        }

        /// <summary>
        /// search businesses based on phone number
        /// </summary>
        /// <param name="phone">phone number of the business you want to get information on</param>
        /// <returns>List of matching businesses</returns>
        public Task<SearchResults> SearchByPhone(string phone)
        {
            var parameters = new Dictionary<string, string>()
            { 
                {"phone", phone} 
            };
            var result = MakeRequest<SearchResults>("phone_search", null, parameters);
            return result;
        }

        //--------------------------------------------------------------------------
        //
        //	Internal Methods
        //
        //--------------------------------------------------------------------------

        /// <summary>
        /// contains all of the oauth magic, makes the http request and returns raw json
        /// </summary>
        /// <param name="area"></param>
        /// <param name="id"></param>
        /// <param name="parameters">hash array of qs parameters</param>
        /// <returns>plain text json response from the api</returns>
        protected Task<T> MakeRequest<T>(string area, string id, Dictionary<string, string> parameters)
        {
            // build the url with parameters
            var url = area;
            if (string.IsNullOrEmpty(id) == false)
            {
                url += "/" + Uri.EscapeDataString(id);
            }

            // restsharp FTW!
            var client = new RestClient(RootUri)
            {
                Authenticator = OAuth1Authenticator.ForProtectedResource(Options.ConsumerKey, Options.ConsumerSecret, Options.AccessToken, Options.AccessTokenSecret)
            };
            var request = new RestRequest(url, Method.GET);

            if (parameters != null)
            {
                var keys = parameters.Keys.ToArray();
                foreach (var k in keys)
                {
                    request.AddParameter(k, parameters[k]);
                }
            }

            SearchResults x = new SearchResults();
            var tcs = new TaskCompletionSource<T>();
            var handle = client.Execute<T>(request).ContinueWith(completedTask =>
            {
                if (completedTask.Status == TaskStatus.RanToCompletion)
                {
                    var response = completedTask.Result;
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        tcs.SetResult(default(T));
                    }
                    else
                    {
                        try
                        {
                            var results = response.Data;
                            tcs.SetResult(results);
                        }
                        catch (Exception ex)
                        {
                            tcs.SetException(ex);
                        }
                    }
                }
                else
                {
                    tcs.SetResult(default(T));
                }
            });

            return tcs.Task;
        }
    }
}
