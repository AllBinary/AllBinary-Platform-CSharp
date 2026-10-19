// Generated Code Do Not Modify

using System;
using System.Linq;
using GPoint = org.allbinary.graphics.GPoint;
using Rectangle = org.allbinary.graphics.Rectangle;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using NullUtil = org.allbinary.logic.NullUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.graphics.form;

public class PaintableForm : ABCustomForm
{
    private static object NULL_PAINTABLE_FORM = NullUtil.getInstance().NULL_OBJECT;
    public static PaintableForm getNullPaintableForm()
    {
        if (PaintableForm.NULL_PAINTABLE_FORM == NullUtil.getInstance().NULL_OBJECT) {
            PaintableForm.NULL_PAINTABLE_FORM = new PaintableForm(StringUtil.getInstance().EMPTY_STRING, new ABCustomItem[0], BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE);
        }
        return ((PaintableForm) PaintableForm.NULL_PAINTABLE_FORM);
    }

    public readonly CanvasStrings canvasStrings = CanvasStrings.getInstance();
    public Rectangle rectangle = RectangleFactory.SINGLETON;
    public int x = 0;
    public int y = 0;
    public FormType formType = FormTypeFactory.getInstance().NULL_FORM_TYPE;
    public PaintableForm(string title, ABCustomItem[] items, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(title, items, backgroundBasicColor, foregroundBasicColor)
    {
        // base(title, items, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.setSelectedIndex(0);
    }

    // throws Exception
    public virtual void init(Rectangle rectangle, FormType formType)
    {
        this.rectangle = rectangle;
        GPoint point = this.rectangle.getPoint();
        this.x = point.getX();
        this.y = point.getY();
        this.formType = formType;
    }

    public override int getWidth()
    {
        return this.rectangle.getWidth();
    }

}

