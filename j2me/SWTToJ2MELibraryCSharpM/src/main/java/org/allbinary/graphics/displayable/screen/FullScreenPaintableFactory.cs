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
using FullScreenPaintable = org.allbinary.game.paint.FullScreenPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;

namespace org.allbinary.graphics.displayable.screen;

public class FullScreenPaintableFactory
{
    private static readonly FullScreenPaintableFactory instance = new FullScreenPaintableFactory();
    public static FullScreenPaintableFactory getInstance()
    {
        return FullScreenPaintableFactory.instance;
    }

    public Paintable paintable = FullScreenPaintable.getInstance();
}

