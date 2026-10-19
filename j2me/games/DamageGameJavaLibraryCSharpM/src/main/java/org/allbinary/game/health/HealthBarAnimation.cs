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
using Animation = org.allbinary.animation.Animation;
using BasicHudFactory = org.allbinary.game.graphics.hud.BasicHudFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.health;

public class HealthBarAnimation : Animation
{
    private readonly BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
    public int x2 = 0;
    public int thickness = 0;
    private int location;
    public AllBinaryLayer allbinaryLayer;
    public HealthBarAnimation(AllBinaryLayer layerInterface, int location)
    {
        this.allbinaryLayer = layerInterface;
        this.location = location;
        BasicHudFactory basicHudFactory = BasicHudFactory.getInstance();
        if (this.location != basicHudFactory.TOPLEFT && this.location != basicHudFactory.BOTTOMLEFT) {
            throw new Exception("Location Not Valid");
        }
        if (layerInterface.getWidth() > 40) {
            this.thickness = 3;
        } else if (layerInterface.getWidth() > 20) {
            this.thickness = 2;
        } else {
            this.thickness = 1;
        }
    }

    public virtual void onHealthChange(int newX2)
    {
        this.x2 = newX2;
        int quarter = (this.allbinaryLayer.getWidth() >> 2);
        if (this.x2 > quarter * 3) {
            this.basicColor = this.basicColorFactory.GREEN;
            this.colorP = ((int) this.basicColor);
        } else if (this.x2 > quarter * 2) {
            this.basicColor = this.basicColorFactory.YELLOW;
            this.colorP = ((int) this.basicColor);
        } else if (this.x2 > quarter) {
            this.basicColor = this.basicColorFactory.ORANGE;
            this.colorP = ((int) this.basicColor);
        } else {
            this.basicColor = this.basicColorFactory.RED;
            this.colorP = ((int) this.basicColor);
        }
    }

    protected virtual int getY()
    {
        BasicHudFactory basicHudFactory = BasicHudFactory.getInstance();
        if (this.location == basicHudFactory.TOPLEFT) {
            return this.allbinaryLayer.getViewPosition().getY() - 4;
        } else if (this.location == basicHudFactory.BOTTOMLEFT) {
            return this.allbinaryLayer.getViewPosition().getY2() + 4;
        }
        return -1;
    }

}

