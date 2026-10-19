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
using PickedUpLayerInterfaceFactoryInterface = org.allbinary.game.layer.pickup.PickedUpLayerInterfaceFactoryInterface;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.layer.drop;

public class DropLayerFactory
{
    private static readonly DropLayerFactory DROP_LAYER_FACTORY = new DropLayerFactory();
    private readonly BasicArrayList list = new BasicArrayListD();
    private DropLayerFactory()
    {
    }

    public virtual void clear()
    {
        this.list.clear();
    }

    public static DropLayerFactory getInstance()
    {
        return DropLayerFactory.DROP_LAYER_FACTORY;
    }

    public virtual int getSize()
    {
        return this.list.size();
    }

    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    public virtual PickedUpLayerInterfaceFactoryInterface getRandomInstance()
    {
        return ((PickedUpLayerInterfaceFactoryInterface) this.basicArrayListUtil.getRandom(this.list));
    }

    public virtual void add(PickedUpLayerInterfaceFactoryInterface layerInterfaceFactoryInterface)
    {
        this.list.add(layerInterfaceFactoryInterface);
    }

    public virtual BasicArrayList getList()
    {
        return this.list;
    }

}

