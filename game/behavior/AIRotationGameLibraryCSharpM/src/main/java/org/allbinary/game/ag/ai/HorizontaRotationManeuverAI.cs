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
using ArtificialIntelligence = org.allbinary.ai.ArtificialIntelligence;
using ArtificialIntelligenceTransitionInterface = org.allbinary.ai.ArtificialIntelligenceTransitionInterface;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using RotationAnimationInterface = org.allbinary.animation.RotationAnimationInterface;
using RotationAnimationInterfaceCompositeInterface = org.allbinary.animation.RotationAnimationInterfaceCompositeInterface;
using BasicAI = org.allbinary.game.ai.BasicAI;
using GameInput = org.allbinary.game.input.GameInput;
using BasicVelocityProperties = org.allbinary.game.physics.velocity.BasicVelocityProperties;
using VelocityInterface = org.allbinary.game.physics.velocity.VelocityInterface;
using VelocityInterfaceCompositeInterface = org.allbinary.game.physics.velocity.VelocityInterfaceCompositeInterface;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using AngleIncrementInfo = org.allbinary.math.AngleIncrementInfo;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.game.ag.ai;

public class HorizontaRotationManeuverAI : BasicAI, ArtificialIntelligenceTransitionInterface
{
    private readonly CircularIndexUtil circularIndexUtil = CircularIndexUtil.createInstanceAt(10, int.MaxValue);
    private int currentSpeedDivisor = 5;
    private readonly IndexedAnimation rotationAnimationInterface;
    private readonly BasicVelocityProperties baseVelocityInterface;
    private readonly VelocityInterface velocityInterface;
    public HorizontaRotationManeuverAI(AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        RotationAnimationInterfaceCompositeInterface rotationAnimationInterfaceCompositeInterface = ((RotationAnimationInterfaceCompositeInterface) this.getOwnerLayerInterface());
        this.rotationAnimationInterface = rotationAnimationInterfaceCompositeInterface.getRotationAnimationInterface();
        VelocityInterfaceCompositeInterface velocityInterfaceCompositeInterface = ((VelocityInterfaceCompositeInterface) this.getOwnerLayerInterface());
        this.baseVelocityInterface = velocityInterfaceCompositeInterface.getVelocityProperties();
        this.velocityInterface = ((VelocityInterface) this.baseVelocityInterface);
        RotationAnimationInterface rotationAnimationInterface = ((RotationAnimationInterface) this.rotationAnimationInterface);
        AngleIncrementInfo angleIncrementInfo = rotationAnimationInterface.getAngleInfoP().getAngleIncrementInfo();
        rotationAnimationInterfaceCompositeInterface.setFrame(((int) angleIncrementInfo.RIGHT_FRAME));
    }

    public override void transition()
    {
        RotationAnimationInterface rotationAnimationInterface = ((RotationAnimationInterface) this.rotationAnimationInterface);
        AngleIncrementInfo angleIncrementInfo = rotationAnimationInterface.getAngleInfoP().getAngleIncrementInfo();
        RotationAnimationInterfaceCompositeInterface rotationAnimationInterfaceCompositeInterface = ((RotationAnimationInterfaceCompositeInterface) this.getOwnerLayerInterface());
        rotationAnimationInterfaceCompositeInterface.setFrame(((int) angleIncrementInfo.RIGHT_FRAME));
        AllBinaryLayer allbinaryLayer = this.getOwnerLayerInterface();
        allbinaryLayer.setPosition(allbinaryLayer.getXP(), 1, allbinaryLayer.getZP());
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        RotationAnimationInterface rotationAnimationInterface = (((RotationAnimationInterface) this.rotationAnimationInterface));
        AngleIncrementInfo angleIncrementInfo = rotationAnimationInterface.getAngleInfoP().getAngleIncrementInfo();
        int frame = this.rotationAnimationInterface.getFrame();
        AllBinaryLayer ownerLayerInterface = this.getOwnerLayerInterface();
        if (ownerLayerInterface.getXP() - ownerLayerInterface.getWidth() <= 0 && frame == ((int) angleIncrementInfo.LEFT_FRAME)) {
            this.reverse();
            this.drop();
        }
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        if (ownerLayerInterface.getX2() + ownerLayerInterface.getWidth() > displayInfo.getLastWidth() && frame == ((int) angleIncrementInfo.RIGHT_FRAME)) {
            this.reverse();
            this.accelerate();
            this.drop();
        }
        int index = this.circularIndexUtil.getIndex();
        if (index % this.currentSpeedDivisor == 0 && index % 2 == 0) {
            base.processKeyAI(Canvas.UP);
            this.velocityInterface.limitMaxXYVelocity(this.velocityInterface.getMaxForwardVelocity() / this.currentSpeedDivisor);
        }
        this.circularIndexUtil.next();
        if (frame == ((int) angleIncrementInfo.LEFT_FRAME)) {
            base.processKeyAI(Canvas.KEY_NUM0);
        } else if (frame == ((int) angleIncrementInfo.RIGHT_FRAME)) {
            base.processKeyAI(Canvas.KEY_POUND);
        }
    }

    protected virtual void reverse()
    {
        RotationAnimationInterface rotationAnimationInterface = ((RotationAnimationInterface) this.rotationAnimationInterface);
        AngleIncrementInfo angleIncrementInfo = rotationAnimationInterface.getAngleInfoP().getAngleIncrementInfo();
        int frame = this.rotationAnimationInterface.getFrame();
        if (frame == ((int) angleIncrementInfo.LEFT_FRAME)) {
            RotationAnimationInterfaceCompositeInterface rotationAnimationInterfaceCompositeInterface = ((RotationAnimationInterfaceCompositeInterface) this.getOwnerLayerInterface());
            rotationAnimationInterfaceCompositeInterface.setFrame(((int) angleIncrementInfo.RIGHT_FRAME));
            this.baseVelocityInterface.zero();
        } else if (frame == ((int) angleIncrementInfo.RIGHT_FRAME)) {
            RotationAnimationInterfaceCompositeInterface rotationAnimationInterfaceCompositeInterface = ((RotationAnimationInterfaceCompositeInterface) this.getOwnerLayerInterface());
            rotationAnimationInterfaceCompositeInterface.setFrame(((int) angleIncrementInfo.LEFT_FRAME));
            this.baseVelocityInterface.zero();
        }
    }

    private void accelerate()
    {
        if (this.currentSpeedDivisor > 1) {
            this.currentSpeedDivisor--;
        }
    }

    private void drop()
    {
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        AllBinaryLayer ownerLayerInterface = this.getOwnerLayerInterface();
        int y = ownerLayerInterface.getYP();
        if (ownerLayerInterface.getY2() + ownerLayerInterface.getHeight() > displayInfo.getLastHeight()) {
            y = 0;
        } else {
            y += ownerLayerInterface.getHeight() + 1;
        }
        ownerLayerInterface.setPosition(ownerLayerInterface.getXP(), y, ownerLayerInterface.getZP());
    }

    public override int getId()
    {
        return ArtificialIntelligence.AI_ID;
    }

}

