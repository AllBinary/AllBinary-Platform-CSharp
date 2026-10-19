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
 *   
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellPositionFactoryInterface = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionFactoryInterface;

namespace org.allbinary.game.layer.geological.resources;

public class GeologicalGeographicMapCellPositionFactory : GeographicMapCellPositionFactoryInterface
{
    private readonly int[] resourcePerMapCellType;
    public GeologicalGeographicMapCellPositionFactory(int[] resourcePerMapCellType)
    {
        this.resourcePerMapCellType = resourcePerMapCellType;
    }

    // throws Exception
    public virtual GeographicMapCellPosition getInstance(BasicGeographicMap geographicMapInterface, int i_column, int i_row, int columns, int rows, int width, int height)
    {
        AllBinaryTiledLayer tiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        int resources = this.resourcePerMapCellType[tiledLayer.getCell(i_column, i_row)] + MyRandomFactory.getInstance().getAbsoluteNextInt(1000);
        return new GeologicalGeographicMapCellPosition(i_column, i_row, columns, rows, width, height, new GeologicalResource(resources));
    }

}

