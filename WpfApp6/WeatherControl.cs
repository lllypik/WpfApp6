using System.Windows;

namespace WpfApp6
{
    enum Precipitation
    {
        Sunny,
        Cloudy,
        Rain,
        Snow
    }
    class WeatherControl : DependencyObject
    {
        private string directionOfWind;
        private int speedOfWind;
        public static readonly DependencyProperty TemperatureOutdoorAirProperty;
        public Precipitation precipitation;

        public WeatherControl(string directionOfWind, int speedOfWind, Precipitation precipitation, int TemperatureOutdoorAir)
        {
            this.directionOfWind = directionOfWind;
            this.speedOfWind = speedOfWind;
            this.precipitation = precipitation;
            this.TemperatureOutdoorAir = TemperatureOutdoorAir;
        }

        public int TemperatureOutdoorAir
        {
            get => (int)GetValue(TemperatureOutdoorAirProperty);
            set => SetValue(TemperatureOutdoorAirProperty, value);
        }

        static WeatherControl()
        {
            TemperatureOutdoorAirProperty = DependencyProperty.Register
                (
                nameof(TemperatureOutdoorAir),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata
                    (
                    0,
                    FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemperatureOutdoorAir)),
                new ValidateValueCallback (ValidateTemperatureOutdoorAir)                  
                );
        }

        private static bool ValidateTemperatureOutdoorAir(object value)
        {
            int temperatureOutdoorAir = (int)value;
            if (temperatureOutdoorAir >= -50 && temperatureOutdoorAir <= 50) return true;
            else return false;
        }

        private static object CoerceTemperatureOutdoorAir(DependencyObject d, object baseValue)
        {
            int temperatureOutdoorAir = (int)baseValue;
            if (temperatureOutdoorAir >= -50 && temperatureOutdoorAir <= 50) return temperatureOutdoorAir;
            else return 0;
        }
    }
}
