/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using DropCellPositionHistory = org.allbinary.media.graphics.geography.map.drop.DropCellPositionHistory;

namespace org.allbinary.game.input;

public class RTSGameLayerPositionFinder : LayerPositionFinderInterface
{
    private static readonly RTSGameLayerPositionFinder instance = new RTSGameLayerPositionFinder();
    public static RTSGameLayerPositionFinder getInstance()
    {
        return RTSGameLayerPositionFinder.instance;
    }

    private RTSGameLayerPositionFinder()
    {
    }

    public virtual AllBinaryLayer getLayerInterface(GeographicMapCellPosition geographicMapCellPosition)
    {
        return DropCellPositionHistory.getInstance().getLayerInterface(geographicMapCellPosition);
    }

}

