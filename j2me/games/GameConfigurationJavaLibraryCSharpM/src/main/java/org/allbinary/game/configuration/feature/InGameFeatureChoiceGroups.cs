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

namespace org.allbinary.game.configuration.feature;

public class InGameFeatureChoiceGroups
{
    private static InGameFeatureChoiceGroups gameFeatureChoiceGroupsExclusive = new InGameFeatureChoiceGroups();
    private static InGameFeatureChoiceGroups gameFeatureChoiceGroupsMultiple = new InGameFeatureChoiceGroups();
    private ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    private InGameFeatureChoiceGroups()
    {
    }

    public static InGameFeatureChoiceGroups getExclusiveInstance()
    {
        return InGameFeatureChoiceGroups.gameFeatureChoiceGroupsExclusive;
    }

    public static InGameFeatureChoiceGroups getMultipleInstance()
    {
        return InGameFeatureChoiceGroups.gameFeatureChoiceGroupsMultiple;
    }

    public virtual ABHashtable<object, object> get()
    {
        return this.hashtable;
    }

    public virtual void add(string name, BasicArrayList list)
    {
        this.hashtable.put(name, list);
    }

}

