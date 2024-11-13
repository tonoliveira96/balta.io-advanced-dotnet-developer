using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {
        /// <summary>
        ///  Create a new URL
        /// </summary>
        /// <param name="adress"></param>
        public Url(string adress)
        {
            Address = adress;
            InvalidUrlException.ThrowIfInvalid(adress);
        }

        /// <summary>
        /// Adress of URL (Website link)
        /// </summary>
        public string Address { get; }
    }
}
