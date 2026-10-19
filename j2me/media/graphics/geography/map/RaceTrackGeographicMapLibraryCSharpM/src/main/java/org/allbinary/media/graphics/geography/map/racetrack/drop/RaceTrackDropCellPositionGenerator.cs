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
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;
using BaseDropCellPositionGenerator = org.allbinary.media.graphics.geography.map.drop.BaseDropCellPositionGenerator;
using BaseRaceTrackGeographicMap = org.allbinary.media.graphics.geography.map.racetrack.BaseRaceTrackGeographicMap;
using NullRaceTrackGeographicMap = org.allbinary.media.graphics.geography.map.racetrack.NullRaceTrackGeographicMap;
using RaceTrackGeographicMapCellType = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellType;
using RaceTrackGeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellTypeFactory;
using RaceTrackGeographicMapInterface = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapInterface;
using RaceTrackRoadsGeographicMapCellHistoryFactory = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackRoadsGeographicMapCellHistoryFactory;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.media.graphics.geography.map.racetrack.drop;

public class RaceTrackDropCellPositionGenerator : BaseDropCellPositionGenerator
{
    public readonly BasicArrayList list = new BasicArrayListD();
    private readonly TimeDelayHelper timeDelayHelper;
    private readonly int STRAIGHTAWAY = 4;
    public RaceTrackGeographicMapInterface raceTrackGeographicMap = NullRaceTrackGeographicMap.NULL_RACE_TRACK_GEOGRAPHIC_MAP;
    public GeographicMapCellTypeFactory raceTrackGeographicMapCellTypeFactory = GeographicMapCellTypeFactory.getInstance();
    protected RaceTrackDropCellPositionGenerator()
    {
        this.timeDelayHelper = new TimeDelayHelper(10000);
    }

    private void init()
    {
        this.list.clear();
    }

    // throws Exception
    public override bool isDropAllowedAt(GeographicMapCellPosition geographicMapCellPosition)
    {
        RaceTrackGeographicMapCellType raceTrackGeographicMapCellType = ((RaceTrackGeographicMapCellType) this.raceTrackGeographicMap.getCellTypeAt(geographicMapCellPosition));
        RaceTrackGeographicMapCellTypeFactory raceTrackGeographicMapCellTypeFactory = ((RaceTrackGeographicMapCellTypeFactory) this.raceTrackGeographicMapCellTypeFactory);
        if (raceTrackGeographicMapCellType == raceTrackGeographicMapCellTypeFactory.HORIZONTAL_STRAIGHT_ROAD_CELL_TYPE || raceTrackGeographicMapCellType == raceTrackGeographicMapCellTypeFactory.VERTICAL_STRAIGHT_ROAD_CELL_TYPE) {
            return true;
        }
        return false;
    }

    // throws Exception
    public override void update(AllBinaryGameLayerManager allBinaryGameLayerManager, BasicGeographicMap geographicMapInterface)
    {
        this.init();
        BaseRaceTrackGeographicMap baseRaceTrackGeographicMap = ((BaseRaceTrackGeographicMap) geographicMapInterface);
        this.raceTrackGeographicMap = baseRaceTrackGeographicMap;
        this.raceTrackGeographicMapCellTypeFactory = ((RaceTrackGeographicMapCellTypeFactory) baseRaceTrackGeographicMap.getGeographicMapCellTypeFactory());
        GeographicMapCellHistory roadGeographicMapCellHistory = RaceTrackRoadsGeographicMapCellHistoryFactory.getInstance();
        BasicArrayList trackedList = roadGeographicMapCellHistory.getTracked();
        GeographicMapCellPosition geographicMapCellPosition = null;
        int lastIndex = trackedList.size() - 1;
        int total = 0;
        int ahead = 0;
        for (int index = lastIndex; index > 0; index--) {
            geographicMapCellPosition = ((GeographicMapCellPosition) trackedList.get(index));
            total = 0;
            ahead = index;
            while (this.isDropAllowedAt(((GeographicMapCellPosition) trackedList.get(ahead)))) {
                total++;
                if (total > this.STRAIGHTAWAY) {
                    this.list.add(geographicMapCellPosition);
                    break;
                }
                ahead++;
                if (ahead > lastIndex) {
                    break;
                }
            }
        }
        int size = this.list.size();
        for (int index = size - 1; index >= 0; index--) {
            this.drop(allBinaryGameLayerManager, index);
        }
    }

    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    // throws Exception
    public override void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (this.timeDelayHelper.isTime(GameTickTimeDelayHelperFactory.getInstance().startTime)) {
            int index = this.basicArrayListUtil.getRandomIndex(this.list);
            this.drop(allBinaryLayerManager, index);
        }
    }

    // throws Exception
    protected virtual void drop(AllBinaryLayerManager allBinaryLayerManager, int index)
    {
        throw new Exception(CommonStrings.getInstance().NOT_IMPLEMENTED);
    }

}

