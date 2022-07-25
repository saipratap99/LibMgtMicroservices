using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TagsAPIService.Exceptions;
using TagsAPIService.Models;
using TagsAPIService.Repositories;
using TagsAPIService.Services;

namespace TagsAPIServiceTests.Services
{
    public class TagsServiceTests
    {
        private readonly TagsService _sut;

        Mock<ITagsRepository> tagsRespositoryMock = new Mock<ITagsRepository>();

        public TagsServiceTests()
        {
            _sut = new TagsService(tagsRespositoryMock.Object);
        }

        [Fact]
        public async Task CreateTagAsync_Should_Return_Success()
        {
            // Arrange
            Tag tag = new Tag() { Id = 1, Name = "CSE" };
            object expected = new { msg = $"Tag {tag.Name} created successfully" };

            // Act
            tagsRespositoryMock.Setup(x => x.CreateTagAsync(tag)).ReturnsAsync(true);

            var actual = await _sut.CreateTagAsync(tag);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetAllTagsAsync_Should_Return_Success()
        {

            List<Tag> expectedTags = new List<Tag>()
            {
                new Tag(){ Id = 1, Name = "CSE"},
                new Tag(){ Id = 2, Name = "Electrical"},
            };

            tagsRespositoryMock.Setup(x => x.GetAllTagsAsync()).ReturnsAsync(expectedTags);

            var actualTags = await _sut.GetAllTagsAsync();

            Assert.Equal(expectedTags, actualTags);

        }

        [Fact]
        public async Task GetTagByIdAsync_Should_Return_Success()
        {
            int id = 1;
            Tag expectedTag = new Tag() { Id = id, Name = "CSE" };

            tagsRespositoryMock.Setup(x => x.GetTagAsync(id)).ReturnsAsync(expectedTag);

            var actualTag = await _sut.GetTagByIdAsync(id);

            Assert.Equal(expectedTag, actualTag);
        }

        [Fact]
        public async Task GetTagByIdAsync_Should_Return_TagNotFoundException()
        {
            int id = 10;
            
            tagsRespositoryMock.Setup(x => x.GetTagAsync(id)).Throws(new TagNotFoundException($"Tag with id {id} not found"));

            Assert.Throws<TagNotFoundException>(() => _sut.GetTagByIdAsync(id).Result);
        }



    }
}
