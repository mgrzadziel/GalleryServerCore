﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace GalleryServer.Data
{
    public class WebHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;
        private static IMemoryCache _cache;

        public static void Configure(IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache)
        {
            _httpContextAccessor = httpContextAccessor;
            _cache = memoryCache;
        }

        public static HttpContext HttpContext => _httpContextAccessor.HttpContext;

        public static string GetRemoteIP => HttpContext.Connection.RemoteIpAddress.ToString();

        public static string GetUserAgent => HttpContext.Request.Headers["User-Agent"].ToString();

        public static string GetScheme => HttpContext.Request.Scheme;

        public static IMemoryCache GetCache()
        {
            return _cache;
        }
    }
}