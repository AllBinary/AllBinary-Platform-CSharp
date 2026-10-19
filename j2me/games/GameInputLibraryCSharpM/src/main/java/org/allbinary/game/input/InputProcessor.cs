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

public class InputProcessor
{
    public readonly GameInputStrings gameInputStrings = GameInputStrings.getInstance();
    public virtual void keyPressedByDevice(int keyCode, int deviceId)
    {
    }

    public virtual void keyReleasedByDevice(Canvas canvas, int keyCode, int deviceId)
    {
    }

}

