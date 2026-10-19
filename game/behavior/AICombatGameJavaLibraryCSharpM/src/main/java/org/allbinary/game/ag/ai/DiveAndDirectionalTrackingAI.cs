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
using ArtificialIntelligenceInterface = org.allbinary.ai.ArtificialIntelligenceInterface;
using Direction = org.allbinary.direction.Direction;
using DirectionFactory = org.allbinary.direction.DirectionFactory;
using DirectionalCompositeInterface = org.allbinary.direction.DirectionalCompositeInterface;
using DirectionalInterface = org.allbinary.direction.DirectionalInterface;
using BasicAI = org.allbinary.game.ai.BasicAI;
using DestroyedEvent = org.allbinary.game.combat.destroy.@event.DestroyedEvent;
using DestroyedEventHandler = org.allbinary.game.combat.destroy.@event.DestroyedEventHandler;
using DestroyedEventListenerInterface = org.allbinary.game.combat.destroy.@event.DestroyedEventListenerInterface;
using GameInput = org.allbinary.game.input.GameInput;
using BasicVelocityProperties = org.allbinary.game.physics.velocity.BasicVelocityProperties;
using VelocityInterfaceCompositeInterface = org.allbinary.game.physics.velocity.VelocityInterfaceCompositeInterface;
using TrackingEvent = org.allbinary.game.tracking.TrackingEvent;
using TrackingEventHandler = org.allbinary.game.tracking.TrackingEventHandler;
using TrackingEventListenerInterface = org.allbinary.game.tracking.TrackingEventListenerInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using MathUtil = org.allbinary.logic.math.MathUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.ag.ai;

