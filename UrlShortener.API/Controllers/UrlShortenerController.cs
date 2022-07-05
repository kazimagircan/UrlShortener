using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.BAL.Services.Url;

namespace UrlShortener.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        IUrlService _urlService;

        public UrlShortenerController(IUrlService urlService)
        {
            _urlService = urlService;

        }


        // Summary:
        //     This method add random short url
        //
        // Parameters:
        //   path:
        //     short url with host address.
        //
        // Returns:
        //     original url.
        [HttpGet("GetUrl/{path}")]
        public string GetUrl(string path)
        {
            return _urlService.GetUrl(path).Result;

        }

        // Summary:
        //     This method add random short url
        //
        // Parameters:
        //   url:
        //     original url.
        //
        // Returns:
        //     short url.
        [HttpPost("CreateUrl")]
        public string CreateUrl(string originalUrl)
        {
            return _urlService.CreateUrl(originalUrl);

        }

        // Summary:
        //     This method add custom short url
        //
        // Parameters:
        //   url:
        //     custom url without host address.
        //
        // Returns:
        //     short url.
        [HttpPost("AddCustomUrl")]
        public string AddCustomUrl( string originalUrl, string shortUrl)
        {
            return _urlService.AddCustomUrl(originalUrl, shortUrl);

        }


    }
}
