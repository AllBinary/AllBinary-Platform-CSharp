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
using BasicHud = org.allbinary.game.graphics.hud.BasicHud;
using Health = org.allbinary.game.health.Health;
using HealthListenerInterface = org.allbinary.game.health.HealthListenerInterface;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using NoTimeDelayHelper = org.allbinary.time.NoTimeDelayHelper;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.game.ag.layer.hud.basic.health;

public class HealthHudWidget : BasicHud, PaintableInterface, HealthListenerInterface
{
    private int healthScale;
    public Animation animationInterface;
    public Health healthInterface;
    public int max = 0;
    private int[] xArray;
    private readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    public HealthHudWidget(Animation animationInterface, Health healthInterface, int location, int direction) : base(location, direction, 2, BasicColorFactory.getInstance().WHITE)
    {
        // base(location, direction, 2, BasicColorFactory.getInstance().WHITE) is called from the constructor declaration
        this.animationInterface = animationInterface;
        this.healthInterface = healthInterface;
        this.healthInterface.addListener(this);
        this.healthScale = (this.healthInterface.getMaxHealth() / 6) + 1;
        this.onHealthChange();
        this.updateMaxWidth = healthInterface.getMaxHealth() * 16;
        this.updateMaxHeight = 16;
        this.xArray = new int[30];
        this.update();
    }

    private void update()
    {
        if (this.xArray != null) {
            for (int index = 0; index < this.xArray.Length; index++) {
                this.xArray[index] = this.getX() + (index * 16);
            }
        }
    }

    public override void setX(int x)
    {
        base.setX(x);
        this.update();
    }

    private TimeDelayHelper timeDelayHelper = NoTimeDelayHelper.SINGLETON;
    private readonly TimeDelayHelper slowBeatTimeDelayHelper = new TimeDelayHelper(1280);
    private readonly TimeDelayHelper mediumBeatTimeDelayHelper = new TimeDelayHelper(640);
    private readonly TimeDelayHelper fastBeatTimeDelayHelper = new TimeDelayHelper(320);
    public override void onHealthChange()
    {
        this.max = (this.healthInterface.getHealth() / this.healthScale);
        this.timeDelayHelper = NoTimeDelayHelper.SINGLETON;
        if (this.max <= 1 && this.healthInterface.isAlive()) {
            this.max = 1;
            if (this.healthScale - this.healthInterface.getHealth() > (this.healthScale * 2) / 3) {
                this.timeDelayHelper = this.slowBeatTimeDelayHelper;
            } else if (this.healthScale - this.healthInterface.getHealth() > this.healthScale / 3) {
                this.timeDelayHelper = this.mediumBeatTimeDelayHelper;
            } else {
                this.timeDelayHelper = this.fastBeatTimeDelayHelper;
            }
        }
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        for (int index = 0; index < this.max; index++) {
            if (this.timeDelayHelper.isTime(this.gameTickTimeDelayHelper.startTime)) {
                this.animationInterface.paintXY(graphics, this.xArray[index], this.getY());
            }
        }
    }

    public override void paintThreed(Graphics graphics)
    {
    }

}

