// Generated Code Do Not Modify

using System;
using System.Linq;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;

namespace org.allbinary.graphics.form.item;

public class ABStringComponent
{
    public static readonly ABStringComponent NULL_STRING_COMPONENT = new ABStringComponent(BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE);
    public virtual BasicColor getBackgroundBasicColor()
    {
        return BasicColorFactory.getInstance().WHITE;
    }

    public ABStringComponent(BasicColor backgroundBasicColor, BasicColor foregroundBasicColor)
    {
    }

    public virtual BasicColor getForegroundBasicColor()
    {
        return BasicColorFactory.getInstance().WHITE;
    }

    public virtual void setForegroundBasicColor(BasicColor foregroundBasicColor)
    {
    }

}

