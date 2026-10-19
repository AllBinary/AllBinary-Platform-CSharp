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

public class BaseSoundsFactory : SoundsFactoryInterface
{
    private bool initialized = false;
    public virtual void init()
    {
    }

    // throws Exception
    public virtual Sound[] getSoundInterfaceArray()
    {
        return new Sound[0];
    }

    public virtual void setInitialized(bool initialized)
    {
        this.initialized = initialized;
    }

    public virtual bool isInitialized()
    {
        return this.initialized;
    }

}

