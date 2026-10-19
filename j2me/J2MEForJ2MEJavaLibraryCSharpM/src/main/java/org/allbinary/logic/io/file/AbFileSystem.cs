/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2026 AllBinary 
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
//using InputStream = java.io.InputStream;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.io.file;

//J2MEForJ2ME
public class AbFileSystem
{
    private static readonly AbFileSystem instance = new AbFileSystem();
    public static AbFileSystem getInstance()
    {
        return AbFileSystem.instance;
    }

    private readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public virtual bool isDirectoryOrFile(string path)
    {
        return false;
    }

    public virtual bool isDirectory(string path)
    {
        return false;
    }

    public virtual string[] getFilesAsStringArrayForPath(string currentDirPath)
    {
        return StringUtil.getInstance().getArrayInstance();
    }

    public virtual string readAsString(string fileName)
    {
        sbyte[] bytes = new sbyte[1000000];
        return this.readAsString(fileName, bytes);
    }

    public virtual string readAsString(string fileName, sbyte[] bytes)
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual bool close(object closeable)
    {
        try {
            if (closeable != null) {
                InputStream inputStream = (((InputStream) closeable));
                inputStream.close();
            }
            return true;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CLOSE, e);
            return false;
        }
    }

}

