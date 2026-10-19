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
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.media.graphics.geography.map.platform;

public class BasicPlatormGeographicMapCellType
{
    private readonly int[] types;
    public static BasicPlatormGeographicMapCellType createType(int type)
    {
        BasicArrayList types = new BasicArrayListS(1);
        types.add(SmallIntegerSingletonFactory.getInstance().getAt(type));
        BasicPlatormGeographicMapCellType basicPlatormGeographicMapCellType = new BasicPlatormGeographicMapCellType(types);
        return basicPlatormGeographicMapCellType;
    }

    public BasicPlatormGeographicMapCellType(BasicArrayList types)
    {
        int size = types.size();
        int[] typeArray = new int[size];
        int? typeAsInteger = null;
        int type = 0;
        for (int index = 0; index < size; index++) {
            typeAsInteger = (((int?) types.get(index)));
            type = ((int) typeAsInteger);
            new GeographicMapCellType(type, 0);
            typeArray[index] = type;
        }
        this.types = typeArray;
    }

    public virtual bool isType(GeographicMapCellType type)
    {
        return this.hasType(type.getType());
    }

    public virtual bool hasType(int type)
    {
        int size = types.Length;
        for (int index = 0; index < size; index++) {
            if (this.types[index] == type) {
                return true;
            }
        }
        return false;
    }

}

