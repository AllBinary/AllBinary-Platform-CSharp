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
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using StatePaintable = org.allbinary.graphics.paint.StatePaintable;

namespace org.allbinary.game.paint;

public class BasicGameDemoPaintable : StatePaintable
{
    private readonly Paintable mainDemoStatePaintable;
    private readonly Paintable ownershipPaintable;
    private readonly Paintable helpPaintableInterface;
    private Paintable currentStatePaintable = NullPaintable.getInstance();
    public BasicGameDemoPaintable(Paintable mainDemoStatePaintable, Paintable ownershipPaintable, Paintable helpPaintableInterface)
    {
        this.mainDemoStatePaintable = mainDemoStatePaintable;
        this.setCurrentStatePaintable(NullPaintable.getInstance());
        this.ownershipPaintable = ownershipPaintable;
        this.helpPaintableInterface = helpPaintableInterface;
    }

    public override void setState(int state)
    {
        if (state == 0) {
            this.setCurrentStatePaintable(this.getMainDemoStatePaintable());
        } else if (state == 1) {
            this.setCurrentStatePaintable(this.helpPaintableInterface);
        } else {
            this.setCurrentStatePaintable(this.ownershipPaintable);
        }
    }

    public override void paint(Graphics graphics)
    {
        this.getCurrentStatePaintable().paint(graphics);
    }

    public virtual Paintable getHelpPaintableInterface()
    {
        return this.helpPaintableInterface;
    }

    protected virtual void setCurrentStatePaintable(Paintable currentStatePaintable)
    {
        this.currentStatePaintable = currentStatePaintable;
    }

    protected virtual Paintable getCurrentStatePaintable()
    {
        return this.currentStatePaintable;
    }

    protected virtual Paintable getMainDemoStatePaintable()
    {
        return this.mainDemoStatePaintable;
    }

}

