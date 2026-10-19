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

namespace org.allbinary.game.layer.pickup;

public class CountedPickedUpLayerInterfaceFactoryPool
{
    private static CountedPickedUpLayerInterfaceFactoryPool SINGLETON = new CountedPickedUpLayerInterfaceFactoryPool();
    private BasicArrayList list;
    private CountedPickedUpLayerInterfaceFactoryPool()
    {
        this.list = new BasicArrayListD();
    }

    public virtual BasicArrayList getList()
    {
        return this.list;
    }

    public static CountedPickedUpLayerInterfaceFactoryPool getInstance()
    {
        return CountedPickedUpLayerInterfaceFactoryPool.SINGLETON;
    }

    public static void init()
    {
        CountedPickedUpLayerInterfaceFactoryPool.SINGLETON = new CountedPickedUpLayerInterfaceFactoryPool();
    }

}

