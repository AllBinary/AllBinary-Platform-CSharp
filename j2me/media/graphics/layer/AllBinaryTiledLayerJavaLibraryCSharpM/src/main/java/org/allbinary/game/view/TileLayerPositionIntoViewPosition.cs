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
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using Layer = org.allbinary.layer.Layer;
using NullLayer = org.allbinary.layer.NullLayer;
using ViewPosition = org.allbinary.view.ViewPosition;

namespace org.allbinary.game.view;

public class TileLayerPositionIntoViewPosition : ViewPosition
{
    private Layer tiledLayer = NullLayer.getInstance();
    public TileLayerPositionIntoViewPosition() : base(0, 0, 0)
    {
        // base(0, 0, 0) is called from the constructor declaration
    }

    public override int getX()
    {
        return base.getX() - this.tiledLayer.getXP();
    }

    public override int getY()
    {
        return base.getY() - this.tiledLayer.getYP();
    }

    public override int getZ()
    {
        return base.getZ() - this.tiledLayer.getZP();
    }

    public virtual void setTiledLayer(AllBinaryTiledLayer tiledLayer)
    {
        this.tiledLayer = tiledLayer;
    }

}

