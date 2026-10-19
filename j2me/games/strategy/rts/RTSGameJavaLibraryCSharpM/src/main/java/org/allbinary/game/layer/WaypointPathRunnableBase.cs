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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using LayerDistanceUtil = org.allbinary.math.LayerDistanceUtil;
using PriorityRunnable = org.allbinary.thread.PriorityRunnable;
using RunnableInterface = org.allbinary.thread.RunnableInterface;

namespace org.allbinary.game.layer;

public class WaypointPathRunnableBase : RunnableInterface, PriorityRunnable
{
    private readonly LayerDistanceUtil layerDistanceUtil = LayerDistanceUtil.getInstance();
    public PathFindingLayerInterface pathFindingLayer = NullPathFindingLayer.NULL_PATH_FINDING_LAYER;
    public PathFindingLayerInterface targetPathFindingLayer = NullPathFindingLayer.NULL_PATH_FINDING_LAYER;
    public int priorityP = Integer.MAX_VALUE;
    public bool runningP = false;
    public virtual bool isRunning()
    {
        return this.runningP;
    }

    public virtual void setRunning(bool isRunning)
    {
        this.runningP = isRunning;
    }

    // throws Exception
    public virtual void setThread(Thread thread)
    {
    }

    public virtual void setTargetLayer(PathFindingLayerInterface waypointLayer)
    {
        this.targetPathFindingLayer = waypointLayer;
        this.setPriority();
    }

    public virtual void setPriority()
    {
        AllBinaryLayer pathFindingLayer = ((AllBinaryLayer) this.pathFindingLayer);
        AllBinaryLayer targetLayer = ((AllBinaryLayer) this.targetPathFindingLayer);
        if (targetLayer != null) {
            int distance = this.layerDistanceUtil.getDistance(targetLayer, pathFindingLayer);
            int distanceCategory = distance / 70;
            this.priorityP = distanceCategory;
        }
    }

    public virtual PathFindingLayerInterface getTargetLayer()
    {
        return this.targetPathFindingLayer;
    }

    public virtual void setUnitLayer(PathFindingLayerInterface unitLayer)
    {
        this.pathFindingLayer = unitLayer;
    }

    public virtual int getPriority()
    {
        return this.priorityP;
    }

    public virtual bool isDone()
    {
        return true;
    }

    public virtual void run()
    {
    }

    public virtual void reset()
    {
    }

}

