using Emmellsoft.IoT.Rpi.SenseHat;

namespace SenseDash.Shared.ViewModel
{
    public class HumidityViewModel : SensorViewModel
    {
        public HumidityViewModel(ISenseHat senseHat) : base(senseHat)
        {
            this.Title = "Humidity";
            this.Unit = "%";
            this.Minimum = 0;
            this.Maximum = 100;
        }
        public void Update()
        {
            _senseHat.Sensors.HumiditySensor.Update();

            if (_senseHat.Sensors.Humidity != null)
            {   
                Value = _senseHat.Sensors.Humidity.Value;
            }
        }
    }
}
