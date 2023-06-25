using Sales.API.Domain.DTOs;
using Xunit;

namespace Sales.API.Test.UnitTest.ComissionTest
{
    public class ComissionTest
    {
        [Fact]
        public void Create_CreateComissionWhenDataIsValid_ReturnNoErrors()
        {
            // Arrange
            var builder = new ComissionTestBuilder().WithDbContextOptions("CreateComission").WithContext().WithMapper().WithService().WithRepository();
            var comissionService = builder.SaveChanges().GetService();


            // Act
            ComissionDTO comissionDTO = ComissionTestValidData.Build();
            var expected = ComissionTestValidData.Response();
            var result = comissionService.CreateAsync(comissionDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Name, result.Result.Entity.Name);
        }

        [Fact]
        public void Create_CreateComissionWhenMaxLength_ReturnError()
        {
            // Arrange
            var builder = new ComissionTestBuilder().WithDbContextOptions("CreateComission").WithContext().WithMapper().WithRepository().WithService();
            var comissionService = builder.SaveChanges().GetService();

            // Act 
            var result = comissionService.CreateAsync(ComissionTestInvalidData.BuildMaxLength());
            var expected = ComissionTestInvalidData.ResponseMaxLength();

            // Assert
            Assert.Equal(result.Result.StatusCode, expected.StatusCode);
            Assert.Equal(result.Result.ValidationErrors, expected.ValidationErrors);
        }

        [Fact]
        public void Create_CreateComissionWhenPercentageIsInvalid_ReturnError()
        {
            // Arrange
            var builder = new ComissionTestBuilder().WithDbContextOptions("CreateComission").WithContext().WithMapper().WithRepository().WithService();
            var comissionService = builder.SaveChanges().GetService();

            // Act 
            var result = comissionService.CreateAsync(ComissionTestInvalidData.BuildPercentageInvalid());
            var expected = ComissionTestInvalidData.ResponsePercentageInvalid();

            // Assert
            Assert.Equal(result.Result.StatusCode, expected.StatusCode);
            Assert.Equal(result.Result.ValidationErrors, expected.ValidationErrors);
        }
    }
}
