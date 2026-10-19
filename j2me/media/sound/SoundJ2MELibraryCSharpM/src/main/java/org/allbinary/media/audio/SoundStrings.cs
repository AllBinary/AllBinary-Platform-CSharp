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

namespace org.allbinary.media.audio;

public class SoundStrings
{
    private static readonly SoundStrings instance = new SoundStrings();
    public static SoundStrings getInstance()
    {
        return SoundStrings.instance;
    }

    public readonly string STOP_ALL = "stopAll";
    public readonly string CLOSE_ALL = "closeAll";
    public readonly string SOUND = " Sound: ";
    public readonly string INIT_SOUND = "Initializing Sound: ";
    public readonly string STOPPING_SOUND = "Stopping Sound: ";
    public readonly string CLOSING_SOUND = "Closing Sound: ";
}

