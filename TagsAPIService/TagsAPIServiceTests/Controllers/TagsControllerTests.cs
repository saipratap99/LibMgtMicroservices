using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TagsAPIService.Controllers;
using TagsAPIService.Models;
using TagsAPIService.Services;

namespace TagsAPIServiceTests.Controllers
{
    public class TagsControllerTests 
    {
        private readonly TagsController _sut;
        Mock<ITagsService> tagsServiceMock = new Mock<ITagsService>();

        public TagsControllerTests()
        {
            _sut = new TagsController(tagsServiceMock.Object);
        }

        [Fact]
        public async Task Index_Should_Return_Success()
        {

            List<Tag> expectedTags = new List<Tag>()
            {
                new Tag(){ Id = 1, Name = "CSE"},
                new Tag(){ Id = 2, Name = "Electrical"},
            };

            var actualTags = await _sut.Index();

            Assert.Equal(expectedTags, actualTags);
        }
    }
}
