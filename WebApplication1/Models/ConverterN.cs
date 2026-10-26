using System;
 
namespace WebApplication1.Models
{
    // Rename the class + file each PR: Converter2, Converter3, ...
    public class Converter2
    {
        public double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }
 
        public double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
 
        public double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }
       public double CelsiusToKelvin(int celsius)
        {
            return celsius + 273.15;
        }
       public double CelsiusToKelvin(short celsius)
        {
            return celsius + 273.15;
        }
       public double CelsiusToKelvin(long celsius)
        {
            return celsius + 273.15;
        }
    }
}
