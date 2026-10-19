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
using CountedPickedUpLayerInterfaceFactory = org.allbinary.game.layer.pickup.CountedPickedUpLayerInterfaceFactory;
using CountedPickedUpLayerInterfaceFactoryPool = org.allbinary.game.layer.pickup.CountedPickedUpLayerInterfaceFactoryPool;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.part;

public class MakeCountedPartsSingletonArrayFactory
{
    private static readonly MakeCountedPartsSingletonArrayFactory instance = new MakeCountedPartsSingletonArrayFactory();
    public static MakeCountedPartsSingletonArrayFactory getInstance()
    {
        return MakeCountedPartsSingletonArrayFactory.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private BasicArrayList list = BasicArrayListUtil.getInstance().getImmutableInstance();
    // throws Exception
    public virtual PartInterface[] getUpdated(PartInterface[] partInterfaceArray)
    {
        this.list = new BasicArrayListD();
        for (int index = 0; index < partInterfaceArray.Length; index++) {
            this.list.add(partInterfaceArray[index]);
        }
        BasicArrayList countedBasicArrayList = CountedPickedUpLayerInterfaceFactoryPool.getInstance().getList();
        CountedPickedUpLayerInterfaceFactory layerInterfaceFactoryInterface = null;
        int size = countedBasicArrayList.size();
        for (int index = 0; index < size; index++) {
            layerInterfaceFactoryInterface = ((CountedPickedUpLayerInterfaceFactory) countedBasicArrayList.objectArray[index]);
            this.list.add(new CountedLayerInterfaceFactoryPart(0, layerInterfaceFactoryInterface));
        }
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Total Parts: ");
        stringBuffer.appendint(this.list.size());
        stringBuffer.append(" Counted: ");
        stringBuffer.appendint(countedBasicArrayList.size());
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF(stringBuffer.ToString(), this, commonStrings.GET_INSTANCE);
        PartInterface[] newPartInterfaceArray = new PartInterface[this.list.size()];
        int newSize = newPartInterfaceArray.Length;
        for (int index = 0; index < newSize; index++) {
            newPartInterfaceArray[index] = ((PartInterface) this.list.get(index));
        }
        return newPartInterfaceArray;
    }

}

