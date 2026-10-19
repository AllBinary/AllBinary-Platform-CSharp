// Generated Code Do Not Modify

using System;
using System.Linq;
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.graphics.form.item;

public class ABTextItem : CustomCustomItem, ABCustomItemInterface
{
    public ABTextItem(string label, int layout, string altText, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(label, backgroundBasicColor, foregroundBasicColor)
    {
        // base(label, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
    }

    public virtual void keyPressed(int keyCode)
    {
    }

    public override void paintUnselected(Graphics graphics, int x, int y)
    {
    }

    public virtual ABStringComponent getLabelStringComponent()
    {
        return ABStringComponent.NULL_STRING_COMPONENT;
    }

}

