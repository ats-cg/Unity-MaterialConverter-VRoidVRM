using System;

public class NotSupportedConversionException : Exception
{
    public NotSupportedConversionException(string converterId, string shaderName) : base($"Conversion for material with shader '{shaderName}' is not supported by {converterId} Conveter.") { }
}