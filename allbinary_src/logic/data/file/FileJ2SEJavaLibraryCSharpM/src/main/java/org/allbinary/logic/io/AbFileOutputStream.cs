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
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbFileNativeUtil = org.allbinary.logic.io.file.AbFileNativeUtil;

namespace org.allbinary.logic.io;

public class AbFileOutputStream : FileOutputStream
{
    // throws FileNotFoundException
    public static AbFileOutputStream createFromAbFile(AbFile file)
    {
        return new AbFileOutputStream(file.getPath(), false);
    }

    // throws FileNotFoundException
    public static AbFileOutputStream createFromAbFileAppend(AbFile file, bool append)
    {
        return new AbFileOutputStream(file.getPath(), append);
    }

    // throws FileNotFoundException
    public static AbFileOutputStream createFromFilePath(string name)
    {
        return new AbFileOutputStream(name, false);
    }

    // throws FileNotFoundException
    public static AbFileOutputStream createFromFilePathAppend(string name, bool append)
    {
        return new AbFileOutputStream(name, append);
    }

    public AbFileOutputStream(string name, bool append) : base(name, append)
    {
        // base(name, append) is called from the constructor declaration
    }

}

