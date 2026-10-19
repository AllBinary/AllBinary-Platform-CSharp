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
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.game.ag.ai;

public class StopAtEdgeAI : BasicAI
{
    public StopAtEdgeAI(AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        AllBinaryLayer ownerLayerInterface = this.getOwnerLayerInterface();
        VelocityInterfaceCompositeInterface velocityInterfaceCompositeInterface = (((VelocityInterfaceCompositeInterface) ownerLayerInterface));
        BasicVelocityProperties velocityProperties = velocityInterfaceCompositeInterface.getVelocityProperties();
        int x = ownerLayerInterface.getXP();
        int y = ownerLayerInterface.getYP();
        int x2 = ownerLayerInterface.getX2();
        int y2 = ownerLayerInterface.getY2();
        int width = ownerLayerInterface.getWidth();
        int height = ownerLayerInterface.getHeight();
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        if (x2 + velocityProperties.getVelocityXBasicDecimalP().getScaled() > displayInfo.getLastWidth()) {
            ownerLayerInterface.setPosition(displayInfo.getLastWidth() - width, y, ownerLayerInterface.getZP());
            velocityProperties.getVelocityYBasicDecimalP().setint(0);
        }
        if (y2 + velocityProperties.getVelocityYBasicDecimalP().getScaled() > displayInfo.getLastHeight()) {
            ownerLayerInterface.setPosition(x, displayInfo.getLastHeight() - height, ownerLayerInterface.getZP());
            velocityProperties.getVelocityXBasicDecimalP().setint(0);
        }
        if (x + velocityProperties.getVelocityXBasicDecimalP().getScaled() < 0) {
            ownerLayerInterface.setPosition(0, y, ownerLayerInterface.getZP());
            velocityProperties.getVelocityYBasicDecimalP().setint(0);
        }
        if (y + velocityProperties.getVelocityYBasicDecimalP().getScaled() < 0) {
            ownerLayerInterface.setPosition(x, 0, ownerLayerInterface.getZP());
            velocityProperties.getVelocityXBasicDecimalP().setint(0);
        }
    }

}

