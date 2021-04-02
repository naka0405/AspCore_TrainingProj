namespace Banks.BusinessLogic
{
    /// <summary>
    /// Class for set jwt token configuration.
    /// </summary>
    public class JwtTokenConfig
    {
        /// <summary>
        /// Gets or sets secret string key.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets issuer of the token.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets intended recipient of the token.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets expiration time in minutes.
        /// </summary>
        public int AccessTokenExpiration { get; set; }
    }
}
