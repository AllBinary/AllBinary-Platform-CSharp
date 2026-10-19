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
//using Graphics = javax.microedition.lcdui.Graphics;
using Processor = org.allbinary.canvas.Processor;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;

namespace org.allbinary.graphics.form;

public class ScrollCurrentSelectionForm : ScrollSelectionForm, UpdateMyFontInterface
{
    private readonly bool moveForSmallScreen;
    public class TempHorizontalFormProcessor : Processor
    {
        private readonly ScrollCurrentSelectionForm scrollCurrentSelectionForm;
        public TempHorizontalFormProcessor(ScrollCurrentSelectionForm scrollCurrentSelectionForm)
        {
            this.scrollCurrentSelectionForm = scrollCurrentSelectionForm;
        }

        // throws Exception
        public override void process()
        {
            this.scrollCurrentSelectionForm.processTempHorizontalForm();
            this.scrollCurrentSelectionForm.processor = Processor.getInstance();
        }

    }
    public class HorizontalFormProcessor : Processor
    {
        private readonly ScrollCurrentSelectionForm scrollCurrentSelectionForm;
        public HorizontalFormProcessor(ScrollCurrentSelectionForm scrollCurrentSelectionForm)
        {
            this.scrollCurrentSelectionForm = scrollCurrentSelectionForm;
        }

        // throws Exception
        public override void process()
        {
            this.scrollCurrentSelectionForm.processHorizontalForm();
            this.scrollCurrentSelectionForm.processor = Processor.getInstance();
        }

    }
    public class VerticalFormProcessor : Processor
    {
        private readonly ScrollCurrentSelectionForm scrollCurrentSelectionForm;
        public VerticalFormProcessor(ScrollCurrentSelectionForm scrollCurrentSelectionForm)
        {
            this.scrollCurrentSelectionForm = scrollCurrentSelectionForm;
        }

        // throws Exception
        public override void process()
        {
            this.scrollCurrentSelectionForm.processVerticalForm();
            this.scrollCurrentSelectionForm.processor = Processor.getInstance();
        }

    }
    public class TempHorizontalItemIndexDx : ItemIndexDx
    {
        private readonly ScrollCurrentSelectionForm scrollCurrentSelectionForm;
        public TempHorizontalItemIndexDx(ScrollCurrentSelectionForm scrollCurrentSelectionForm)
        {
            this.scrollCurrentSelectionForm = scrollCurrentSelectionForm;
        }

        // throws Exception
        public override int getDx(int index, ABCustomItem item, int dx, int dy)
        {
            return this.scrollCurrentSelectionForm.getXTempHorizontalForm(index, item, dx, dy);
        }

    }
    public class HorizontalItemIndexDx : ItemIndexDx
    {
        private readonly ScrollCurrentSelectionForm scrollCurrentSelectionForm;
        public HorizontalItemIndexDx(ScrollCurrentSelectionForm scrollCurrentSelectionForm)
        {
            this.scrollCurrentSelectionForm = scrollCurrentSelectionForm;
        }

        // throws Exception
        public override int getDx(int index, ABCustomItem item, int dx, int dy)
        {
            return this.scrollCurrentSelectionForm.getXHorizontalForm(index, item, dx, dy);
        }

    }
    public class VerticalItemIndexDx : ItemIndexDx
    {
        private readonly ScrollCurrentSelectionForm scrollCurrentSelectionForm;
        public VerticalItemIndexDx(ScrollCurrentSelectionForm scrollCurrentSelectionForm)
        {
            this.scrollCurrentSelectionForm = scrollCurrentSelectionForm;
        }

