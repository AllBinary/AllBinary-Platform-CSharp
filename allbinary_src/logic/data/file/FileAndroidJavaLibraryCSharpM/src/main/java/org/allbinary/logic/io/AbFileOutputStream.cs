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
//using FileNotFoundException = java.io.FileNotFoundException;
//using FileOutputStream = java.io.FileOutputStream;
//using IOException = java.io.IOException;
//using OutputStream = java.io.OutputStream;
//using FileChannel = java.nio.channels.FileChannel;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbFileNativeUtil = org.allbinary.logic.io.file.AbFileNativeUtil;

namespace org.allbinary.logic.io;

public class AbFileOutputStream : OutputStream
{
    // throws FileNotFoundException
    public static AbFileOutputStream createFromAbFile(AbFile file)
    {
        return new AbFileOutputStream(new FileOutputStream(AbFileNativeUtil.get(file)));
    }

    // throws FileNotFoundException
    public static AbFileOutputStream createFromAbFileAppend(AbFile file, bool append)
    {
        return new AbFileOutputStream(new FileOutputStream(file.getPath()));
    }

    // throws FileNotFoundException
    public static AbFileOutputStream createFromFilePath(string name)
    {
        return new AbFileOutputStream(new FileOutputStream(name));
    }

    // throws FileNotFoundException
    public static AbFileOutputStream createFromFilePathAppend(string name, bool append)
    {
        return new AbFileOutputStream(new FileOutputStream(name));
    }

    private FileOutputStream fileOutputStream;
    public AbFileOutputStream(FileOutputStream fileOutputStream)
    {
        this.fileOutputStream = fileOutputStream;
    }

    // throws IOException
    public override void close()
    {
        this.fileOutputStream.close();
    }

    public virtual FileChannel getChannel()
    {
        return this.fileOutputStream.getChannel();
    }

    // throws IOException
    public override void write(sbyte[] buffer)
    {
        this.fileOutputStream.write(buffer);
    }

    // throws IOException
    public override void write(sbyte[] buffer, int offset, int count)
    {
        this.fileOutputStream.write(buffer, offset, count);
    }

    // throws IOException
    public override void write(int b)
    {
        this.fileOutputStream.write(b);
    }

}

