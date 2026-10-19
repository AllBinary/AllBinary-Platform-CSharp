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
//using Canvas = javax.microedition.lcdui.Canvas;
using MultiPlayerGameFeatureFactory = org.allbinary.game.configuration.feature.MultiPlayerGameFeatureFactory;

namespace org.allbinary;

public class PostGameCommandFactory
{
    private static readonly PostGameCommandFactory instance = new PostGameCommandFactory();
    public static PostGameCommandFactory getInstance()
    {
        return PostGameCommandFactory.instance;
    }

    public virtual void addCommands(Canvas canvas)
    {
        MultiPlayerGameFeatureFactory.getInstance().addCommands(canvas);
    }

}

