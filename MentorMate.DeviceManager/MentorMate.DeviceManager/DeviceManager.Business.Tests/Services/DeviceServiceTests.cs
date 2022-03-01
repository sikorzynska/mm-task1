using MentorMate.DeviceManager.Business.Services;
using MentorMate.DeviceManager.Business.Services.Interfaces;
using MentorMate.DeviceManager.Data.Entities;
using MentorMate.DeviceManager.Data.Repositories.Interfaces;
using MentorMate.DeviceManager.Domain.Models.Devices;
using MentorMate.DeviceManager.Domain.Models.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Business.Tests.Services
{
    [TestClass]
    public class DeviceServiceTests
    {
        private Mock<IDeviceRepository>? _deviceRepository;
        private IDeviceService? _deviceService;

        [TestInitialize]
        public void Initialize()
        {
            _deviceRepository = new Mock<IDeviceRepository>();

            _deviceService = new DeviceService(_deviceRepository.Object);
        }
        [TestMethod]
        public async Task GetAllDevices_ShouldReturnAllProductsOrderedByReleaseDateDescending()
        {
            //Arrange
            var sort = new SortingModel();

            var devices = Devices();

            await SetupGetAll(devices);

            var expectedResult = JsonSerializeList(ToListGDM(devices));

            //Act
            var actualResult = JsonSerializeList(_deviceService.GetAllAsync(sort).Result);

            //Assert
            CollectionAssert.AreEqual(expectedResult.ToList(), actualResult.ToList());
        }

        [TestMethod]
        public async Task GetAllDevices_ShouldOnlyReturnTakenSince()
        {
            //Arrange
            var takenSinceDate = new DateTime(2022, 1, 4);

            var sort = new SortingModel()
            {
                TakenSince = takenSinceDate
            };

            var devices = Devices();

            var expectedDevices = devices.Where(x => x.DateTaken >= takenSinceDate);

            await SetupGetAll(devices);

            var expectedResult = JsonSerializeList(ToListGDM(expectedDevices));

            //Act
            var actualResult = JsonSerializeList(_deviceService.GetAllAsync(sort).Result);

            //Assert
            CollectionAssert.AreEqual(expectedResult.ToList(), actualResult.ToList());
        }

        [TestMethod]
        public async Task GetAllDevices_ShouldOnlyReturnBetweenReleaseDatePeriod()
        {
            //Arrange
            var firstDate = new DateTime(2022, 1, 2);
            var secondDate = new DateTime(2022, 1, 4);

            var sort = new SortingModel()
            {
                ReleaseDateFrom = firstDate,
                ReleaseDateTo = secondDate
            };

            var devices = Devices();

            var expectedDevices = devices.Where(x => x.ReleaseDate >= firstDate && x.ReleaseDate <= secondDate);

            await SetupGetAll(devices);

            var expectedResult = JsonSerializeList(ToListGDM(expectedDevices));

            //Act
            var actualResult = JsonSerializeList(_deviceService.GetAllAsync(sort).Result);

            //Assert
            CollectionAssert.AreEqual(expectedResult.ToList(), actualResult.ToList());
        }

        [TestMethod]
        public async Task GetAllDevices_ShouldOnlyReturnTaken()
        {
            //Arrange
            var sort = new SortingModel()
            {
                IsTaken = true
            };

            var devices = Devices();

            var expectedDevices = devices.Where(x => x.DateTaken != null);

            await SetupGetAll(devices);

            var expectedResult = JsonSerializeList(ToListGDM(expectedDevices));

            //Act
            var actualResult = JsonSerializeList(_deviceService.GetAllAsync(sort).Result);

            //Assert
            CollectionAssert.AreEqual(expectedResult.ToList(), actualResult.ToList());
        }

        [TestMethod]
        public async Task GetAllDevices_ShouldOnlyReturnNotTaken()
        {
            //Arrange
            var sort = new SortingModel()
            {
                IsTaken = false
            };

            var devices = Devices();

            var expectedDevices = devices.Where(x => x.DateTaken == null);

            await SetupGetAll(devices);

            var expectedResult = JsonSerializeList(ToListGDM(expectedDevices));

            //Act
            var actualResult = JsonSerializeList(_deviceService.GetAllAsync(sort).Result);

            //Assert
            CollectionAssert.AreEqual(expectedResult.ToList(), actualResult.ToList());
        }

        [TestMethod]
        public async Task GetAllDevices_ShouldOnlyReturnByManufacturer()
        {
            var manufacturer = "Samsung";
            //Arrange
            var sort = new SortingModel()
            {
                Manufacturer = manufacturer
            };

            var devices = Devices();

            var expectedDevices = devices.Where(x => x.Manufacturer == manufacturer);

            await SetupGetAll(devices);

            var expectedResult = JsonSerializeList(ToListGDM(expectedDevices));

            //Act
            var actualResult = JsonSerializeList(_deviceService.GetAllAsync(sort).Result);

            //Assert
            CollectionAssert.AreEqual(expectedResult.ToList(), actualResult.ToList());
        }

        [TestMethod]
        public async Task GetAllDevices_ShouldOnlyReturnTakenByManufacturer()
        {
            var manufacturer = "Samsung";
            //Arrange
            var sort = new SortingModel()
            {
                IsTaken = true,
                Manufacturer = manufacturer
            };

            var devices = Devices();

            var expectedDevices = devices.Where(x => x.Manufacturer == manufacturer && x.DateTaken != null);

            await SetupGetAll(devices);

            var expectedResult = JsonSerializeList(ToListGDM(expectedDevices));

            //Act
            var actualResult = JsonSerializeList(_deviceService.GetAllAsync(sort).Result);

            //Assert
            CollectionAssert.AreEqual(expectedResult.ToList(), actualResult.ToList());
        }



        private async Task SetupGetAll(List<Device> devices) =>
            _deviceRepository.Setup(x => x.GetAllAsync().Result).Returns(devices);

        private List<Device> Devices() =>
            new List<Device>
            {
                new Device
                {
                    Name = "Phone 1",
                    Model = "Model 1",
                    Manufacturer = "Samsung",
                    ReleaseDate = new DateTime(2022, 1, 1),
                    DateTaken = new DateTime(2022, 1, 6)
                },
                new Device
                {
                    Name = "Phone 2",
                    Model = "Model 2",
                    Manufacturer = "Apple",
                    ReleaseDate = new DateTime(2022, 1, 2),
                    DateTaken = new DateTime(2022, 1, 5)
                },
                new Device
                {
                    Name = "Phone 3",
                    Model = "Model 3",
                    Manufacturer = "Huawei",
                    ReleaseDate = new DateTime(2022, 1, 3),
                    DateTaken = new DateTime(2022, 1, 4)
                },
                new Device
                {
                    Name = "Phone 4",
                    Model = "Model 4",
                    Manufacturer = "Samsung",
                    ReleaseDate = new DateTime(2022, 1, 4),
                },
                new Device
                {
                    Name = "Phone 5",
                    Model = "Model 5",
                    Manufacturer = "Acer",
                    ReleaseDate = new DateTime(2022, 1, 5),
                },
            };
        private List<GeneralDeviceModel> ToListGDM(IEnumerable<Device> devices) =>
            devices.OrderByDescending(x => x.ReleaseDate).Select(d => new GeneralDeviceModel
            {
                Id = d.Id,
                Name = d.Name,
                Model = d.Model,
                Manufacturer = d.Manufacturer,
                ReleaseDate = d.ReleaseDate.ToString("dddd, dd MMMM yyyy"),
                DateTaken = d.DateTaken != null
                ? d.DateTaken.Value.ToString("dddd, dd MMMM yyyy")
                : "N/A"
            }).ToList();

        private List<string> JsonSerializeList(IEnumerable<GeneralDeviceModel> devices)
        {
            var result = new List<string>();

            foreach (var device in devices)
            {
                string deviceString = JsonConvert.SerializeObject(device);
                result.Add(deviceString);
            }

            return result;
        }


    }
}
