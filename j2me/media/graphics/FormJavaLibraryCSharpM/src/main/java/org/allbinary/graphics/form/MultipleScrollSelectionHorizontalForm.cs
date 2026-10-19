// Generated Code Do Not Modify

using System;
using System.Linq;
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using J2MEUtil = org.allbinary.J2MEUtil;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.graphics.form;

public class MultipleScrollSelectionHorizontalForm : ScrollSelectionForm, UpdateMyFontInterface
{
    // throws Exception
    public static ScrollSelectionForm createForm(string title, ABCustomItem[] items, Rectangle rectangle, FormType formType, int border, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor)
    {
        ScrollSelectionForm scrollSelectionForm = new MultipleScrollSelectionHorizontalForm(title, items, ItemPaintableFactory.getInstance(), border, backgroundBasicColor, foregroundBasicColor);
        scrollSelectionForm.init(rectangle, formType);
        return scrollSelectionForm;
    }

    public class MultipleScrollSelectionFormHorizontalPaintable : ItemIndexPaintable
    {
        private readonly MultipleScrollSelectionHorizontalForm multipleScrollSelectionForm;
        public MultipleScrollSelectionFormHorizontalPaintable(MultipleScrollSelectionHorizontalForm multipleScrollSelectionForm)
        {
            this.multipleScrollSelectionForm = multipleScrollSelectionForm;
        }

        // throws Exception
        public override int paint(Graphics graphics, int index, ABCustomItem item, int dx, int dy)
        {
            return this.multipleScrollSelectionForm.paintHorizontal(graphics, index, item, dx, dy);
        }

    }
    public class MultipleScrollSelectionFormVerticalPaintable : ItemIndexPaintable
    {
        private readonly MultipleScrollSelectionHorizontalForm multipleScrollSelectionForm;
        public MultipleScrollSelectionFormVerticalPaintable(MultipleScrollSelectionHorizontalForm multipleScrollSelectionForm)
        {
            this.multipleScrollSelectionForm = multipleScrollSelectionForm;
        }

        // throws Exception
        public override int paint(Graphics graphics, int index, ABCustomItem item, int dx, int dy)
        {
            return this.multipleScrollSelectionForm.paintVertical(graphics, index, item, dx, dy);
        }

    }
    private Paintable rectPaintable = NullPaintable.getInstance();
    private ItemIndexPaintable multipleScrollSelectionHorizontalFormTypeItemIndexPaintable = ItemIndexPaintable.getInstance();
    private readonly int backgroundColor = ((int) BasicColorFactory.getInstance().TRANSPARENT_GREY);
    private MyFontProcessor myFontProcessor;
    private bool logged = false;
    private int fontHeight = 0;
    public MultipleScrollSelectionHorizontalForm(string title, ABCustomItem[] items, ItemPaintableFactory formPaintableFactory, int border, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(title, items, formPaintableFactory, border, 3, backgroundBasicColor, foregroundBasicColor)
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        // base(title, items, formPaintableFactory, border, 3, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        if (J2MEUtil.isJ2ME() || J2MEUtil.isHTML()) {
        } else {
            class MPaintable : Paintable
            {
                public override void paint(Graphics graphics)
                {
                    this.fillRect(graphics);
                }

            }
            this.rectPaintable = new MPaintable();
        }
    }

    private void fillRect(Graphics graphics)
    {
        graphics.setColor(this.backgroundColor);
        graphics.fillRect(this.x, this.y, this.rectangle.getWidth(), this.rectangle.getHeight());
    }

    // throws Exception
    public override void init(Rectangle rectangle, FormType formType)
    {
        base.init(rectangle, formType);
        FormTypeFactory formTypeFactory = FormTypeFactory.getInstance();
        if (formType == formTypeFactory.HORIZONTAL_FORM) {
            this.multipleScrollSelectionHorizontalFormTypeItemIndexPaintable = new MultipleScrollSelectionFormHorizontalPaintable(this);
        } else if (formType == formTypeFactory.VERTICAL_CENTER_FORM) {
            this.multipleScrollSelectionHorizontalFormTypeItemIndexPaintable = new MultipleScrollSelectionFormVerticalPaintable(this);
        } else if (formType == formTypeFactory.NULL_FORM_TYPE) {
        } else {
            throw new Exception(formTypeFactory.UNK);
        }
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.fontHeight = font.getHeight();
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    // throws Exception
    private int paintHorizontal(Graphics graphics, int index, ABCustomItem item, int dx, int dy)
    {
        int dx2 = this.paintItem(graphics, index, item, dx, dy) + this.border;
        this.paintable.paint(graphics, index, dx, dy);
        dx = dx2;
        return dx;
    }

    // throws Exception
    private int paintVertical(Graphics graphics, int index, ABCustomItem item, int dx, int dy)
    {
        this.paintItem(graphics, index, item, dx, dy);
        this.paintable.paint(graphics, index, dx, dy);
        return dx;
    }

    public override int getStartIndex()
    {
        return this.getSelectedIndex();
    }

    public override void paint(Graphics graphics)
    {
        try {
            this.myFontProcessor.process(graphics);
            int start = this.getStartIndex();
            int size = this.size();
            int dx = this.x;
            int dy = this.y;
            this.rectPaintable.paint(graphics);
            graphics.drawString(this.getTitle(), this.x, this.y - this.fontHeight, 0);
            ABCustomItem item = null;
            for (int index = start; index < size; index++) {
                item = this.get(index);
                if (dx >= this.rectangle.getMaxX()) {
                    if (this.logged) {
                    } else {
                        this.logged = true;
                        PreLogUtil.put(new StringMaker().append("painting beyond maxx: ").appendint(((int) this.rectangle.getMaxX())).ToString(), this, this.canvasStrings.PAINT);
                    }
                }
                dx = this.multipleScrollSelectionHorizontalFormTypeItemIndexPaintable.paint(graphics, index, item, dx, dy);
            }
        } catch (Exception e) {
            PreLogUtil.put(this.commonStrings.EXCEPTION, this, this.canvasStrings.PAINT);
        }
    }

}

