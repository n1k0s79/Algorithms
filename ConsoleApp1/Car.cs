using System.Net.Http.Headers;

namespace ConsoleApp1
{
    public class Car
    {
        public Engine Engine;
        private Func<double, double, string> drive;

        public Car(Func<double, double, string> drive)
        {
            this.drive = drive;
            Engine = new Engine();
            Engine.StateChanged += Engine_StateChanged;
        }

        private void Engine_StateChanged(object? sender, string e)
        {
        }

        public void NotifyOnChange(string notification)
        {
        }

        public double GetMaximumSpeed(RoadType roadType)
        {
            var speedGetters = new Dictionary<RoadType, Func<double>>()
            {
                [ RoadType.OneWay ] = GetMaximumSpeedForOneWayRoad,
                [ RoadType.TwoWay ] = () => 100,
                [ RoadType.HighWay ] = () => 130 ,
                [ RoadType.Pedestrian] = () => 10,
            };
            return speedGetters[roadType]();
        }

        private double GetMaximumSpeedForOneWayRoad()
        {
            return 60;
        }

        public enum RoadType
        {
            OneWay,
            TwoWay,
            Pedestrian,
            HighWay,
            Square
        }
    }
}
