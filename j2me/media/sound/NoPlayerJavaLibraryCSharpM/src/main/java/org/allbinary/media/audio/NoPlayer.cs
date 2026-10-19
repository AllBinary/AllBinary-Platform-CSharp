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
//using Control = javax.microedition.media.Control;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.media.audio;

public class NoPlayer : BasicPlayer
{
    public static readonly NoPlayer NO_PLAYER = new NoPlayer();
    public NoPlayer()
    {
    }

    public override void close()
    {
    }

    public override string getContentType()
    {
        return StringUtil.getInstance().NULL_STRING;
    }

    public override Control getControl(string controlType)
    {
        return new NullControl();
    }

    public override Control[] getControls()
    {
        return new Control[0];
    }

}

