using System;

public class InvalidTemperatureConverterException : Exception
{
    public InvalidTemperatureConverterException(TemperatureUnit unit) : base($"Duplicate converter for {unit}.")
    {
    }

    public InvalidTemperatureConverterException(string message) : base(message)
    {
    }
}

public class InvalidTemperatureConversionException : Exception
{
    public InvalidTemperatureConversionException(TemperatureUnit unitTo) : base($"No supported conversion to {unitTo}") { }
}