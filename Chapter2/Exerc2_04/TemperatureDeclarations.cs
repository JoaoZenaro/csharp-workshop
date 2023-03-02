public enum TemperatureUnit
{
    C,
    F,
    K
}

public record Temperature(double Degrees, TemperatureUnit Unit);

public interface ITemperatureConverter
{
    public TemperatureUnit Unit { get; }
    public Temperature ToC(Temperature temperature);
    public Temperature FromC(Temperature temperature);
}