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
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.business.installer;

public class InitializerData
{
    private static readonly InitializerData instance = new InitializerData();
    public static InitializerData getInstance()
    {
        return InitializerData.instance;
    }

    public readonly string DBUSER = "DBUSER";
    public readonly string DBPASSWORD = "DBPASSWORD";
    public readonly string ADMINJDBCDRIVER = "ADMIN_JDBCDRIVER";
    public readonly string ADMINSCHEMA = "ADMINSCHEMA";
    public readonly string ADMINSERVER = "ADMINSERVER";
    public readonly string ADMINPORT = "ADMINPORT";
    public readonly string CUSTOMERJDBCDRIVER = "CUSTOMER_JDBCDRIVER";
    public readonly string CUSTOMERNAME = "CUSTOMERNAME";
    public readonly string CUSTOMERUSERNAME = "CUSTOMERUSERNAME";
    public readonly string CUSTOMERPASSWORD = "CUSTOMERPASSWORD";
    public readonly string CUSTOMERSCHEMA = "CUSTOMERSCHEMA";
    public readonly string CUSTOMERSERVER = "CUSTOMERSERVER";
    public readonly string CUSTOMERPORT = "CUSTOMERPORT";
    public readonly string HISTORYJDBCDRIVER = "HISTORY_JDBCDRIVER";
    public readonly string HISTORYNAME = "HISTORYNAME";
    public readonly string HISTORYUSERNAME = "HISTORYUSERNAME";
    public readonly string HISTORYPASSWORD = "HISTORYPASSWORD";
    public readonly string HISTORYSCHEMA = "HISTORYSCHEMA";
    public readonly string HISTORYSERVER = "HISTORYSERVER";
    public readonly string HISTORYPORT = "HISTORYPORT";
    public readonly string LOGJDBCDRIVER = "LOG_JDBCDRIVER";
    public readonly string LOGNAME = "LOGNAME";
    public readonly string LOGUSERNAME = "LOGUSERNAME";
    public readonly string LOGPASSWORD = "LOGPASSWORD";
    public readonly string LOGSCHEMA = "LOGSCHEMA";
    public readonly string LOGSERVER = "LOGSERVER";
    public readonly string LOGPORT = "LOGPORT";
    public readonly string INVENTORYJDBCDRIVER = "INVENTORY_JDBCDRIVER";
    public readonly string INVENTORYNAME = "INVENTORYNAME";
    public readonly string INVENTORYUSERNAME = "INVENTORYUSERNAME";
    public readonly string INVENTORYPASSWORD = "INVENTORYPASSWORD";
    public readonly string INVENTORYSCHEMA = "INVENTORYSCHEMA";
    public readonly string INVENTORYSERVER = "INVENTORYSERVER";
    public readonly string INVENTORYPORT = "INVENTORYPORT";
    public readonly string STATICPAGESJDBCDRIVER = "STATICPAGES_JDBCDRIVER";
    public readonly string STATICPAGESNAME = "STATICPAGESNAME";
    public readonly string STATICPAGESUSERNAME = "STATICPAGESUSERNAME";
    public readonly string STATICPAGESPASSWORD = "STATICPAGESPASSWORD";
    public readonly string STATICPAGESSCHEMA = "STATICPAGESSCHEMA";
    public readonly string STATICPAGESSERVER = "STATICPAGESSERVER";
    public readonly string STATICPAGESPORT = "STATICPAGESPORT";
    public virtual string getJdbcDriverSolutionInfo()
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

}

