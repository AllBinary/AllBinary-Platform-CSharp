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
//using Image = javax.microedition.lcdui.Image;
using CostLayerInterfaceFactoryInterface = org.allbinary.game.layer.CostLayerInterfaceFactoryInterface;
using TechEventListenerInterface = org.allbinary.game.rts.technology.@event.TechEventListenerInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Animation = org.allbinary.animation.Animation;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using NullUtil = org.allbinary.logic.NullUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using PrimitiveLongUtil = org.allbinary.logic.math.PrimitiveLongUtil;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;

namespace org.allbinary.game.layer.item;

public class RTSLayerCostAnimation : Animation, TechEventListenerInterface, UpdateMyFontInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly PrimitiveLongUtil primitiveLongUtil = PrimitiveLongUtil.createPowerOfTen(10000);
    private readonly string DOLLAR = "$";
    private readonly Image image;
    private readonly CostLayerInterfaceFactoryInterface layerInterfaceFactoryInterface;
    private MyFontProcessor myFontProcessor;
    private char[] costString = NullUtil.getInstance().NULL_CHAR_ARRAY;
    private int len = 0;
    private int adjustedCostX = 0;
    private int fontHeight = 0;
    public RTSLayerCostAnimation(Image image, CostLayerInterfaceFactoryInterface layerInterfaceFactoryInterface)
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        this.image = image;
        this.layerInterfaceFactoryInterface = layerInterfaceFactoryInterface;
        this.update();
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.fontHeight = font.getHeight();
        this.adjustedCostX = font.stringWidth(this.DOLLAR);
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void onEvent(AllBinaryEventObject @event)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public override void onTechEvent(AllBinaryEventObject @event)
    {
        try {
            this.update();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "onTechEvent", e);
        }
    }

    // throws Exception
    public virtual void update()
    {
        this.len = 0;
        this.costString = this.primitiveLongUtil.getCharArray(this.layerInterfaceFactoryInterface.getCost());
        this.len = this.primitiveLongUtil.getCurrentTotalDigits();
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.myFontProcessor.process(graphics);
        base.paintXY(graphics, x, y);
        int adjustedCostY = this.image.getHeight() - this.fontHeight;
        int xa = x + 2;
        graphics.drawString(this.DOLLAR, xa, y + adjustedCostY, 0);
        graphics.drawChars(this.costString, 0, this.len, x + this.adjustedCostX, y + adjustedCostY, 0);
    }

}

