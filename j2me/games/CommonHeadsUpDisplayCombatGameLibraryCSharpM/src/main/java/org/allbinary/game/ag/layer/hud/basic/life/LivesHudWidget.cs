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
using Animation = org.allbinary.animation.Animation;
using Life = org.allbinary.game.ag.life.Life;
using BasicHud = org.allbinary.game.graphics.hud.BasicHud;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using DisplayChangeEvent = org.allbinary.graphics.displayable.@event.DisplayChangeEvent;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;

namespace org.allbinary.game.ag.layer.hud.basic.life;

public class LivesHudWidget : BasicHud, PaintableInterface
{
    private readonly Life lifeInterface;
    private readonly int[] xArray;
    private readonly Animation animationInterface;
    public LivesHudWidget(Animation animationInterface, Life lifeInterface, int location, int direction) : base(location, direction, 2, BasicColorFactory.getInstance().WHITE)
    {
        // base(location, direction, 2, BasicColorFactory.getInstance().WHITE) is called from the constructor declaration
        this.lifeInterface = lifeInterface;
        int size = ((int) this.getLifeInterface().getMaxlives());
        this.xArray = new int[size];
        this.animationInterface = animationInterface;
        this.updateMaxWidth = this.lifeInterface.getMaxlives() * 16;
        this.updateMaxHeight = 16;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        base.updateMeasurement(graphics);
        int maxLives = ((int) this.getLifeInterface().getMaxlives());
        for (int index = 0; index < maxLives; index++) {
            this.xArray[index] = this.getX() + (index * 16);
        }
    }

    public override void onDisplayChangeEvent(DisplayChangeEvent displayChangeEvent)
    {
        base.onDisplayChangeEvent(displayChangeEvent);
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    public override void setX(int x)
    {
        base.setX(x);
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        for (int index = ((int) this.getLifeInterface().get()); --index >= 0; ) {
            this.animationInterface.paintXY(graphics, this.xArray[index], this.getY());
        }
    }

    public override void paintThreed(Graphics graphics)
    {
    }

    public virtual Life getLifeInterface()
    {
        return this.lifeInterface;
    }

}

