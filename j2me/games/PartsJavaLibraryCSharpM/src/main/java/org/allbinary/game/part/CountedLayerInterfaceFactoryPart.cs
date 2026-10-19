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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using Animation = org.allbinary.animation.Animation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using CountedPickedUpLayerInterfaceFactory = org.allbinary.game.layer.pickup.CountedPickedUpLayerInterfaceFactory;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using NullUtil = org.allbinary.logic.NullUtil;
using PrimitiveLongUtil = org.allbinary.logic.math.PrimitiveLongUtil;
using org.allbinary.util;

namespace org.allbinary.game.part;

public class CountedLayerInterfaceFactoryPart : PartInterface, UpdateMyFontInterface
{
    public static readonly CountedLayerInterfaceFactoryPart NULL_COUNTED_LAYER_INTERFACE_FACTORY = new CountedLayerInterfaceFactoryPart(0, CountedPickedUpLayerInterfaceFactory.NULL_COUNTED_PICKUP_LAYER_FACTORY);
    private readonly MyFontProcessor updateMyFontProcessor;
    private MyFontProcessor myFontProcessor;
    private Animation animationInterface = NullAnimationFactory.getFactoryInstance().getInstance(0);
    private int total = 0;
    private char[] totalString = NullUtil.getInstance().NULL_CHAR_ARRAY;
    private int xOffset = 0;
    private CountedPickedUpLayerInterfaceFactory countedPickedUpLayerInterfaceFactory = CountedPickedUpLayerInterfaceFactory.NULL_COUNTED_PICKUP_LAYER_FACTORY;
    private readonly PrimitiveLongUtil primitiveLongUtil;
    public CountedLayerInterfaceFactoryPart(int total, CountedPickedUpLayerInterfaceFactory countedPickedUpLayerInterfaceFactory)
    {
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        this.primitiveLongUtil = PrimitiveLongUtil.createPowerOfTen(1000);
        this.init(total, countedPickedUpLayerInterfaceFactory);
    }

    public virtual void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.setXOffset(font.charsWidth(this.totalString, 0, this.primitiveLongUtil.getCurrentTotalDigits()) + (font.getSize() >> 1));
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    private void init(int total, CountedPickedUpLayerInterfaceFactory countedPickedUpLayerInterfaceFactory)
    {
        this.setCountedPickedUpLayerInterfaceFactory(countedPickedUpLayerInterfaceFactory);
        this.total = total;
    }

    // throws Exception
    public virtual AllBinaryLayer getInstance(ABHashtable<object, object> hashtable, int x, int y, int z)
    {
        if (this.total > 0) {
            this.setTotal(this.total - 1);
            return this.getCountedPickedUpLayerInterfaceFactory().getNextInstance(hashtable, x, y, z);
        } else {
            throw new Exception("No more left. Could use a listener to automatically remove");
        }
    }

    public virtual int getTotal()
    {
        return this.total;
    }

    public virtual void setTotal(int total)
    {
        this.total = total;
        this.totalString = this.primitiveLongUtil.getCharArray(total);
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    public virtual void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
    }

    public virtual void paintThreed(Graphics graphics)
    {
    }

    public virtual Animation getAnimationInterface()
    {
        return this.animationInterface;
    }

    public virtual void setAnimationInterface(Animation animationInterface)
    {
        this.animationInterface = animationInterface;
    }

    public virtual int getXOffset()
    {
        return this.xOffset;
    }

    private void setXOffset(int totalStringWidth)
    {
        this.xOffset = totalStringWidth;
    }

    public virtual char[] getTotalString()
    {
        return this.totalString;
    }

    public virtual CountedPickedUpLayerInterfaceFactory getCountedPickedUpLayerInterfaceFactory()
    {
        return this.countedPickedUpLayerInterfaceFactory;
    }

    public virtual void setCountedPickedUpLayerInterfaceFactory(CountedPickedUpLayerInterfaceFactory countedPickedUpLayerInterfaceFactory)
    {
        this.countedPickedUpLayerInterfaceFactory = countedPickedUpLayerInterfaceFactory;
    }

}

