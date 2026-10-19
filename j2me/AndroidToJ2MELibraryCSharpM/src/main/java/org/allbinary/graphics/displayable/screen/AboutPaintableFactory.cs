/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2022 AllBinary
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
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;

namespace org.allbinary.graphics.displayable.screen;

public class AboutPaintableFactory
{
    private static readonly AboutPaintableFactory instance = new AboutPaintableFactory();
    public static AboutPaintableFactory getInstance()
    {
        return AboutPaintableFactory.instance;
    }

    public Paintable[] paintableArray = new Paintable[] { NullPaintable.getInstance() };
}

