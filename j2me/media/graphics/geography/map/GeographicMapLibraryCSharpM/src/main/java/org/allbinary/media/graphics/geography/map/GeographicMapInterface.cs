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
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using Layer = org.allbinary.layer.Layer;

namespace org.allbinary.media.graphics.geography.map;

public interface GeographicMapInterface
{
    int? getId();

    string getName();

    void reset();

    AllBinaryTiledLayer getAllBinaryTiledLayer();

    // throws Exception
    bool getCellPositionsAt(Layer layer, GeographicMapCellPosition[][] currentCellPositionArray, GeographicMapCellPosition[][] cellPositionArray);

    // throws Exception
    GeographicMapCellPosition getCellPositionAtXY(int x, int y);

    // throws Exception
    GeographicMapCellPosition getCellPositionAtXYNoThrow(int x, int y);

    int getCellTypeFromMapCellTypeInt(int cellTypeId);

    // throws Exception
    GeographicMapCellType getCellTypeAtXY(int x, int y);

    // throws Exception
    GeographicMapCellType getCellTypeAt(GeographicMapCellPosition geographicMapCellPosition);

    BasicGeographicMapCellPositionFactory getGeographicMapCellPositionFactory();

    GeographicMapCellPositionFactoryInterface getGeographicMapCellPositionFactoryInterface();

    BasicColor getForegroundBasicColor();

    BasicColor getBackgroundBasicColor();

}

