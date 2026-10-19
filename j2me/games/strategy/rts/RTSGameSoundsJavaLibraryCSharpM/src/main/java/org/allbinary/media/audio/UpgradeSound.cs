/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
 *  
 * By agreeing to this license you and any business entity you represent are 
 * legally bound to the AllBinary Open License Version 1 legal agreement. 
 *  
 * You may obtain the AllBinary Open License Version 1 legal agreement from 
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository. 
 *  
 * Created By: Travis Berthelot  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using CompositeSound = org.allbinary.media.audio.CompositeSound;
using Sound = org.allbinary.media.audio.Sound;

namespace org.allbinary.media.audio;

public class UpgradeSound : CompositeSound
{
    private static Sound soundInterface = new UpgradeSound();
    private UpgradeSound() : base("resource:/wav/upgrade.wav")
    {
        // base("resource:/wav/upgrade.wav") is called from the constructor declaration
    }

    public static Sound getInstance()
    {
        return UpgradeSound.soundInterface;
    }

}

