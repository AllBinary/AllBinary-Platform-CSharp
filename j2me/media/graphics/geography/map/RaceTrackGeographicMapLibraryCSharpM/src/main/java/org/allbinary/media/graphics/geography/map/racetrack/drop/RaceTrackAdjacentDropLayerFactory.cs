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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;
using LayerInterfaceFactoryInterface = org.allbinary.layer.LayerInterfaceFactoryInterface;

namespace org.allbinary.media.graphics.geography.map.racetrack.drop;

public class RaceTrackAdjacentDropLayerFactory
{
    private static RaceTrackAdjacentDropLayerFactory DROP_LAYER_FACTORY = new RaceTrackAdjacentDropLayerFactory();
    private BasicArrayList list = new BasicArrayListD();
    private RaceTrackAdjacentDropLayerFactory()
    {
    }

    public virtual void clear()
    {
        this.list.clear();
    }

    public static RaceTrackAdjacentDropLayerFactory getInstance()
    {
        return RaceTrackAdjacentDropLayerFactory.DROP_LAYER_FACTORY;
    }

    public virtual int getSize()
    {
        return this.list.size();
    }

    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    public virtual LayerInterfaceFactoryInterface getRandomInstance()
    {
        return ((LayerInterfaceFactoryInterface) this.basicArrayListUtil.getRandom(this.list));
    }

    public virtual void add(LayerInterfaceFactoryInterface layerInterfaceFactoryInterface)
    {
        this.list.add(layerInterfaceFactoryInterface);
    }

}

