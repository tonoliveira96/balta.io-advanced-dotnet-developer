using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Test.ValueObjects
{
    public class UrlTests
    {
        private const string ValidUrl = "https://learn.microsoft.com";

        [Fact]
        public void ShouldBeReturnException_WhenUrlIsInvalid()
        {
            Assert.Throws<InvalidUrlException>(() => new Url("banana"));
        }

        [Fact]
        public void ShouldNotReturnExceptionWheUrlIsInvalid()
        {
            var url = new Url(ValidUrl);

            Assert.Equal(ValidUrl, url.Adress);
        }
    }
}