public class DiveAndDirectionalTrackingAI : BasicAI, TrackingEventListenerInterface, DestroyedEventListenerInterface
{
    private readonly MathUtil mathUtil = MathUtil.getInstance();
    private readonly DirectionFactory directionFactory = DirectionFactory.getInstance();
    private readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(500);
    private readonly BasicArrayList list = new BasicArrayListD();
    private readonly DirectionalInterface directionalInterface;
    private readonly BasicVelocityProperties velocityInterface;
    private readonly int[] directionToKeyMap = new int[] { Canvas.LEFT, Canvas.DOWN, Canvas.UP, Canvas.RIGHT };
    private bool initialDropped = false;
    private bool diveP = false;
    private Direction directionOfTarget = Direction.getInstance(0);
    private readonly int MIN_DISTANCE = 40;
    private AllBinaryLayer lastTrackingLayerInterface = AllBinaryLayer.NULL_ALLBINARY_LAYER;
    private readonly ArtificialIntelligenceInterface artificialIntelligenceInterface;
    private readonly Visitor aiVistor;
    private Direction lastDirection = DirectionFactory.getInstance().NO_DIRECTION;
    public DiveAndDirectionalTrackingAI(AllBinaryLayer ownerLayerInterface, ArtificialIntelligenceInterface artificialIntelligenceInterface, GameInput gameInput, Visitor visitor) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        this.aiVistor = visitor;
        this.artificialIntelligenceInterface = artificialIntelligenceInterface;
        DirectionalCompositeInterface directionalCompositeInterface = ((DirectionalCompositeInterface) this.getOwnerLayerInterface());
        this.directionalInterface = directionalCompositeInterface.getDirectionalInterface();
        VelocityInterfaceCompositeInterface velocityInterfaceCompositeInterface = ((VelocityInterfaceCompositeInterface) this.getOwnerLayerInterface());
        this.velocityInterface = velocityInterfaceCompositeInterface.getVelocityProperties();
        DestroyedEventHandler.getInstance().addListenerInterface(this);
        this.init();
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (this.isBeyondTarget()) {
            this.init();
            this.velocityInterface.zero();
        }
        if (!this.diveP) {
            this.target(allBinaryLayerManager);
        } else {
            this.dive();
            this.attack();
        }
        this.list.clear();
    }

    private void init()
    {
        this.diveP = false;
        this.directionOfTarget = DirectionFactory.getInstance().NOT_BORDERED_WITH;
        TrackingEventHandler.getInstance().addListenerInterface(this);
    }

    // throws Exception
    private void target(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (this.list.size() == 0) {
            return;
        }
        TrackingEvent lastTrackingEvent = ((TrackingEvent) this.list.removeAt(0));
        this.lastTrackingLayerInterface = lastTrackingEvent.getLayerInterface();
        AllBinaryLayer layerInterface = this.lastTrackingLayerInterface;
        AllBinaryLayer ownerLayerInterface = this.getOwnerLayerInterface();
        if (layerInterface.getGroupInterface() == ownerLayerInterface.getGroupInterface()) {
            return;
        }
        int x = this.lastTrackingLayerInterface.getXP();
        int y = this.lastTrackingLayerInterface.getYP();
        int yDistance = ownerLayerInterface.getYP() - y - ownerLayerInterface.getHeight();
        int xDistance = ownerLayerInterface.getXP() - x - ownerLayerInterface.getWidth();
        DirectionFactory directionFactory = DirectionFactory.getInstance();
        if (this.mathUtil.abs(yDistance) > this.mathUtil.abs(xDistance)) {
            if (yDistance > this.MIN_DISTANCE) {
                this.directionOfTarget = directionFactory.UP;
            } else if (yDistance < -this.MIN_DISTANCE) {
                this.directionOfTarget = directionFactory.DOWN;
            }
        } else {
            if (xDistance > this.MIN_DISTANCE) {
                this.directionOfTarget = directionFactory.LEFT;
            } else if (xDistance < -this.MIN_DISTANCE) {
                this.directionOfTarget = directionFactory.RIGHT;
            }
        }
        if (!this.initialDropped && this.directionOfTarget != directionFactory.NOT_BORDERED_WITH) {
            this.drop();
        }
        if (this.initialDropped) {
            if (this.directionOfTarget == directionFactory.UP || this.directionOfTarget == directionFactory.DOWN) {
                this.verticalTargeting(x);
            } else if (this.directionOfTarget == directionFactory.LEFT || this.directionOfTarget == directionFactory.RIGHT) {
                this.horizontalTargeting(y);
            } else {
                this.artificialIntelligenceInterface.processAI(allBinaryLayerManager);
            }
        }
    }

    // throws Exception
    private void verticalTargeting(int x)
    {
        AllBinaryLayer ownerLayerInterface = this.getOwnerLayerInterface();
        if (ownerLayerInterface.getXP() < x) {
            this.moveRight();
        }
        if (ownerLayerInterface.getXP() > x) {
            this.moveLeft();
        }
        if (ownerLayerInterface.getXP() > x - 3 && ownerLayerInterface.getXP() < x + 3) {
            this.setDive();
        }
    }

    // throws Exception
    private void horizontalTargeting(int y)
    {
        AllBinaryLayer ownerLayerInterface = this.getOwnerLayerInterface();
        if (ownerLayerInterface.getYP() < y) {
            this.moveDown();
        }
        if (ownerLayerInterface.getYP() > y) {
            this.moveUp();
        }
        if (ownerLayerInterface.getYP() > y - 3 && ownerLayerInterface.getYP() < y + 3) {
            this.setDive();
        }
    }

    private void setDive()
    {
        this.diveP = true;
        this.velocityInterface.zero();
        TrackingEventHandler.getInstance().removeListener(this);
    }

    // throws Exception
    private void moveRight()
    {
        this.setLastDirection(this.directionFactory.RIGHT);
        this.directionalInterface.setFrameByDirection(this.lastDirection);
        this.aiVistor.visit(this);
    }

    // throws Exception
    private void moveLeft()
    {
        this.setLastDirection(this.directionFactory.LEFT);
        this.directionalInterface.setFrameByDirection(this.lastDirection);
        this.aiVistor.visit(this);
    }

    // throws Exception
    private void moveDown()
    {
        this.setLastDirection(this.directionFactory.DOWN);
        this.directionalInterface.setFrameByDirection(this.lastDirection);
        this.aiVistor.visit(this);
    }

    // throws Exception
    private void moveUp()
    {
        this.setLastDirection(this.directionFactory.UP);
        this.directionalInterface.setFrameByDirection(this.lastDirection);
        this.aiVistor.visit(this);
    }

    // throws Exception
    private void dive()
    {
        this.directionalInterface.setFrameByDirection(this.directionOfTarget);
        this.aiVistor.visit(this);
    }

    // throws Exception
    private void attack()
    {
        base.processKeyAI(Canvas.KEY_NUM1);
    }

    // throws Exception
    private void drop()
    {
        if (this.timeDelayHelper.isTime(this.gameTickTimeDelayHelper.startTime)) {
            this.initialDropped = true;
            this.aiVistor.visit(this);
        }
    }

    private bool isBeyondTarget()
    {
        if (this.directionOfTarget == this.directionFactory.DOWN) {
            if (this.getOwnerLayerInterface().getYP() > this.lastTrackingLayerInterface.getYP() + this.MIN_DISTANCE) {
                return true;
            } else {
                return false;
            }
        } else if (this.directionOfTarget == this.directionFactory.UP) {
            if (this.getOwnerLayerInterface().getYP() < this.lastTrackingLayerInterface.getYP() + this.MIN_DISTANCE) {
                return true;
            } else {
                return false;
            }
        } else if (this.directionOfTarget == this.directionFactory.RIGHT) {
            if (this.getOwnerLayerInterface().getXP() > this.lastTrackingLayerInterface.getXP() + this.MIN_DISTANCE) {
                return true;
            } else {
                return false;
            }
        } else if (this.directionOfTarget == this.directionFactory.LEFT) {
            if (this.getOwnerLayerInterface().getXP() < this.lastTrackingLayerInterface.getXP() + this.MIN_DISTANCE) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public override void onMovement(TrackingEvent trackingEvent)
    {
        this.list.add(trackingEvent);
    }

    public override void onDestroyed(DestroyedEvent destroyedEvent)
    {
        if (this.getOwnerLayerInterface() == destroyedEvent.getLayerInterface()) {
            TrackingEventHandler.getInstance().removeListener(this);
            DestroyedEventHandler.getInstance().removeListener(this);
        }
    }

    public virtual void setLastDirection(Direction lastDirection)
    {
        this.lastDirection = lastDirection;
        int value = this.getLastDirection().getValue();
        if (value < 4) {
            base.setLastKey(this.directionToKeyMap[value]);
        }
    }

    public override void setLastKey(int lastKey)
    {
        base.setLastKey(lastKey);
        if (this.getLastKey() == Canvas.LEFT) {
            this.lastDirection = DirectionFactory.getInstance().LEFT;
        } else if (this.getLastKey() == Canvas.DOWN) {
            this.lastDirection = DirectionFactory.getInstance().DOWN;
        } else if (this.getLastKey() == Canvas.UP) {
            this.lastDirection = DirectionFactory.getInstance().UP;
        } else if (this.getLastKey() == Canvas.RIGHT) {
            this.lastDirection = DirectionFactory.getInstance().RIGHT;
        }
    }

    public virtual Direction getLastDirection()
    {
        return this.lastDirection;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(base.ToString());
        stringBuffer.append(" LastDirection: ");
        stringBuffer.append(StringUtil.getInstance().toString(this.getLastDirection()));
        return stringBuffer.ToString();
    }

}

