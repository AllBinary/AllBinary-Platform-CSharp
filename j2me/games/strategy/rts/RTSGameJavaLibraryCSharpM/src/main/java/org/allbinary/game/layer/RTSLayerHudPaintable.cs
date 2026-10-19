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
using AndroidUtil = org.allbinary.AndroidUtil;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using BasicWeaponPart = org.allbinary.game.part.weapon.BasicWeaponPart;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;

namespace org.allbinary.game.layer;

public class RTSLayerHudPaintable : SelectionHudPaintable, UpdateMyFontInterface
{
    private static readonly RTSLayerHudPaintable instance = new RTSLayerHudPaintable();
    public static RTSLayerHudPaintable getInstance()
    {
        return RTSLayerHudPaintable.instance;
    }

    private string[] weaponProperties = StringUtil.getInstance().getArrayInstance();
    private CollidableDestroyableDamageableLayer rtsLayer = CollidableDestroyableDamageableLayer.getNullInstance();
    public int costY = 0;
    public int costY1 = 0;
    private int fontHeight = 0;
    private RTSLayerHudPaintable()
    {
    }

    public override void updateMeasurement(Graphics graphics)
    {
        base.updateMeasurement(graphics);
        Font font = graphics.getFont();
        this.fontHeight = font.getHeight();
        this.costY1 = (this.y + ((this.weaponProperties.Length + 1) * this.fontHeight));
        if (!AndroidUtil.isAndroid()) {
            this.costY = this.costY1;
        } else {
            this.costY = (this.y + ((this.weaponProperties.Length + 2) * this.fontHeight));
        }
    }

    public override void updateSelectionInfo()
    {
        this.setName(this.getRtsLayer().getName());
        BasicWeaponPart partInterface = ((BasicWeaponPart) this.getRtsLayer().getPartInterfaceArray()[0]);
        this.weaponProperties = partInterface.getWeaponProperties().toStringArray();
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    public override void paint(Graphics graphics)
    {
        base.paint(graphics);
        int size = this.weaponProperties.Length;
        for (int index = 0; index < size; index++) {
            graphics.drawString(this.weaponProperties[index], this.textX, this.y + ((index + 1) * this.fontHeight), 0);
        }
    }

    public virtual void setRtsLayer(RTSLayer rtsLayer)
    {
        this.rtsLayer = rtsLayer;
    }

    private CollidableDestroyableDamageableLayer getRtsLayer()
    {
        return this.rtsLayer;
    }

}

