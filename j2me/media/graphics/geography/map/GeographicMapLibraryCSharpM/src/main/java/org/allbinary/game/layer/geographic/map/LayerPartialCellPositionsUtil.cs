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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;

namespace org.allbinary.game.layer.geographic.map;

public class LayerPartialCellPositionsUtil
{
    private static readonly LayerPartialCellPositionsUtil instance = new LayerPartialCellPositionsUtil();
    // throws Exception
    public BasicArrayList getAll(BasicGeographicMap geographicMapInterface, AllBinaryLayer layerInterface, BasicArrayList reusableList)
    {
        reusableList.clear();
        GeographicMapCellPosition topLeftGeographicMapCellPosition = geographicMapInterface.getCellPositionAtXYNoThrow(layerInterface.getXP(), layerInterface.getYP());
        GeographicMapCellPosition topRightGeographicMapCellPosition = geographicMapInterface.getCellPositionAtXYNoThrow(layerInterface.getXP() + layerInterface.getWidth(), layerInterface.getYP());
        GeographicMapCellPosition bottomLeftGeographicMapCellPosition = geographicMapInterface.getCellPositionAtXYNoThrow(layerInterface.getXP(), layerInterface.getYP() + layerInterface.getHeight());
        GeographicMapCellPosition bottomRightGeographicMapCellPosition = geographicMapInterface.getCellPositionAtXYNoThrow(layerInterface.getXP() + layerInterface.getWidth(), layerInterface.getYP() + layerInterface.getHeight());
        if (topLeftGeographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            reusableList.add(topLeftGeographicMapCellPosition);
        }
        if (topRightGeographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION && topLeftGeographicMapCellPosition != topRightGeographicMapCellPosition) {
            reusableList.add(topRightGeographicMapCellPosition);
        }
        if (bottomLeftGeographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION && !reusableList.contains(bottomLeftGeographicMapCellPosition)) {
            reusableList.add(bottomLeftGeographicMapCellPosition);
        }
        if (bottomRightGeographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION && !reusableList.contains(bottomRightGeographicMapCellPosition)) {
            reusableList.add(bottomRightGeographicMapCellPosition);
        }
        return reusableList;
    }

    // throws Exception
    public BasicArrayList getAllDXY(BasicGeographicMap geographicMapInterface, AllBinaryLayer layerInterface, int dx, int dy, BasicArrayList reusableList)
    {
        reusableList.clear();
        GeographicMapCellPosition topLeftGeographicMapCellPosition = geographicMapInterface.getCellPositionAtXYNoThrow(layerInterface.getXP() + dx, layerInterface.getYP() + dy);
        GeographicMapCellPosition topRightGeographicMapCellPosition = geographicMapInterface.getCellPositionAtXYNoThrow(layerInterface.getXP() + layerInterface.getWidth() + dx, layerInterface.getYP() + dy);
        GeographicMapCellPosition bottomLeftGeographicMapCellPosition = geographicMapInterface.getCellPositionAtXYNoThrow(layerInterface.getXP() + dx, layerInterface.getYP() + layerInterface.getHeight() + dy);
        GeographicMapCellPosition bottomRightGeographicMapCellPosition = geographicMapInterface.getCellPositionAtXYNoThrow(layerInterface.getXP() + layerInterface.getWidth() + dx, layerInterface.getYP() + layerInterface.getHeight() + dy);
        if (topLeftGeographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            reusableList.add(topLeftGeographicMapCellPosition);
        }
        if (topRightGeographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION && topLeftGeographicMapCellPosition != topRightGeographicMapCellPosition) {
            reusableList.add(topRightGeographicMapCellPosition);
        }
        if (bottomLeftGeographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION && !reusableList.contains(bottomLeftGeographicMapCellPosition)) {
            reusableList.add(bottomLeftGeographicMapCellPosition);
        }
        if (bottomRightGeographicMapCellPosition != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION && !reusableList.contains(bottomRightGeographicMapCellPosition)) {
            reusableList.add(bottomRightGeographicMapCellPosition);
        }
        return reusableList;
    }

    public static LayerPartialCellPositionsUtil getInstance()
    {
        return LayerPartialCellPositionsUtil.instance;
    }

}

