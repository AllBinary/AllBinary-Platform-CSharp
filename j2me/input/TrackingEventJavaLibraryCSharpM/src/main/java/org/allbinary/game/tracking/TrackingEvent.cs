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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.tracking;

public class TrackingEvent : AllBinaryEventObject
{
    private AllBinaryLayer layerInterface = AllBinaryLayer.NULL_ALLBINARY_LAYER;
    public TrackingEvent(object allBinaryLayerInterface) : base(allBinaryLayerInterface)
    {
        // base(allBinaryLayerInterface) is called from the constructor declaration
        if (allBinaryLayerInterface != TrackingEventHandler.getInstance()) {
            this.setLayerInterface(((AllBinaryLayer) allBinaryLayerInterface));
        }
    }

    public virtual void init(object anyType)
    {
        this.setSource(anyType);
    }

    public virtual AllBinaryLayer getLayerInterface()
    {
        return this.layerInterface;
    }

    private void setLayerInterface(AllBinaryLayer layerInterface)
    {
        this.layerInterface = layerInterface;
    }

    public virtual void setLayerInterfaceForCircularStaticPool(AllBinaryLayer layerInterface)
    {
        this.layerInterface = layerInterface;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("TrackingEvent: \n");
        stringBuffer.append("LayerInterface: ");
        stringBuffer.append(this.layerInterface.ToString());
        return stringBuffer.ToString();
    }

}

