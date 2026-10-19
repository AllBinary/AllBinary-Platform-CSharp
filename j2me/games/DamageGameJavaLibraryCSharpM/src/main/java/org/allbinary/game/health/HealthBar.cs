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
using Paintable = org.allbinary.graphics.paint.Paintable;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.health;

public class HealthBar : Paintable, HealthListenerInterface
{
    private readonly HealthBarAnimation animationInterface;
    private readonly HealthInterface healthInterface;
    public readonly AllBinaryLayer allbinaryLayer;
    public HealthBar(AllBinaryLayer layerInterface, Health healthInterface, HealthBarAnimation animationInterface, int direction)
    {
        this.allbinaryLayer = layerInterface;
        this.animationInterface = animationInterface;
        this.healthInterface = healthInterface;
        this.healthInterface.addListener(this);
        this.onHealthChange();
    }

    public override void onHealthChange()
    {
        this.animationInterface.onHealthChange(this.healthInterface.getHealth() * this.allbinaryLayer.getWidth() / this.healthInterface.getMaxHealth());
    }

    public override void paint(Graphics graphics)
    {
        this.animationInterface.paintXY(graphics, 0, 0);
    }

    public override void paintThreed(Graphics graphics)
    {
        this.animationInterface.paintThreedXYZ(graphics, 0, 0, 0);
    }

}

