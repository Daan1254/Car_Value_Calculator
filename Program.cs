namespace Car_Value_Calculator;

using Car_Value_Calculator.classes;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>
        {
            new Car("D-307-ZP", FuelType.Gasoline),
            new Car("NX-GS-17", FuelType.Diesel),
            new Car("NX-GS-18", FuelType.Gas),
            new Car("NX-GS-19", FuelType.Electric)
        };
        Random rnd = new Random();
        while (Check(cars))
        {
            foreach (var car in cars)
            {
                if (car.Mileage >= 100000) continue;
                int kilometers = rnd.Next(1000, 20001);
                car.Drive(kilometers);
                Console.WriteLine(car.ToString());
            }
        }
    }
    
    private static bool Check(List<Car> list)
    {
        foreach (var car in list)
        {
            if (car.Mileage < 100000)
            {
                return true;
            }
        }
        Console.WriteLine("All Cars have 100000km");
        LogCars(list);
        return false;
    }
    
    private static void LogCars(List<Car> cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}