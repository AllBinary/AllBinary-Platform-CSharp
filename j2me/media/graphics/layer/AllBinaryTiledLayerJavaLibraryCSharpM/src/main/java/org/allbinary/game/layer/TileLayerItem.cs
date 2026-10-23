/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
//using Screen = javax.microedition.lcdui.Screen;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using ABCustomItemInterface = org.allbinary.graphics.form.item.ABCustomItemInterface;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.game.layer;

public class TileLayerItem : ABCustomItem, ABCustomItemInterface
{
    private readonly AllBinaryTiledLayer tiledLayer;
    public TileLayerItem(string label, AllBinaryTiledLayer tiledLayer, int layout, string altText, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(label, backgroundBasicColor, foregroundBasicColor)
    {
        // base(label, backgroundBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.tiledLayer = tiledLayer;
    }

    public override void setOwner(Screen owner)
    {
    }

    public override int getMinimumWidth()
    {
        return this.tiledLayer.getWidth();
    }

    public override int getMinimumHeight()
    {
        return this.tiledLayer.getHeight();
    }

    public virtual int getMinContentHeight()
    {
        return this.tiledLayer.getHeight();
    }

    public virtual int getMinContentWidth()
    {
        return this.tiledLayer.getWidth();
    }

    public virtual int getPrefContentHeight(int width)
    {
        return this.tiledLayer.getHeight();
    }

    public virtual int getPrefContentWidth(int height)
    {
        return this.tiledLayer.getWidth();
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.tiledLayer.setPosition(x, y, this.tiledLayer.getZP());
        this.tiledLayer.paint(graphics);
    }

    public override void paintUnselected(Graphics graphics, int x, int y)
    {
    }

}

