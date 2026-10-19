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

namespace org.allbinary.logic.io.file;

public class FileFactory
{
    private static readonly FileFactory instance = new FileFactory();
    public static FileFactory getInstance()
    {
        return FileFactory.instance;
    }

    // throws Exception
    public virtual AbFile getInstance(string filePath)
    {
        return AbFile.createAbFileFromRawPath(filePath);
    }

    // throws Exception
    public virtual AbFile getInstance(AbFile file, string childFilePath)
    {
        return AbFile.createAbFileWithChild(file, childFilePath);
    }

    // throws Exception
    public virtual bool isFile(string path)
    {
        AbFile file = AbFile.createAbFile(path);
        if (file.exists()) {
            return true;
        } else {
            return false;
        }
    }

}

