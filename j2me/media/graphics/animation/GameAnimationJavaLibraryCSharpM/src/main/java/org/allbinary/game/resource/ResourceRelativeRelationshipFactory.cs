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
using RelativeRelationship = org.allbinary.graphics.RelativeRelationship;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.resource;

public class ResourceRelativeRelationshipFactory : ResourceRelativeRelationshipFactoryInterface
{
    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    private readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    private bool initialized = false;
    // throws Exception
    public virtual void init(int level)
    {
        this.setInitialized(true);
    }

    // throws Exception
    public virtual BasicArrayList getResourceRelativeRelationshipList(string resource)
    {
        object listCanBeNull = this.hashtable.get(resource);
        if (listCanBeNull == null) {
            return this.basicArrayListUtil.getImmutableInstance();
        }
        return ((BasicArrayList) listCanBeNull);
    }

    // throws Exception
    public virtual void addResourceRelativeRelationship(string resource, RelativeRelationship hardPoint)
    {
        BasicArrayList list = this.getResourceRelativeRelationshipList(resource);
        if (list == this.basicArrayListUtil.getImmutableInstance()) {
            list = new BasicArrayListD();
        }
        list.add(hardPoint);
        this.hashtable.put(resource, list);
    }

    public virtual bool isLoadingLevel(int level)
    {
        return false;
    }

    public virtual bool isFeature()
    {
        return false;
    }

    public virtual void setInitialized(bool initialized)
    {
        this.initialized = initialized;
    }

    public virtual bool isInitialized()
    {
        return this.initialized;
    }

}

