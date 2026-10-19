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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.health;

public class HealthBarTwodAnimation : HealthBarAnimation
{
    public HealthBarTwodAnimation(AllBinaryLayer layerInterface, int location) : base(layerInterface, location)
    {
        // base(layerInterface, location) is called from the constructor declaration
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        int ax = this.allbinaryLayer.getViewPosition().getX();
        this.basicSetColorUtil.setBasicColorP3(graphics, this.basicColor, this.colorP);
        graphics.fillRect(ax, this.getY() - 1, this.x2, this.thickness);
    }

}

