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
//using Command = javax.microedition.lcdui.Command;
//using Graphics = javax.microedition.lcdui.Graphics;
using J2MEUtil = org.allbinary.J2MEUtil;
using Animation = org.allbinary.animation.Animation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using RectangleAdjustedAnimation = org.allbinary.animation.vector.RectangleAdjustedAnimation;
using RectangleFilledAdjustedAnimation = org.allbinary.animation.vector.RectangleFilledAdjustedAnimation;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using CommandTextItem = org.allbinary.graphics.form.item.CommandTextItem;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;

namespace org.allbinary.graphics.form;

public class CommandCurrentSelectionForm : ScrollCurrentSelectionForm, UpdateMyFontInterface
{
    public readonly Animation[] selectedAnimationArray = new Animation[16];
    public readonly Animation[] unSelectedAnimationArray = new Animation[16];
    public CommandCurrentSelectionForm(string title, ABCustomItem[] items, int border, bool moveForSmallScreen, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(title, items, ItemPaintableFactory.getInstance(), border, -3, moveForSmallScreen, backgroundBasicColor, foregroundBasicColor)
    {
        // base(title, items, ItemPaintableFactory.getInstance(), border, -3, moveForSmallScreen, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.initAnimations();
        this.addAll(items);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        this.updateAll(graphics, this.getAllitems());
        base.updateMeasurement(graphics);
    }

    private void initAnimations()
    {
        Animation nullAnimation = NullAnimationFactory.getFactoryInstance().getInstance(0);
        for (int index = this.selectedAnimationArray.Length; --index >= 0; ) {
            this.selectedAnimationArray[index] = nullAnimation;
        }
        for (int index = this.unSelectedAnimationArray.Length; --index >= 0; ) {
            this.unSelectedAnimationArray[index] = nullAnimation;
        }
    }

    private void addAll(ABCustomItem[] items)
    {
        for (int index = items.Length; --index >= 0; ) {
            this.addAt(index, items[index]);
        }
    }

    private void addAt(int index, ABCustomItem item)
    {
        BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
        BasicColor buttonColor = basicColorFactory.TRANSPARENT_GREY;
        BasicColor selectedButtonColor = basicColorFactory.TRANSPARENT_RED;
        int width = item.getMinimumWidth();
        int height = item.getMinimumHeight();
        int adjustedBorder = 3;
        int offset = -(this.halfBorder + adjustedBorder);
        int rectWidth = width + this.border - adjustedBorder;
        int rectHeight = height + this.border - adjustedBorder;
        if (J2MEUtil.isJ2ME() || J2MEUtil.isHTML()) {
            this.selectedAnimationArray[index] = new RectangleAdjustedAnimation(rectWidth, rectHeight, offset, offset, selectedButtonColor);
        } else {
            this.selectedAnimationArray[index] = new RectangleFilledAdjustedAnimation(rectWidth, rectHeight, offset, offset, selectedButtonColor);
        }
        adjustedBorder = 4;
        if (J2MEUtil.isJ2ME() || J2MEUtil.isHTML()) {
            this.unSelectedAnimationArray[index] = new RectangleAdjustedAnimation(rectWidth, rectHeight, offset, offset, buttonColor);
        } else {
            this.unSelectedAnimationArray[index] = new RectangleFilledAdjustedAnimation(rectWidth, rectHeight, offset, offset, buttonColor);
        }
    }

    private void updateAll(Graphics graphics, ABCustomItem[] items)
    {
        for (int index = items.Length; --index >= 0; ) {
            items[index].preMeasurement(graphics);
            this.updateAt(index, items[index]);
        }
    }

    private void updateAt(int index, ABCustomItem item)
    {
        BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
        BasicColor buttonColor = basicColorFactory.TRANSPARENT_GREY;
        BasicColor selectedButtonColor = basicColorFactory.TRANSPARENT_RED;
        int width = item.getMinimumWidth();
        int height = item.getMinimumHeight();
        int adjustedBorder = 3;
        int offset = -(this.halfBorder + adjustedBorder);
        int rectWidth = width + this.border - adjustedBorder;
        int rectHeight = height + this.border - adjustedBorder;
        if (J2MEUtil.isJ2ME() || J2MEUtil.isHTML()) {
            RectangleAdjustedAnimation rectangleAdjustedAnimation = ((RectangleAdjustedAnimation) this.selectedAnimationArray[index]);
            rectangleAdjustedAnimation.setWidth(rectWidth);
            rectangleAdjustedAnimation.setHeight(rectHeight);
            rectangleAdjustedAnimation.setOffsetX(offset);
            rectangleAdjustedAnimation.setOffsetY(offset);
            rectangleAdjustedAnimation.setBasicColorP(selectedButtonColor);
        } else {
            RectangleFilledAdjustedAnimation rectangleAdjustedAnimation = ((RectangleFilledAdjustedAnimation) this.selectedAnimationArray[index]);
            rectangleAdjustedAnimation.setWidth(rectWidth);
            rectangleAdjustedAnimation.setHeight(rectHeight);
            rectangleAdjustedAnimation.setOffsetX(offset);
            rectangleAdjustedAnimation.setOffsetY(offset);
            rectangleAdjustedAnimation.setBasicColorP(selectedButtonColor);
        }
        adjustedBorder = 4;
        if (J2MEUtil.isJ2ME() || J2MEUtil.isHTML()) {
            RectangleAdjustedAnimation rectangleAdjustedAnimation = ((RectangleAdjustedAnimation) this.unSelectedAnimationArray[index]);
            rectangleAdjustedAnimation.setWidth(rectWidth);
            rectangleAdjustedAnimation.setHeight(rectHeight);
            rectangleAdjustedAnimation.setOffsetX(offset);
            rectangleAdjustedAnimation.setOffsetY(offset);
            rectangleAdjustedAnimation.setBasicColorP(buttonColor);
        } else {
            RectangleFilledAdjustedAnimation rectangleAdjustedAnimation = ((RectangleFilledAdjustedAnimation) this.unSelectedAnimationArray[index]);
            rectangleAdjustedAnimation.setWidth(rectWidth);
            rectangleAdjustedAnimation.setHeight(rectHeight);
            rectangleAdjustedAnimation.setOffsetX(offset);
            rectangleAdjustedAnimation.setOffsetY(offset);
            rectangleAdjustedAnimation.setBasicColorP(buttonColor);
        }
    }

    public virtual Command getSelectedCommand()
    {
        int index = base.getSelectedIndex();
        CommandTextItem commandTextItem = ((CommandTextItem) this.get(index));
        return commandTextItem.getCommand();
    }

    public override int append(ABCustomItem item)
    {
        int result = base.append(item);
        this.addAt(result, item);
        return result;
    }

    public override void delete(int itemNum)
    {
        base.delete(itemNum);
    }

    public override void deleteAll()
    {
        this.initAnimations();
        base.deleteAll();
    }

    public override void insert(int itemNum, ABCustomItem item)
    {
        base.insert(itemNum, item);
    }

    public override void set(int itemNum, ABCustomItem item)
    {
        base.set(itemNum, item);
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        base.paint(graphics);
    }

    // throws Exception
    public override int paintItem(Graphics graphics, int index, ABCustomItem item, int x, int y)
    {
        this.selectedAnimationArray[index].paintXY(graphics, x, y);
        return base.paintItem(graphics, index, item, x, y);
    }

    // throws Exception
    public override int paintUnselectedItem(Graphics graphics, int index, ABCustomItem item, int x, int y)
    {
        this.unSelectedAnimationArray[index].paintXY(graphics, x, y);
        return base.paintUnselectedItem(graphics, index, item, x, y);
    }

}

