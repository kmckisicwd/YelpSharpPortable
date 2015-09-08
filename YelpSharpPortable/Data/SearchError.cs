
namespace YelpSharpPortable.Data
{
    /// <summary>
    /// general error result data after calling the search api
    /// </summary>
    public class SearchError
    {
        /// <summary>
        /// Short description of error
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Enum of possible error id's
        /// </summary>
        public ErrorId Id { get; set; }
        /// <summary>
        /// Lengthier version of text, null for some errors
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Field with error, null for some errors
        /// </summary>
        public string Field { get; set; }
    }

    public enum ErrorId
    {
        InternalError,
        ExceededReqs,
        MissingParameter,
        InvalidParameter,
        InvalidSignature,
        InvalidCredentials,
        InvalidOauthCredentials,
        AccountUnconfirmed,
        PasswordTooLong,
        UnavailableForLocation,
        AreaTooLarge,
        MultipleLocations,
        BusinessUnavailable,
        UnspecifiedLocation
    }
}
