/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
 * 
 * By agreeing to this license you and any business entity you represent are
 * legally bound to the AllBinary Open License Version 1 legal agreement.
 * 
 * You may obtain the AllBinary Open License Version 1 legal agreement from
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository.
 * 
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
//using Canvas = javax.microedition.lcdui.Canvas;
//using Graphics = javax.microedition.lcdui.Graphics;
using GPoint = org.allbinary.graphics.GPoint;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using RectangleCollisionUtil = org.allbinary.math.RectangleCollisionUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.graphics.form;

public class ScrollSelectionForm : PaintableForm
{
    private static PaintableForm createForm(string title, ABCustomItem[] items, ItemPaintableFactory formPaintableFactory, int border, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor)
    {
        try {
            if (formPaintableFactory == ItemPaintableFactory.getInstance()) {
                return new ScrollSelectionForm(title, items, formPaintableFactory, border, -3, backgroundBasicColor, foregroundBasicColor);
            } else {
                CommonStrings commonStrings = CommonStrings.getInstance();
                LogUtil logUtil = LogUtil.getInstance();
                logUtil.putF(commonStrings.EXCEPTION, logUtil, commonStrings.EXCEPTION);
                return PaintableForm.getNullPaintableForm();
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            LogUtil logUtil = LogUtil.getInstance();
            logUtil.put(commonStrings.EXCEPTION, logUtil, commonStrings.EXCEPTION, e);
            return PaintableForm.getNullPaintableForm();
        }
    }

    private static object NULL_SCROLL_SELECTION_FORM = NullUtil.getInstance().NULL_OBJECT;
    public static ScrollSelectionForm getNullScrollSelectionForm()
    {
        if (ScrollSelectionForm.NULL_SCROLL_SELECTION_FORM == NullUtil.getInstance().NULL_OBJECT) {
            ScrollSelectionForm.NULL_SCROLL_SELECTION_FORM = ScrollSelectionForm.createForm(StringUtil.getInstance().EMPTY_STRING, new ABCustomItem[0], ItemPaintableFactory.getInstance(), 0, BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE);
        }
        return ((ScrollSelectionForm) ScrollSelectionForm.NULL_SCROLL_SELECTION_FORM);
    }

    private static object NULL_SCROLL_SELECTION_HORIZONTAL_FORM = NullUtil.getInstance().NULL_OBJECT;
    public static ScrollSelectionForm getNullScrollSelectionFormHorizontal()
    {
        if (ScrollSelectionForm.NULL_SCROLL_SELECTION_HORIZONTAL_FORM == NullUtil.getInstance().NULL_OBJECT) {
            ScrollSelectionForm.NULL_SCROLL_SELECTION_HORIZONTAL_FORM = ScrollSelectionForm.createForm(StringUtil.getInstance().EMPTY_STRING, new ABCustomItem[0], ItemPaintableFactory.getInstance(), 0, BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE);
        }
        return ((ScrollSelectionForm) ScrollSelectionForm.NULL_SCROLL_SELECTION_HORIZONTAL_FORM);
    }

    private static readonly string INSIDE_FORM = " inside form";
    private static readonly string IS_IN_FORM = "isInForm";
    public class ScrollSelectionFormHorizontalPaintable : ItemIndexPaintable
    {
        private readonly ScrollSelectionForm scrollSelectionForm;
        public ScrollSelectionFormHorizontalPaintable(ScrollSelectionForm scrollSelectionForm)
        {
            this.scrollSelectionForm = scrollSelectionForm;
        }

        // throws Exception
        public override int paint(Graphics graphics, int index, ABCustomItem item, int dx, int dy)
        {
            return this.scrollSelectionForm.paintItemHorizontal(graphics, index, item, dx, dy);
        }

    }
    public class ScrollSelectionFormVerticalPaintable : ItemIndexPaintable
    {
        private readonly ScrollSelectionForm scrollSelectionForm;
        public ScrollSelectionFormVerticalPaintable(ScrollSelectionForm scrollSelectionForm)
        {
            this.scrollSelectionForm = scrollSelectionForm;
        }

        // throws Exception
        public override int paint(Graphics graphics, int index, ABCustomItem item, int dx, int dy)
        {
            return this.scrollSelectionForm.paintItemVertical(graphics, index, item, dx, dy);
        }

    }
    public class ScrollSelectionFormTempHorizontalPaintable : ItemIndexPaintable
    {
        private readonly ScrollSelectionForm scrollSelectionForm;
        public ScrollSelectionFormTempHorizontalPaintable(ScrollSelectionForm scrollSelectionForm)
        {
            this.scrollSelectionForm = scrollSelectionForm;
        }

        // throws Exception
        public override int paint(Graphics graphics, int index, ABCustomItem item, int dx, int dy)
        {
            return this.scrollSelectionForm.paintItemTempHorizontal(graphics, index, item, dx, dy);
        }

    }
    public class ScrollSelectionFormHorizontalDx : ItemIndexDx
    {
        private readonly ScrollSelectionForm scrollSelectionForm;
        public ScrollSelectionFormHorizontalDx(ScrollSelectionForm multipleScrollSelectionForm)
        {
            this.scrollSelectionForm = multipleScrollSelectionForm;
        }

        // throws Exception
        public override int getDx(int index, ABCustomItem item, int dx, int dy)
        {
            return this.scrollSelectionForm.getSelectedIndexForPointHorizontalDx(index, item, dx, dy);
        }

    }
    public class ScrollSelectionFormVericalDx : ItemIndexDx
    {
        private readonly ScrollSelectionForm scrollSelectionForm;
        public ScrollSelectionFormVericalDx(ScrollSelectionForm multipleScrollSelectionForm)
        {
            this.scrollSelectionForm = multipleScrollSelectionForm;
        }

        // throws Exception
        public override int getDx(int index, ABCustomItem item, int dx, int dy)
        {
            return this.scrollSelectionForm.getSelectedIndexForPointVerticalDx(index, item, dx, dy);
        }

    }
    public class ScrollSelectionFormTempHorizontalDx : ItemIndexDx
    {
        private readonly ScrollSelectionForm scrollSelectionForm;
        public ScrollSelectionFormTempHorizontalDx(ScrollSelectionForm multipleScrollSelectionForm)
        {
            this.scrollSelectionForm = multipleScrollSelectionForm;
        }

        // throws Exception
        public override int getDx(int index, ABCustomItem item, int dx, int dy)
        {
            return this.scrollSelectionForm.getSelectedIndexForPointTempHorizontalDx(index, item, dx, dy);
        }

    }
    private readonly RectangleCollisionUtil rectangleCollisionUtil = RectangleCollisionUtil.getInstance();
    public readonly int border;
    public readonly int halfBorder;
    private BasicColor buttonBasicColor;
    public ItemIndexPaintable scrollSelectionFormFormTypeItemIndexPaintable = ItemIndexPaintable.getInstance();
    private ItemIndexDx formTypeItemIndexDx = ItemIndexDx.getInstance();
    public ItemPaintable paintable = ItemPaintableFactory.getInstance();
    private readonly int adjustedExtraBorder;
    public ScrollSelectionForm(string title, ABCustomItem[] items, ItemPaintableFactory formPaintableFactory, int border, int adjustedExtraBorder, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(title, items, backgroundBasicColor, foregroundBasicColor)
    {
        // base(title, items, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.adjustedExtraBorder = adjustedExtraBorder;
        this.buttonBasicColor = foregroundBasicColor;
        this.border = border;
        this.halfBorder = (border >> 1);
        this.paintable = formPaintableFactory.getInstanceItemPaintable(this);
    }

    // throws Exception
    public override void init(Rectangle rectangle, FormType formType)
    {
        base.init(rectangle, formType);
        FormTypeFactory formTypeFactory = FormTypeFactory.getInstance();
        if (formType == formTypeFactory.HORIZONTAL_FORM) {
            this.scrollSelectionFormFormTypeItemIndexPaintable = new ScrollSelectionFormHorizontalPaintable(this);
            this.formTypeItemIndexDx = new ScrollSelectionFormHorizontalDx(this);
        } else if (formType == formTypeFactory.VERTICAL_CENTER_FORM) {
            this.scrollSelectionFormFormTypeItemIndexPaintable = new ScrollSelectionFormVerticalPaintable(this);
            this.formTypeItemIndexDx = new ScrollSelectionFormVericalDx(this);
        } else if (formType == formTypeFactory.TEMP_HORIZONTAL_FORM) {
            this.scrollSelectionFormFormTypeItemIndexPaintable = new ScrollSelectionFormTempHorizontalPaintable(this);
            this.formTypeItemIndexDx = new ScrollSelectionFormTempHorizontalDx(this);
        } else if (formType == formTypeFactory.NULL_FORM_TYPE) {
        } else {
            throw new Exception(formTypeFactory.UNK);
        }
    }

    public virtual int paintItemHorizontal(Graphics graphics, int index, ABCustomItem item, int x, int y)
    {
        int width = item.getMinimumWidth();
        return x + width + this.border;
    }

    public virtual int paintItemVertical(Graphics graphics, int index, ABCustomItem item, int x, int y)
    {
        int height = item.getMinimumHeight();
        return y + height + this.border;
    }

    public virtual int paintItemTempHorizontal(Graphics graphics, int index, ABCustomItem item, int x, int y)
    {
        return 0;
    }

    public virtual int getSelectedIndexForPointHorizontalDx(int index, ABCustomItem item, int dx, int dy)
    {
        return dx - this.halfBorder;
    }

    public virtual int getSelectedIndexForPointVerticalDx(int index, ABCustomItem item, int dx, int dy)
    {
        return dx + this.getDiffX(item);
    }

    public virtual int getSelectedIndexForPointTempHorizontalDx(int index, ABCustomItem item, int dx, int dy)
    {
        return dx + this.getDiffX(item);
    }

    public override int append(ABCustomItem item)
    {
        return base.append(item);
    }

    // throws Exception
    public virtual ABCustomItem getSelectedItem(GPoint point)
    {
        int index = this.getSelectedIndexForPoint(point);
        if (index != -1) {
            return this.get(index);
        } else {
            return ABCustomItem.getNullInstance();
        }
    }

    // throws Exception
    public virtual int getItemIndex(ABCustomItem item)
    {
        ABCustomItem nextItem = null;
        int size = this.size();
        for (int index = 0; index < size; index++) {
            nextItem = ((ABCustomItem) this.get(index));
            if (nextItem == item) {
                return index;
            }
        }
        return -1;
    }

    public virtual int getStartIndex()
    {
        return 0;
    }

    private static readonly string GET_SELECTED_INDEX = "getSelectedIndexForPoint";
    // throws Exception
    public virtual int getSelectedIndexForPoint(GPoint point)
    {
        int start = this.getStartIndex();
        int size = this.size();
        int dx = this.getDx();
        int dy = this.getDy();
        FormTypeFactory formTypeFactory = FormTypeFactory.getInstance();
        CommonLabels commonLabels = CommonLabels.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(commonLabels.START_LABEL);
        stringBuffer.appendint(start);
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(commonLabels.TOTAL_LABEL);
        stringBuffer.appendint(size);
        this.logUtil.putF(stringBuffer.ToString(), this, ScrollSelectionForm.GET_SELECTED_INDEX);
        ABCustomItem item = null;
        int width = 0;
        int height = 0;
        int diffX = 0;
        for (int index = start; index < size; index++) {
            item = this.get(index);
            width = item.getMinimumWidth();
            height = item.getMinimumHeight();
            diffX = this.formTypeItemIndexDx.getDx(index, item, dx, dy);
            if (this.rectangleCollisionUtil.isInside(diffX, dy - this.halfBorder, diffX + width + this.border, dy + height + this.halfBorder + 1, point.getX(), point.getY())) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(commonLabels.ITEM_LABEL);
                stringBuffer.append(item.getLabel());
                stringBuffer.append(CommonSeps.getInstance().SPACE);
                stringBuffer.append(commonLabels.INDEX_LABEL);
                stringBuffer.appendint(index);
                this.logUtil.putF(stringBuffer.ToString(), this, ScrollSelectionForm.GET_SELECTED_INDEX);
                return index;
            }
            if (this.formType == formTypeFactory.HORIZONTAL_FORM) {
                dx = dx + width + this.border;
                if (dx > this.rectangle.getMaxX()) {
                    break;
                }
            } else if (this.formType == formTypeFactory.VERTICAL_CENTER_FORM) {
                dy = dy + height + this.border;
                if (dy > this.rectangle.getMaxY()) {
                    break;
                }
            } else if (this.formType == formTypeFactory.NULL_FORM_TYPE) {
            } else {
                throw new Exception(formTypeFactory.UNK);
            }
        }
        return -1;
    }

    // throws Exception
    public virtual int processInputKey(int gameKeyCode)
    {
        FormTypeFactory formTypeFactory = FormTypeFactory.getInstance();
        if (this.size() == 0) {
            return -1;
        }
        int index = this.getSelectedIndex();
        if (this.formType == formTypeFactory.HORIZONTAL_FORM || this.formType == formTypeFactory.TEMP_HORIZONTAL_FORM) {
            if (gameKeyCode == Canvas.RIGHT) {
                index++;
            } else if (gameKeyCode == Canvas.LEFT) {
                index--;
            }
        } else if (this.formType == formTypeFactory.VERTICAL_CENTER_FORM) {
            if (gameKeyCode == Canvas.DOWN) {
                index++;
            } else if (gameKeyCode == Canvas.UP) {
                index--;
            }
        } else if (this.formType == formTypeFactory.NULL_FORM_TYPE) {
        } else {
            throw new Exception(formTypeFactory.UNK);
        }
        int max = this.size() - 1;
        if (index < 0) {
            this.setSelectedIndex(0);
        } else if (index > max) {
            this.setSelectedIndex(max);
        } else {
            this.setSelectedIndex(index);
        }
        return -1;
    }

    public virtual bool isInForm(GPoint point)
    {
        if (this.rectangleCollisionUtil.isInside(this.x, this.y - this.halfBorder, this.rectangle.getMaxX() + this.border, this.rectangle.getMaxY() + this.border, point.getX(), point.getY())) {
            this.logUtil.putF(new StringMaker().append(StringUtil.getInstance().toString(point)).append(ScrollSelectionForm.INSIDE_FORM).ToString(), this, ScrollSelectionForm.IS_IN_FORM);
            return true;
        }
        return false;
    }

    // throws Exception
    public virtual int paintItem(Graphics graphics, int index, ABCustomItem item, int x, int y)
    {
        item.paintXY(graphics, x, y);
        int width = item.getMinimumWidth();
        int height = item.getMinimumHeight();
        graphics.setColor(((int) this.getButtonBasicColor()));
        int adjustedBorder = 3;
        graphics.drawRect(x - this.halfBorder - adjustedBorder, y - this.halfBorder - adjustedBorder, width + this.border + this.adjustedExtraBorder, height + this.border + this.adjustedExtraBorder);
        return this.scrollSelectionFormFormTypeItemIndexPaintable.paint(graphics, index, item, x, y);
    }

    // throws Exception
    public virtual int paintUnselectedItem(Graphics graphics, int index, ABCustomItem item, int x, int y)
    {
        graphics.setColor(((int) this.getButtonBasicColor()));
        item.paintUnselected(graphics, x, y);
        return this.scrollSelectionFormFormTypeItemIndexPaintable.paint(graphics, index, item, x, y);
    }

    public virtual int getDiffX(ABCustomItem item)
    {
        return 0;
    }

    public virtual int getDx()
    {
        return this.x;
    }

    public virtual int getDy()
    {
        return this.y;
    }

    public virtual void setButtonBasicColor(BasicColor buttonBasicColor)
    {
        this.buttonBasicColor = buttonBasicColor;
    }

    private BasicColor getButtonBasicColor()
    {
        return this.buttonBasicColor;
    }

}

