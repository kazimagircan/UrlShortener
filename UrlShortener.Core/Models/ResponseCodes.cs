using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UrlShortener.Core.Models
{
    public class ResponseCodes
    {
        public static readonly string DigitError = "Please you must enter valid url, parameter must max 6 digits.";
        public static readonly string ValidationError = "Please you must enter valid url, parameter must include [1234567890abcdefghijklmnopqrstuvwxyzABCDFGHJKLMNPQRSTVWXYZ]";
        public static readonly string Empty = "Please you must enter valid url, parameter is empty.";
        public static readonly string NotFound = "Please you must enter valid url, url is not found.";
        public static readonly string AlreadyUse = "Please you must use another url, url is already used.";

    }
}
