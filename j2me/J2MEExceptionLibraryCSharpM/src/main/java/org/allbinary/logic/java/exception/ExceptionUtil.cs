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

namespace org.allbinary.logic.java.exception;

//ActualPlatform
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
    private readonly string NONE = "No Stack Trace";
    public virtual string getStackTrace(Exception e)
    {
        System.IO.MemoryStream bs = new System.IO.MemoryStream();
        Console.WriteLine(e);
        string output = System.Text.Encoding.UTF8.GetString(bs.ToArray());
        if (output != null) {
            return new string((output).ToCharArray());
        }
        return this.NONE;
    }

}

