using BDOBook.Services;
using Moq;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BDOBook.Tests.Services
{
    public class NewsServiceTests
    {
        [Fact]
        public void TheConstructor_WhenCalledWithAnEmptyString()
        {
            Assert.Throws<ArgumentException>(() => new NewsService("", null));
        }

        [Fact]
        public void TheConstructor_WhenCalledWithANullString()
        {
            Assert.Throws<ArgumentException>(() => new NewsService(null, null));
        }

        [Fact]
        public void TheConstructor_WhenCalledWithANullHttpClientFactory()
        {
            Assert.Throws<ArgumentNullException>(() => new NewsService("token", null));
        }

        [Fact]
        public void WhenGetMostRecent_RunsSuccessfully()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var httpClient = new HttpClient(new MockHttpMessageHandler()) { BaseAddress = new Uri("https://test.test/") };
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var newsService = new NewsService("token", mockFactory.Object);

            var response = newsService.GetMostRecent().Result;

            Assert.NotNull(response);
            Assert.Single(response.Data);

            var article = response.Data.First();
            Assert.Equal("https://www.espn.com/wnba/story/_/id/38194686/wnba-commissioner-cup-2023-las-vegas-aces-new-york-liberty", article.Url);
            Assert.Equal("Is Aces-Liberty Commissioner's Cup a preview of WNBA Finals?", article.Title);
            Assert.Equal("The three-year-old WNBA Commissioner's Cup is still finding its identity, but players appreciate the chance to boost their salary and add some hardware.", article.Description);
        }
    }

    internal class MockHttpMessageHandler : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(
                    "{\r\n  \"meta\": {\r\n    \"found\": 771142,\r\n    \"returned\": 10,\r\n    \"limit\": 10,\r\n    \"page\": 1\r\n  },\r\n  \"data\": [\r\n    {\r\n      \"uuid\": \"2018a147-2f7c-4a87-b5f4-0e07ea043e67\",\r\n      \"title\": \"Is Aces-Liberty Commissioner's Cup a preview of WNBA Finals?\",\r\n      \"description\": \"The three-year-old WNBA Commissioner's Cup is still finding its identity, but players appreciate the chance to boost their salary and add some hardware.\",\r\n      \"keywords\": \"\",\r\n      \"snippet\": \"The Las Vegas Aces meet the New York Liberty in Tuesday's Commissioner's Cup championship (9 p.m. ET), a matchup many expect to be a preview of the WNBA Finals....\",\r\n      \"url\": \"https://www.espn.com/wnba/story/_/id/38194686/wnba-commissioner-cup-2023-las-vegas-aces-new-york-liberty\",\r\n      \"image_url\": \"https://a1.espncdn.com/combiner/i?img=/photo/2023/0815/r1210759_1296x729_16-9.jpg\",\r\n      \"language\": \"en\",\r\n      \"published_at\": \"2023-08-15T14:35:35.000000Z\",\r\n      \"source\": \"espn.com\",\r\n      \"categories\": [\r\n        \"sports\",\r\n        \"general\"\r\n      ],\r\n      \"relevance_score\": null,\r\n      \"locale\": \"us\"\r\n    }\r\n  ]\r\n}",
                    Encoding.UTF8,
                    "application/json")
            };

            return await Task.FromResult(response);
        }
    }

}
