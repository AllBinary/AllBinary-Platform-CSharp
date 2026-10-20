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
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;

namespace org.allbinary.canvas;

public class GameGlobalsFactory
{
    private static readonly GameGlobalsFactory instance = new GameGlobalsFactory();
    public static GameGlobalsFactory getInstance()
    {
        return GameGlobalsFactory.instance;
    }

    public bool newCanvas = true;
    public long newDisplaybleTime = ((long) int.MinValue);
    public GPoint point = PointFactory.getInstance().ZERO_ZERO;
}

