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
using AbPathData = org.allbinary.logic.io.path.AbPathData;

namespace org.allbinary.logic.communication.http.request;

public class HttpRequestUtil
{
    private static readonly HttpRequestUtil instance = new HttpRequestUtil();
    public static HttpRequestUtil getInstance()
    {
        return HttpRequestUtil.instance;
    }

    private HttpRequestUtil()
    {
    }

    public virtual int getLastSeparatorIndex(string requestPath)
    {
        int beginIndex = requestPath.LastIndexOf(AbPathData.getInstance().SEPARATOR);
        if (beginIndex < 0) {
            beginIndex = requestPath.LastIndexOf("\\");
        }
        return beginIndex;
    }

    // throws Exception
    public virtual string generateFileName(string requestPath)
    {
        int beginIndex = this.getLastSeparatorIndex(requestPath);
        if (beginIndex < 0) {
            return requestPath;
        } else {
            return requestPath.Substring(beginIndex + 1);
        }
    }

}

