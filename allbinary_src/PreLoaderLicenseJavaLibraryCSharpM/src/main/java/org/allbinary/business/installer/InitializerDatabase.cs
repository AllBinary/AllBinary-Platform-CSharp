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
using java.util;
using DatabaseConnectionInfoInterface = org.allbinary.business.init.db.DatabaseConnectionInfoInterface;
using DbConnectionInfo = org.allbinary.business.init.db.DbConnectionInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.installer;

public class InitializerDatabase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string adminDbUserName = null;
    private string adminDbPassword = null;
    private string adminJdbcDriver = null;
    private string adminSchema = null;
    private string adminServer = null;
    private string adminPort = null;
    private static readonly int MAXDB = 30;
    private static readonly int MAX = 16;
    private static readonly int MIN = 4;
    private static readonly int MINPASSWORD = 0;
    private DynamicInitDb initDb = null;
    public InitializerDatabase(AbeClientInformationInterface abeClientInformation, Map map)
    {
        StringMaker stringBuffer = new StringMaker();
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        Set keys = map.keySet();
        object[] keyArray = keys.toArray();
        int size = keyArray.Length;
        for (int index = 0; index < size; index++) {
            string key = ((string) keyArray[index]);
            string[] values = ((string[]) map.get(key));
            hashMap.put(new string((key).ToCharArray()), new string((values[0]).ToCharArray()));
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append("key: ");
            stringBuffer.append(key);
            stringBuffer.append(" Value: ");
            stringBuffer.append(values[0]);
            this.logUtil.putF(stringBuffer.ToString(), this, "getFormData()");
        }
        this.getFormData(abeClientInformation, hashMap);
    }

    public InitializerDatabase(AbeClientInformationInterface abeClientInformation, HashMap initHashMap)
    {
        this.getFormData(abeClientInformation, initHashMap);
    }

    public virtual void getFormData(AbeClientInformationInterface abeClientInformation, HashMap hashMap)
    {
        try {
            InitializerData initializerData = InitializerData.getInstance();
            this.setAdminDbUserName(((string) hashMap.get(initializerData.DBUSER)));
            this.setAdminDbPassword(((string) hashMap.get(initializerData.DBPASSWORD)));
            this.setAdminJdbcDriver(((string) hashMap.get(initializerData.ADMINJDBCDRIVER)));
            this.setAdminSchema(((string) hashMap.get(initializerData.ADMINSCHEMA)));
            this.setAdminServer(((string) hashMap.get(initializerData.ADMINSERVER)));
            this.setAdminPort(((string) hashMap.get(initializerData.ADMINPORT)));
            DbConnectionInfo dbConnectionInfo = new DbConnectionInfo();
            string adminDbName = StringUtil.getInstance().EMPTY_STRING;
            dbConnectionInfo.setJdbcDriver(getAdminJdbcDriver());
            dbConnectionInfo.setName(adminDbName);
            dbConnectionInfo.setUserName(getAdminDbUserName());
            dbConnectionInfo.setPassword(getAdminDbPassword());
            dbConnectionInfo.setSchema(getAdminSchema());
            dbConnectionInfo.setServer(getAdminServer());
            dbConnectionInfo.setPort(getAdminPort());
            this.initDb = new DynamicInitDb(abeClientInformation, ((DatabaseConnectionInfoInterface) dbConnectionInfo));
        } catch (Exception e) {
            this.logUtil.put("Unable to get form data", this, "getFormData()", e);
        }
    }

    private bool isJdbcDriverValid(string jdbcDriverClassPathString)
    {
        try {
            Class.forName(jdbcDriverClassPathString).newInstance();
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual bool isValid()
    {
        bool isValid = true;
        if (!this.isJdbcDriverValid(this.adminJdbcDriver)) {
            isValid = false;
        }
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (!stringValidationUtil.isValidRequired(this.adminDbUserName, InitializerDatabase.MIN, InitializerDatabase.MAX)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.adminDbPassword, InitializerDatabase.MINPASSWORD, InitializerDatabase.MAX)) {
            isValid = false;
        }
        return isValid;
    }

    private string getJdbcDriverValidationInfo(string jdbcDriver)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("The JDBC driver (");
        stringBuffer.append(jdbcDriver);
        stringBuffer.append(") you have provided is not valid.<br/>");
        return stringBuffer.ToString();
    }

    public virtual string getInvalidInfo()
    {
        bool isValid = true;
        bool isJdbcDriversValid = true;
        StringMaker stringBuffer = new StringMaker();
        if (!this.isJdbcDriverValid(this.adminJdbcDriver)) {
            isJdbcDriversValid = false;
            stringBuffer.append(this.getJdbcDriverValidationInfo(this.getAdminJdbcDriver()));
        }
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (!stringValidationUtil.isValidRequired(this.adminDbUserName, InitializerDatabase.MIN, InitializerDatabase.MAX)) {
            stringBuffer.append("Admin username should be < " + InitializerDatabase.MAX + " and > " + InitializerDatabase.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidNotRequired(this.adminDbPassword, InitializerDatabase.MINPASSWORD, InitializerDatabase.MAX)) {
            stringBuffer.append("Admin password should be < " + InitializerDatabase.MAX + " and > " + InitializerDatabase.MINPASSWORD + " characters in length.<br />");
        }
        if (!isJdbcDriversValid) {
            stringBuffer.append(InitializerData.getInstance().getJdbcDriverSolutionInfo());
        }
        return stringBuffer.ToString();
    }

    public virtual bool createUsers()
    {
        try {
            this.initDb.addUsers();
            return true;
        } catch (Exception e) {
            this.logUtil.put("Unable to Create Users", this, "createUsers()", e);
            return false;
        }
    }

    public virtual bool createDatabases()
    {
        try {
            this.initDb.addDatabases();
            return true;
        } catch (Exception e) {
            this.logUtil.put("Unable to Create Databases", this, "createDatabases()", e);
            return false;
        }
    }

    public virtual bool createTables()
    {
        try {
            this.initDb.addTables();
            return true;
        } catch (Exception e) {
            this.logUtil.put("Unable to Create Tables", this, "createTables()", e);
            return false;
        }
    }

    public virtual string getAdminDbUserName()
    {
        return this.adminDbUserName;
    }

    public virtual void setAdminDbUserName(string adminDbUserName)
    {
        this.adminDbUserName = adminDbUserName;
    }

    public virtual string getAdminDbPassword()
    {
        return this.adminDbPassword;
    }

    public virtual void setAdminDbPassword(string adminDbPassword)
    {
        this.adminDbPassword = adminDbPassword;
    }

    public virtual string getAdminJdbcDriver()
    {
        return this.adminJdbcDriver;
    }

    public virtual void setAdminJdbcDriver(string adminJdbcDriver)
    {
        this.adminJdbcDriver = adminJdbcDriver;
    }

    public virtual string getAdminSchema()
    {
        return this.adminSchema;
    }

    public virtual void setAdminSchema(string adminSchema)
    {
        this.adminSchema = adminSchema;
    }

    public virtual string getAdminServer()
    {
        return this.adminServer;
    }

    public virtual void setAdminServer(string adminServer)
    {
        this.adminServer = adminServer;
    }

    public virtual string getAdminPort()
    {
        return this.adminPort;
    }

    public virtual void setAdminPort(string adminPort)
    {
        this.adminPort = adminPort;
    }

}

