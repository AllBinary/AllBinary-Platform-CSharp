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
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.ai;

public class ArtificialIntelligenceInterfaceFactoryInterfaceFactory
{
    private static ArtificialIntelligenceInterfaceFactoryInterfaceFactory SINGLETON = new ArtificialIntelligenceInterfaceFactoryInterfaceFactory();
    private BasicArrayList list = BasicArrayListUtil.getInstance().getImmutableInstance();
    public virtual void clear()
    {
        this.list = new BasicArrayListD();
    }

    public static ArtificialIntelligenceInterfaceFactoryInterfaceFactory getInstance()
    {
        return ArtificialIntelligenceInterfaceFactoryInterfaceFactory.SINGLETON;
    }

    public virtual ArtificialIntelligenceInterfaceFactoryInterface getInstanceFromCollection(ABHashtable<object, object> hashtable)
    {
        int? typeInteger = ((int?) hashtable.get(((object) BasicAI.ID)));
        int type = ((int) typeInteger);
        ArtificialIntelligenceInterfaceFactoryInterface artificialIntelligenceInterfaceFactoryInterface = ((ArtificialIntelligenceInterfaceFactoryInterface) this.list.objectArray[type - 1]);
        return artificialIntelligenceInterfaceFactoryInterface;
    }

    public virtual void add(ArtificialIntelligenceInterfaceFactoryInterface artificialIntelligenceInterfaceFactoryInterface)
    {
        this.list.add(artificialIntelligenceInterfaceFactoryInterface);
    }

}

