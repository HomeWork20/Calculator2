using System;

using Calculator2.Fixtures;
using Calculator2.Pages;
using Xunit;

namespace Calculator2.Tests
{
    public class FunctionalTests : IClassFixture<ApplicationFixture>
    {
        ApplicationFixture AppFixture { get; set; }

        public FunctionalTests(ApplicationFixture appFixture)
        {
            AppFixture = appFixture;
        }

        [Fact]
        public void CalculateSqrtTest()
        {   
            AppFixture.Navigate().GoToUrl(MainPage.URL);
            MainPage mainPage = new MainPage(AppFixture.Driver);

            double number = Math.Round(new Random().NextDouble() * 99 + 1, 2);
            mainPage.TypeNumber(number);
            mainPage.ButtonSqrt.Click();
            mainPage.ButtonEqually.Click();
            
            Assert.Equal(Math.Sqrt(number), mainPage.GetDoubleResult());

            mainPage.ButtonMultiply.Click();
            mainPage.ButtonEqually.Click();

            Assert.Equal(number, mainPage.GetDoubleResult());
        }
    }
}
