using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Core.Helpers
{
    public class ShortUrlHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;
       
        public static void SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public static string CombineUrl(string originalUrl,string shortUrl)
        {
            return string.Concat(originalUrl + " => " + _httpContextAccessor.HttpContext.Request.Host.ToString(), "/", shortUrl); 
        }


    }
}
