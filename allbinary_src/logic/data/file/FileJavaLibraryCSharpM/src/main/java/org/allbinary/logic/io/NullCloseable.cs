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
//using Closeable = java.io.Closeable;
//using IOException = java.io.IOException;

namespace org.allbinary.logic.io;

public class NullCloseable : Closeable
{
    public static readonly NullCloseable NULL_CLOSEABLE = new NullCloseable();
    // throws IOException
    public virtual void close()
    {
    }

}

