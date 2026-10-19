// Generated Code Do Not Modify

using System;
using System.Linq;
//using Font = javax.microedition.lcdui.Font;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.graphics.font;

//OpenGLNoneOther2JavaLibrary
public class FontDebugBase
{
    private static readonly FontDebugBase instanceBase = new FontDebugBase();
    public static FontDebugBase getInstance()
    {
        return FontDebugBase.instanceBase;
    }

    public readonly string SET_FONT = "setFont";
    public virtual void debugMetrics(Font currentFont, float convertedTextSize, object displayMetrics, StringMaker stringBuffer)
    {
    }

    public virtual void debugDpi(int densityDpi, StringMaker stringBuffer)
    {
    }

    public virtual void debugDimension(Font currentFont, float convertedTextSize, int longestDimensionTotalPixels, StringMaker stringBuffer)
    {
    }

}

