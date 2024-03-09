namespace MatConv
{
    public class MaterialConvertersSettings
    {
        public static MaterialConverter[] Converters = {
            new URPLitConverter(),
            new URPUnlitConverter(),
            new URPMToon10Converter(),
            new LiltoonMultiConveter(),
        };
    }
}