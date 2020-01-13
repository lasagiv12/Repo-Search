using Matrix_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Matrix_Test
{
    public class RepoSerarch
    {
        private string baseAddress { get; }
        private HttpClient client { set; get; }
        private RepoResults repoResults { set; get; }

        public RepoSerarch()
        {
            client = new HttpClient();
            baseAddress = "https://api.github.com/search/";
            repoResults = new RepoResults();
        }

        public async Task<RepoResults> Start(string searchValue)
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Matrix_Test", "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.mercy-preview+json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(searchValue);

            if (response.IsSuccessStatusCode)
            {
                repoResults = await response.Content.ReadAsAsync<RepoResults>();
                return repoResults;
            }
            return null;
        }
    }
}


            
                

   
