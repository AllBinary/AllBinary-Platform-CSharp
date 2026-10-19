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
//using InputStream = java.io.InputStream;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.data.resource;

//J2SE - J2ME
public class ResourceUtil
{
    private static object classLoader = NullUtil.getInstance().NULL_OBJECT;
    private static readonly ResourceUtil instance = new ResourceUtil();
    public static ResourceUtil getInstance()
    {
        return ResourceUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private ResourceUtil()
    {
    }

    public virtual void setLoadingPaths(string path, string ext)
    {
        this.logUtil.putF(CommonStrings.getInstance().NOT_IMPLEMENTED, this, "setLoadingPaths");
    }

    public virtual void setClassLoader(ClassLoader classLoader)
    {
        this.logUtil.putF(new StringMaker().append("Resource Loader: ").append(classLoader.GetType().FullName).ToString(), this, "setClassLoader");
        ResourceUtil.classLoader = classLoader;
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
        CommonSeps commonSeps = CommonSeps.getInstance();
        int index = resource.IndexOf(commonSeps.COLON);
        string resourcePath = resource.Substring(index + startIndex);
        InputStream inputStream = resource.GetType().getResourceAsStream(resourcePath);
        if (inputStream != null) {
            return inputStream;
        }
        ClassLoader classLoader = ((ClassLoader) ResourceUtil.classLoader);
        inputStream = classLoader.getResourceAsStream(resourcePath);
        if (inputStream != null) {
            return inputStream;
        }
        inputStream = Thread.currentThread().getContextClassLoader().getResourceAsStream(resourcePath);
        if (inputStream != null) {
            return inputStream;
        }
        return inputStream;
    }

    public virtual void addResource(string resource, int? value)
    {
    }

}

