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
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using RotationAnimationInterface = org.allbinary.animation.RotationAnimationInterface;
using RotationAnimationInterfaceCompositeInterface = org.allbinary.animation.RotationAnimationInterfaceCompositeInterface;
using LurchAI = org.allbinary.game.ag.ai.tactical.LurchAI;
using GameInput = org.allbinary.game.input.GameInput;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AngleIncrementInfo = org.allbinary.math.AngleIncrementInfo;

namespace org.allbinary.game.ag.ai;

public class LurchRotationAI : LurchAI
{
    private IndexedAnimation rotationAnimationInterface;
    public LurchRotationAI(AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        RotationAnimationInterfaceCompositeInterface rotationAnimationInterfaceCompositeInterface = ((RotationAnimationInterfaceCompositeInterface) this.getOwnerLayerInterface());
        this.rotationAnimationInterface = rotationAnimationInterfaceCompositeInterface.getRotationAnimationInterface();
        this.update();
    }

    public override void reverse()
    {
        base.reverse();
        this.update();
    }

    private void update()
    {
        if (this.currentRelativeAngle == 0) {
            RotationAnimationInterface rotationAnimationInterface = ((RotationAnimationInterface) this.rotationAnimationInterface);
            AngleIncrementInfo angleIncrementInfo = rotationAnimationInterface.getAngleInfoP().getAngleIncrementInfo();
            RotationAnimationInterfaceCompositeInterface rotationAnimationInterfaceCompositeInterface = ((RotationAnimationInterfaceCompositeInterface) this.getOwnerLayerInterface());
            rotationAnimationInterfaceCompositeInterface.setFrame(((int) angleIncrementInfo.RIGHT_FRAME));
        } else if (this.currentRelativeAngle == 180) {
            RotationAnimationInterface rotationAnimationInterface = ((RotationAnimationInterface) this.rotationAnimationInterface);
            AngleIncrementInfo angleIncrementInfo = rotationAnimationInterface.getAngleInfoP().getAngleIncrementInfo();
            RotationAnimationInterfaceCompositeInterface rotationAnimationInterfaceCompositeInterface = ((RotationAnimationInterfaceCompositeInterface) this.getOwnerLayerInterface());
            rotationAnimationInterfaceCompositeInterface.setFrame(((int) angleIncrementInfo.LEFT_FRAME));
        }
    }

}

