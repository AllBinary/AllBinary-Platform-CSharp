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
//using IOException = java.io.IOException;
using OutputStream = java.io.OutputStream;

namespace org.allbinary.logic.io;

public class NullOutputStream : OutputStream
{
    public static readonly NullOutputStream NULL_OUTPUT_STREAM = new NullOutputStream();
    // throws IOException
    public override void write(int b)
    {
    }

    // throws IOException
    public override void write(sbyte[] b, int off, int len)
    {
    }

    public override void close()
    {
    }

}

