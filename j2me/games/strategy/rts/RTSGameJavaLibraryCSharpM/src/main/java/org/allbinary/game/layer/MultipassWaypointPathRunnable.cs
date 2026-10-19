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
using NullUtil = org.allbinary.logic.NullUtil;
using ARunnable = org.allbinary.thread.ARunnable;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using MultipassState = org.allbinary.media.graphics.geography.pathfinding.MultipassState;
using PathFindingInfo = org.allbinary.media.graphics.geography.pathfinding.PathFindingInfo;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.layer;

public class MultipassWaypointPathRunnable : WaypointPathRunnableBase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    private readonly MultipassState multipassState = new MultipassState();
    private bool done = false;
    private BasicArrayList list;
    private object pathFindingInfo = NullUtil.getInstance().NULL_OBJECT;
    private class FirstRunnable : ARunnable
    {
        private readonly MultipassWaypointPathRunnable multipassWaypointPathRunnable;
        public FirstRunnable(MultipassWaypointPathRunnable multipassWaypointPathRunnable)
        {
            this.multipassWaypointPathRunnable = multipassWaypointPathRunnable;
        }

        public override void run()
        {
            this.multipassWaypointPathRunnable.processFirstRunnable();
        }

    }
    private readonly Runnable FIRST_RUNNABLE;
    //    private boolean first = true;
    private class SecondRunnable : ARunnable
    {
        private readonly MultipassWaypointPathRunnable multipassWaypointPathRunnable;
        public SecondRunnable(MultipassWaypointPathRunnable multipassWaypointPathRunnable)
        {
            this.multipassWaypointPathRunnable = multipassWaypointPathRunnable;
        }

        public override void run()
        {
            this.multipassWaypointPathRunnable.processSecondRunnable();
        }

    }
    private readonly Runnable SECOND_RUNNABLE;
    private class EndRunnable : ARunnable
    {
        private readonly MultipassWaypointPathRunnable multipassWaypointPathRunnable;
        public EndRunnable(MultipassWaypointPathRunnable multipassWaypointPathRunnable)
        {
            this.multipassWaypointPathRunnable = multipassWaypointPathRunnable;
        }

        public override void run()
        {
            this.multipassWaypointPathRunnable.processEndRunnable();
        }

    }
    private readonly Runnable END_RUNNABLE;
    private readonly Runnable ALREADY_ENDED_RUNNABLE = new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
        public virtual void run()
        {
            throw new SystemException();
        }

#endif
;
    private Runnable currentPassRunnable;
    public MultipassWaypointPathRunnable()
    {
        this.list = this.basicArrayListUtil.getImmutableInstance();
        this.FIRST_RUNNABLE = new FirstRunnable(this);
        this.SECOND_RUNNABLE = new SecondRunnable(this);
        this.END_RUNNABLE = new EndRunnable(this);
        this.currentPassRunnable = this.FIRST_RUNNABLE;
    }

    public override void setRunning(bool isRunning)
    {
        this.runningP = isRunning;
        if (this.runningP) {
            this.reset();
            this.done = false;
        }
    }

    public override void run()
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            this.currentPassRunnable.run();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            this.setRunning(false);
        }
    }

    private void reset2()
    {
        this.multipassState.step = 0;
        this.multipassState.iteration = 0;
        this.multipassState.iteration2 = 0;
        this.pathFindingInfo = NullUtil.getInstance().NULL_OBJECT;
    }

    private void finish()
    {
        this.reset2();
        this.currentPassRunnable = this.ALREADY_ENDED_RUNNABLE;
        this.done = true;
    }

    public override bool isDone()
    {
        return this.done;
    }

    public override void reset()
    {
        this.reset2();
        this.currentPassRunnable = this.FIRST_RUNNABLE;
        this.done = false;
    }

    private void processFirstRunnable()
    {
        try {
            this.pathFindingLayer.getWaypointRunnableLogHelper().start(this.pathFindingLayer);
            this.reset2();
            GeographicMapCellPosition geographicMapCellPosition = this.pathFindingLayer.getCurrentGeographicMapCellPosition();
            if (geographicMapCellPosition == null) {
                throw new Exception("Should never be running here");
            }
            this.pathFindingInfo = this.targetPathFindingLayer.getWaypointBehavior().getWaypoint().getPathFindingInfo(geographicMapCellPosition);
            PathFindingInfo localPathFindingInfo = ((PathFindingInfo) this.pathFindingInfo);
            this.list = this.targetPathFindingLayer.getWaypointBehavior().getWaypoint().getPathsList(geographicMapCellPosition, localPathFindingInfo, this.multipassState);
            if (this.list != this.basicArrayListUtil.getImmutableInstance()) {
                this.END_RUNNABLE.run();
            } else {
                this.currentPassRunnable = this.SECOND_RUNNABLE;
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            this.setRunning(false);
            this.finish();
        }
    }

    private void processSecondRunnable()
    {
        try {
            GeographicMapCellPosition geographicMapCellPosition = this.pathFindingLayer.getCurrentGeographicMapCellPosition();
            PathFindingInfo localPathFindingInfo = ((PathFindingInfo) this.pathFindingInfo);
            this.list = this.targetPathFindingLayer.getWaypointBehavior().getWaypoint().getPathsList(geographicMapCellPosition, localPathFindingInfo, this.multipassState);
            if (this.list != this.basicArrayListUtil.getImmutableInstance()) {
                this.END_RUNNABLE.run();
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            this.setRunning(false);
            this.finish();
        }
    }

    private void processEndRunnable()
    {
        try {
            WaypointBehaviorBase waypointBehavior = this.pathFindingLayer.getWaypointBehavior();
            waypointBehavior.setWaypointPathsList(this.list);
            this.pathFindingLayer.getWaypointRunnableLogHelper().end(this.pathFindingLayer);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
            this.setRunning(false);
        }
        this.finish();
    }

}