        // throws Exception
        public override int getDx(int index, ABCustomItem item, int dx, int dy)
        {
            return this.scrollCurrentSelectionForm.getXVerticalForm(index, item, dx, dy);
        }

    }
    public readonly MyFontProcessor updateMyFontProcessor;
    public MyFontProcessor myFontProcessor;
    private Processor processor = Processor.getInstance();
    private ItemIndexDx preItemIndexDx = ItemIndexDx.getInstance();
    private int dx = 0;
    private int dy = 0;
    private int maxWidth = 0;
    public ScrollCurrentSelectionForm(string title, ABCustomItem[] items, ItemPaintableFactory formPaintableFactory, int border, int adjustedExtraBorder, bool moveForSmallScreen, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(title, items, formPaintableFactory, border, adjustedExtraBorder, backgroundBasicColor, foregroundBasicColor)
    {
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        // base(title, items, formPaintableFactory, border, adjustedExtraBorder, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.moveForSmallScreen = moveForSmallScreen;
    }

    // throws Exception
    public override void init(Rectangle rectangle, FormType formType)
    {
        base.init(rectangle, formType);
        FormTypeFactory formTypeFactory = FormTypeFactory.getInstance();
        if (formType == formTypeFactory.TEMP_HORIZONTAL_FORM) {
            this.processor = new TempHorizontalFormProcessor(this);
            this.preItemIndexDx = new TempHorizontalItemIndexDx(this);
        } else if (formType == formTypeFactory.HORIZONTAL_FORM) {
            this.processor = new HorizontalFormProcessor(this);
            this.preItemIndexDx = new HorizontalItemIndexDx(this);
        } else if (formType == formTypeFactory.VERTICAL_CENTER_FORM) {
            this.processor = new VerticalFormProcessor(this);
            this.preItemIndexDx = new VerticalItemIndexDx(this);
        } else if (formType == formTypeFactory.NULL_FORM_TYPE) {
        } else {
            this.logUtil.putF(formTypeFactory.UNK, this, this.commonStrings.INIT);
        }
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    private void processTempHorizontalForm()
    {
        this.dx = this.x - 30 + (this.rectangle.getWidth() >> 1);
        this.dy = this.y;
    }

    private void processHorizontalForm()
    {
        int size = this.size();
        int totalWidth = 0;
        ABCustomItem item = null;
        for (int index = 0; index < size; index++) {
            item = this.get(index);
            totalWidth += item.getMinimumWidth() + this.border;
        }
        this.dx = this.x + (this.rectangle.getWidth() >> 1) - (totalWidth >> 1);
        this.dy = this.y + (this.rectangle.getHeight() >> 1);
        if (this.moveForSmallScreen) {
            int maxTitleHeight = 175;
            if (this.dy < maxTitleHeight) {
                this.dy = maxTitleHeight;
            }
        }
    }

    private void processVerticalForm()
    {
        int totalHeight = 0;
        int size = this.size();
        ABCustomItem item2 = null;
        for (int index = 0; index < size; index++) {
            item2 = this.get(index);
            if (this.maxWidth < item2.getMinimumWidth()) {
                this.maxWidth = item2.getMinimumWidth();
            }
            totalHeight += item2.getMinimumHeight() + this.border;
        }
        this.dx = ((this.rectangle.getWidth() - this.maxWidth) / 2);
        if (this.size() > 0) {
            this.dy = this.y + ((this.rectangle.getHeight() - totalHeight) / 2);
            if (this.moveForSmallScreen) {
                int maxTitleHeight = 175;
                if (this.dy < maxTitleHeight) {
                    this.dy = maxTitleHeight;
                }
            }
        } else {
            this.dy = this.y;
        }
    }

    private int getXTempHorizontalForm(int index, ABCustomItem item, int dx, int dy)
    {
        return this.getDiffX(item);
    }

    private int getXHorizontalForm(int index, ABCustomItem item, int dx, int dy)
    {
        return 0;
    }

    private int getXVerticalForm(int index, ABCustomItem item, int dx, int dy)
    {
        return this.getDiffX(item) + this.halfBorder;
    }

    protected override int getDiffX(ABCustomItem item)
    {
        return ((this.maxWidth - item.getMinimumWidth()) >> 1);
    }

    public override int getDx()
    {
        return this.dx;
    }

    public override int getDy()
    {
        return this.dy;
    }

    public override void paint(Graphics graphics)
    {
        try {
            this.processor.process();
            int delta = 0;
            int deltaX = this.getDx();
            int deltaY = this.getDy();
            int size = this.size();
            FormTypeFactory formTypeFactory = FormTypeFactory.getInstance();
            ABCustomItem item = null;
            for (int index = 0; index < size; index++) {
                item = this.get(index);
                int diffX = this.preItemIndexDx.getDx(index, item, this.dx, this.dy);
                if (index == this.getSelectedIndex()) {
                    delta = this.paintItem(graphics, index, item, deltaX + diffX, deltaY);
                    this.paintable.paint(graphics, index, deltaX + diffX, deltaY);
                } else {
                    delta = this.paintUnselectedItem(graphics, index, item, deltaX + diffX, deltaY);
                    this.paintable.paint(graphics, index, deltaX + diffX, deltaY);
                }
                if (this.formType == formTypeFactory.TEMP_HORIZONTAL_FORM) {
                } else if (this.formType == formTypeFactory.HORIZONTAL_FORM) {
                    deltaX = delta;
                } else if (this.formType == formTypeFactory.VERTICAL_CENTER_FORM) {
                    deltaY = delta;
                } else {
                    throw new Exception(formTypeFactory.UNK);
                }
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.canvasStrings.PAINT, e);
        }
    }

}

