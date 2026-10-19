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
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using TextAnimation = org.allbinary.animation.text.TextAnimation;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.animation.caption;

public class CaptionAnimationHelper : CaptionAnimationHelperBase
{
    private readonly TimeDelayHelper timeHelper = new TimeDelayHelper(620);
    private readonly TextAnimation textAnimation = new TextAnimation(StringUtil.getInstance().EMPTY_STRING, AnimationBehavior.getInstance());
    private readonly Animation captionAnimation;
    private Animation animation = NullAnimationFactory.getFactoryInstance().getInstance(0);
    public CaptionAnimationHelper(Animation captionAnimation, int captionDx, int captionDy, int dx, int dy)
    {
        this.captionAnimation = new CaptionAnimation(captionAnimation, this.textAnimation, captionDx, captionDy, dx, dy);
    }

    public override bool isShowing()
    {
        if (this.animation == this.captionAnimation) {
            return true;
        } else {
            return false;
        }
    }

    public override void tick()
    {
        if (this.timeHelper.isTime(GameTickTimeDelayHelperFactory.getInstance().startTime)) {
            this.animation = NullAnimationFactory.getFactoryInstance().getInstance(0);
        }
    }

    public override void update(string message, BasicColor basicColor)
    {
        this.textAnimation.setBasicColorP(basicColor);
        this.textAnimation.setText(message);
        this.animation = this.captionAnimation;
        this.timeHelper.setStartTimeTNT();
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.animation.paintXY(graphics, x, y);
    }

}

