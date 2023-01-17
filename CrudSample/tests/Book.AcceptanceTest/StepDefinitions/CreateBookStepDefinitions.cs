using Book.AcceptanceTest.Drivers;
using System;
using TechTalk.SpecFlow;

namespace Book.AcceptanceTest.StepDefinitions
{
    [Binding]
    public class CreateBookStepDefinitions
    {
        private readonly BookDriver _driver;

        public CreateBookStepDefinitions(BookDriver driver)
        {
            _driver = driver;
        }

        [Given(@"system error codes are following")]
        public void GivenSystemErrorCodesAreFollowing(Table table)
        {
            _driver.SetSystemError(table);
        }

        [When(@"user create a new author with below data")]
        public async Task WhenUserCreateANewAuthorWithBelowData(Table table)
        {
           await _driver.CreateAuthorWithInformation(table);
        }

        [When(@"user Create a new Book with below data")]
        public async Task WhenUserCreateANewBookWithBelowData(Table table)
        {
           await _driver.CreateBookWithInformation(table);
        }

        [Then(@"user get all list of all books, and filter name of ""([^""]*)"" there must be ""([^""]*)"" result")]
        public async Task ThenUserGetAllListOfAllBooksAndFilterNameOfThereMustBeResult(string name, string result)
        {
            int response = await _driver.BookCountWithName(name);

            Assert.Equal(response.ToString() , result);
        }

        [Then(@"system responds with ""([^""]*)"" error")]
        public void ThenSystemRespondsWithError(string error)
        {
            if (_driver.SenarioContext.ErrorStatus)
                Assert.Equal(error.Trim(), _driver.SenarioContext.ErrorCode);
        }
    }
}


