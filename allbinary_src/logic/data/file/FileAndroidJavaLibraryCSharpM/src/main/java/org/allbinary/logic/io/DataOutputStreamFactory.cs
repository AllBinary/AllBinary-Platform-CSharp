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
using AbFile = org.allbinary.logic.io.file.AbFile;

namespace org.allbinary.logic.io;

public class DataOutputStreamFactory
{
    private static readonly DataOutputStreamFactory instance = new DataOutputStreamFactory();
    public static DataOutputStreamFactory getInstance()
    {
        return DataOutputStreamFactory.instance;
    }

    // throws Exception
    public virtual AbDataOutputStream getInstanceForAbFile(AbFile file)
    {
        AbFileOutputStream idFileOutputStream = AbFileOutputStream.createFromAbFile(file);
        AbDataOutputStream idOutData = new AbDataOutputStream(idFileOutputStream);
        return idOutData;
    }

    // throws Exception
    public virtual AbDataOutputStream getInstance(string filePath, string fileName)
    {
        FileStreamFactory fileStreamFactory = FileStreamFactory.getInstance();
        AbFileOutputStream fileOutputStream = fileStreamFactory.getFileOutputStreamInstance(filePath, fileName);
        AbDataOutputStream idOutData = new AbDataOutputStream(fileOutputStream);
        return idOutData;
    }

}

