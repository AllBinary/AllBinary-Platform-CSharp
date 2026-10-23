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
using System.Runtime.CompilerServices;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.graphics.color;

public class BasicColorCacheFactory
{
    private static readonly BasicColorCacheFactory instance = new BasicColorCacheFactory();
    public static BasicColorCacheFactory getInstance()
    {
        return BasicColorCacheFactory.instance;
    }

    private readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    private BasicColorCacheFactory()
    {
    }

    public virtual void add(BasicColor basicDefaultColor)
    {
        this.hashtable.put(basicDefaultColor.intValue(), basicDefaultColor);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual BasicColor getAndOrCreate(int? integer)
    {
        BasicColor basicColor = ((BasicColor) this.hashtable.get(integer));
        if (basicColor == null) {
            basicColor = BasicColorFactory.getInstance().createInstance(((int) integer));
            this.hashtable.put(integer, basicColor);
        }
        return basicColor;
    }

}

