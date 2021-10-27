using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork19
{
    class Computer
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CPUType { get; set; }
        public int CPUfreq { get; set; }
        public int RAMCapacity { get; set; }
        public int HDDCapacity { get; set; }
        public int GraphCardCapacity { get; set; }
        public int CompPrice { get; set; }
        public int CompsAmmount { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputers1 = new List<Computer>()
            {
                new Computer() { Id = 1, BrandName = "Acer", CPUType = "Intel Celeron", CPUfreq = 2000, RAMCapacity = 4000, HDDCapacity = 1000, GraphCardCapacity =  2000, CompPrice = 300, CompsAmmount = 20},
                new Computer() { Id = 2, BrandName = "Asus", CPUType = "Intel Core i5", CPUfreq = 2000, RAMCapacity = 4000, HDDCapacity = 4000, GraphCardCapacity =  3000, CompPrice = 500, CompsAmmount = 50},
                new Computer() { Id = 3, BrandName = "Intel", CPUType = "Intel Celeron", CPUfreq = 2000, RAMCapacity = 8000, HDDCapacity = 3000, GraphCardCapacity =  1000, CompPrice = 1000, CompsAmmount = 10},
                new Computer() { Id = 4, BrandName = "Lenovo", CPUType = "AMD Athlon", CPUfreq = 2000, RAMCapacity = 8000, HDDCapacity = 1000, GraphCardCapacity =  2000, CompPrice = 1000, CompsAmmount = 100},
                new Computer() { Id = 5, BrandName = "HP", CPUType = "AMD Athlon", CPUfreq = 2000, RAMCapacity = 9000, HDDCapacity = 2000, GraphCardCapacity =  1000, CompPrice = 800, CompsAmmount = 50},
                new Computer() { Id = 6, BrandName = "Dell", CPUType = "Intel Pentium", CPUfreq = 2000, RAMCapacity = 6000, HDDCapacity = 4000, GraphCardCapacity =  1000, CompPrice = 900, CompsAmmount = 10},
                new Computer() { Id = 7, BrandName = "Aopen", CPUType = "Intel Core i3", CPUfreq = 2000, RAMCapacity = 4000, HDDCapacity = 1000, GraphCardCapacity =  3000, CompPrice = 500, CompsAmmount = 17},
                new Computer() { Id = 8, BrandName = "MSI", CPUType = "Intel Core i7", CPUfreq = 2000, RAMCapacity = 8000, HDDCapacity = 1000, GraphCardCapacity =  2000, CompPrice = 300, CompsAmmount = 200}
            };

            Console.WriteLine("Перечень и характеристики компьютеров:");
            foreach (Computer c in listComputers1)
            {
                Console.WriteLine($" Id: {c.Id}, BrandName: {c.BrandName,6}, CPUType: {c.CPUType,13}, CPUfreq: {c.CPUfreq}, RAMCapacity: {c.RAMCapacity}, HDDCapacity: {c.HDDCapacity}, GraphCardCapacity: {c.GraphCardCapacity}, CompPrice: {c.CompPrice}, CompsAmmount {c.CompsAmmount}");
            }

            Console.WriteLine();
            Console.WriteLine("Введите тип процессора для сортировки компьютеров:");
            string compCPUType = Console.ReadLine();
            Console.WriteLine("Перечень компьютеров после сортировки:");

            List<Computer> listComputers2 = listComputers1.
                Where(comp => comp.CPUType == compCPUType)
                .ToList();
            foreach (Computer c in listComputers2)
            {
                Console.WriteLine($" Id: {c.Id}, BrandName: {c.BrandName,6}, CPUType: {c.CPUType,13}, CPUfreq: {c.CPUfreq}, RAMCapacity: {c.RAMCapacity}, HDDCapacity: {c.HDDCapacity}, GraphCardCapacity: {c.GraphCardCapacity}, CompPrice: {c.CompPrice}, CompsAmmount {c.CompsAmmount}");
            }

            Console.WriteLine();
            Console.WriteLine("Введите объем ОЗУ для сортировки компьютеров:");
            int compRAMCapacity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Перечень компьютеров после сортировки:");
            List<Computer> listComputers3 = listComputers1.
                Where(comp2 => comp2.RAMCapacity > compRAMCapacity).
                ToList();
            foreach (Computer c in listComputers3)
            {
                Console.WriteLine($" Id: {c.Id}, BrandName: {c.BrandName,6}, CPUType: {c.CPUType,13}, CPUfreq: {c.CPUfreq}, RAMCapacity: {c.RAMCapacity}, HDDCapacity: {c.HDDCapacity}, GraphCardCapacity: {c.GraphCardCapacity}, CompPrice: {c.CompPrice}, CompsAmmount {c.CompsAmmount}");
            }

            Console.WriteLine();
            Console.WriteLine("Вывод всего списка, отсортированного по увеличению стоимости:");

            IEnumerable<Computer> listComputers4 = listComputers1.
            OrderBy(comp2 => comp2.CompPrice);
            foreach (Computer c in listComputers4)
            {
                Console.WriteLine($" Id: {c.Id}, BrandName: {c.BrandName,6}, CPUType: {c.CPUType,13}, CPUfreq: {c.CPUfreq}, RAMCapacity: {c.RAMCapacity}, HDDCapacity: {c.HDDCapacity}, GraphCardCapacity: {c.GraphCardCapacity}, CompPrice: {c.CompPrice}, CompsAmmount {c.CompsAmmount}");
            }

            Console.WriteLine();
            Console.WriteLine("Вывод списка, сгруппированного по типу процессора:");
            var listComputers5 = listComputers1.
                GroupBy(comp2 => comp2.CPUType);
            foreach (var c in listComputers5)
            {
                Console.WriteLine("Группа по типу процессора: " + c.Key);
                foreach (var item in c)
                {
                    Console.WriteLine($" Id: {item.Id}, BrandName: {item.BrandName,6}, CPUType: {item.CPUType,13}, CPUfreq: {item.CPUfreq}, RAMCapacity: {item.RAMCapacity}, HDDCapacity: {item.HDDCapacity}, GraphCardCapacity: {item.GraphCardCapacity}, CompPrice: {item.CompPrice}, CompsAmmount {item.CompsAmmount}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Вывод данных о самом дорогом компьютере:");
            int max = listComputers1.Max(comp2 => comp2.CompPrice);
            IEnumerable<Computer> listComputers6 = listComputers1.
                Where(comp2 => comp2.CompPrice == max)
                .ToList();
            foreach (Computer c in listComputers6)
            {
                Console.WriteLine($" Id: {c.Id}, BrandName: {c.BrandName,6}, CPUType: {c.CPUType,13}, CPUfreq: {c.CPUfreq}, RAMCapacity: {c.RAMCapacity}, HDDCapacity: {c.HDDCapacity}, GraphCardCapacity: {c.GraphCardCapacity}, CompPrice: {c.CompPrice}, CompsAmmount {c.CompsAmmount}");
            }

            Console.WriteLine();
            Console.WriteLine("Вывод данных о самом бюджетном компьютере:");
            int min = listComputers1.Min(comp2 => comp2.CompPrice);
            IEnumerable<Computer> listComputers7 = listComputers1.
                Where(comp2 => comp2.CompPrice == min)
                .ToList();
            foreach (Computer c in listComputers7)
            {
                Console.WriteLine($" Id: {c.Id}, BrandName: {c.BrandName,6}, CPUType: {c.CPUType,13}, CPUfreq: {c.CPUfreq}, RAMCapacity: {c.RAMCapacity}, HDDCapacity: {c.HDDCapacity}, GraphCardCapacity: {c.GraphCardCapacity}, CompPrice: {c.CompPrice}, CompsAmmount {c.CompsAmmount}");
            }

            Console.WriteLine();
            Console.WriteLine("Определение наличия компьютеров в количестве > 30 шт.:");
            var listComputers8 = listComputers1.
                Any(comp2 => comp2.CompsAmmount > 30);
            if (listComputers8 == true)
            {
                Console.WriteLine("Подтверждено наличие хотя бы одного компьютера в количестве > 30 шт.");

            }
            else
            {
                Console.WriteLine("Отсутствуют компьютеры в количестве > 30 шт.");
            }

            Console.ReadKey();
        }
    }
}
