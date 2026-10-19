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
//using BufferedReader = java.io.BufferedReader;
//using FileReader = java.io.FileReader;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbFileNativeUtil = org.allbinary.logic.io.file.AbFileNativeUtil;

namespace org.allbinary.logic.io;

public class BufferedLineReader
{
    private readonly BufferedReader tmpIn;
    public BufferedLineReader(AbFile file)
    {
        this.tmpIn = new BufferedReader(new FileReader(AbFileNativeUtil.get(file)));
    }

    public virtual void readUpToLines(long readAheadIndex)
    {
    }

    // throws Exception
    public virtual string readLine()
    {
        return this.tmpIn.readLine();
    }

    public virtual long getSize()
    {
        return 0L;
    }

    public virtual int getCurrent()
    {
        return 0;
    }

}

