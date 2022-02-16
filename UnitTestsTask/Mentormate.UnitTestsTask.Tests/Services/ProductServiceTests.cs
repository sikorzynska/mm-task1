using Mentormate.UnitTestsTask.Contracts;
using Mentormate.UnitTestsTask.Entities;
using Mentormate.UnitTestsTask.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace Mentormate.UnitTestsTask.Tests.Services
{
    [TestClass]
    public class ProductServiceTests
    {
        private Mock<IProductRepository>? _productRepository;
        private Mock<IPriceRepository>? _priceRepository;
        private Mock<IDiscountRepository>? _discountRepository;
        private ProductService? _productService;

        [TestInitialize]
        public void Initialize()
        {
            _productRepository = new Mock<IProductRepository>();
            _priceRepository = new Mock<IPriceRepository>();
            _discountRepository = new Mock<IDiscountRepository>();

            _productService = new ProductService(_productRepository.Object, _priceRepository.Object, _discountRepository.Object);

            _productRepository.Setup(x => x.GetById(It.IsAny<long>())).Returns(new Product());
            _priceRepository.Setup(x => x.GetBasePrice(It.IsAny<long>())).Returns(new BasePrice());
            _discountRepository.Setup(x => x.GetDiscountAmount(It.IsAny<long>(), It.IsAny<long>())).Returns(new decimal());
        }

        [TestMethod]
        public Task GetProductPrice_ShouldReturnCorrectProductPrice()
        {
            //Arrange
            var productId = 5;
            var productName = "Very ripe banana";
            var productPrice = 13;

            var product = new Product()
            {
                Id = productId,
                Name = productName,
            };

            var basePrice = new BasePrice()
            {
                IsFinal = true,
                Ammount = 13,
            };

            var expectedId = productId;
            var expectedName = productName;
            var expectedPrice = productPrice;

            _productRepository.Setup(x => x.GetById(productId)).Returns(product);
            _priceRepository.Setup(x => x.GetBasePrice(productId)).Returns(basePrice);

            //Act
            var actualResult = _productService.GetProductPrice(productId, 3, DateTime.UtcNow);

            //Assert
            Assert.AreEqual(expectedId, actualResult.Id, "ID should match.");
            Assert.AreEqual(expectedName, actualResult.Name, "Name should match.");
            Assert.AreEqual(expectedPrice, actualResult.Price, "Price should match.");
            return Task.CompletedTask;
        }

        [TestMethod]
        public Task GetProductPrice_ShouldApplyDiscount()
        {
            //Arrange
            var productId = 5;
            var fakeId = 3;
            var productName = "Very ripe banana";

            var product = new Product()
            {
                Id = productId,
                Name = productName,
            };

            _productRepository.Setup(x => x.GetById(productId)).Returns(product);

            //Act
            Action expectedAct = () => { throw new ArgumentException($"Cannot find product with id: {fakeId}."); };
            var expectedException = Assert.ThrowsException<ArgumentException>(expectedAct);

            try
            {
                _productService.GetProductPrice(fakeId, 3, DateTime.UtcNow);
                Assert.IsTrue(false, "Should have thrown the exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(ex.Message, expectedException.Message, "Exception messages should be the same.");
            }

            //Assert
            return Task.CompletedTask;
        }
    }
}
