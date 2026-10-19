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
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using FileInputStream = java.io.FileInputStream;
//using InputStream = java.io.InputStream;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.data.resource;

//J2SE - PC
public class ResourceUtil
{
    private static readonly ResourceUtil instance = new ResourceUtil();
    public static ResourceUtil getInstance()
    {
        return ResourceUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string path = StringUtil.getInstance().EMPTY_STRING;
    private string ext = StringUtil.getInstance().EMPTY_STRING;
    private ResourceUtil()
    {
    }

    public virtual void setLoadingPaths(string path, string ext)
    {
        this.path = path;
        this.ext = ext;
    }

    public virtual void setClassLoader(ClassLoader classLoader)
    {
    }

    // throws Exception
    public virtual InputStream getResourceAsStream(string resource)
    {
        InputStream inputStream = this.getResourceAsStreamAtStart(resource, 2);
        if (inputStream == null) {
            inputStream = this.getResourceAsStreamAtStart(resource, 1);
            if (inputStream == null) {
                throw new Exception(new StringMaker().append("Unable to obtain: ").append(resource).ToString());
            }
        }
        return inputStream;
    }

    // throws Exception
    private InputStream getResourceAsStreamAtStart(string resource, int startIndex)
    {
        InputStream inputStream = new FileInputStream(new StringMaker().append(this.path).append(resource).append(this.ext).ToString());
        if (inputStream != null) {
            sbyte[] byteArray = new sbyte[inputStream.available()];
            StreamUtil.getInstance().getByteArray(inputStream, new System.IO.MemoryStream(), byteArray);
            return new ByteArrayInputStream(byteArray);
        }
        return inputStream;
    }

    public virtual void addResource(string resource, int? value)
    {
    }

}

