// Generated Code Do Not Modify

using System;
using System.Linq;
//using Graphics = javax.microedition.lcdui.Graphics;
//using Screen = javax.microedition.lcdui.Screen;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.graphics.form.item;

public class ABCustomItem
{
    public static object NULL_CUSTOM_ITEM = NullUtil.getInstance().NULL_OBJECT;
    public static ABCustomItem getNullInstance()
    {
        if (ABCustomItem.NULL_CUSTOM_ITEM == NullUtil.getInstance().NULL_OBJECT) {
            ABCustomItem.NULL_CUSTOM_ITEM = new ABCustomItem(StringUtil.getInstance().EMPTY_STRING, BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE);
        }
        return ((ABCustomItem) ABCustomItem.NULL_CUSTOM_ITEM);
    }

    public ABCustomItem(string label, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor)
    {
    }

    public virtual void setOwner(Screen owner)
    {
    }

    public virtual void paintXY(Graphics graphics, int x, int y)
    {
    }

    public virtual void paintUnselected(Graphics graphics, int x, int y)
    {
    }

    public virtual bool isFocusable()
    {
        return false;
    }

    public virtual string getLabel()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual void setLabel(string label)
    {
    }

    public virtual int getHeight()
    {
        return 0;
    }

    public virtual void setHeight(int height)
    {
    }

    public virtual float getValue()
    {
        return 0.0f;
    }

    public virtual void setValue(float value)
    {
    }

    public virtual int getMinimumWidth()
    {
        return 0;
    }

    public virtual int getMinimumHeight()
    {
        return 0;
    }

    public virtual void preMeasurement(Graphics graphics)
    {
    }

}

