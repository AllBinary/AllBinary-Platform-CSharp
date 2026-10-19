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

namespace org.allbinary.emulator;

public class InitEmulatorFactory
{
    private static readonly InitEmulatorFactory instance = new InitEmulatorFactory();
    public static InitEmulatorFactory getInstance()
    {
        return InitEmulatorFactory.instance;
    }

    public virtual void setInitEmulator(bool initEmulator)
    {
        this.initEmulator = initEmulator;
    }

    public virtual bool isInitEmulator()
    {
        return this.initEmulator;
    }

    private bool initEmulator = false;
}

