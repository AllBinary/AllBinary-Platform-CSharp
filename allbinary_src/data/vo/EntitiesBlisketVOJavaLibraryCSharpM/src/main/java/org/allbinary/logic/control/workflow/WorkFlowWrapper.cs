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
//using Method = java.lang.reflect.Method;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.control.workflow;

public class WorkFlowWrapper : WorkFlowInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private object anyType;
    public WorkFlowWrapper(object anyType)
    {
        this.anyType = anyType;
    }

    public virtual object getWorkFlowObject()
    {
        return this.anyType;
    }

    // throws Exception
    public virtual string getName()
    {
        try {
            Type helperClass = this.anyType.GetType();
            Method method = helperClass.getMethod("getName", null);
            string result = ((string) method.invoke(this.anyType, null));
            return result;
        } catch (Exception e) {
            string error = "Reflection Exception";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getName()", e);
            }
            throw new Exception(error);
        }
    }

    // throws Exception
    public virtual string getStoreName()
    {
        try {
            Type helperClass = this.anyType.GetType();
            Method method = helperClass.getMethod("getStoreName", null);
            string result = ((string) method.invoke(this.anyType, null));
            return result;
        } catch (Exception e) {
            string error = "Reflection Exception";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getStoreName()", e);
            }
            throw new Exception(error);
        }
    }

    // throws Exception
    public virtual int? process()
    {
        try {
            Type helperClass = this.anyType.GetType();
            Method method = helperClass.getMethod(this.commonStrings.PROCESS, null);
            int? result = ((int?) method.invoke(this.anyType, null));
            return result;
        } catch (Exception e) {
            string error = "Reflection Exception";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
            }
            throw new Exception(error);
        }
    }

}

