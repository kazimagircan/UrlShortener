using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Helpers;
using UrlShortener.Core.Models;
using UrlShortener.Core.Patterns;

namespace UrlShortener.BAL.Services.Url
{
    public class UrlService : IUrlService
    {
        private UnitOfWork uow;

        public UrlService()
        {
            uow = new UnitOfWork();
        }

        // <summary>
        // This method add record and check user short url via ShortUrl Class
        // </summary>
        public string AddCustomUrl(string originalUrl, string shortUrl)
        {

            if (!String.IsNullOrWhiteSpace(shortUrl))
            {
                if (shortUrl.Length > 6)
                    return ResponseCodes.DigitError;

                if(!ShortUrl.Check(shortUrl))
                    return ResponseCodes.ValidationError;

                try
                {
                    while (uow.Repository<DAL.Models.Entities.Url>().Any(x => x.ShortUrl == shortUrl))
                    {
                        return ResponseCodes.AlreadyUse;
                    }

                    DAL.Models.Entities.Url model = new DAL.Models.Entities.Url
                    {
                        OriginalUrl = originalUrl,
                        ShortUrl = shortUrl,
                        CreatedDate = DateTime.UtcNow
                    };
                    uow.Repository<DAL.Models.Entities.Url>().AddAsync(model);
                    uow.SaveChanges();

                    return ShortUrlHelper.CombineUrl(originalUrl, shortUrl);
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
            }
            else
                return ResponseCodes.Empty;
            
        }

        // <summary>
        // This method add record and generate short url via ShortUrl Class
        // </summary>
        public string CreateUrl(string data)
        {
            if (!String.IsNullOrWhiteSpace(data))
            {
                var shortUrl = ShortUrl.Encode();

                try
                {
                    while (uow.Repository<DAL.Models.Entities.Url>().Any(x => x.ShortUrl == shortUrl))
                    {
                        shortUrl = ShortUrl.Encode();
                    }

                    DAL.Models.Entities.Url model = new DAL.Models.Entities.Url
                    {
                        OriginalUrl = data,
                        ShortUrl= shortUrl,
                        CreatedDate = DateTime.UtcNow
                    };
                    uow.Repository<DAL.Models.Entities.Url>().AddAsync(model);
                    uow.SaveChanges();
                    return ShortUrlHelper.CombineUrl(data, shortUrl);
                }
                catch (Exception e)
                {
                    return e.Message.ToString();
                }
            }
            else
                return ResponseCodes.Empty;

            
        }

        // <summary>
        // This method get record and generate original url via ShortUrl Class
        // </summary>
        public async Task<string> GetUrl(string path)
        {
            try
            {
                var url = await uow.Repository<DAL.Models.Entities.Url>()
                                    .Find(x=>x.ShortUrl==path);

                if(url != null)
                    return url.OriginalUrl;
                else
                    return ResponseCodes.NotFound; 
            }
            catch (Exception e)
            {

                return e.Message.ToString();

            }

        }
    }

}
