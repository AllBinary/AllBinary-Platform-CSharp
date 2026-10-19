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

namespace org.allbinary.logic.java.exception;

//NoPlatform
public class ExceptionUtil
{
    private static readonly ExceptionUtil instance = new ExceptionUtil();
    public static ExceptionUtil getInstance()
    {
        return ExceptionUtil.instance;
    }

    private ExceptionUtil()
    {
    }

    public readonly Exception PRETEND_EXCEPTION = new Exception("Not Really An Exception");
    public virtual string getStackTrace(Exception e)
    {
        throw new SystemException();
    }

}

