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
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;
using RaceTrackGeographicMapCellType = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellType;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.media.graphics.geography.map.topview;

public class BasicTopViewGeographicMapCellType
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string name;
    public readonly int cost;
    private readonly int[] types;
    public static BasicTopViewGeographicMapCellType createType(string name, int type, int cost)
    {
        BasicArrayList types = new BasicArrayListS(1);
        types.add(type);
        return new BasicTopViewGeographicMapCellType(name, types, cost);
    }

    public BasicTopViewGeographicMapCellType(string name, BasicArrayList types, int cost)
    {
        int size = types.size();
        int[] typeArray = new int[size];
        int? typeAsInteger = null;
        int type = 0;
        for (int index = 0; index < size; index++) {
            typeAsInteger = (((int?) types.get(index)));
            type = ((int) typeAsInteger);
            if (GeographicMapCellTypeFactory.getInstance().getGeographicMapCellTypeArray()[type] == null) {
                new RaceTrackGeographicMapCellType(name, type, cost, 0);
            } else {
            }
            typeArray[index] = type;
        }
        this.name = name;
        this.cost = cost;
        this.types = typeArray;
    }

    public virtual bool isType(GeographicMapCellType type)
    {
        return this.hasType(type.getType());
    }

    public virtual bool hasType(int type)
    {
        int size = this.types.Length;
        for (int index = 0; index < size; index++) {
            if (this.types[index] == type) {
                return true;
            }
        }
        return false;
    }

    public virtual int[] getTypes()
    {
        return this.types;
    }

    public override string ToString()
    {
        StringMaker stringMaker = new StringMaker();
        int size = this.types.Length;
        for (int index = 0; index < size; index++) {
            stringMaker.appendint(this.types[index]).append(CommonSeps.getInstance().COMMA);
        }
        return stringMaker.ToString();
    }

}

