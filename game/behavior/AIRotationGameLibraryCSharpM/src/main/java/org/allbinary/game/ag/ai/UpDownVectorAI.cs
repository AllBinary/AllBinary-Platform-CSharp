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
using BasicAI = org.allbinary.game.ai.BasicAI;
using GameInput = org.allbinary.game.input.GameInput;
using BasicVelocityProperties = org.allbinary.game.physics.velocity.BasicVelocityProperties;
using VelocityInterfaceCompositeInterface = org.allbinary.game.physics.velocity.VelocityInterfaceCompositeInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using BasicDecimal = org.allbinary.logic.math.BasicDecimal;

namespace org.allbinary.game.ag.ai;

public class UpDownVectorAI : BasicAI
{
    private readonly BasicVelocityProperties velocityInterface;
    private int index = 0;
    public UpDownVectorAI(AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        VelocityInterfaceCompositeInterface velocityInterfaceCompositeInterface = ((VelocityInterfaceCompositeInterface) this.getOwnerLayerInterface());
        this.velocityInterface = velocityInterfaceCompositeInterface.getVelocityProperties();
        this.velocityInterface.getVelocityYBasicDecimalP().setint(0);
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        int y = this.getOwnerLayerInterface().getHeight() * 270;
        if (this.index < 5) {
            BasicDecimal basicDecimal = this.velocityInterface.getVelocityYBasicDecimalP();
            basicDecimal.setint(0);
            basicDecimal.addint(y);
            this.index++;
        } else if (this.index < 10) {
            BasicDecimal basicDecimal = this.velocityInterface.getVelocityYBasicDecimalP();
            basicDecimal.setint(0);
            basicDecimal.subtractint(y);
            this.index++;
        } else {
            this.index = 0;
            this.processAI(allBinaryLayerManager);
        }
    }

}

