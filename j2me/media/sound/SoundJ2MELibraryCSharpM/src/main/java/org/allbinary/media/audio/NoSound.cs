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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.media.audio;

public class NoSound : Sound
{
    public static NoSound getInstance()
    {
        return NoSound.instance;
    }

    private static readonly NoSound instance = new NoSound();
    private NoSound() : base(StringUtil.getInstance().EMPTY_STRING)
    {
        // base(StringUtil.getInstance().EMPTY_STRING) is called from the constructor declaration
        this.setPlayerP(NoPlayer.NO_PLAYER);
    }

}

