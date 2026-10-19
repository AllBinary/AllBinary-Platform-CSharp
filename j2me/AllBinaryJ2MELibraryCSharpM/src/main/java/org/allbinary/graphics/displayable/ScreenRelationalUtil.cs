// Generated Code Do Not Modify

using System;
using System.Linq;
//using Image = javax.microedition.lcdui.Image;

namespace org.allbinary.graphics.displayable;

public class ScreenRelationalUtil
{
    private static readonly ScreenRelationalUtil instance = new ScreenRelationalUtil();
    public static ScreenRelationalUtil getInstance()
    {
        return ScreenRelationalUtil.instance;
    }

    public virtual float getScaleImage(Image image)
    {
        return this.getScaleWH(image.getWidth(), image.getHeight());
    }

    public virtual float getScaleWH(int aWidth, int aHeight)
    {
        return this.getScaleWHA(aWidth, aHeight, 20);
    }

    public virtual float getScaleWHA(int aWidth, int aHeight, int add)
    {
        DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
        int[] last = displayInfoSingleton.getLast();
        float width = ((float) last[displayInfoSingleton.WIDTH]);
        float height = ((float) last[displayInfoSingleton.HEIGHT]);
        float largestSize = width;
        if (largestSize < height) {
            largestSize = height;
        }
        float scale = (largestSize) / ((float) aWidth);
        return scale;
    }

    public virtual int getScaledHeight(int aWidth, int aHeight)
    {
        return ((int) (this.getScaleWH(aWidth, aHeight) * ((float) aHeight)));
    }

    public virtual int getScaledHeightAdd(int aWidth, int aHeight, int add)
    {
        return ((int) (this.getScaleWHA(aWidth, aHeight, add) * ((float) aHeight)));
    }

}

