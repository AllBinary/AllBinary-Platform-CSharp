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
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPositionBaseFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionBaseFactory;
using GeographicMapCellPositionFactoryInterface = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionFactoryInterface;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class BaseRaceTrackGeographicMap : BasicGeographicMap, RaceTrackGeographicMapInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private RaceTrackInfo raceTrackInfo;
    private RaceTrackData raceTrackData;
    private BasicGeographicMap miniGeographicMap;
    public BaseRaceTrackGeographicMap(RaceTrackInfo raceTrackInfo, RaceTrackData raceTrackData, AllBinaryTiledLayer tiledLayer, BasicGeographicMap miniGeographicMap, GeographicMapCellPositionFactoryInterface geographicMapCellPositionFactoryInterface, GeographicMapCellPositionBaseFactory geographicMapCellPositionBaseFactory, GeographicMapCellTypeFactory geographicMapCellTypeFactory) : base(raceTrackInfo.getId(), raceTrackInfo.getName(), raceTrackData.getCellTypeIdToGeographicMapCellTypeArray(), tiledLayer, raceTrackInfo.getForegroundBasicColor(), raceTrackInfo.getBackgroundBasicColor(), geographicMapCellPositionFactoryInterface, geographicMapCellPositionBaseFactory, geographicMapCellTypeFactory)
    {
        // base(raceTrackInfo.getId(), raceTrackInfo.getName(), raceTrackData.getCellTypeIdToGeographicMapCellTypeArray(), tiledLayer, raceTrackInfo.getForegroundBasicColor(), raceTrackInfo.getBackgroundBasicColor(), geographicMapCellPositionFactoryInterface, geographicMapCellPositionBaseFactory, geographicMapCellTypeFactory) is called from the constructor declaration
        this.raceTrackInfo = raceTrackInfo;
        this.raceTrackData = raceTrackData;
        this.miniGeographicMap = miniGeographicMap;
        AllBinaryTiledLayer miniTiledLayer = this.miniGeographicMap.getAllBinaryTiledLayer();
        if (miniTiledLayer.getColumns() != this.getGeographicMapCellPositionFactory().getColumns()) {
            string error = new StringMaker().append("RaceTrackMap has incorrect Mini Map columns: ").appendint(((int) miniTiledLayer.getColumns())).append(" != ").appendint(((int) this.getGeographicMapCellPositionFactory().getColumns())).ToString();
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR);
            throw new Exception(error);
        }
        if (miniTiledLayer.getRows() != this.getGeographicMapCellPositionFactory().getRows()) {
            string error = "RaceTrackMap has incorrect Mini Map rows";
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR);
            throw new Exception(error);
        }
    }

    public override RaceTrackInfo getRaceTrackInfo()
    {
        return this.raceTrackInfo;
    }

    public override void setRaceTrackInfo(RaceTrackInfo aRaceTrackInfo)
    {
        this.raceTrackInfo = aRaceTrackInfo;
    }

    public virtual void setMiniBasicGeographicMap(BasicGeographicMap miniBasicGeographicMap)
    {
        this.miniGeographicMap = miniBasicGeographicMap;
    }

    public virtual BasicGeographicMap getMiniBasicGeographicMap()
    {
        return this.miniGeographicMap;
    }

    public override RaceTrackData getRaceTrackData()
    {
        return this.raceTrackData;
    }

    public override void setRaceTrackData(RaceTrackData raceTrackData)
    {
        this.raceTrackData = raceTrackData;
    }

}

