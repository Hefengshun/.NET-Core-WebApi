namespace Zhaoxi.NET6Demo.IdentitySer.Utility
{
    public class JWTTokenOptions
    {
        public string? Audience { get; set; }

        /// <summary>
        /// 加密key
        /// </summary>
        public string? SecurityKey { get; set; }


        public string? Issuer { get; set; }
    }
}
