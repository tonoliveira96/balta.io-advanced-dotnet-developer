using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Campaign : ValueObject
    {
        /// <summary>
        /// Generate a new campaign for URL.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="medium"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="term"></param>
        /// <param name="content"></param>
        public Campaign(
            string source, 
            string medium, 
            string name, 
            string? id = null, 
            string? term = null, 
            string? content = null)
        {
            Source = source;
            Medium = medium;
            Name = name;
            Id = id;
            Term = term;
            Content = content;

            InvalidCampaignException.ThrowIfNull(source, "UTM Source is invalid");
            InvalidCampaignException.ThrowIfNull(medium, "UTM Medium is invalid");
            InvalidCampaignException.ThrowIfNull(name, "UTM Name is invalid");
        }

        public string Source { get; }
        public string Medium { get; }
        public string Name { get; }
        public string? Id { get; set; }
        public string? Term { get; set; }
        public string? Content { get; set; }
    }
}
