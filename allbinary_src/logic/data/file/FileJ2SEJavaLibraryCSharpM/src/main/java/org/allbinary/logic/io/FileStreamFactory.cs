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
using NullUtil = org.allbinary.logic.NullUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbPath = org.allbinary.logic.io.path.AbPath;

namespace org.allbinary.logic.io;

public class FileStreamFactory
{
    private static object SINGLETON = NullUtil.getInstance().NULL_OBJECT;
    public static FileStreamFactory getInstance()
    {
        if (FileStreamFactory.SINGLETON == NullUtil.getInstance().NULL_OBJECT) {
            FileStreamFactory.SINGLETON = new FileStreamFactory();
        }
        return ((FileStreamFactory) FileStreamFactory.SINGLETON);
    }

    private FileStreamFactory()
    {
    }

    // throws Exception
    public virtual AbFileInputStream getFileInputStreamInstance(string path, string fileName)
    {
        AbPath FILEABPATH = new AbPath(path, fileName);
        AbFile file = AbFile.createAbFileFromAbPath(FILEABPATH);
        return new AbFileInputStream(file);
    }

    // throws Exception
    public virtual AbFileOutputStream getFileOutputStreamInstance(string path, string fileName)
    {
        AbPath FILEABPATH = new AbPath(path, fileName);
        AbFile file = AbFile.createAbFileFromAbPath(FILEABPATH);
        if (file.exists()) {
            file.delete();
            file.createNewFile();
        }
        return AbFileOutputStream.createFromAbFile(file);
    }

    // throws Exception
    public virtual void delete(string path, string fileName)
    {
        AbPath FILEABPATH = new AbPath(path, fileName);
        AbFile file = AbFile.createAbFileFromAbPath(FILEABPATH);
        file.delete();
    }

}

