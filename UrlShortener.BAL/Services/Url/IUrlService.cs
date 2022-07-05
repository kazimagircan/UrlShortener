using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.BAL.Services.Url
{
    public interface IUrlService
    {
        string CreateUrl(string data);
        string AddCustomUrl(string originalUrl, string shortUrl);
        Task<string> GetUrl(string path);

    }
}
