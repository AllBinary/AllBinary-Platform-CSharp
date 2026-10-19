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
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using CharArrayFactory = org.allbinary.logic.java.character.CharArrayFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using CommonButtons = org.allbinary.input.motion.button.CommonButtons;

namespace org.allbinary.game.layer;

public class UpgradableRTSLayerHudPaintable : SelectionHudPaintable
{
    private static readonly UpgradableRTSLayerHudPaintable instance = new UpgradableRTSLayerHudPaintable();
    public static UpgradableRTSLayerHudPaintable getInstance()
    {
        return UpgradableRTSLayerHudPaintable.instance;
    }

    private readonly string PERCENT = "%";
    private CollidableDestroyableDamageableLayer rtsLayer = CollidableDestroyableDamageableLayer.getNullInstance();
    public int costY = 0;
    public int costY1 = 0;
    private int percentCompleteX2 = 0;
    private RTSLayerCompositePaintable rtsLayerCompositePaintableLateInit = null;
    private int charHeight = 0;
    private int charWidth = 0;
    private UpgradableRTSLayerHudPaintable()
    {
    }

    public override void updateMeasurement(Graphics graphics)
    {
        base.updateMeasurement(graphics);
        Font font = graphics.getFont();
        this.charHeight = font.getHeight();
        this.charWidth = MyFontProcessor.defaultCharWidth(font);
    }

    public override void update()
    {
        base.update();
        CommonButtons commonButtons = CommonButtons.getInstance();
        this.costY = (this.y + commonButtons.STANDARD_BUTTON_SIZE);
        this.costY1 = (this.y + commonButtons.STANDARD_BUTTON_SIZE - this.charHeight);
        this.percentCompleteX2 = this.imageX + commonButtons.STANDARD_BUTTON_SIZE - this.charWidth;
        DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
        if (displayInfoSingleton.getLastWidth() > 320) {
            this.rtsLayerCompositePaintableLateInit = new UpgradableWideRTSLayerPaintable(this);
        } else {
            this.rtsLayerCompositePaintableLateInit = new RTSLayerCompositePaintable(this);
        }
    }

    public override void updateSelectionInfo()
    {
        RTSLayer rtsLayer = ((RTSLayer) this.getRtsLayer());
        this.rtsLayerCompositePaintableLateInit.update(rtsLayer);
        this.setAnimationInterface(rtsLayer.getVerticleBuildAnimationInterface());
        this.setName(rtsLayer.getName());
    }

    private int percentComplete = 0;
    private int percentCompleteX = 0;
    private char[] percentCompleteArray = CharArrayFactory.getInstance().getZeroCharArray();
    private int currentTotalDigits = 0;
    public override void updateInfo()
    {
        RTSLayer rtsLayer = ((RTSLayer) this.getRtsLayer());
        this.percentComplete = rtsLayer.getPercentComplete();
        if (this.percentComplete < 10) {
            this.percentCompleteX = 32;
        } else if (this.percentComplete < 100) {
            this.percentCompleteX = 24;
        } else {
            this.percentCompleteX = 16;
        }
        this.percentCompleteArray = this.getPrimitiveLongUtil().getCharArray(this.percentComplete);
        this.currentTotalDigits = this.getPrimitiveLongUtil().getCurrentTotalDigits();
    }

    public override void paint(Graphics graphics)
    {
        base.paint(graphics);
        this.rtsLayerCompositePaintableLateInit.paint(graphics);
        graphics.drawChars(this.percentCompleteArray, 0, this.currentTotalDigits, this.imageX + this.percentCompleteX, this.costY, 0);
        graphics.drawString(this.PERCENT, this.percentCompleteX2, this.costY, 0);
        this.getAnimationInterface().paintXY(graphics, this.imageX, this.y);
    }

    public virtual void setRtsLayer(RTSLayer rtsLayer)
    {
        this.rtsLayer = rtsLayer;
    }

    protected virtual CollidableDestroyableDamageableLayer getRtsLayer()
    {
        return this.rtsLayer;
    }

}

