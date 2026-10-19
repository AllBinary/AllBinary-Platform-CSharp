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
using DbConnectionInfo = org.allbinary.business.init.db.DbConnectionInfo;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace org.allbinary.business.installer;

//Warning you must have sql root access
public class InitDb
{
    private object anyType = null;
    private readonly string METHOD_CALL_GET_HOST_NAME = "getHostName";
    private readonly string METHOD_CALL_ADD_USERS = "addUsers";
    private readonly string METHOD_CALL_ADD_DATABASES = "addDatabases";
    private readonly string METHOD_CALL_ADD_TABLES = "addTables";
    private readonly string METHOD_CALL_TEMP_MAIN_PATH = "useTemporaryMainPath";
    private readonly string METHOD_CALL_MAIN_PATH = "useNormalMainPath";
    public InitDb()
    {
    }

    public InitDb(DbConnectionInfo dbConnectionInfo)
    {
    }

    protected virtual void setHelper(object anyType)
    {
        this.anyType = anyType;
    }

    protected virtual object getHelper()
    {
        return this.anyType;
    }

    private string getHostName()
    {
        try {
            Type dynamicClass = this.anyType.GetType();
            Method method = dynamicClass.getMethod(this.METHOD_CALL_GET_HOST_NAME, null);
            string result = ((string) method.invoke(this.anyType, null));
            return result;
        } catch (Exception e) {
            return null;
        }
    }

    public virtual bool addUsers()
    {
        try {
            Type dynamicClass = this.anyType.GetType();
            Method method = dynamicClass.getMethod(this.METHOD_CALL_ADD_USERS, null);
            bool? result = ((bool?) method.invoke(this.anyType, null));
            return result;
        } catch (Exception e) {
            return false;
        }
    }

    public virtual bool addDatabases()
    {
        try {
            Type dynamicClass = this.anyType.GetType();
            Method method = dynamicClass.getMethod(this.METHOD_CALL_ADD_DATABASES, null);
            bool? result = ((bool?) method.invoke(this.anyType, null));
            return result;
        } catch (Exception e) {
            return false;
        }
    }

    public virtual bool addTables()
    {
        try {
            Type dynamicClass = this.anyType.GetType();
            Method method = dynamicClass.getMethod(this.METHOD_CALL_ADD_TABLES, null);
            bool? result = ((bool?) method.invoke(this.anyType, null));
            return result;
        } catch (Exception e) {
            return false;
        }
    }

    public virtual bool useTemporaryMainPath()
    {
        try {
            Type dynamicClass = this.anyType.GetType();
            Method method = dynamicClass.getMethod(this.METHOD_CALL_TEMP_MAIN_PATH, null);
            bool? result = ((bool?) method.invoke(this.anyType, null));
            return result;
        } catch (Exception e) {
            return false;
        }
    }

    public virtual bool useNormalMainPath()
    {
        try {
            Type dynamicClass = this.anyType.GetType();
            Method method = dynamicClass.getMethod(this.METHOD_CALL_MAIN_PATH, null);
            bool? result = ((bool?) method.invoke(this.anyType, null));
            return result;
        } catch (Exception e) {
            return false;
        }
    }

}

