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

namespace org.allbinary.media.audio;

public class EarlySoundsFactory : BaseSoundsFactory
{
    private static readonly EarlySoundsFactory instance = new EarlySoundsFactory();
    // throws Exception
    public override Sound[] getSoundInterfaceArray()
    {
        Sound[] soundInterfaceArray = new Sound[2];
        int index = 0;
        soundInterfaceArray[index++] = SelectSound.getInstance();
        soundInterfaceArray[index++] = ErrorSound.getInstance();
        return soundInterfaceArray;
    }

    public static EarlySoundsFactory getInstance()
    {
        return EarlySoundsFactory.instance;
    }

}

