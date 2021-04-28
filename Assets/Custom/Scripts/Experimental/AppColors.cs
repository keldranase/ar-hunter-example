using UnityEngine;

/// <summary>
/// A class to store colors, that are used in app
/// </summary>
public static class AppColors
{
    /// This class feels redundant, and it would be enough to have some kind of
    /// Utility class with enum for color names and symbol table for colors

    public static Color white = GetColorFromString("000000", 1f);
    public static Color tenGray = GetColorFromString("323031", 0.1f);
    public static Color thirtyGray = GetColorFromString("323031", 0.3f);
    public static Color sixtyGray = GetColorFromString("323031", 0.6f);
    public static Color fullGray = GetColorFromString("323031", 1f);
    public static Color almostBlack = GetColorFromString("323031", 1f);
    public static Color red = GetColorFromString("F42958", 1f);

    private static int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }

    private static float HexToNorm(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    private static Color GetColorFromString(string hexString, float alphaIn)
    {
        float red = HexToNorm(hexString.Substring(0, 2));
        float green = HexToNorm(hexString.Substring(2, 2));
        float blue = HexToNorm(hexString.Substring(4, 2));
        return new Color(red, green, blue, alphaIn);
    }
}