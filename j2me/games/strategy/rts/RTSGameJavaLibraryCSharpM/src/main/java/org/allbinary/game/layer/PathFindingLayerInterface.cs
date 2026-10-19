/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using DestroyableInterface = org.allbinary.game.combat.destroy.DestroyableInterface;
using GroupInterfaceCompositeInterface = org.allbinary.game.identification.GroupInterfaceCompositeInterface;
using GameKeyEventSourceInterface = org.allbinary.game.input.GameKeyEventSourceInterface;
using WaypointLayerInterface = org.allbinary.game.layer.waypoint.WaypointLayerInterface;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer;

public interface PathFindingLayerInterface : WaypointLayerInterface, GameKeyEventSourceInterface, GroupInterfaceCompositeInterface, DestroyableInterface
{
    // throws Exception
    BasicArrayList getEndGeographicMapCellPositionList();

    bool shouldHandleStartSameAsEnd();

    GeographicMapCellPositionAreaBase getGeographicMapCellPositionArea();

    SelectionHudPaintable getHudPaintable();

    // throws Exception
    void handleCost(PathFindingLayerInterface ownerLayer);

    PathFindingLayerInterface getParentLayer();

    RTSLayer2LogHelper getRTSLayer2LogHelper();

    // throws Exception
    void setTarget(PathFindingLayerInterface targetGameLayer);

}

