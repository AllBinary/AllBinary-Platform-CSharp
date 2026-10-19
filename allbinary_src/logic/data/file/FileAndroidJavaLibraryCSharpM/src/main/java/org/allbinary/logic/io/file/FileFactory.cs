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
using Context = android.content.Context;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;

namespace org.allbinary.logic.io.file;

public class FileFactory
{
    private static readonly FileFactory SINGLETON = new FileFactory(ResourceUtil.getInstance().getContext());
    private Context context;
    private FileFactory(Context context)
    {
        this.context = context;
    }

    public static FileFactory getInstance()
    {
        return FileFactory.SINGLETON;
    }

    // throws Exception
    public virtual bool isFile(string path)
    {
        try {
            this.context.openFileInput(path);
            return true;
        } catch (FileNotFoundException e) {
            return false;
        }
    }

    public virtual Context getContext()
    {
        return this.context;
    }

    // throws Exception
    public virtual AbFile getFile(string filePath)
    {
        return AbFile.createAbFileFromRawPath(filePath);
    }

    // throws Exception
    public virtual AbFile getInstance(AbFile file, string childFilePath)
    {
        return AbFile.createAbFileWithChild(file, childFilePath);
    }

}

