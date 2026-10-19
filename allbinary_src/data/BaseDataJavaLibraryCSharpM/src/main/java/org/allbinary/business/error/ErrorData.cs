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

namespace org.allbinary.business.error;

public class ErrorData
{
    private static readonly ErrorData instance = new ErrorData();
    public static ErrorData getInstance()
    {
        return ErrorData.instance;
    }

    private ErrorData()
    {
    }

    public readonly string NAME = "ERROR_NAME";
    public readonly string TEXT = "ERROR_TEXT";
}

