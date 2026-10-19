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
using ItemPaintable = org.allbinary.graphics.form.ItemPaintable;
using ItemPaintableFactory = org.allbinary.graphics.form.ItemPaintableFactory;
using PaintableForm = org.allbinary.graphics.form.PaintableForm;
using ScrollCurrentSelectionForm = org.allbinary.graphics.form.ScrollCurrentSelectionForm;

namespace org.allbinary.game.displayable.canvas;

public class PreGameLockableFormPaintableFactory : ItemPaintableFactory
{
    private readonly int lockedIndex;
    public PreGameLockableFormPaintableFactory(int lockedIndex)
    {
        this.lockedIndex = lockedIndex;
    }

    // throws Exception
    public override ItemPaintable getInstanceItemPaintable(PaintableForm paintableForm)
    {
        return new PreGameLockablePaintable(((ScrollCurrentSelectionForm) paintableForm), this.lockedIndex);
    }

}

