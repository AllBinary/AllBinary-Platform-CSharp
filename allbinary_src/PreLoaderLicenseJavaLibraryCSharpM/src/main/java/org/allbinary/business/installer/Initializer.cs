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
using HistoryDbInitInfo = org.allbinary.business.init.db.HistoryDbInitInfo;
using InventoryDbInitInfo = org.allbinary.business.init.db.InventoryDbInitInfo;
using LogDbInitInfo = org.allbinary.business.init.db.LogDbInitInfo;
using StaticPagesDbInitInfo = org.allbinary.business.init.db.StaticPagesDbInitInfo;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.installer;

public class Initializer
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string userJdbcDriver = null;
    private string userName = null;
    private string userUserName = null;
    private string userPassword = null;
    private string userSchema = null;
    private string userServer = null;
    private string userPort = null;
    private string historyJdbcDriver = null;
    private string historyName = null;
    private string historyUserName = null;
    private string historyPassword = null;
    private string historySchema = null;
    private string historyServer = null;
    private string historyPort = null;
    private string logJdbcDriver = null;
    private string logName = null;
    private string logUserName = null;
    private string logPassword = null;
    private string logSchema = null;
    private string logServer = null;
    private string logPort = null;
    private string inventoryJdbcDriver = null;
    private string inventoryName = null;
    private string inventoryUserName = null;
    private string inventoryPassword = null;
    private string inventorySchema = null;
    private string inventoryServer = null;
    private string inventoryPort = null;
    private string staticPagesJdbcDriver = null;
    private string staticPagesName = null;
    private string staticPagesUserName = null;
    private string staticPagesPassword = null;
    private string staticPagesSchema = null;
    private string staticPagesServer = null;
    private string staticPagesPort = null;
    private static readonly int MAXDB = 30;
    private static readonly int MAX = 16;
    private static readonly int MIN = 4;
    private static readonly int MINPASSWORD = 0;
    public Initializer(Map<object, object> map)
    {
        StringMaker stringBuffer = new StringMaker();
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        Set<object> keys = map.keySet();
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
        this.getFormData(hashMap);
    }

    public Initializer(HashMap<object, object> initHashMap)
    {
        this.getFormData(initHashMap);
    }

    public virtual void getFormData(HashMap<object, object> hashMap)
    {
        try {
            InitializerData initializerData = InitializerData.getInstance();
            this.userJdbcDriver = ((string) hashMap.get(initializerData.CUSTOMERJDBCDRIVER));
            this.userName = ((string) hashMap.get(initializerData.CUSTOMERNAME));
            this.userUserName = ((string) hashMap.get(initializerData.CUSTOMERUSERNAME));
            this.userPassword = ((string) hashMap.get(initializerData.CUSTOMERPASSWORD));
            this.userSchema = ((string) hashMap.get(initializerData.CUSTOMERSCHEMA));
            this.userServer = ((string) hashMap.get(initializerData.CUSTOMERSERVER));
            this.userPort = ((string) hashMap.get(initializerData.CUSTOMERPORT));
            this.historyJdbcDriver = ((string) hashMap.get(initializerData.HISTORYJDBCDRIVER));
            this.historyName = ((string) hashMap.get(initializerData.HISTORYNAME));
            this.historyUserName = ((string) hashMap.get(initializerData.HISTORYUSERNAME));
            this.historyPassword = ((string) hashMap.get(initializerData.HISTORYPASSWORD));
            this.historySchema = ((string) hashMap.get(initializerData.HISTORYSCHEMA));
            this.historyServer = ((string) hashMap.get(initializerData.HISTORYSERVER));
            this.historyPort = ((string) hashMap.get(initializerData.HISTORYPORT));
            this.logJdbcDriver = ((string) hashMap.get(initializerData.LOGJDBCDRIVER));
            this.logName = ((string) hashMap.get(initializerData.LOGNAME));
            this.logUserName = ((string) hashMap.get(initializerData.LOGUSERNAME));
            this.logPassword = ((string) hashMap.get(initializerData.LOGPASSWORD));
            this.logSchema = ((string) hashMap.get(initializerData.LOGSCHEMA));
            this.logServer = ((string) hashMap.get(initializerData.LOGSERVER));
            this.logPort = ((string) hashMap.get(initializerData.LOGPORT));
            this.inventoryJdbcDriver = ((string) hashMap.get(initializerData.INVENTORYJDBCDRIVER));
            this.inventoryName = ((string) hashMap.get(initializerData.INVENTORYNAME));
            this.inventoryUserName = ((string) hashMap.get(initializerData.INVENTORYUSERNAME));
            this.inventoryPassword = ((string) hashMap.get(initializerData.INVENTORYPASSWORD));
            this.inventorySchema = ((string) hashMap.get(initializerData.INVENTORYSCHEMA));
            this.inventoryServer = ((string) hashMap.get(initializerData.INVENTORYSERVER));
            this.inventoryPort = ((string) hashMap.get(initializerData.INVENTORYPORT));
            this.staticPagesJdbcDriver = ((string) hashMap.get(initializerData.STATICPAGESJDBCDRIVER));
            this.staticPagesName = ((string) hashMap.get(initializerData.STATICPAGESNAME));
            this.staticPagesUserName = ((string) hashMap.get(initializerData.STATICPAGESUSERNAME));
            this.staticPagesPassword = ((string) hashMap.get(initializerData.STATICPAGESPASSWORD));
            this.staticPagesSchema = ((string) hashMap.get(initializerData.STATICPAGESSCHEMA));
            this.staticPagesServer = ((string) hashMap.get(initializerData.STATICPAGESSERVER));
            this.staticPagesPort = ((string) hashMap.get(initializerData.STATICPAGESPORT));
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
        if (!this.isJdbcDriverValid(this.userJdbcDriver)) {
            isValid = false;
        }
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (!stringValidationUtil.isValidRequired(this.userName, Initializer.MIN, Initializer.MAXDB)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.userUserName, Initializer.MIN, Initializer.MAX)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.userPassword, Initializer.MINPASSWORD, Initializer.MAX)) {
            isValid = false;
        }
        if (!this.isJdbcDriverValid(this.historyJdbcDriver)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.historyName, Initializer.MIN, Initializer.MAXDB)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.historyUserName, Initializer.MIN, Initializer.MAX)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.historyPassword, Initializer.MINPASSWORD, Initializer.MAX)) {
            isValid = false;
        }
        if (!this.isJdbcDriverValid(this.logJdbcDriver)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.logName, Initializer.MIN, Initializer.MAXDB)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.logUserName, Initializer.MIN, Initializer.MAX)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.logPassword, Initializer.MINPASSWORD, Initializer.MAX)) {
            isValid = false;
        }
        if (!this.isJdbcDriverValid(this.inventoryJdbcDriver)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.inventoryName, Initializer.MIN, Initializer.MAXDB)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.inventoryUserName, Initializer.MIN, Initializer.MAX)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.inventoryPassword, Initializer.MINPASSWORD, Initializer.MAX)) {
            isValid = false;
        }
        if (!this.isJdbcDriverValid(this.staticPagesJdbcDriver)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.staticPagesName, Initializer.MIN, Initializer.MAXDB)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidRequired(this.staticPagesUserName, Initializer.MIN, Initializer.MAX)) {
            isValid = false;
        }
        if (!stringValidationUtil.isValidNotRequired(this.staticPagesPassword, Initializer.MINPASSWORD, Initializer.MAX)) {
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

    private string getJdbcDriverSolutionInfo()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("The following describes the possible problems and solutions regarding the Jdbc Driver error(s):<p/>");
        stringBuffer.append("1. A JDBC driver you specified is not in your classpath.<br/>");
        stringBuffer.append("Solution 1: Move the JDBC driver into any directory specified in the existing classpath. <br/>");
        stringBuffer.append("Solution 2: Add the directory that contains the JDBC driver to the classpath.<br/>");
        stringBuffer.append("Solution 3: Add the JDBC driver to the WEB-INF/lib directory where you installed this webapp.<br/>");
        stringBuffer.append("2. The JDBC driver you specified does not exit.<br/>");
        stringBuffer.append("Solution: Get a JDBC driver. <br/>");
        stringBuffer.append("3. The JDBC driver you specified is not valid.<br/>");
        stringBuffer.append("Solution: Use a valid JDBC driver.<p/>");
        return stringBuffer.ToString();
    }

    public virtual string getInvalidInfo()
    {
        bool isJdbcDriversValid = true;
        StringMaker stringBuffer = new StringMaker();
        if (!this.isJdbcDriverValid(this.userJdbcDriver)) {
            isJdbcDriversValid = false;
            stringBuffer.append(this.getJdbcDriverValidationInfo(this.userJdbcDriver));
        }
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (!stringValidationUtil.isValidRequired(this.userName, Initializer.MIN, Initializer.MAXDB)) {
            stringBuffer.append("User db name should be < " + Initializer.MAXDB + " and > " + Initializer.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidRequired(this.userUserName, Initializer.MIN, Initializer.MAX)) {
            stringBuffer.append("User db username should be < " + Initializer.MAX + " and > " + Initializer.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidNotRequired(this.userPassword, Initializer.MINPASSWORD, Initializer.MAX)) {
            stringBuffer.append("User DB password should be < " + Initializer.MAX + " and > " + Initializer.MINPASSWORD + " characters in length.<br />");
        }
        if (!this.isJdbcDriverValid(this.historyJdbcDriver)) {
            isJdbcDriversValid = false;
            stringBuffer.append(this.getJdbcDriverValidationInfo(this.historyJdbcDriver));
        }
        if (!stringValidationUtil.isValidRequired(this.historyName, Initializer.MIN, Initializer.MAXDB)) {
            stringBuffer.append("History db should be < " + Initializer.MAXDB + " and > " + Initializer.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidRequired(this.historyUserName, Initializer.MIN, Initializer.MAX)) {
            stringBuffer.append("History db username should be < " + Initializer.MAX + " and > " + Initializer.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidNotRequired(this.historyPassword, Initializer.MINPASSWORD, Initializer.MAX)) {
            stringBuffer.append("History db password should be < " + Initializer.MAX + " and > " + Initializer.MINPASSWORD + " characters in length.<br />");
        }
        if (!this.isJdbcDriverValid(this.logJdbcDriver)) {
            isJdbcDriversValid = false;
            stringBuffer.append(this.getJdbcDriverValidationInfo(this.logJdbcDriver));
        }
        if (!stringValidationUtil.isValidRequired(this.logName, Initializer.MIN, Initializer.MAXDB)) {
            stringBuffer.append("Log db should be < " + Initializer.MAXDB + " and > " + Initializer.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidRequired(this.logUserName, Initializer.MIN, Initializer.MAX)) {
            stringBuffer.append("Log db username should be < " + Initializer.MAX + " and > " + Initializer.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidNotRequired(this.logPassword, Initializer.MINPASSWORD, Initializer.MAX)) {
            stringBuffer.append("Log db password should be < " + Initializer.MAX + " and > " + Initializer.MINPASSWORD + " characters in length.<br />");
        }
        if (!this.isJdbcDriverValid(this.inventoryJdbcDriver)) {
            isJdbcDriversValid = false;
            stringBuffer.append(this.getJdbcDriverValidationInfo(this.inventoryJdbcDriver));
        }
        if (!stringValidationUtil.isValidRequired(this.inventoryName, Initializer.MIN, Initializer.MAXDB)) {
            stringBuffer.append("Inventory db should be < " + Initializer.MAXDB + " and > " + Initializer.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidRequired(this.inventoryUserName, Initializer.MIN, Initializer.MAX)) {
            stringBuffer.append("Inventory db username should be < " + Initializer.MAX + " and > " + Initializer.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidNotRequired(this.inventoryPassword, Initializer.MINPASSWORD, Initializer.MAX)) {
            stringBuffer.append("Inventory DB password should be < " + Initializer.MAX + " and > " + Initializer.MINPASSWORD + " characters in length.<br />");
        }
        if (!this.isJdbcDriverValid(this.staticPagesJdbcDriver)) {
            isJdbcDriversValid = false;
            stringBuffer.append(this.getJdbcDriverValidationInfo(this.staticPagesJdbcDriver));
        }
        if (!stringValidationUtil.isValidRequired(this.staticPagesName, Initializer.MIN, Initializer.MAXDB)) {
            stringBuffer.append("Static Pages db should be < " + Initializer.MAXDB + " and > " + Initializer.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidRequired(this.staticPagesUserName, Initializer.MIN, Initializer.MAX)) {
            stringBuffer.append("Static Pages db username should be < " + Initializer.MAX + " and > " + Initializer.MIN + " characters in length.<br />");
        }
        if (!stringValidationUtil.isValidNotRequired(this.staticPagesPassword, Initializer.MINPASSWORD, Initializer.MAX)) {
            stringBuffer.append("Static Pages DB password should be < " + Initializer.MAX + " and > " + Initializer.MINPASSWORD + " characters in length.<br />");
        }
        if (!isJdbcDriversValid) {
            stringBuffer.append(getJdbcDriverSolutionInfo());
        }
        return stringBuffer.ToString();
    }

    // throws Exception
    public virtual void set()
    {
        this.logUtil.putF("Creating DB connection files", this, "set()");
        UserDbInitInfo userDbInitInfo = new UserDbInitInfo(false);
        userDbInitInfo.setJdbcDriver(this.userJdbcDriver);
        userDbInitInfo.setName(this.userName);
        userDbInitInfo.setUserName(this.userUserName);
        userDbInitInfo.setPassword(this.userPassword);
        userDbInitInfo.setSchema(this.userSchema);
        userDbInitInfo.setServer(this.userServer);
        userDbInitInfo.setPort(this.userPort);
        userDbInitInfo.setHasRead(true);
        userDbInitInfo.write();
        HistoryDbInitInfo historyDbInitInfo = new HistoryDbInitInfo(false);
        historyDbInitInfo.setJdbcDriver(this.historyJdbcDriver);
        historyDbInitInfo.setName(this.historyName);
        historyDbInitInfo.setUserName(this.historyUserName);
        historyDbInitInfo.setPassword(this.historyPassword);
        historyDbInitInfo.setSchema(this.historySchema);
        historyDbInitInfo.setServer(this.historyServer);
        historyDbInitInfo.setPort(this.historyPort);
        historyDbInitInfo.setHasRead(true);
        historyDbInitInfo.write();
        LogDbInitInfo logDbInitInfo = new LogDbInitInfo(false);
        logDbInitInfo.setJdbcDriver(this.logJdbcDriver);
        logDbInitInfo.setName(this.logName);
        logDbInitInfo.setUserName(this.logUserName);
        logDbInitInfo.setPassword(this.logPassword);
        logDbInitInfo.setSchema(this.logSchema);
        logDbInitInfo.setServer(this.logServer);
        logDbInitInfo.setPort(this.logPort);
        logDbInitInfo.setHasRead(true);
        logDbInitInfo.write();
        StaticPagesDbInitInfo staticPagesDbInitInfo = new StaticPagesDbInitInfo(false);
        staticPagesDbInitInfo.setJdbcDriver(this.staticPagesJdbcDriver);
        staticPagesDbInitInfo.setName(this.staticPagesName);
        staticPagesDbInitInfo.setUserName(this.staticPagesUserName);
        staticPagesDbInitInfo.setPassword(this.staticPagesPassword);
        staticPagesDbInitInfo.setSchema(this.staticPagesSchema);
        staticPagesDbInitInfo.setServer(this.staticPagesServer);
        staticPagesDbInitInfo.setPort(this.staticPagesPort);
        staticPagesDbInitInfo.setHasRead(true);
        staticPagesDbInitInfo.write();
        InventoryDbInitInfo inventoryDbInitInfo = new InventoryDbInitInfo(false);
        inventoryDbInitInfo.setJdbcDriver(this.inventoryJdbcDriver);
        inventoryDbInitInfo.setName(this.inventoryName);
        inventoryDbInitInfo.setUserName(this.inventoryUserName);
        inventoryDbInitInfo.setPassword(this.inventoryPassword);
        inventoryDbInitInfo.setSchema(this.inventorySchema);
        inventoryDbInitInfo.setServer(this.inventoryServer);
        inventoryDbInitInfo.setPort(this.inventoryPort);
        inventoryDbInitInfo.setHasRead(true);
        inventoryDbInitInfo.write();
        this.logUtil.putF("Created DB connection files", this, "set()");
    }

}

