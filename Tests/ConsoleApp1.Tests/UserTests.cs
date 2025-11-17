using MealPlannerApp;
using Xunit;

namespace ConsoleApp1.Tests
{
    public class UserTests
    {
        [Fact]
        public void User_Should_Add_Preference()
        {
            var u = new User("Gabriel");
            u.AddPreference("vegano");

            Assert.Contains("vegano", u.Preferences);
        }

        [Fact]
        public void User_Should_Not_Add_Duplicate_Preference()
        {
            var u = new User("Gabriel");
            u.AddPreference("leve");
            u.AddPreference("leve");

            Assert.Single(u.Preferences);
        }
    }
}
