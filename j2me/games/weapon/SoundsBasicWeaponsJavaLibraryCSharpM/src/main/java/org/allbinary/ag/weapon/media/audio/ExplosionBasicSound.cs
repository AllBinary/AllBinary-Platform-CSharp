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
using CompositeSound = org.allbinary.media.audio.CompositeSound;
using Sound = org.allbinary.media.audio.Sound;

namespace org.allbinary.ag.weapon.media.audio;

public class ExplosionBasicSound : CompositeSound
{
    private static Sound soundInterface = new ExplosionBasicSound();
    private ExplosionBasicSound() : base("resource:/wav/explosion.wav")
    {
        // base("resource:/wav/explosion.wav") is called from the constructor declaration
    }

    public static Sound getInstance()
    {
        return ExplosionBasicSound.soundInterface;
    }

}

