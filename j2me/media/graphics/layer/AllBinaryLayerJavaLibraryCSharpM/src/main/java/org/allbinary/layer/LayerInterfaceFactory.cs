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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.layer;

public class LayerInterfaceFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly LayerInterfaceFactory SINGLETON = new LayerInterfaceFactory();
    private BasicArrayList list = BasicArrayListUtil.getInstance().getImmutableInstance();
    public static LayerInterfaceFactory getInstance()
    {
        return LayerInterfaceFactory.SINGLETON;
    }

    public virtual void init()
    {
        this.list = new BasicArrayListD();
    }

    private readonly string HASHTABLE_LABEL = "Hashtable: ";
    // throws Exception
    public virtual AllBinaryLayer getNexInstance(ABHashtable<object, object> hashtable, int x, int y, int z)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF(new StringMaker().append(this.HASHTABLE_LABEL).append(StringUtil.getInstance().toString(hashtable)).ToString(), this, commonStrings.GET_INSTANCE);
        int? typeInteger = ((int?) hashtable.get(((object) Layer.ID)));
        LayerInterfaceFactoryInterface layerInterfaceFactoryInterface = ((LayerInterfaceFactoryInterface) this.list.objectArray[((int) typeInteger) - 1]);
        return layerInterfaceFactoryInterface.getNextInstance(hashtable, x, y, z);
    }

    public virtual void add(LayerInterfaceFactoryInterface layerInterfaceFactoryInterface)
    {
        this.list.add(layerInterfaceFactoryInterface);
    }

}

