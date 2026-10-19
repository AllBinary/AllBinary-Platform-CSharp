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

namespace org.allbinary.android;

public class AndroidInfoFactory
{
    private static readonly AndroidInfoFactory instance = new AndroidInfoFactory();
    public static AndroidInfoFactory getInstance()
    {
        return AndroidInfoFactory.instance;
    }

    private readonly int version = 8;
    public virtual int getVersion()
    {
        return this.version;
    }

}

