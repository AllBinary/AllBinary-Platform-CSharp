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
using Graphics = javax.microedition.lcdui.Graphics;
using Image = javax.microedition.lcdui.Image;
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
        for (int numOfHealth_0 = 0; numOfHealth_0 <= max; numOfHealth_0++) {
            this.image[numOfHealth_0] = imageCacheFactory.get(this, numOfHealth_0 + 1 * 10, 10);
        }
        for (int numOfHealth_1 = 0; numOfHealth_1 <= max; numOfHealth_1++) {
            for (int index = 0; index < numOfHealth_1; index++) {
                this.animationInterface.paint(this.image[numOfHealth_1].getGraphics(), numOfHealth_1 * 10, 0);
            }
        }
    }

    public virtual void paint(Graphics graphics)
    {
        graphics.drawImage(this.image[max], x, y, Anchor.TOP_LEFT);
    }

}

