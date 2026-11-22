// Generated Code Do Not Modify

using System;
using System.Linq;
using Graphics = javax.microedition.lcdui.Graphics;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;

namespace org.allbinary.graphics.form.item;

public class CustomCustomItem : ABCustomItem, UpdateMyFontInterface
{
    public readonly MyFontProcessor updateMyFontProcessor;
    public MyFontProcessor myFontProcessor;
    public CustomCustomItem(string label, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(label, backgroundBasicColor, foregroundBasicColor)
    {
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        // Constructor invocation emitted in the initializer.
    }

    public virtual void updateMeasurement(Graphics graphics)
    {
    }

}

