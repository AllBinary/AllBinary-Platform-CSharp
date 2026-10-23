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
//using IOException = java.io.IOException;
using XmlRpcException = org.apache.xmlrpc.XmlRpcException;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using SpecialMessageUtil = org.allbinary.canvas.SpecialMessageUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using org.allbinary.util;

namespace org.allbinary.logic.communication.log;

//ActualPlatform
public class LogUtil
{
    private static readonly LogUtil instance = new LogUtil();
    public static LogUtil getInstance()
    {
        return LogUtil.instance;
    }

    private readonly string MESSAGE = "message";
    private bool isFirstException = true;
    private TimeDelayHelper timeDelayHelper = new TimeDelayHelper(200000);
    public AbeClientInformationInterface abeClientInformation = null;
    private LogUtil()
    {
    }

    private readonly StringMaker stringBuffer = new StringMaker();
    public virtual void putL(Log log)
    {
        if (log == null) {
            return;
        }
        string specialMessage = log.getSpecialMessage();
        object anyType = log.getObject();
        string functionName = log.getFunctionName();
        object exception = log.getThrowable();
        this.put(specialMessage, anyType, functionName, exception);
    }

    public virtual void putF(string specialMessage, object anyType, string functionName)
    {
    }

    public virtual void putF(string specialMessage, string className, string functionName)
    {
    }

    public virtual void put(string specialMessage, object anyType, string functionName, object exception)
    {
        if (exception != null) {
            if (string.CompareOrdinal(exception.GetType().FullName, typeof(XmlRpcException).getName()) == 0) {
                return;
            }
            if (string.CompareOrdinal(exception.GetType().FullName, typeof(IOException).getName()) == 0) {
                return;
            }
            if (this.isFirstException || this.timeDelayHelper.isTimeTNT()) {
                string className = CommonStrings.getInstance().EMPTY;
                this.isFirstException = false;
                if (anyType != null && anyType.GetType().FullName != null) {
                    className = new string((anyType.GetType().FullName).ToCharArray());
                }
                string message = LogFormatUtil.getInstance().get(className, functionName, specialMessage, exception);
                try {
                    Console.WriteLine("Eeeek");
                    if (this.abeClientInformation == null) {
                        throw new SystemException();
                    }
                    ABHashtable<object, object> hashtable = this.abeClientInformation.toHashtable();
                    this.stringBuffer.delete(0, this.stringBuffer.length());
                    this.stringBuffer.append(message);
                    this.stringBuffer.append(CommonSeps.getInstance().SPACE);
                    this.stringBuffer.append(SpecialMessageUtil.getInstance().get());
                    hashtable.put(this.MESSAGE, this.stringBuffer.ToString());
                    new XmlRpcRemoteLogClient(this.abeClientInformation).get(hashtable);
                } catch (Exception e) {
                    Console.WriteLine("Exception");
                    Console.WriteLine(e);
                }
            }
        }
    }

}

