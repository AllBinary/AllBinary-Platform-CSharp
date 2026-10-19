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
using System.Runtime.CompilerServices;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.logic.communication.log.config;

public class LoggingInitInfo
{
    private static BasicArrayList logConfigInfoList = null;
    private static bool hasRead = false;
    public LoggingInitInfo()
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void write()
    {
        try {
            LoggingInitInfo.hasRead = false;
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    private static void read()
    {
        try {
        } catch (Exception e) {
            throw e;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void setHasRead(bool value)
    {
        LoggingInitInfo.hasRead = value;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    private static void updateIfNeeded()
    {
        if (!LoggingInitInfo.hasRead) {
            LoggingInitInfo.read();
            LoggingInitInfo.hasRead = true;
            if (LoggingInitInfo.logConfigInfoList == null) {
                throw new Exception("Read Failed");
            }
        }
    }

    public virtual bool isValid()
    {
        try {
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void set(BasicArrayList logConfigInfoList)
    {
        LoggingInitInfo.logConfigInfoList = logConfigInfoList;
    }

    // throws Exception
    public static BasicArrayList get()
    {
        LoggingInitInfo.updateIfNeeded();
        return LoggingInitInfo.logConfigInfoList;
    }

    // throws Exception
    public static BasicArrayList getTypeList()
    {
        LoggingInitInfo.updateIfNeeded();
        BasicArrayList allLogTypeVector = new BasicArrayListD();
        int size = LoggingInitInfo.logConfigInfoList.size();
        for (int index = 0; index < size; index++) {
            LogConfig logConfigInfo = ((LogConfig) LoggingInitInfo.logConfigInfoList.objectArray[index]);
            BasicArrayList logTypeVector = logConfigInfo.getTypeVector();
            if (logConfigInfo.isEnabled()) {
                allLogTypeVector.addAllList(logTypeVector);
            }
        }
        return allLogTypeVector;
    }

    // throws Exception
    public virtual int getNumberOfLogConfigs()
    {
        return LoggingInitInfo.logConfigInfoList.size();
    }

    public override string ToString()
    {
        try {
            return null;
        } catch (Exception e) {
            return "Error";
        }
    }

}

