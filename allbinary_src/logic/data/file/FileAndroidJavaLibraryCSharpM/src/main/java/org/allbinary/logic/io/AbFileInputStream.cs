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
using System.Runtime.CompilerServices;
//using FileInputStream = java.io.FileInputStream;
//using FileNotFoundException = java.io.FileNotFoundException;
//using IOException = java.io.IOException;
//using InputStream = java.io.InputStream;
//using FileChannel = java.nio.channels.FileChannel;

namespace org.allbinary.logic.io;

public class AbFileInputStream : InputStream
{
    private FileInputStream fileInputStream;
    public AbFileInputStream(FileInputStream fileInputStream)
    {
        this.fileInputStream = fileInputStream;
    }

    public override void mark(int readlimit)
    {
        this.fileInputStream.mark(readlimit);
    }

    public override bool markSupported()
    {
        return this.fileInputStream.markSupported();
    }

    // throws IOException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void reset()
    {
        this.fileInputStream.reset();
    }

    // throws IOException
    public override int available()
    {
        return this.fileInputStream.available();
    }

    // throws IOException
    public override void close()
    {
        this.fileInputStream.close();
    }

    public virtual FileChannel getChannel()
    {
        return this.fileInputStream.getChannel();
    }

    // throws IOException
    public override int read()
    {
        return this.fileInputStream.read();
    }

    // throws IOException
    public override int read(sbyte[] b)
    {
        return this.fileInputStream.read(b);
    }

    // throws IOException
    public override int read(sbyte[] buffer, int offset, int count)
    {
        return this.fileInputStream.read(buffer, offset, count);
    }

    // throws IOException
    public override long skip(long n)
    {
        return this.fileInputStream.skip(n);
    }

}

