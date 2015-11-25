using Emmellsoft.IoT.Rpi.SenseHat;

namespace SenseDash.Shared.ViewModel
{
    public class PressureViewModel : SensorViewModel
    {
        public PressureViewModel(ISenseHat senseHat) : base(senseHat)
        {
            this.Title = "Pressure";
            this.Unit = "mbar";
            this.Minimum = 1000;
            this.Maximum = 1050;
        }
        public void Update()
        {
            _senseHat.Sensors.PressureSensor.Update();

            if (_senseHat.Sensors.Pressure != null)
            {   
                Value = _senseHat.Sensors.Pressure.Value;
            }
        }
    }
}
