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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;

namespace org.allbinary.game.layer;

public class WaypointPathRunnable : WaypointPathRunnableBase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public WaypointPathRunnable()
    {
    }

    public override void run()
    {
        try {
            this.pathFindingLayer.getWaypointRunnableLogHelper().start(this.pathFindingLayer);
            WaypointBehaviorBase waypointBehavior = this.pathFindingLayer.getWaypointBehavior();
            GeographicMapCellPosition geographicMapCellPosition = this.pathFindingLayer.getCurrentGeographicMapCellPosition();
            if (geographicMapCellPosition == null) {
                throw new Exception("Should never be running here");
            }
            waypointBehavior.setWaypointPathsList(this.targetPathFindingLayer.getWaypointBehavior().getWaypoint().getPathsListRunnable(geographicMapCellPosition));
            this.pathFindingLayer.getWaypointRunnableLogHelper().end(this.pathFindingLayer);
            System.Threading.Thread.Sleep((int) (15L + (this.priorityP * 2)));
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            this.setRunning(false);
        }
    }

    public override bool isDone()
    {
        return true;
    }

}

