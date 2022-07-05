using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UrlShortener.DAL.Models.Entities
{
    [Table("URL")]

    public class Url
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OriginalUrl { get; set; }

        [Required]
        public string ShortUrl { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
