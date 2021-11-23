using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Domain.Services
{
    public class ImageService
    {
        private HttpClient client = new HttpClient();
         public string GetImagePath(string name)
        {
            name = "Iphone 11";
            var response = client.GetAsync($"https://www.pinterest.com/search/pins/?q={name}").Result;
            var str = response.Content.ReadAsStringAsync().Result;

            return str;
        }
    }
}
