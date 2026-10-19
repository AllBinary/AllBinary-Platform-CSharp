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
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using Closeable = java.io.Closeable;
//using InputStream = java.io.InputStream;
//using OutputStream = java.io.OutputStream;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.io;

public class StreamUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly StreamUtil instance = new StreamUtil();
    public static StreamUtil getInstance()
    {
        return StreamUtil.instance;
    }

    private StreamUtil()
    {
    }

    // throws Exception
    public virtual OutputStream get(InputStream inputStream, OutputStream outputStream, sbyte[] buffer)
    {
        int len = 0;
        while (true) {
            len = inputStream.read(buffer, 0, buffer.Length);
            if (len != -1) {
            } else {
                break;
            }
            outputStream.write(buffer, 0, len);
        }
        return outputStream;
    }

    // throws Exception
    public virtual sbyte[] getByteArray(InputStream inputStream, System.IO.MemoryStream outputStream2, sbyte[] byteArray)
    {
        System.IO.MemoryStream outputStream = outputStream2;
        try {
            this.get(inputStream, outputStream, byteArray);
            return outputStream.toByteArray();
        } catch (Exception e) {
            throw e;
        } finally {
            this.close(outputStream);
        }
    }

    public virtual bool close(Closeable closeable)
    {
        try {
            if (closeable != null) {
                closeable.close();
            }
            return true;
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CLOSE, e);
            return false;
        }
    }

}

