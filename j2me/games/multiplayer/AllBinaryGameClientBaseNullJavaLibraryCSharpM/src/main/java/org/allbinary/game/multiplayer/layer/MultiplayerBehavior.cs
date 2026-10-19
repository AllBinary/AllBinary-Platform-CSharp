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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.multiplayer.layer;

public class MultiplayerBehavior
{
    public static readonly MultiplayerBehavior NULL_MULTIPLAYER_BEHAVIOR = new MultiplayerBehavior(StringUtil.getInstance().EMPTY_STRING);
    protected MultiplayerBehavior(string username)
    {
    }

    public virtual void startTick()
    {
    }

    public virtual void endTick()
    {
    }

    public virtual long getApproximateElapsed()
    {
        return 0L;
    }

}

