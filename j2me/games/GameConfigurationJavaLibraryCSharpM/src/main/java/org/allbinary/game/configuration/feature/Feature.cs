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
using ChangedGameFeatureListener = org.allbinary.game.configuration.@event.ChangedGameFeatureListener;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.game.configuration.feature;

public class Feature
{
    private static ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    private readonly string name;
    public Feature(string name)
    {
        this.name = name;
        Feature.add(name, this);
        ChangedGameFeatureListener.getInstance().add(this);
    }

    public static Feature getInstance(string name)
    {
        return ((Feature) Feature.hashtable.get(name));
    }

    private static void add(string name, Feature gameFeature)
    {
        Feature.hashtable.put(name, gameFeature);
    }

    public override string ToString()
    {
        return this.getName();
    }

    public virtual string getName()
    {
        return this.name;
    }

}

