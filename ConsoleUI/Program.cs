// See https://aka.ms/new-console-template for more information


using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
BrandManager brandManager = new BrandManager(new EfBrandDal());
ColorManager colorManager = new ColorManager(new EfColorDal());
UserManager userManager  = new UserManager(new EfUserDal());
CustomerManager customerManager  = new CustomerManager(new EfCustomerDal());
RentalManager rentalManager = new RentalManager(new EfRentalDal());


Console.WriteLine(carManager.GetById(1).Data.ColorId);

//Car Class Methods
//CarTest();
//CarTestWithDTO();
//AddCarTest(carManager);
//UpdateCarTest(carManager);
//Console.WriteLine(carManager.GetById(5).ModelYear);
//-----------------------------------------------------------------------------------------------
// Brand Class Methods
//AddBrand(brandManager);
//ListBrands(brandManager);
//-------------------------------------------------------------------------------------------------
//Color Class Methods
//ListColors(colorManager);
//AddColor(colorManager);

//UpdateBrandTest(brandManager);

DateTime test = new DateTime(2022, 12, 05);
DateTime test2 = new DateTime(2022, 12, 06);
Rental newRent = new Rental() {CarId=2,CustomerId=1,RentDate= test,IsReturn=true,ReturnDate=test2 };


rentalManager.AddRent(newRent);


static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    int i = carManager.GetAll().Data.Count;


    foreach (var car in carManager.GetAll().Data)
    {
        i--;
        if (i != 0)
        {
            Console.WriteLine(car.Description);
            continue;
        }
        Console.Write(car.Description);

    }
}

static void AddCarTest(CarManager carManager)
{
    Car NewCar = new Car() { BrandId = 3, ColorId = 2, ModelYear = "2022", DailyPrice = 895056, Description = "Sıfır Ayarında 2000KM de" };

    carManager.AddCar(NewCar);
}

static void CarTestWithDTO()
{
    CarManager carManager = new CarManager(new EfCarDal());
    var result = carManager.GetCarDetails();
    if (result.Success)
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine(car.BrandName + " " + car.ModelYear + " " + car.DailyPrice + "TL");
        }
        Console.WriteLine(Messages.CarsListed);
    }
    else
    {
        Console.WriteLine(Messages.Maintenences);
    }
 
}

static void UpdateBrandTest(BrandManager brandManager)
{
    Console.WriteLine("Güncellencek Markanın ID numarasını gir:");
    var ıd = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Değişiklik yapın");
    var changes = Console.ReadLine();
    Brand tempBrand = new Brand() { BrandId = ıd, BrandName = changes };
    brandManager.UpdateBrand(tempBrand);
    Console.WriteLine(Messages.BrandUpdated);
}

static void UpdateCarTest(CarManager carManager)
{
    
    List<Car> test = new List<Car>();
    Console.WriteLine("model gir");
    var model = Console.ReadLine();
    Console.WriteLine("fiyat gir");
    var price =Convert.ToInt32(Console.ReadLine());
    //Car updatedCAR = new Car() { CarId = 5, BrandId = 3, ColorId = 2, ModelYear = "2022", DailyPrice = 88888, Description = "Sıfır Ayarında 5000KM de" };
    Car updatedCAR = new Car() { CarId = 5, BrandId = 3, ColorId = 2, ModelYear = model, DailyPrice = price, Description = "Sıfır Ayarında 5000KM de" };
  
    carManager.UpdateCar(updatedCAR);
}

static void AddBrand(BrandManager brandManager)
{
    string nbrand;
    Console.WriteLine("Lütfen Eklemek İstediğiniz Markanın Adını Yazın.");
    nbrand = Console.ReadLine();
    Brand NewBrand = new Brand() { BrandName = nbrand };
    brandManager.AddBrand(NewBrand);
    Console.WriteLine(nbrand + "isimli marka başarıyla Sisteme Eklenmiştir");
}

static void ListBrands(BrandManager brandManager)
{
    foreach (var brand in brandManager.GetAll().Data)
    {
        Console.WriteLine(brand.BrandName);
    }

    Console.WriteLine("Lütfen bir ID numarası girin");
    var x = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine(x + "ID numaralı markanın adı:" + brandManager.GetById(x).Data.BrandName);
}

static void ListColors(ColorManager colorManager)
{
    foreach (var color in colorManager.GetAll().Data)
    {
        Console.WriteLine(color.ColorName);
    }
    Console.WriteLine("Bir ID girin:");
    var x = Convert.ToInt16(Console.ReadLine());
    Console.WriteLine(colorManager.GetById(x).Data.ColorName);
}

static void AddColor(ColorManager colorManager)
{
    Console.WriteLine("eklemek istediğiniz rengin adını girin");
    string cname = Console.ReadLine();
    Color newcolor = new Color { ColorName = cname };
    colorManager.AddColor(newcolor);
}