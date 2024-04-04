using System.Globalization;
using System.Text.RegularExpressions;

namespace Car_Value_Calculator.classes;

public enum FuelType
{
    Gasoline = 100,
    Diesel = 150,
    Electric = 130,
    Gas = 90
}

public class Car
{
    public string Plate { get; private set; }
    public int Mileage { get; private set; }
    private FuelType FuelType { get; }

    public Car(string plate, FuelType fuelType)
    {
        if (IsValidPlateNumber(plate))
        {
            Plate = plate;
        }
        else
        {
            throw new ArgumentException("Invalid plate number format.");
        }

        FuelType = fuelType;
        Mileage = 1;
    }

    public void Drive(int kilometers)
    {
        if (kilometers > 0)
        {
            Mileage = Mileage + kilometers;
        }
    }

    public override string ToString()
    {
        return $"{Plate} {FuelType} {Mileage} km op de teller heeft een dagwaarde van {CalculateValue()} euro";
    }

    private string CalculateValue()
    {
        int baseValue = 500000;
        int fuelFactor = (int)FuelType; // Using the enum's integer value directly

        if (fuelFactor == 0) // Check if the value is unknown
        {
            return "Unknown Fuel type";
        }

        int calculatedValue = (baseValue / Mileage) * fuelFactor;
        return calculatedValue.ToString();
    }

    private static bool IsValidPlateNumber(string plate)
    {
        if (string.IsNullOrWhiteSpace(plate))
        {
            return false;
        }

        return true;
    }

}
