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
using java.util;
using Layer = org.allbinary.layer.Layer;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using EnumerationUtil = org.allbinary.util.EnumerationUtil;

namespace org.allbinary.game.layer;

public class LevelLayersFinder
{
    private static readonly LevelLayersFinder instance = new LevelLayersFinder();
    public static LevelLayersFinder getInstance()
    {
        return LevelLayersFinder.instance;
    }

    private readonly EnumerationUtil enumerationUtil = EnumerationUtil.getInstance();
    public virtual BasicArrayList get(ABHashtable<object, object> hashtable)
    {
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        BasicArrayList list = new BasicArrayListD();
        Enumeration enumeration = hashtable.keys();
        ABHashtable<object, object> layerHashtableCanBeNull = null;
        int? integerCanBeNull = null;
        int? cachedIntegerCanBeNull = null;
        while (this.enumerationUtil.hasMoreElements(enumeration)) {
            layerHashtableCanBeNull = ((ABHashtable<object, object>) hashtable.get(((object) this.enumerationUtil.nextElement(enumeration))));
            integerCanBeNull = ((int?) layerHashtableCanBeNull.get(((object) Layer.ID)));
            cachedIntegerCanBeNull = smallIntegerSingletonFactory.getAt(((int) integerCanBeNull));
            if (!list.contains(cachedIntegerCanBeNull)) {
                list.add(cachedIntegerCanBeNull);
            }
        }
        return list;
    }

}

