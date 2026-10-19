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
using ArtificialIntelligenceInterface = org.allbinary.ai.ArtificialIntelligenceInterface;
using TopULayerBounds = org.allbinary.bounds.TopULayerBounds;
using ArtificialIntelligenceInterfaceFactoryInterface = org.allbinary.game.ai.ArtificialIntelligenceInterfaceFactoryInterface;
using GameInput = org.allbinary.game.input.GameInput;
using VelocityInterface = org.allbinary.game.physics.velocity.VelocityInterface;
using VelocityInterfaceCompositeInterface = org.allbinary.game.physics.velocity.VelocityInterfaceCompositeInterface;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai;

public class TopUBoundBounceAIFactory : ArtificialIntelligenceInterfaceFactoryInterface
{
    // throws Exception
    public virtual ArtificialIntelligenceInterface getInstance(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput)
    {
        VelocityInterfaceCompositeInterface velocityInterfaceCompositeInterface = ((VelocityInterfaceCompositeInterface) ownerLayerInterface);
        VelocityInterface velocityInterface = ((VelocityInterface) velocityInterfaceCompositeInterface.getVelocityProperties());
        int maxDistancePerTick = (velocityInterface.getMaxForwardVelocity() >> velocityInterface.getVelocityXBasicDecimalP().getScaledFactor());
        int halfWidth = ownerLayerInterface.getWidth() * 2 + maxDistancePerTick + 1;
        int halfHeight = ownerLayerInterface.getHeight() * 2 + maxDistancePerTick + 1;
        GPoint point = PointFactory.getInstance().createXY(halfWidth, halfHeight + 60);
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        Rectangle rectangle = new Rectangle(point, (displayInfo.getLastWidth() - halfWidth - point.getX()), (displayInfo.getLastHeight() - halfHeight - point.getY()));
        return new BoundBounceAI(ownerLayerInterface, gameInput, new TopULayerBounds(rectangle), new ReverseVelocityBoundsVisitor(ownerLayerInterface));
    }

}

