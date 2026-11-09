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
using Writer = java.io.Writer;

namespace org.allbinary.logic.io;

public class NullWriter : Writer
{
    public static readonly NullWriter NULL_WRITER = new NullWriter();
    // throws IOException
    public override void write(int c)
    {
    }

    // throws IOException
    public override void write(char[] cbuf, int off, int len)
    {
    }

    // throws IOException
    public override void write(string str)
    {
    }

    // throws IOException
    public override void write(string str, int off, int len)
    {
    }

    // throws IOException
    public override void flush()
    {
    }

    // throws IOException
    public override void close()
    {
    }

}

