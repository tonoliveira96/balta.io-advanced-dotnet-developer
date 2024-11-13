using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Test
{
    public class UtmTests
    {
        private const string Result = "https://balta.io/" +
                              "?utm_source=src" +
                              "&utm_medium=med" +
                              "&utm_campaign=nme" +
                              "&utm_id=id" +
                              "&utm_term=ter" +
                              "&utm_content=ctn";

        private readonly Url _url = new("https://balta.io/");

        private readonly Campaign _campaign = new(
            "src",
            "med",
            "nme",
            "id",
            "ter",
            "ctn");

        [Fact]
        public void ShouldReturnUrlFromUtm()
        {
            var utm = new Utm(_url, _campaign);

            Assert.Equal(Result, utm.ToString());
            Assert.Equal(Result, (string)utm);
        }

        [Fact]
        public void ShouldReturnUtmFromUrl()
        {
            Utm utm = Result;
            Assert.Equal("https://balta.io/", utm.Url.Address);
            Assert.Equal("src", utm.Campaign.Source);
            Assert.Equal("med", utm.Campaign.Medium);
            Assert.Equal("nme", utm.Campaign.Name);
            Assert.Equal("id", utm.Campaign.Id);
            Assert.Equal("ter", utm.Campaign.Term);
            Assert.Equal("ctn", utm.Campaign.Content);
        }
    }
}
