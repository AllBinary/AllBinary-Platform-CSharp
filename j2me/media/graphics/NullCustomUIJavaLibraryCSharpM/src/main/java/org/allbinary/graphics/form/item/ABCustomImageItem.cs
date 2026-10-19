// Generated Code Do Not Modify

using System;
using System.Linq;
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.graphics.form.item;

public class ABCustomImageItem : ABCustomItem
{
    public int yOffset = 0;
    public ABCustomImageItem(string label, Image image, int layout, string altText, BasicColor basicColor, int yOffset) : base(label, basicColor, basicColor)
    {
        // base(label, basicColor, basicColor) is called from the constructor declaration
    }

    public virtual Image getImage()
    {
        return NullImage.NULL_IMAGE;
    }

}

