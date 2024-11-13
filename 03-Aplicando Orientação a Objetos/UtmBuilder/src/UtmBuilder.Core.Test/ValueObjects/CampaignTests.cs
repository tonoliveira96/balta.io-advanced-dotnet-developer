using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Test.ValueObjects
{
    public class CampaignTests
    {
        [Theory]
        [InlineData("", "", "")]
        [InlineData("src", "", "")]
        [InlineData("src", "mdu", "")]
        [InlineData("src", "mdu", "nam")]
        public void Campaign(string source, string medium, string name)
        {
            try
            {
                new Campaign(source, medium, name);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }
    }
}
