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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellPositionBaseFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionBaseFactory;
using GeographicMapCellPositionFactoryInterface = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionFactoryInterface;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class RaceTrackGeographicMap : BaseRaceTrackGeographicMap
{
    private readonly CustomMapGeneratorBase customMapGenerator;
    public RaceTrackGeographicMap(RaceTrackInfo raceTrackInfo, RaceTrackData raceTrackData, AllBinaryTiledLayerFactoryInterface tiledLayerFactoryInterface, GeographicMapCellPositionFactoryInterface geographicMapCellPositionFactoryInterface, GeographicMapCellPositionBaseFactory geographicMapCellPositionBaseFactory, GeographicMapCellTypeFactory geographicMapCellTypeFactory, CustomMapGeneratorBaseFactory customMapGeneratorBaseFactory) : base(raceTrackInfo, raceTrackData, tiledLayerFactoryInterface.getInstance(raceTrackInfo, raceTrackData), new BasicGeographicMapFactory().getInstance(raceTrackInfo, raceTrackData, tiledLayerFactoryInterface, geographicMapCellPositionFactoryInterface, geographicMapCellTypeFactory), geographicMapCellPositionFactoryInterface, geographicMapCellPositionBaseFactory, geographicMapCellTypeFactory)
    {
        // base(raceTrackInfo, raceTrackData, tiledLayerFactoryInterface.getInstance(raceTrackInfo, raceTrackData), new BasicGeographicMapFactory().getInstance(raceTrackInfo, raceTrackData, tiledLayerFactoryInterface, geographicMapCellPositionFactoryInterface, geographicMapCellTypeFactory), geographicMapCellPositionFactoryInterface, geographicMapCellPositionBaseFactory, geographicMapCellTypeFactory) is called from the constructor declaration
        this.customMapGenerator = customMapGeneratorBaseFactory.create(this);
    }

    public virtual CustomMapGeneratorBase getCustomMapGenerator()
    {
        return this.customMapGenerator;
    }

    // throws Exception
    public virtual bool isValid(GeographicMapCellPosition geographicMapCellPosition)
    {
        int[][] customMapArray = this.customMapGenerator.getCustomMapArray();
        if (geographicMapCellPosition.getColumn() >= customMapArray[0].Length) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Column: ");
            stringBuffer.appendint(((int) geographicMapCellPosition.getColumn()));
            stringBuffer.append(" not in: ");
            stringBuffer.appendint(customMapArray[0].Length);
            this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
            if (geographicMapCellPosition.getColumn() == customMapArray[0].Length) {
                return true;
            } else {
                return false;
            }
        } else if (geographicMapCellPosition.getRow() > customMapArray.Length) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Row: ");
            stringBuffer.appendint(((int) geographicMapCellPosition.getRow()));
            stringBuffer.append(" not in: ");
            stringBuffer.appendint(customMapArray.Length);
            this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
            if (geographicMapCellPosition.getRow() == customMapArray.Length) {
                return true;
            } else {
                return false;
            }
        }
        return true;
    }

}

