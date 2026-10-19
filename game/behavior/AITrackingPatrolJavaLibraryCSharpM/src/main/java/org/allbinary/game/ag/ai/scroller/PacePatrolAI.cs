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
//using Canvas = javax.microedition.lcdui.Canvas;
using Direction = org.allbinary.direction.Direction;
using DirectionCompositeInterface = org.allbinary.direction.DirectionCompositeInterface;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using GameInput = org.allbinary.game.input.GameInput;
using TrackingEvent = org.allbinary.game.tracking.TrackingEvent;
using TrackingEventHandler = org.allbinary.game.tracking.TrackingEventHandler;
using TrackingEventListenerInterface = org.allbinary.game.tracking.TrackingEventListenerInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LayerInterface = org.allbinary.layer.LayerInterface;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.ag.ai.scroller;

public class PacePatrolAI : BasePatrolAI, TrackingEventListenerInterface
{
    private BasicArrayList trackingList;
    private int firingDistance = 0;
    public bool isFollowLimitedByTerrain = false;
    public PacePatrolAI(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(hashtable, ownerLayerInterface, gameInput)
    {
        // base(hashtable, ownerLayerInterface, gameInput) is called from the constructor declaration
        TrackingEventHandler.getInstance().addListenerInterface(this);
        this.trackingList = new BasicArrayListD();
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        this.update();
        Direction direction = this.setFiringDirectionForTargetIfInRange();
        DirectionFactory directionFactory = DirectionFactory.getInstance();
        if (direction == directionFactory.LEFT) {
            if (this.lastKeyDirection != keyDirection || !this.isFollowLimitedByTerrain) {
                base.processKeyAI(Canvas.LEFT);
            }
            keyDirection = Canvas.LEFT;
            this.lastKeyDirection = keyDirection;
            xTotalDistance = 0;
            base.processKeyAI(Canvas.KEY_NUM1);
        } else if (direction == directionFactory.RIGHT) {
            if (this.lastKeyDirection != keyDirection || !this.isFollowLimitedByTerrain) {
                base.processKeyAI(Canvas.RIGHT);
            }
            keyDirection = Canvas.RIGHT;
            this.lastKeyDirection = keyDirection;
            xTotalDistance = 0;
            base.processKeyAI(Canvas.KEY_NUM1);
        } else {
            base.processKeyAI(this.keyDirection);
        }
    }

    private Direction setFiringDirectionForTargetIfInRange()
    {
        DirectionFactory directionFactory = DirectionFactory.getInstance();
        AllBinaryLayer ownerLayerInterface = this.getOwnerLayerInterface();
        Direction direction = directionFactory.NOT_BORDERED_WITH;
        TrackingEvent lastTrackingEvent = null;
        LayerInterface lastTrackingLayerInterface = null;
        DirectionCompositeInterface directionCompositeInterface = null;
        int size = this.trackingList.size();
        for (int index = 0; index < size; index++) {
            lastTrackingEvent = ((TrackingEvent) this.trackingList.get(0));
            lastTrackingLayerInterface = lastTrackingEvent.getLayerInterface();
            int x = lastTrackingLayerInterface.getXP();
            int y = lastTrackingLayerInterface.getYP();
            int yDistance = ownerLayerInterface.getYP() - y - ownerLayerInterface.getHeight();
            int xDistance = ownerLayerInterface.getXP() - x - ownerLayerInterface.getWidth();
            int absXDistance = Math.Abs(xDistance);
            int absYDistance = Math.Abs(yDistance);
            if (absYDistance <= 100) {
                if (absXDistance < getFiringDistance() / 2) {
                    directionCompositeInterface = ((DirectionCompositeInterface) this.getOwnerLayerInterface());
                    if (xDistance < 0 && directionCompositeInterface.getDirection() == directionFactory.RIGHT) {
                        direction = directionFactory.RIGHT;
                    } else if (xDistance > 0 && directionCompositeInterface.getDirection() == directionFactory.LEFT) {
                        direction = directionFactory.LEFT;
                    }
                }
            }
        }
        return direction;
    }

    public override void disable()
    {
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public override void onMovement(TrackingEvent trackingEvent)
    {
        this.trackingList.clear();
        this.trackingList.add(trackingEvent);
    }

    public virtual int getFiringDistance()
    {
        return this.firingDistance;
    }

    public virtual void setFiringDistance(int firingDistance)
    {
        this.firingDistance = firingDistance;
    }

}

