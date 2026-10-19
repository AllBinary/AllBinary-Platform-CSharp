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
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class PathCacheFactory
{
    private static PathCacheFactory pathFactory = new PathCacheFactory();
    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    private readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    private PathCacheFactory()
    {
    }

    public static PathCacheFactory getInstance()
    {
        return PathCacheFactory.pathFactory;
    }

    public virtual int getSize()
    {
        return this.hashtable.size();
    }

    public virtual void add(int? pathId, BasicArrayList list)
    {
        this.hashtable.put(pathId, list);
    }

    public virtual void remove(int? pathId)
    {
        this.hashtable.remove(pathId);
    }

    // throws Exception
    public virtual void removeAll()
    {
        this.hashtable.clear();
        if (this.hashtable.size() > 0) {
            throw new Exception("Did not clear");
        }
    }

    // throws Exception
    public virtual BasicArrayList getOrCreate(int? pathIdInteger)
    {
        object listCanBeNull = this.hashtable.get(pathIdInteger);
        if (listCanBeNull == null) {
            listCanBeNull = this.basicArrayListUtil.getImmutableInstance();
        }
        return ((BasicArrayList) listCanBeNull);
    }

}

