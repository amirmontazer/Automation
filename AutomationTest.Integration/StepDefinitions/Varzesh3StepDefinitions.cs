namespace AutomationTest.Integration.StepDefinitions;

[Binding]
public class Varzesh3StepDefinitions
{
    private HttpClient _client;
    private HttpResponseMessage _response;
    private string _baseUrl;

    [Given(@"the API endpoint is ""([^""]*)""")]
    public void GivenTheAPIEndpointIs(string baseUrl)
    {
        _baseUrl = baseUrl;
        _client = new HttpClient();
    }

    [When(@"I search for ""([^""]*)""")]
    public async Task WhenISearchFor(string query)
    {
        var requestUri = $"{_baseUrl}?q={query}";
        _response = await _client.GetAsync(requestUri);
    }

    [Then(@"the response should contain ""([^""]*)""")]
    public async Task ThenTheResponseShouldContain(string expectedText)
    {
        var content = await _response.Content.ReadAsStringAsync();
        Assert.Contains(expectedText, content);
    }

    [Then(@"the status code should be (.*)")]
    public void ThenTheStatusCodeShouldBe(int expectedStatusCode)
    {
        var statusCode = (int)_response.StatusCode;
        Assert.Equal(expectedStatusCode, (int)_response.StatusCode);
    }
}
