using ICS.Common.Tests;
using ICS.Common.Tests.Seeds;
using ICS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS.DAL.Tests
{
    public class DbContextStudentTests(ITestOutputHelper output) : DbContextTestsBase(output)
    {
        [Fact]
        public async Task AddNew_Student_Persisted()
        {
            // Arrange
            var entity = new StudentEntity
            {
                Id = Guid.Parse("fab130cd-eefe-443f-baf6-3d96cc2cbf23"),
                Name = "Petr",
                Surname = "Pavel",
                ImageUrl = "https://example.com/photo.jpg"
            };

            // Act
            IcsDbContextSut.Students.Add(entity);
            await IcsDbContextSut.SaveChangesAsync();

            // Assert
            await using var dbContext = DbContextFactory.CreateDbContext();
            var actualEntity = await dbContext.Students.SingleAsync(s => s.Id == entity.Id);
            DeepAssert.Equal(entity, actualEntity);
        }

        [Fact]
        public async Task GetAll_Students_ContainsSeededStudent()
        {
            // Act
            var entities = await IcsDbContextSut.Students.ToArrayAsync();

            // Assert
            bool contains = entities.Any(e =>
                e.Id == StudentSeeds.StudentEntity.Id &&
                e.Name == StudentSeeds.StudentEntity.Name &&
                e.Surname == StudentSeeds.StudentEntity.Surname &&
                e.ImageUrl == StudentSeeds.StudentEntity.ImageUrl
            );
            Assert.True(contains);
        }

        [Fact]
        public async Task GetById_Student_StudentEntityRetrieved()
        {
            // Act
            var entity = await IcsDbContextSut.Students.SingleAsync(e => e.Id == StudentSeeds.StudentEntity.Id);

            // Assert
            DeepAssert.Equal(StudentSeeds.StudentEntity, entity);
        }

        [Fact]
        public async Task Update_Student_Persisted()
        {
            // Arrange
            var entity = StudentSeeds.StudentEntity with { Name = "Updated Name" };

            // Act
            IcsDbContextSut.Students.Update(entity);
            await IcsDbContextSut.SaveChangesAsync();

            // Assert
            await using var dbContext = DbContextFactory.CreateDbContext();
            var actual = await dbContext.Students.SingleAsync(e => e.Id == entity.Id);
            DeepAssert.Equal(entity, actual);
        }

        [Fact]
        public async Task Delete_Student_Removed()
        {
            // Arrange
            var entity = StudentSeeds.StudentEntity;

            // Act
            IcsDbContextSut.Students.Remove(entity);
            await IcsDbContextSut.SaveChangesAsync();

            // Assert
            await using var dbContext = DbContextFactory.CreateDbContext();
            var actual = await dbContext.Students.SingleOrDefaultAsync(e => e.Id == entity.Id);
            Assert.Null(actual);
        }

        [Fact]
        public async Task DeleteById_Student_Removed()
        {
            // Arrange
            var entity = StudentSeeds.StudentEntity;

            // Act
            IcsDbContextSut.Remove(IcsDbContextSut.Students.Single(e => e.Id == entity.Id));
            await IcsDbContextSut.SaveChangesAsync();

            // Assert
            await using var dbContext = DbContextFactory.CreateDbContext();
            var actual = await dbContext.Students.SingleOrDefaultAsync(e => e.Id == entity.Id);
            Assert.Null(actual);
        }
    }
}
