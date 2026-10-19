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

namespace org.allbinary.game;

public class NullIntermissionEnableListener : IntermissionEnableListenerInterface
{
    private static readonly IntermissionEnableListenerInterface SINGLETON = new NullIntermissionEnableListener();
    public static IntermissionEnableListenerInterface getInstance()
    {
        return NullIntermissionEnableListener.SINGLETON;
    }

    private NullIntermissionEnableListener()
    {
    }

    public virtual void notifyIntermission(bool enable)
    {
    }

}

