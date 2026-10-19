/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Animation = org.allbinary.animation.Animation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using InitUpdatePaintable = org.allbinary.graphics.paint.InitUpdatePaintable;
using CommonButtons = org.allbinary.input.motion.button.CommonButtons;
using TouchButtonLocationHelper = org.allbinary.input.motion.button.TouchButtonLocationHelper;
using PrimitiveLongUtil = org.allbinary.logic.math.PrimitiveLongUtil;

namespace org.allbinary.game.layer;

public class SelectionHudPaintable : InitUpdatePaintable, UpdateMyFontInterface
{
    public readonly int y = CommonButtons.getInstance().STANDARD_BUTTON_SIZE + 17;
    private readonly PrimitiveLongUtil primitiveLongUtil;
    public readonly MyFontProcessor updateMyFontProcessor;
    public MyFontProcessor myFontProcessor = updateMyFontProcessor;
    private int x = 0;
    public int textX = 0;
    public int imageX = 0;
    private BasicColor basicColor = BasicColorFactory.getInstance().BLACK;
    private int color = 0;
    private int width = 0;
    private int height = 0;
    private string name = StringUtil.getInstance().EMPTY_STRING;
    private Animation animationInterface = NullAnimationFactory.getFactoryInstance().getInstance(0);
    private readonly int backgroundColor = ((int) BasicColorFactory.getInstance().GREY);
    protected SelectionHudPaintable()
    {
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.update();
        this.primitiveLongUtil = PrimitiveLongUtil.createPowerOfTen(10000);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        CommonButtons commonButtons = CommonButtons.getInstance();
        Font font = graphics.getFont();
        this.setHeight(commonButtons.STANDARD_BUTTON_SIZE + font.getHeight());
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void update()
    {
        CommonButtons commonButtons = CommonButtons.getInstance();
        TouchButtonLocationHelper touchButtonLocationHelper = new TouchButtonLocationHelper();
        DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
        this.x = commonButtons.STANDARD_BUTTON_SIZE + touchButtonLocationHelper.getColumnsRemainderHalf();
        this.textX = this.getX() + 4;
        this.width = displayInfoSingleton.getLastWidth() - this.getX() * 2;
        this.imageX = this.getWidth() + touchButtonLocationHelper.getColumnsRemainderHalf() - 10;
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    public virtual void updateSelectionInfo()
    {
    }

    public virtual void updateInfo()
    {
    }

    protected virtual PrimitiveLongUtil getPrimitiveLongUtil()
    {
        return this.primitiveLongUtil;
    }

    protected virtual void setAnimationInterface(Animation animationInterface)
    {
        this.animationInterface = animationInterface;
    }

    protected virtual Animation getAnimationInterface()
    {
        return this.animationInterface;
    }

    protected virtual void setName(string name)
    {
        this.name = name;
    }

    protected virtual string getName()
    {
        return this.name;
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
        this.setColor(((int) basicColor));
    }

    protected virtual BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

    public virtual void setColor(int color)
    {
        this.color = color;
    }

    public virtual int getColor()
    {
        return this.color;
    }

    protected virtual int getWidth()
    {
        return this.width;
    }

    protected virtual void setHeight(int height)
    {
        this.height = height;
    }

    protected virtual int getHeight()
    {
        return this.height;
    }

    protected virtual int getX()
    {
        return this.x;
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        graphics.setColor(this.backgroundColor);
        graphics.drawRect(this.getX(), this.y, this.getWidth(), this.getHeight());
        graphics.setColor(this.getColor());
        graphics.drawString(this.getName(), this.textX, this.y, 0);
    }

}

