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
using Reader = java.io.Reader;

namespace org.allbinary.logic.io;

public class NullReader : Reader
{
    public static readonly NullReader NULL_READER = new NullReader();
    // throws IOException
    public override int read()
    {
        return -1;
    }

    // throws IOException
    public override int read(char[] cbuf, int off, int len)
    {
        return -1;
    }

    // throws IOException
    public override bool ready()
    {
        return false;
    }

    // throws IOException
    public override long skip(long n)
    {
        return 0L;
    }

    public override void close()
    {
    }

}

