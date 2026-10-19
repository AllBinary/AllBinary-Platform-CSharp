/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
 *  
 * By agreeing to this license you and any business entity you represent are 
 * legally bound to the AllBinary Open License Version 1 legal agreement. 
 *  
 * You may obtain the AllBinary Open License Version 1 legal agreement from 
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository. 
 *  
 * Created By: Travis Berthelot  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using GameInfo = org.allbinary.game.GameInfo;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using GeographicMapCompositeInterface = org.allbinary.media.graphics.geography.map.GeographicMapCompositeInterface;

namespace org.allbinary.game.layer;

public class FakeLayerManager : AllBinaryGameLayerManager, GeographicMapCompositeInterface
{
    private BasicGeographicMap[] geographicMapInterfaceArray = BasicGeographicMap.NULL_BASIC_GEOGRAPHIC_MAP_ARRAY;
    private GeographicMapCellType[] geographicMapCellTypeArray = GeographicMapCellType.NULL_GEOGRAPHIC_MAP_CELL_TYPE_ARRAY;
    public FakeLayerManager(GameInfo gameInfo) : base(BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE, gameInfo)
    {
        // base(BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE, gameInfo) is called from the constructor declaration
    }

    public override BasicGeographicMap[] getGeographicMapInterface()
    {
        return this.geographicMapInterfaceArray;
    }

    public override void setGeographicMapInterface(BasicGeographicMap[] geographicMapInterfaceArray)
    {
        this.geographicMapInterfaceArray = geographicMapInterfaceArray;
        this.geographicMapCellTypeArray = new GeographicMapCellType[this.geographicMapInterfaceArray.Length];
    }

    public override GeographicMapCellType[] geographicMapCellTypeArray()
    {
        return this.geographicMapCellTypeArray;
    }

}

