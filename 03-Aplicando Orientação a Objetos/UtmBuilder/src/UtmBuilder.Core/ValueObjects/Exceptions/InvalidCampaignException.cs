namespace UtmBuilder.Core.ValueObjects.Exceptions
{
    public partial class InvalidCampaignException : Exception
    {
        private const string DefaultMessage = "Invalid UTM exception";
        public InvalidCampaignException(string message = DefaultMessage) : base(message) { }

        public static void ThrowIfNull(
            string? item,
            string message = DefaultMessage)
        {
            if (string.IsNullOrEmpty(item))
            {
                throw new InvalidUrlException(message);
            }

        }
    }
}
