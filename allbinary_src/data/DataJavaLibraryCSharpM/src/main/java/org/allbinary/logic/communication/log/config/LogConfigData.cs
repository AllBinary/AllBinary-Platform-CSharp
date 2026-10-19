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

namespace org.allbinary.logic.communication.log.config;

public class LogConfigData
{
    private static readonly LogConfigData instance = new LogConfigData();
    public static LogConfigData getInstance()
    {
        return LogConfigData.instance;
    }

    private LogConfigData()
    {
    }

    public readonly string NAME = "LOG_CONFIG_NAME";
    public readonly string DESCRIPTION = "LOG_CONFIG_DESCRIPTION";
    public readonly string FILE = "LOG_CONFIG_FILE";
}

