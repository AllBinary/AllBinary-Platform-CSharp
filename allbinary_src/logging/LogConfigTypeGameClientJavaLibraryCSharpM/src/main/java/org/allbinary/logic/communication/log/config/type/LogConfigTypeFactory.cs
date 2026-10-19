/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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

namespace org.allbinary.logic.communication.log.config.type;

public class LogConfigTypeFactory
{
    private static readonly LogConfigTypeFactory instance = new LogConfigTypeFactory();
    public static LogConfigTypeFactory getInstance()
    {
        return LogConfigTypeFactory.instance;
    }

    private readonly string NO_DESCRIPTION = "No Description";
    public readonly LogConfigType OS;
    public readonly LogConfigType FACTORYERROR;
    private LogConfigTypeFactory()
    {
        this.OS = new LogConfigType("Operating System", this.NO_DESCRIPTION);
        this.FACTORYERROR = new LogConfigType("Factory Error", this.NO_DESCRIPTION);
        LogConfigTypes.LOGGING.add(OS);
        LogConfigTypes.LOGGING.add(this.FACTORYERROR);
    }

}

