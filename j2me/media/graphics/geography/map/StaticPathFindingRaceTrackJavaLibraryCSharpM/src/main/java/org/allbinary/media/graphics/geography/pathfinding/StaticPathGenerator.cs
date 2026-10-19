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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CellPosition = org.allbinary.graphics.CellPosition;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using PathData = org.allbinary.media.graphics.geography.map.PathData;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class StaticPathGenerator : PathGeneratorInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    protected StaticPathGenerator()
    {
        PreLogUtil.put("Using Static Path Finding", this, CommonStrings.getInstance().CONSTRUCTOR);
    }

    // throws Exception
    public virtual void init(object geographicMapInterface, int totalPaths)
    {
    }

    // throws Exception
    private BasicArrayList getGeographicMapCellPositionListFromBasicGeographicMapCellPositionList(BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory, BasicArrayList pathList)
    {
        BasicArrayList list = new BasicArrayListD();
        int size = pathList.size();
        CellPosition basicGeographicMapCellPosition = null;
        GeographicMapCellPosition geographicMapCellPosition = null;
        for (int index = 0; index < size; index++) {
            basicGeographicMapCellPosition = ((CellPosition) pathList.get(index));
            geographicMapCellPosition = geographicMapCellPositionFactory.getAt(basicGeographicMapCellPosition.getColumn(), basicGeographicMapCellPosition.getRow());
            list.add(geographicMapCellPosition);
        }
        return list;
    }

    // throws Exception
    public virtual BasicArrayList createList(BasicGeographicMap geographicMapInterface, GeographicMapCellHistory geographicMapCellHistory, PathFindingInfo pathFindingInfo, int totalPaths)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            PathCacheFactory pathCacheFactory = PathCacheFactory.getInstance();
            int? mapIdInteger = geographicMapInterface.getAllBinaryTiledLayer().getDataId();
            BasicArrayList list = pathCacheFactory.getOrCreate(mapIdInteger);
            if (list == this.basicArrayListUtil.getImmutableInstance()) {
                list = new BasicArrayListD();
                SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
                BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
                int id = PathData.getInstance().OFFSET + ((int) mapIdInteger);
                BasicArrayList basicList = pathCacheFactory.getOrCreate(smallIntegerSingletonFactory.getAt(id));
                int size = basicList.size();
                BasicArrayList pathList = null;
                for (int index = 0; index < size; index++) {
                    pathList = this.getGeographicMapCellPositionListFromBasicGeographicMapCellPositionList(geographicMapCellPositionFactory, ((BasicArrayList) basicList.get(index)));
                    list.add(pathList);
                }
                pathCacheFactory.add(mapIdInteger, list);
                pathCacheFactory.remove(smallIntegerSingletonFactory.getAt(id));
            }
            this.logUtil.putF(new StringMaker().append("Using Cached Path(s): ").append(StringUtil.getInstance().toString(list)).ToString(), this, commonStrings.GET_INSTANCE);
            return list;
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            return new BasicArrayListD();
        }
    }

}

