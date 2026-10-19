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
//using Image = javax.microedition.lcdui.Image;
using AnimationInterface = org.allbinary.animation.AnimationInterface;
using HealthInterface = org.allbinary.game.health.HealthInterface;
using Anchor = org.allbinary.graphics.Anchor;
using ImageCacheFactory = org.allbinary.image.ImageCacheFactory;

namespace org.allbinary.game.layer.hud.basic;

public class ImageHealthGraphic : HealthGraphic
{
    private Image[] image;
    public ImageHealthGraphic(AnimationInterface animationInterface, HealthInterface healthInterface, int location, int direction) : base(animationInterface, healthInterface, location, direction)
    {
        // base(animationInterface, healthInterface, location, direction) is called from the constructor declaration
        this.image = new Image[this.healthInterface.getMaxHealth()];
        ImageCacheFactory imageCacheFactory = ImageCacheFactory.getInstance();
        for (int numOfHealth = 0; numOfHealth <= max; numOfHealth++) {
            this.image[numOfHealth] = imageCacheFactory.get(this, numOfHealth + 1 * 10, 10);
        }
        for (int numOfHealth = 0; numOfHealth <= max; numOfHealth++) {
            for (int index = 0; index < numOfHealth; index++) {
                this.animationInterface.paint(this.image[numOfHealth].getGraphics(), numOfHealth * 10, 0);
            }
        }
    }

    public virtual void paint(Graphics graphics)
    {
        graphics.drawImage(this.image[max], x, y, Anchor.TOP_LEFT);
    }

}

