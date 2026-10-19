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

namespace org.allbinary.game.graphics.hud;

public class BasicHudFactory
{
    private static readonly BasicHudFactory instance = new BasicHudFactory();
    public static BasicHudFactory getInstance()
    {
        return BasicHudFactory.instance;
    }

    private BasicHudFactory()
    {
    }

    public readonly string DIRECTION_EXCEPTION = "Only Horizontal Direction is Allowed Currently";
    public readonly int VERTICAL = 0;
    public readonly int HORIZONTAL = 1;
    public readonly int BOTTOMLEFT = 0;
    public readonly int BOTTOMRIGHT = 1;
    public readonly int TOPLEFT = 2;
    public readonly int TOPRIGHT = 3;
    public readonly int BOTTOMCENTER = 4;
    public readonly int TOPCENTER = 5;
    public readonly int ABSOLUTE = 6;
}

