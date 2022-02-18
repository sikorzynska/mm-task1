using Mentormate.UnitTestsTask.Contracts;
using Mentormate.UnitTestsTask.Entities;
using Mentormate.UnitTestsTask.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
        }

        [TestMethod]
        public void GetProductPrice_ShouldReturnCorrectProductPrice()
        {
            //Arrange
            var userId = 1;

            var product = DefaultProduct();
            var basePrice = DefaultBasePrice(true);

            var expectedId = product.Id;
            var expectedName = product.Name;
            var expectedPrice = basePrice.Ammount;

            SetupProductRepository(product.Id, product);
            SetupPriceRepository(product.Id, basePrice);

            //Act
            var actualResult = _productService!.GetProductPrice(product.Id, userId, DateTime.UtcNow);

            //Assert
            Assert.AreEqual(expectedId, actualResult.Id, "ID should match.");
            Assert.AreEqual(expectedName, actualResult.Name, "Name should match.");
            Assert.AreEqual(expectedPrice, actualResult.Price, "Price should match.");
        }

        [TestMethod]
        public void GetProductPrice_ShouldApplyDiscountBecauseItsMonday()
        {
            //Arrange
            var userId = 1;
            var discountAmount = 5;

            var product = DefaultProduct();
            var basePrice = DefaultBasePrice(false);

            var expectedPrice = basePrice.Ammount - discountAmount;
            //Get last week's monday
            DateTime mondayOfLastWeek = DateTime.UtcNow.AddDays(-(int)DateTime.UtcNow.DayOfWeek - 6);

            SetupAllRepositories(product.Id, userId, product, basePrice, discountAmount);

            //Act
            var actualResult = _productService!.GetProductPrice(product.Id, userId, mondayOfLastWeek);

            //Assert
            Assert.AreEqual(expectedPrice, actualResult.Price, "Price should match.");
        }

        [TestMethod]
        public void GetProductPrice_ShouldApplyDiscountBecauseIts10AM()
        {
            //Arrange
            var userId = 1;
            var discountAmount = 5;

            var product = DefaultProduct();
            var basePrice = DefaultBasePrice(false);

            var expectedPrice = basePrice.Ammount - discountAmount;
            string dateString = "2005-05-05 10:12 AM";
            DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);

            SetupAllRepositories(product.Id, userId, product, basePrice, discountAmount);

            //Act
            var actualResult = _productService!.GetProductPrice(product.Id, userId, date);

            //Assert
            Assert.AreEqual(expectedPrice, actualResult.Price, "Price should match.");
        }

        [TestMethod]
        public void GetProductPrice_DiscountShouldNotMakePriceBelowZero()
        {
            //Arrange
            var userId = 1;
            var discountAmount = 15;

            var product = DefaultProduct();

            var basePrice = DefaultBasePrice(false);

            var expectedPrice = 0;

            //Random 10AM datetime
            string dateString = "2005-05-05 10:12 AM";
            DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);

            SetupAllRepositories(product.Id, userId, product, basePrice, discountAmount);

            //Act
            var actualResult = _productService!.GetProductPrice(product.Id, userId, date);

            //Assert
            Assert.AreEqual(expectedPrice, actualResult.Price, "Price should match.");
        }

        [TestMethod]
        public void GetProductPrice_NullProduct_ShouldThrowException()
        {
            //Arrange
            var productId = 1;
            Product product = null;

            SetupProductRepository(productId, product);

            //Act
            Action expectedAction = () => { throw new ArgumentException("Cannot find product with id: 1."); };
            var expectedException = Assert.ThrowsException<ArgumentException>(expectedAction);

            Action actualAction = () => _productService!.GetProductPrice(productId, 10, DateTime.UtcNow); ;
            var actualException = Assert.ThrowsException<ArgumentException>(actualAction);

            //Assert
            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

        [TestMethod]
        public void GetProductPrice_NullBasePrice_ShouldThrowException()
        {
            //Arrange
            var productId = 1;
            Product product = DefaultProduct();
            BasePrice basePrice = null;

            SetupProductRepository(productId, product);
            SetupPriceRepository(productId, basePrice);

            //Act
            Action expectedAction = () => { throw new ArgumentException("Cannot find price for product with id: 1."); };
            var expectedException = Assert.ThrowsException<ArgumentException>(expectedAction);

            Action actualAction = () => _productService!.GetProductPrice(productId, 10, DateTime.UtcNow);
            var actualException = Assert.ThrowsException<ArgumentException>(actualAction);

            //Assert
            Assert.AreEqual(expectedException.Message, actualException.Message);
        }

        private Product DefaultProduct() =>
            new Product()
             {
                 Id = 1,
                 Name = "Banana",
             };

        private BasePrice DefaultBasePrice(bool IsFinal) =>
            new BasePrice()
            {
                IsFinal = IsFinal,
                Ammount = 10
            };


        private void SetupProductRepository(long productId, Product product) =>
            _productRepository!.Setup(x => x.GetById(productId)).Returns(product);

        private void SetupPriceRepository(long productId, BasePrice basePrice) =>
            _priceRepository!.Setup(x => x.GetBasePrice(productId)).Returns(basePrice);

        private void SetupAllRepositories(long productId, long userId, Product product, BasePrice basePrice, decimal discountAmount)
        {
            _productRepository!.Setup(x => x.GetById(productId)).Returns(product);
            _priceRepository!.Setup(x => x.GetBasePrice(productId)).Returns(basePrice);
            _discountRepository!.Setup(x => x.GetDiscountAmount(productId, userId)).Returns(discountAmount);
        }

    }
}
