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
//using Graphics = javax.microedition.lcdui.Graphics;
using BoundsVisitorInterface = org.allbinary.bounds.BoundsVisitorInterface;
using LayerBounds = org.allbinary.bounds.LayerBounds;
using BasicAI = org.allbinary.game.ai.BasicAI;
using GameInput = org.allbinary.game.input.GameInput;
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.game.ag.ai;

public class BoundBounceAI : BasicAI
{
    public int currentRelativeAngle = 0;
    private LayerBounds layerBounds;
    private BoundsVisitorInterface boundsVisitorInterface;
    public BoundBounceAI(AllBinaryLayer ownerLayerInterface, GameInput gameInput, LayerBounds layerBounds, BoundsVisitorInterface boundsVisitorInterface) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        this.layerBounds = layerBounds;
        this.boundsVisitorInterface = boundsVisitorInterface;
    }

    public virtual void paint(Graphics graphics)
    {
        Rectangle rectange = this.layerBounds.getRectangleP();
        graphics.drawRect(rectange.getPoint().getX(), rectange.getPoint().getY(), rectange.getWidth(), rectange.getHeight());
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        this.layerBounds.visit(this.boundsVisitorInterface);
    }

}

