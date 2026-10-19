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
using AngleInfo = org.allbinary.math.AngleInfo;
using NamedAngle = org.allbinary.math.NamedAngle;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer;

public class RTSLayerLogHelper
{
    private static readonly RTSLayerLogHelper instance = new RTSLayerLogHelper();
    public static RTSLayerLogHelper getInstance()
    {
        return RTSLayerLogHelper.instance;
    }

    public virtual void setClosestGeographicMapCellHistory(PathFindingLayerInterface associatedAdvancedRTSGameLayer, BasicArrayList pathsList)
    {
    }

    public virtual void trackTo(PathFindingLayerInterface associatedAdvancedRTSGameLayer, GeographicMapCellPosition nextUnvisitedPathGeographicMapCellPosition, int dx, int dy, string reason)
    {
    }

    public virtual void turnTo(PathFindingLayerInterface associatedAdvancedRTSGameLayer, int dx, int dy, AngleInfo angleInfo, int angle, NamedAngle movementAngle, bool evading, int targetAngle)
    {
    }

    public virtual void doneMoving(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void closeEnough(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void movingLeft(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void movingRight(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void movingUp(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void movingDown(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void currentMoveEnded(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void evade(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void rotateLeft(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void rotateRight(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void handle(PathFindingLayerInterface associatedAdvancedRTSGameLayer, NamedAngle movementAngle)
    {
    }

    public virtual void noRotation(PathFindingLayerInterface associatedAdvancedRTSGameLayer)
    {
    }

    public virtual void notOnPath(PathFindingLayerInterface associatedAdvancedRTSGameLayer, GeographicMapCellHistory geographicMapCellHistory, GeographicMapCellPosition currentGeographicMapCellPosition, BasicArrayList pathList)
    {
    }

}

