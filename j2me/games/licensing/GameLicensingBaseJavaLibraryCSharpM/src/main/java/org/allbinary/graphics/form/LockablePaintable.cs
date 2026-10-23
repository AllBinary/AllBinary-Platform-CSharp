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
using FeaturedAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.FeaturedAnimationInterfaceFactoryInterfaceFactory;
using LockedResources = org.allbinary.logic.system.security.licensing.LockedResources;
using LockedUtil = org.allbinary.logic.system.security.licensing.LockedUtil;

namespace org.allbinary.graphics.form;

public class LockablePaintable : ItemPaintable
{
    private readonly Animation animation = FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(LockedResources.getInstance().LOCKED_DEMO_GAME_FEATURE_RESOURCE).getInstance(0);
    private readonly int lockedIndex;
    public LockablePaintable(int lockedIndex)
    {
        this.lockedIndex = lockedIndex;
    }

    public override void paint(Graphics graphics, int currentIndex, int x, int y)
    {
        if (LockedUtil.getInstance().isLocked() && currentIndex >= this.getLockedIndex()) {
            this.getAnimation().paintXY(graphics, x, y);
        }
    }

    public virtual int getLockedIndex()
    {
        return this.lockedIndex;
    }

    public virtual Animation getAnimation()
    {
        return this.animation;
    }

}

