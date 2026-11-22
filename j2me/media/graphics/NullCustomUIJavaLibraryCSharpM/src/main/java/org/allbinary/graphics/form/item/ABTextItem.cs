// Generated Code Do Not Modify

using System;
using System.Linq;
using Graphics = javax.microedition.lcdui.Graphics;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.graphics.form.item;

public class ABTextItem : CustomCustomItem, ABCustomItemInterface
{
    public ABTextItem(string label, int layout, string altText, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(label, backgroundBasicColor, foregroundBasicColor)
    {
        // Constructor invocation emitted in the initializer.
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

    public override int getMinimumWidth()
    {
        return base.getMinimumWidth();
    }

    public override int getMinimumHeight()
    {
        return base.getMinimumHeight();
    }

    public override string getLabel()
    {
        return base.getLabel();
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        base.paintXY(graphics, x, y);
    }

}

