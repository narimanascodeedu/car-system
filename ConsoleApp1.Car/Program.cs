using ConsoleApp1.Car.Infrastructure;
using ConsoleApp1.Car.Manager;
using System;
using System.Linq;
using System.Text;
using static ConsoleApp1.Car.Cars;

namespace ConsoleApp1.Car
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Car System v.1";

            var brandMgr = new BrandManager();
            var modelMgr = new ModelManager();
            var carsMgr = new CarsManager();

        readMenu:
            PrintMenu();

            Menu menu = ScanManager.ReadMenu("menudan secin: ");

            switch (menu)
            {
                case Menu.BrandAdd:
                    Console.Clear();
                    Brand b = new Brand();
                    b.Name = ScanManager.Readstring("Markanin adin daxil edin: ");
                    brandMgr.Add(b);
                    goto case Menu.BrandsAll;
                case Menu.BrandEdit:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    int idForBrandEdit = ScanManager.ReadInteger("deismek istediyiniz markanin id-ni yazin: ");
                    Brand b2 = brandMgr.GetAll().FirstOrDefault(b => b.Id == idForBrandEdit);
                    b2.Name = ScanManager.Readstring("markani daxil edin: ");
                    brandMgr.Edit(b2);
                    goto case Menu.BrandsAll;
                case Menu.BrandRemove:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    int idForBrand = ScanManager.ReadInteger("silmek istediyiniz markanin id-ni yazin: ");
                    Brand b1 = brandMgr.GetAll().FirstOrDefault(b => b.Id == idForBrand);
                    brandMgr.Remove(b1);
                    goto case Menu.BrandsAll;
                case Menu.BrandSingle:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    int idForBrandSingle = ScanManager.ReadInteger("Baxmaq istediyiniz markanin id-sini yazin: ");
                    Brand bSingle = brandMgr.GetAll().FirstOrDefault(b => b.Id == idForBrandSingle);
                    foreach (var item in brandMgr.GetAll())
                    {
                        if (item.Id == bSingle.Id)
                            Console.WriteLine(item);
                    }
                    foreach (var item in modelMgr.GetAll())
                    {
                        if (item.BrandId == bSingle.Id)
                            Console.WriteLine(item);
                    }
                    goto readMenu;
                case Menu.BrandsAll:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    goto readMenu;
                case Menu.ModelAdd:
                    Model m = new Model();
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    m.Name = ScanManager.Readstring("modelin adin yazin :  ");
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    ShowAllBrands(brandMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    m.BrandId = ScanManager.ReadInteger("Avtomobilin markasi (siyahidan ID nomresi ile secin): ");
                    modelMgr.Add(m);
                    goto case Menu.ModelsAll;
                case Menu.ModelEdit:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    int idForModelEdit = ScanManager.ReadInteger("deismek istediyiniz modelin id-ni yazin: ");
                    Model b3 = modelMgr.GetAll().FirstOrDefault(b => b.Id == idForModelEdit);
                    b3.Name = ScanManager.Readstring("modeli daxil edin: ");
                    modelMgr.Edit(b3);
                    goto case Menu.ModelsAll;
                case Menu.ModelRemove:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    int idForModel = ScanManager.ReadInteger("silmek istediyiniz modelin id-ni yazin: ");
                    Model m1 = modelMgr.GetAll().FirstOrDefault(m => m.Id == idForModel);
                    modelMgr.Remove(m1);
                    goto case Menu.ModelsAll;
                case Menu.ModelSingle:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    int idForModelSingle = ScanManager.ReadInteger("Baxmaq istediyiniz modelin id-sini yazin: ");
                    Model mSingle = modelMgr.GetAll().FirstOrDefault(m => m.Id == idForModelSingle);
                    foreach (var item in modelMgr.GetAll())
                    {
                        if (item.Id == mSingle.Id)
                            Console.WriteLine(item);
                    }
                    foreach (var item in carsMgr.GetAll())
                    {
                        if (item.ModelId == mSingle.Id)
                            Console.WriteLine(item);
                    }
                    goto readMenu;
                case Menu.ModelsAll:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    goto readMenu;
                case Menu.CarsAdd:
                    Cars c = new Cars();
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    ShowAllModels(modelMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    c.Year = ScanManager.ReadInteger("Avtomobilin ili: ");
                    c.Price = ScanManager.ReadDouble("Avtomobilin qiymeti: ");
                    c.Color = ScanManager.Readstring("Avtomobilin rengi: ");
                    c.Engine = ScanManager.ReadDouble("Avtomobilin muherriki: ");
                    ShowFuelType();
                    FuelType fuel = ScanManager.ReadFuel("yanacaq novunu menudan secin: ");
                    c.TypeFuel = fuel;
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    ShowAllModels(modelMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    c.ModelId = ScanManager.ReadInteger("Avtomobilin modeli: (siyahidan ID nomresi ile secin) ");
                    carsMgr.Add(c);
                    goto case Menu.CarsAll;
                case Menu.CarsEdit:
                    Console.Clear();
                    ShowAllCars(carsMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    int idForCarsEdit = ScanManager.ReadInteger("deismek istediyiniz modelin id-ni yazin: ");
                    Cars b4 = carsMgr.GetAll().FirstOrDefault(b => b.Id == idForCarsEdit);
                    b4.Year = ScanManager.ReadInteger("avtomobilin ilin daxil edin: ");
                    b4.Price = ScanManager.ReadDouble("Avtomobilin qiymeti: ");
                    b4.Color = ScanManager.Readstring("Avtomobilin rengi: ");
                    b4.Engine = ScanManager.ReadDouble("Avtomobilin muherriki: ");
                    ShowFuelType();
                    FuelType fuel1 = ScanManager.ReadFuel("yanacaq novunu menudan secin: ");
                    b4.TypeFuel = fuel1;
                    carsMgr.Edit(b4);
                    goto case Menu.CarsAll;
                case Menu.CarsRemove:
                    Console.Clear();
                    ShowAllCars(carsMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    int idForCars = ScanManager.ReadInteger("silmek istediyiniz avtomobilin id-ni yazin: ");
                    Cars c1 = carsMgr.GetAll().FirstOrDefault(c => c.Id == idForCars);
                    carsMgr.Remove(c1);
                    goto case Menu.CarsAll;
                case Menu.CarsSingle:
                    Console.Clear();
                    ShowAllCars(carsMgr);
                    Console.WriteLine(new String('-', Console.WindowWidth));
                    int idForCarsSingle = ScanManager.ReadInteger("Baxmaq istediyiniz avtomobilin id-sini yazin: ");
                    Cars cSingle = carsMgr.GetAll().FirstOrDefault(c => c.Id == idForCarsSingle);
                    foreach (var item in carsMgr.GetAll())
                    {
                        if (item.Id == cSingle.Id)
                            Console.WriteLine(item);
                    }
                    goto readMenu;
                case Menu.CarsAll:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    ShowAllModels(modelMgr);
                    ShowAllCars(carsMgr);
                    goto readMenu;
                case Menu.Exit:
                    goto lEnd;
                default:
                    break;
            }
        lEnd:
            Console.WriteLine("END.....");
            Console.WriteLine("cixmaq ucun her hansi bir duymeni sixin");
            Console.ReadKey();
        }
        static void PrintMenu()
        {
            Console.WriteLine(new String('-',Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(Menu)))
            {

                Menu m = (Menu)Enum.Parse(typeof(Menu), item);
                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}.{item}");
            }
            Console.WriteLine($"{new string('-',Console.WindowWidth)} \n");
        }
        static void ShowAllBrands(BrandManager brandMgr)
        {
            //Console.Clear();
            Console.WriteLine("********* Brands *********");
            foreach (var item in brandMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
        static void ShowAllModels(ModelManager modelMgr)
        {
            Console.WriteLine("********* Models *********");
            foreach (var item in modelMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
        static void ShowAllCars(CarsManager carsMgr)
        {
            Console.WriteLine("********* Cars *********");
            foreach (var item in carsMgr.GetAll())
            {
                Console.WriteLine(item);
                Console.WriteLine(new String('-', Console.WindowWidth));
            }
        }
        static void ShowFuelType()
        {
            foreach (var item in Enum.GetNames(typeof(FuelType)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                FuelType f = (FuelType)Enum.Parse(typeof(FuelType), item);
                Console.WriteLine($"{((byte)f).ToString().PadLeft(2)}.{item}");
                Console.ResetColor();
            }
        }
    }
}
