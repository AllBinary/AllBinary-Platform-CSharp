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
using LayerManager = org.allbinary.layer.LayerManager;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.layer.@event;

public class LayerManagerEvent : AllBinaryEventObject
{
    private AllBinaryLayer layerInterface = AllBinaryLayer.NULL_ALLBINARY_LAYER;
    private readonly string crud;
    public LayerManagerEvent(LayerManager layerManager, string crud) : base(layerManager)
    {
        // base(layerManager) is called from the constructor declaration
        this.crud = crud;
    }

    public virtual AllBinaryLayer getLayerInterface()
    {
        return this.layerInterface;
    }

    public virtual void setLayerInterface(AllBinaryLayer layerInterface)
    {
        this.layerInterface = layerInterface;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("LayerManagerEvent: \n");
        stringBuffer.append("LayerInterface: ");
        stringBuffer.append(this.getLayerInterface().ToString());
        stringBuffer.append("\nCRUD: ");
        stringBuffer.append(this.crud.ToString());
        return stringBuffer.ToString();
    }

}

