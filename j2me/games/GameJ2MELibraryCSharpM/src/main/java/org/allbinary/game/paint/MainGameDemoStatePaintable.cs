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
using Paintable = org.allbinary.graphics.paint.Paintable;

namespace org.allbinary.game.paint;

public class MainGameDemoStatePaintable : Paintable
{
    private readonly Paintable ownershipPaintableInterface;
    private readonly Paintable menuPaintableInterface;
    public MainGameDemoStatePaintable(Paintable ownershipPaintableInterface, Paintable menuPaintableInterface)
    {
        this.ownershipPaintableInterface = ownershipPaintableInterface;
        this.menuPaintableInterface = menuPaintableInterface;
    }

    public override void paint(Graphics graphics)
    {
        this.menuPaintableInterface.paint(graphics);
        this.ownershipPaintableInterface.paint(graphics);
    }

    public virtual Paintable getOwnershipPaintableInterface()
    {
        return this.ownershipPaintableInterface;
    }

    public virtual Paintable getMenuPaintableInterface()
    {
        return this.menuPaintableInterface;
    }

}

