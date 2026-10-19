/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;

namespace org.allbinary.game.displayable.canvas;

public class NullAllBinaryGameCanvas : AllBinaryGameCanvasInterface
{
    public static readonly NullAllBinaryGameCanvas NULL_ALLBINARY_GAME_CANVAS = new NullAllBinaryGameCanvas();
    public virtual AllBinaryGameLayerManager getLayerManager()
    {
        throw new SystemException();
    }

    public virtual void addCommand(Command cmd)
    {
        throw new SystemException();
    }

    public virtual int getHeight()
    {
        throw new SystemException();
    }

    public virtual int getWidth()
    {
        throw new SystemException();
    }

    public virtual void removeCommand(Command cmd)
    {
        throw new SystemException();
    }

    public virtual void setCommandListener(CommandListener l)
    {
        throw new SystemException();
    }

}

