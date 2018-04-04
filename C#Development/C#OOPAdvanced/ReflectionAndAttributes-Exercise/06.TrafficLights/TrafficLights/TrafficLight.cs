namespace TrafficLights
{
    public class TrafficLight
    {
        public TrafficLight(Light lightState) => this.LightState = lightState;

        public Light LightState { get; set; }

        public void SwitchState() => this.LightState = (Light)((int)++this.LightState % 3);

        public override string ToString() => this.LightState.ToString();
    }
}