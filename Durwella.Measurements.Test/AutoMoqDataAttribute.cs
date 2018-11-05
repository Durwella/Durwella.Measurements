using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Measurements
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute(bool configureMembers = true)
            : base(() => BuildFixture(configureMembers))
        {

        }
        private static IFixture BuildFixture(bool configureMembers)
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization() { ConfigureMembers = configureMembers });
            return fixture;
        }
    }
}
