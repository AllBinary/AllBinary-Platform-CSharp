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
using GameFeatureImageCacheFactory = org.allbinary.image.GameFeatureImageCacheFactory;
using LockedResources = org.allbinary.logic.system.security.licensing.LockedResources;
using LockedUtil = org.allbinary.logic.system.security.licensing.LockedUtil;
using LockablePaintable = org.allbinary.graphics.form.LockablePaintable;
using ScrollCurrentSelectionForm = org.allbinary.graphics.form.ScrollCurrentSelectionForm;

namespace org.allbinary.game.displayable.canvas;

public class PreGameLockablePaintable : LockablePaintable
{
    private readonly int halfWidth;
    private readonly ScrollCurrentSelectionForm paintableForm;
    public PreGameLockablePaintable(ScrollCurrentSelectionForm paintableForm, int lockedIndex) : base(lockedIndex)
    {
        // base(lockedIndex) is called from the constructor declaration
        this.paintableForm = paintableForm;
        this.halfWidth = GameFeatureImageCacheFactory.getInstance().getWithKey(LockedResources.getInstance().LOCKED_DEMO_GAME_FEATURE_RESOURCE).getWidth() / 2;
    }

    public override void paint(Graphics graphics, int currentIndex, int x, int y)
    {
        if (LockedUtil.getInstance().isLocked() && this.getPaintableForm().getSelectedIndex() >= this.getLockedIndex()) {
            this.getAnimation().paintXY(graphics, this.getPaintableForm().getDx() - this.halfWidth, this.getPaintableForm().getDy() + 34);
        }
    }

    protected virtual ScrollCurrentSelectionForm getPaintableForm()
    {
        return this.paintableForm;
    }

}

