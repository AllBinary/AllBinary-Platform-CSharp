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

namespace org.allbinary.logic.communication.log;

public class LogData
{
    public readonly long MAX = 5000000L;
    public readonly string extension = "log";
    public readonly string backupFileExt = AbPathData.getInstance().EXTENSION_SEP + "bak" + AbPathData.getInstance().EXTENSION_SEP + "txt";
    public readonly string ALLBINARY = "allbinary";
    public readonly string NAME = "LOG_NAME";
    public readonly string DESCRIPTION = "LOG_DESCRIPTION";
}

