using MentorMate.DeviceManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorMate.DeviceManager.Data.Misc
{
    public static class Devices
    {
        public static ICollection<Device> All =>
            new List<Device>
            {
                new Device
                {
                    Name = "Samsung Galaxy S22 Ultra",
                    Model = "Galaxy S22 Ultra",
                    Manufacturer = "Samsung",
                    ReleaseDate = new DateTime(2022, 1, 13),
                    DateTaken = new DateTime(2022, 2, 1)
                },
                new Device
                {
                    Name = "Samsung Galaxy Z Flip3",
                    Model = "Galaxy Z Flip3",
                    Manufacturer = "Samsung",
                    ReleaseDate = new DateTime(2021, 7, 5),
                },
                new Device
                {
                    Name = "Samsung Galaxy A7",
                    Model = "Galaxy A7",
                    Manufacturer = "Samsung",
                    ReleaseDate = new DateTime(2017, 3, 26),
                    DateTaken = new DateTime(2020, 10, 9)
                },
                new Device
                {
                    Name = "Nokia 9 PureView",
                    Model = "9 PureView",
                    Manufacturer = "Nokia",
                    ReleaseDate = new DateTime(2019, 4, 22),
                    DateTaken = new DateTime(2020, 11, 24)
                },
                new Device
                {
                    Name = "Nokia 8.3 5G",
                    Model = "8.3 5G",
                    Manufacturer = "Nokia",
                    ReleaseDate = new DateTime(2017, 11, 11),
                },
                new Device
                {
                    Name = "Acer Liquid Z6 Plus",
                    Model = "Liquid Z6 Plus",
                    Manufacturer = "Acer",
                    ReleaseDate = new DateTime(2020, 2, 9),
                    DateTaken = new DateTime(2021, 9, 19)
                },
                new Device
                {
                    Name = "Acer Liquid Z6",
                    Model = "Liquid Z6",
                    Manufacturer = "Acer",
                    ReleaseDate = new DateTime(2019, 12, 3),
                },
                new Device
                {
                    Name = "Acer Liquid Jade",
                    Model = "Liquid Jade",
                    Manufacturer = "Acer",
                    ReleaseDate = new DateTime(2015, 2, 14),
                    DateTaken = new DateTime(2016, 5, 15)
                },
                new Device
                {
                    Name = "Huawei Ascend G300",
                    Model = "Ascend G300",
                    Manufacturer = "Huawei",
                    ReleaseDate = new DateTime(2012, 2, 9),
                    DateTaken = new DateTime(2014, 6, 29)
                },
                new Device
                {
                    Name = "Huawei Ascend D Quad XL",
                    Model = "Ascend D Quad XL",
                    Manufacturer = "Huawei",
                    ReleaseDate = new DateTime(2017, 8, 2),
                },
                new Device
                {
                    Name = "Huawei Mate X",
                    Model = "Mate X",
                    Manufacturer = "Huawei",
                    ReleaseDate = new DateTime(2019, 4, 29),
                },
                new Device
                {
                    Name = "Huawei Mate 30",
                    Model = "Mate 30",
                    Manufacturer = "Huawei",
                    ReleaseDate = new DateTime(2019, 3, 3),
                    DateTaken = new DateTime(2021, 6, 29)
                },
                new Device
                {
                    Name = "Huawei Mate 30 Pro",
                    Model = "Mate 30 Pro",
                    Manufacturer = "Huawei",
                    ReleaseDate = new DateTime(2020, 8, 2),
                    DateTaken = new DateTime(2022, 2, 2)
                },
                new Device
                {
                    Name = "Motorola Edge 30 Pro",
                    Model = "Edge 30 Pro",
                    Manufacturer = "Motorola",
                    ReleaseDate = new DateTime(2019, 12, 12),
                    DateTaken = new DateTime(2019, 12, 16)
                },
                new Device
                {
                    Name = "Motorola G Stylus",
                    Model = "G Stylus",
                    Manufacturer = "Motorola",
                    ReleaseDate = new DateTime(2022, 1, 12),
                },
                new Device
                {
                    Name = "Motorola Tab G70",
                    Model = "Tab G70",
                    Manufacturer = "Motorola",
                    ReleaseDate = new DateTime(2019, 11, 30),
                },
                new Device
                {
                    Name = "Motorola Edge X 30",
                    Model = "Edge X 30",
                    Manufacturer = "Motorola",
                    ReleaseDate = new DateTime(2020, 12, 12),
                },
            };

    }
}
