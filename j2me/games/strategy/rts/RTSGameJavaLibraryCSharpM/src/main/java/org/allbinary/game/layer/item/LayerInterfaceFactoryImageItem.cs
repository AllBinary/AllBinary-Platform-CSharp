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
//using Graphics = javax.microedition.lcdui.Graphics;
//using Image = javax.microedition.lcdui.Image;
using ABCustomImageItem = org.allbinary.graphics.form.item.ABCustomImageItem;
using Animation = org.allbinary.animation.Animation;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using LayerInterfaceFactoryInterface = org.allbinary.layer.LayerInterfaceFactoryInterface;

namespace org.allbinary.game.layer.item;

public class LayerInterfaceFactoryImageItem : ABCustomImageItem
{
    private readonly Animation[] animationArray;
    private readonly LayerInterfaceFactoryInterface layerInterfaceFactoryInterface;
    public LayerInterfaceFactoryImageItem(string label, Image img, int layout, string altText, BasicColor basicColor, Animation[] animationArray, LayerInterfaceFactoryInterface layerInterfaceFactoryInterface) : base(label, img, layout, altText, basicColor, 0)
    {
        // base(label, img, layout, altText, basicColor, 0) is called from the constructor declaration
        this.animationArray = animationArray;
        this.layerInterfaceFactoryInterface = layerInterfaceFactoryInterface;
    }

    public virtual LayerInterfaceFactoryInterface getLayerInterfaceFactoryInterface()
    {
        return this.layerInterfaceFactoryInterface;
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        base.paintXY(graphics, x, y);
        for (int index = this.animationArray.Length; --index >= 0; ) {
            this.animationArray[index].paintXY(graphics, x, y);
        }
    }

}

