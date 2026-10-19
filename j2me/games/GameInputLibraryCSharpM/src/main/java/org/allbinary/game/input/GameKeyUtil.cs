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
//using Canvas = javax.microedition.lcdui.Canvas;

namespace org.allbinary.game.input;

public class GameKeyUtil
{
    private static readonly GameKeyUtil instance = new GameKeyUtil();
    public virtual bool isDirectionKey(int key)
    {
        if (key == Canvas.UP || key == Canvas.DOWN || key == Canvas.LEFT || key == Canvas.RIGHT) {
            return true;
        } else {
            return false;
        }
    }

    public static GameKeyUtil getInstance()
    {
        return GameKeyUtil.instance;
    }

}

