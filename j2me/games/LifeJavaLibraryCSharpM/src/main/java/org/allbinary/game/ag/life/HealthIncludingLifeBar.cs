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
using Health = org.allbinary.game.health.Health;
using HealthBarAnimation = org.allbinary.game.health.HealthBarAnimation;
using HealthBarTwodAnimation = org.allbinary.game.health.HealthBarTwodAnimation;
using HealthInterface = org.allbinary.game.health.HealthInterface;
using HealthListenerInterface = org.allbinary.game.health.HealthListenerInterface;
using Paintable = org.allbinary.graphics.paint.Paintable;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.ag.life;

public class HealthIncludingLifeBar : Paintable, HealthListenerInterface
{
    // throws Exception
    public static HealthIncludingLifeBar createHealthIncludingLifeBar(AllBinaryLayer layerInterface, Life life, Health healthInterface, int location, int direction)
    {
        return new HealthIncludingLifeBar(layerInterface, life, healthInterface, new HealthBarTwodAnimation(layerInterface, location), direction);
    }

    private readonly HealthBarAnimation animationInterface;
    private readonly Life life;
    private readonly HealthInterface healthInterface;
    public readonly AllBinaryLayer allbinaryLayer;
    public HealthIncludingLifeBar(AllBinaryLayer layerInterface, Life life, Health healthInterface, HealthBarAnimation animationInterface, int direction)
    {
        this.allbinaryLayer = layerInterface;
        this.animationInterface = animationInterface;
        this.life = life;
        this.healthInterface = healthInterface;
        this.healthInterface.addListener(this);
        this.onHealthChange();
    }

    public override void onHealthChange()
    {
        this.animationInterface.onHealthChange(((this.healthInterface.getHealth() + (this.healthInterface.getMaxHealth() * this.life.get())) * this.allbinaryLayer.getWidth()) / (this.healthInterface.getMaxHealth() + (this.healthInterface.getMaxHealth() * this.life.getStartLives())));
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

