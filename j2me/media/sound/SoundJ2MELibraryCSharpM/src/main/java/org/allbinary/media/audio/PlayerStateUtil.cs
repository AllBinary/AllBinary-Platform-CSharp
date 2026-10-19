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
//using Player = javax.microedition.media.Player;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.audio;

public class PlayerStateUtil
{
    private static readonly PlayerStateUtil instance = new PlayerStateUtil();
    public static PlayerStateUtil getInstance()
    {
        return PlayerStateUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly string UNREALIZED = "UNREALIZED";
    public readonly string REALIZED = "REALIZED";
    public readonly string PREFETCHED = "PREFETCHED";
    public readonly string STARTED = "STARTED";
    public readonly string CLOSED = "CLOSED";
    public virtual string convert(int state)
    {
        if (state == Player.UNREALIZED) {
            return this.UNREALIZED;
        } else if (state == Player.REALIZED) {
            return this.REALIZED;
        } else if (state == Player.PREFETCHED) {
            return this.PREFETCHED;
        } else if (state == Player.STARTED) {
            return this.STARTED;
        } else if (state == Player.CLOSED) {
            return this.CLOSED;
        }
        return this.commonStrings.UNKNOWN;
    }

}

