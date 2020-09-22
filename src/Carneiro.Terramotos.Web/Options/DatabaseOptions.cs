namespace Carneiro.Terramotos.Web.Options
{
    public class DatabaseOptions
    {
        /// <summary>
        /// Gets or sets the timeout, in seconds. Default is 60 seconds.
        /// </summary>
        /// <value>
        /// The timeout.
        /// </value>
        public int Timeout { get; set; } = 60;

        /// <summary>
        /// Gets or sets the failure settings.
        /// </summary>
        /// <value>
        /// The failure settings.
        /// </value>
        public DatabaseFailureOptions Failure { get; set; } = new DatabaseFailureOptions();

        /// <summary>
        /// Gets or sets a value indicating whether [enable sensitive data logging].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable sensitive data logging]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableSensitiveDataLogging { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether [enable detailed errors].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable detailed errors]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableDetailedErrors { get; set; } = false;
    }
}