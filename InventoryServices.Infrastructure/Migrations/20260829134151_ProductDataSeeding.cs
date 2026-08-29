using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var defaultDate = new DateTimeOffset(
    2026, 8, 29, 0, 0, 0, TimeSpan.Zero);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[]
                {
        "Sku",
        "Name",
        "Price",
        "Qty",
        "CreatedAt",
        "UpdatedAt"
                },
                values: new object[,]
                {
        { "CPU-001", "Intel Core i5-14400F Processor", 4299.99m, 15, defaultDate, defaultDate },
        { "CPU-002", "Intel Core i7-14700K Processor", 7899.99m, 8, defaultDate, defaultDate },
        { "CPU-003", "AMD Ryzen 5 7600 Processor", 3999.99m, 20, defaultDate, defaultDate },
        { "CPU-004", "AMD Ryzen 7 7800X3D Processor", 8499.99m, 7, defaultDate, defaultDate },

        { "GPU-001", "NVIDIA GeForce RTX 4060 8GB", 7499.99m, 10, defaultDate, defaultDate },
        { "GPU-002", "NVIDIA GeForce RTX 4070 Super 12GB", 14999.99m, 5, defaultDate, defaultDate },
        { "GPU-003", "AMD Radeon RX 7600 8GB", 6999.99m, 12, defaultDate, defaultDate },
        { "GPU-004", "AMD Radeon RX 7800 XT 16GB", 12999.99m, 6, defaultDate, defaultDate },

        { "RAM-001", "Kingston Fury Beast 16GB DDR4", 899.99m, 40, defaultDate, defaultDate },
        { "RAM-002", "Kingston Fury Beast 32GB DDR5", 2199.99m, 25, defaultDate, defaultDate },
        { "RAM-003", "Corsair Vengeance 16GB DDR5", 1399.99m, 30, defaultDate, defaultDate },
        { "RAM-004", "Corsair Vengeance RGB 32GB DDR5", 2699.99m, 18, defaultDate, defaultDate },

        { "SSD-001", "Samsung 980 500GB NVMe SSD", 1099.99m, 35, defaultDate, defaultDate },
        { "SSD-002", "Samsung 990 Pro 1TB NVMe SSD", 2299.99m, 22, defaultDate, defaultDate },
        { "SSD-003", "Kingston NV2 1TB NVMe SSD", 1199.99m, 45, defaultDate, defaultDate },
        { "SSD-004", "Crucial BX500 2TB SATA SSD", 2499.99m, 14, defaultDate, defaultDate },

        { "HDD-001", "Seagate Barracuda 1TB Hard Drive", 849.99m, 28, defaultDate, defaultDate },
        { "HDD-002", "Seagate Barracuda 2TB Hard Drive", 1199.99m, 20, defaultDate, defaultDate },
        { "HDD-003", "Western Digital Blue 4TB Hard Drive", 1999.99m, 11, defaultDate, defaultDate },

        { "MB-001", "ASUS Prime B760M-A Motherboard", 2899.99m, 13, defaultDate, defaultDate },
        { "MB-002", "MSI MAG B650 Tomahawk Motherboard", 4499.99m, 9, defaultDate, defaultDate },
        { "MB-003", "Gigabyte B550 Aorus Elite Motherboard", 2699.99m, 16, defaultDate, defaultDate },
        { "MB-004", "ASRock Z790 Pro RS Motherboard", 4999.99m, 6, defaultDate, defaultDate },

        { "PSU-001", "Cooler Master 550W Power Supply", 1099.99m, 24, defaultDate, defaultDate },
        { "PSU-002", "Corsair RM750e 750W Power Supply", 2299.99m, 17, defaultDate, defaultDate },
        { "PSU-003", "Super Flower 850W Gold Power Supply", 2799.99m, 10, defaultDate, defaultDate },

        { "CASE-001", "NZXT H5 Flow ATX Computer Case", 1899.99m, 12, defaultDate, defaultDate },
        { "CASE-002", "Corsair 4000D Airflow Computer Case", 1799.99m, 15, defaultDate, defaultDate },
        { "CASE-003", "Cooler Master MasterBox Computer Case", 1299.99m, 20, defaultDate, defaultDate },

        { "MON-001", "Dell 24-Inch Full HD Monitor", 2499.99m, 18, defaultDate, defaultDate },
        { "MON-002", "LG 27-Inch QHD IPS Monitor", 4999.99m, 10, defaultDate, defaultDate },
        { "MON-003", "Samsung Odyssey G5 32-Inch Gaming Monitor", 6499.99m, 7, defaultDate, defaultDate },
        { "MON-004", "ASUS TUF 27-Inch 165Hz Gaming Monitor", 5799.99m, 9, defaultDate, defaultDate },

        { "KB-001", "Logitech K120 USB Keyboard", 249.99m, 60, defaultDate, defaultDate },
        { "KB-002", "Logitech G413 Mechanical Keyboard", 1499.99m, 25, defaultDate, defaultDate },
        { "KB-003", "Redragon K552 Mechanical Keyboard", 899.99m, 30, defaultDate, defaultDate },

        { "MSE-001", "Logitech M185 Wireless Mouse", 299.99m, 55, defaultDate, defaultDate },
        { "MSE-002", "Logitech G502 Gaming Mouse", 1299.99m, 22, defaultDate, defaultDate },
        { "MSE-003", "Razer DeathAdder Gaming Mouse", 999.99m, 27, defaultDate, defaultDate },

        { "HS-001", "Logitech H390 USB Headset", 799.99m, 32, defaultDate, defaultDate },
        { "HS-002", "HyperX Cloud II Gaming Headset", 1899.99m, 14, defaultDate, defaultDate },
        { "HS-003", "Razer BlackShark V2 Gaming Headset", 1699.99m, 16, defaultDate, defaultDate },

        { "WEB-001", "Logitech C270 HD Webcam", 699.99m, 29, defaultDate, defaultDate },
        { "WEB-002", "Logitech C920 Full HD Webcam", 1799.99m, 13, defaultDate, defaultDate },

        { "NET-001", "TP-Link AC1200 Wi-Fi Router", 999.99m, 21, defaultDate, defaultDate },
        { "NET-002", "TP-Link AX3000 Wi-Fi 6 Router", 2299.99m, 11, defaultDate, defaultDate },
        { "NET-003", "TP-Link USB Wi-Fi Adapter", 349.99m, 38, defaultDate, defaultDate },

        { "CL-001", "Cooler Master Hyper 212 CPU Cooler", 899.99m, 23, defaultDate, defaultDate },
        { "CL-002", "DeepCool LS520 Liquid CPU Cooler", 2199.99m, 12, defaultDate, defaultDate },

        { "SPK-001", "Logitech Z120 Desktop Speakers", 399.99m, 34, defaultDate, defaultDate }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
    """
    DELETE FROM Products
    WHERE Sku IN (
        'CPU-001', 'CPU-002', 'CPU-003', 'CPU-004',
        'GPU-001', 'GPU-002', 'GPU-003', 'GPU-004',
        'RAM-001', 'RAM-002', 'RAM-003', 'RAM-004',
        'SSD-001', 'SSD-002', 'SSD-003', 'SSD-004',
        'HDD-001', 'HDD-002', 'HDD-003',
        'MB-001', 'MB-002', 'MB-003', 'MB-004',
        'PSU-001', 'PSU-002', 'PSU-003',
        'CASE-001', 'CASE-002', 'CASE-003',
        'MON-001', 'MON-002', 'MON-003', 'MON-004',
        'KB-001', 'KB-002', 'KB-003',
        'MSE-001', 'MSE-002', 'MSE-003',
        'HS-001', 'HS-002', 'HS-003',
        'WEB-001', 'WEB-002',
        'NET-001', 'NET-002', 'NET-003',
        'CL-001', 'CL-002',
        'SPK-001'
    );
    """);
        }
    }
}
