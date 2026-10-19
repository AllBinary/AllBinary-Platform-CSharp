// Generated Code Do Not Modify

using System;
using System.Linq;
//using Canvas = javax.microedition.lcdui.Canvas;
//using Font = javax.microedition.lcdui.Font;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Visitor = org.allbinary.logic.util.visitor.Visitor;

namespace org.allbinary.graphics.form.item;

public class ABTextFieldItem : ABTextItem
{
    private Font font;
    public ABTextFieldItem(Canvas canvas, Visitor visitor, string label, string value, int maxSize, int layout, string altText, Font font, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(label, layout, altText, backgroundBasicColor, foregroundBasicColor)
    {
        // base(label, layout, altText, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.font = font;
    }

    public override string getLabel()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public override void setLabel(string label)
    {
    }

    public virtual string getString()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual void setString(string @string)
    {
    }

    public virtual void setFocus(bool state)
    {
    }

    public virtual int getFontHeight()
    {
        return this.font.getHeight();
    }

    public virtual void setBackgroundBasicColorP(BasicColor basicColor)
    {
    }

    public virtual void setForegroundBasicColorP(BasicColor basicColor)
    {
    }

}

