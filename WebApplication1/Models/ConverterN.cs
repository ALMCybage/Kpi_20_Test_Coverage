
namespace WebApplication1.Models
{
    // Rename the class + file each PR: Converter2, Converter3, ...
    public class Converter2
    {
        public double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

                public double CelsiusToFahrenheit(int celsius)
        {
            return (celsius * 9 / 5) + 32;
        }
    }
}
