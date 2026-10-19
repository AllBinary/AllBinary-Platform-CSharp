/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
 *  
 * By agreeing to this license you and any business entity you represent are 
 * legally bound to the AllBinary Open License Version 1 legal agreement. 
 *  
 * You may obtain the AllBinary Open License Version 1 legal agreement from 
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository. 
 *  
 * Created By: Travis Berthelot  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.layer;

public class RTSLayerEvent : AllBinaryEventObject
{
    private PathFindingLayerInterface rtsLayer = NullPathFindingLayer.NULL_PATH_FINDING_LAYER;
    public RTSLayerEvent(PathFindingLayerInterface rtsLayer) : base(rtsLayer)
    {
        // base(rtsLayer) is called from the constructor declaration
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("RTSLayerEvent: \n");
        stringBuffer.append("RTSLayer: ");
        stringBuffer.append(this.getRtsLayer().ToString());
        return stringBuffer.ToString();
    }

    public virtual PathFindingLayerInterface getRtsLayer()
    {
        return this.rtsLayer;
    }

    public virtual void setRtsLayer(PathFindingLayerInterface rtsLayer)
    {
        this.rtsLayer = rtsLayer;
    }

}

