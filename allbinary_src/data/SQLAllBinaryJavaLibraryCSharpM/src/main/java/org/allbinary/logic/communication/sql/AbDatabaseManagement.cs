/*
 * 
 * To change this license header, choose License Headers in Project Properties. 
 * To change this template file, choose Tools | Templates 
 * and open the template in the editor.  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
//using InetAddress = java.net.InetAddress;
using DatabaseConnectionInfoInterface = org.allbinary.business.init.db.DatabaseConnectionInfoInterface;
using DbConnectionInfo = org.allbinary.business.init.db.DbConnectionInfo;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.sql;

public class AbDatabaseManagement : AbSqlBean
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly StringMaker sqlCommandLog = new StringMaker();
    private readonly string GRANT_ALL = "GRANT SELECT, INSERT, UPDATE, DELETE, CREATE, DROP, INDEX, ALTER ON ";
    private readonly string DOT_STAR = ".*";
    private readonly string TO = " TO ";
    private readonly string AT_LOCALHOST = "@localhost";
    private readonly string IDENTIFIED_BY = " IDENTIFIED BY '";
    private readonly string WITH_GRANT_OPTION = "' WITH GRANT OPTION";
    private readonly string FAILED = "Failed";
    private readonly string GET_HOST_NAME = "getHostName()";
    private readonly string METHOD_ADD_USER = "addUser()";
    public readonly string METHOD_ADD_USERS = "addUsers()";
    private readonly string METHOD_ADD_DB = "addDb()";
    public readonly string METHOD_ADD_DATABASES = "addDatabases()";
    public readonly string METHOD_ADD_TABLES = "addTables()";
    public readonly string UNABLE_TO_CREATE_USER = "Unable to Create User: ";
    public readonly string UNABLE_TO_CREATE_DATABASE = "Unable to Create Database: ";
    public readonly string UNABLE_TO_CREATE_TABLES = "Unable to Create Tables";
    public readonly string ADD_TABLES_RESULTS_LABEL = "Add Table Results: ";
    public AbDatabaseManagement(DatabaseConnectionInfoInterface databaseConnectionInfoInterface) : base(((DbConnectionInfo) databaseConnectionInfoInterface))
    {
        // base(((DbConnectionInfo) databaseConnectionInfoInterface)) is called from the constructor declaration
    }

    public AbDatabaseManagement(DbConnectionInfo connectionInfo) : base(connectionInfo)
    {
        // base(connectionInfo) is called from the constructor declaration
    }

    private string getHostName()
    {
        try {
            InetAddress addr = InetAddress.getLocalHost();
            return addr.getHostName();
        } catch (Exception e) {
            this.logUtil.put(this.FAILED, this, GET_HOST_NAME, e);
            return null;
        }
    }

    // throws Exception
    public virtual bool addDbUser(string hostName, string db, string userName, string password)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.GRANT_ALL);
        stringBuffer.append(db);
        stringBuffer.append(this.DOT_STAR);
        stringBuffer.append(this.TO);
        stringBuffer.append(userName);
        stringBuffer.append(hostName);
        stringBuffer.append(this.IDENTIFIED_BY);
        stringBuffer.append(password);
        stringBuffer.append(this.WITH_GRANT_OPTION);
        string sqlStatement = stringBuffer.ToString();
        this.sqlCommandLog.append(sqlStatement);
        this.sqlCommandLog.append(this.commonSeps.NEW_LINE);
        base.executeSQLStatement(sqlStatement);
        return true;
    }

    public virtual bool addDbUser(string db, string userName, string password)
    {
        try {
            this.addDbUser(this.AT_LOCALHOST, db, userName, password);
            string hostName = this.getHostName();
            if (hostName != null) {
                this.addDbUser(hostName, db, userName, password);
            }
            return true;
        } catch (Exception e) {
            this.logUtil.put(this.UNABLE_TO_CREATE_USER + userName, this, this.METHOD_ADD_USER, e);
            return false;
        }
    }

    public virtual bool? addDb(string db)
    {
        try {
            string sqlStatement = this.sqlStrings.CREATE_DATABASE + db;
            this.sqlCommandLog.append(sqlStatement);
            this.sqlCommandLog.append(this.commonSeps.NEW_LINE);
            base.executeSQLStatement(sqlStatement);
            return true;
        } catch (Exception e) {
            this.logUtil.put(this.UNABLE_TO_CREATE_DATABASE + db, this, this.METHOD_ADD_DB, e);
            return false;
        }
    }

}

