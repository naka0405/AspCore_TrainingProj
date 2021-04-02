using Banks.Entities.Entities;

namespace Banks.BusinessLogic.Interfaces
{
    /// <summary>
    ///  An interface which contains methods to work with access tokens.
    /// </summary>
    public interface IAuthJwtManager
    {
        /// <summary>
        /// Generate access token with nesessarry parameters.
        /// </summary>
        /// <param name="user">Instance of User.</param>
        /// <returns>String with token.</returns>
        string GenerateToken(User user);
    }
}
