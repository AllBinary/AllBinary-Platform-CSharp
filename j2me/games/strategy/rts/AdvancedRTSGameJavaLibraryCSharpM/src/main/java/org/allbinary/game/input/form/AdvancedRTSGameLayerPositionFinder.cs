/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using LayerPositionFinderInterface = org.allbinary.game.input.LayerPositionFinderInterface;
using WaypointCellPositionHistory = org.allbinary.game.layer.waypoint.WaypointCellPositionHistory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using DropCellPositionHistory = org.allbinary.media.graphics.geography.map.drop.DropCellPositionHistory;

namespace org.allbinary.game.input.form;

public class AdvancedRTSGameLayerPositionFinder : LayerPositionFinderInterface
{
    private static readonly AdvancedRTSGameLayerPositionFinder instance = new AdvancedRTSGameLayerPositionFinder();
    public static AdvancedRTSGameLayerPositionFinder getInstance()
    {
        return AdvancedRTSGameLayerPositionFinder.instance;
    }

    private AdvancedRTSGameLayerPositionFinder()
    {
    }

    public virtual AllBinaryLayer getLayerInterface(GeographicMapCellPosition geographicMapCellPosition)
    {
        AllBinaryLayer layerInterface = DropCellPositionHistory.getInstance().getLayerInterface(geographicMapCellPosition);
        if (layerInterface == AllBinaryLayer.NULL_ALLBINARY_LAYER) {
            layerInterface = WaypointCellPositionHistory.getInstance().getLayerInterface(geographicMapCellPosition);
        }
        return layerInterface;
    }

}

