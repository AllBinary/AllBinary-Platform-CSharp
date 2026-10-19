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
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.android.input.motion;

public class AnalogControllerHelper
{
    private readonly int reduceTimeFactor;
    public AnalogControllerHelper(int reduceTimeFactor)
    {
        this.reduceTimeFactor = reduceTimeFactor;
    }

    private readonly int SCALE_VALUE = AnalogControllerConfigurationFactory.getInstance().SCALE_VALUE;
    private readonly TimeDelayHelper rightTimeElapsedHelper = new TimeDelayHelper(0);
    private readonly TimeDelayHelper leftTimeElapsedHelper = new TimeDelayHelper(0);
    private readonly TimeDelayHelper downTimeElapsedHelper = new TimeDelayHelper(0);
    private readonly TimeDelayHelper upTimeElapsedHelper = new TimeDelayHelper(0);
    // throws Exception
    public virtual void right(CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer, int xAnalogValue)
    {
        this.rightTimeElapsedHelper.delay = ((this.SCALE_VALUE - xAnalogValue) >> this.reduceTimeFactor);
        if (this.rightTimeElapsedHelper.isTimeTNT()) {
            collidableDestroyableDamageableLayer.right();
        }
    }

    // throws Exception
    public virtual void left(CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer, int xAnalogValue)
    {
        this.leftTimeElapsedHelper.delay = ((this.SCALE_VALUE + xAnalogValue) >> this.reduceTimeFactor);
        if (this.leftTimeElapsedHelper.isTimeTNT()) {
            collidableDestroyableDamageableLayer.left();
        }
    }

    // throws Exception
    public virtual void up(CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer, int xAnalogValue)
    {
        this.upTimeElapsedHelper.delay = ((this.SCALE_VALUE - xAnalogValue) >> this.reduceTimeFactor);
        if (this.upTimeElapsedHelper.isTimeTNT()) {
            collidableDestroyableDamageableLayer.up();
        }
    }

    // throws Exception
    public virtual void down(CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer, int xAnalogValue)
    {
        this.downTimeElapsedHelper.delay = ((this.SCALE_VALUE + xAnalogValue) >> this.reduceTimeFactor);
        if (this.downTimeElapsedHelper.isTimeTNT()) {
            collidableDestroyableDamageableLayer.down();
        }
    }

}

