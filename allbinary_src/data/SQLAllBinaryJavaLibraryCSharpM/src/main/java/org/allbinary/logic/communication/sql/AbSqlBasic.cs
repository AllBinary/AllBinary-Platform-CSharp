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
//using Connection = java.sql.Connection;
//using ResultSet = java.sql.ResultSet;
//using SQLException = java.sql.SQLException;
//using Statement = java.sql.Statement;
using DatabaseConnectionInfoInterface = org.allbinary.business.init.db.DatabaseConnectionInfoInterface;
using DbConnectionInfo = org.allbinary.business.init.db.DbConnectionInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SqlConnectionPool = org.allbinary.logic.communication.sql.connection.pool.SqlConnectionPool;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.sql;

public class AbSqlBasic
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly SqlConnectionPool sqlConnectionPool = SqlConnectionPool.getInstance();
    private DbConnectionInfo databaseConnectionInfoInterface;
    private int connectAttemptCounter;
    public Connection conn;
    public readonly StringUtil stringUtil = StringUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly CommonSeps commonSeps = CommonSeps.getInstance();
    public readonly StdUtil stdUtil = StdUtil.getInstance();
    public readonly SqlTypeStrings sqlTypeStrings = SqlTypeStrings.getInstance();
    public readonly SqlStrings sqlStrings = SqlStrings.getInstance();
    public readonly string INSERT = "insert";
    public readonly string UPDATE = "update";
    public readonly string FAILED_SQL_STATEMENT = "Failed\nSQL Statement: ";
    public readonly string SUCCESS_SQL_STATEMENT = "Success\nSQL Statement: ";
    private readonly string METHOD_EXECUTED_SQL_STATEMENT = "executedSQLStatement";
    private readonly string METHOD_CREATE = "create";
    private readonly string DATABASE_CREATED_LABEL = "Database Created: ";
    private readonly string DATABASE_CREATION_FAILED_LABEL = "Database Creation Failed: ";
    private readonly string SQL_CONNECTION_FAILED = "SQL Connection Failed";
    private readonly string SQL_CONNECTION_RETRYING = "SQL Connection Retrying";
    private readonly string SQL_CONNECTION_RETRY = "SQL Connection Retry";
    private readonly string METHOD_CREATE_CONNECTION = "createConnection()";
    private readonly string METHOD_INITIALIZE = "initialize";
    private readonly string LOAD_JDBC_DRIVER_FAILED_LABEL = "Load JDBC Driver Failed: ";
    public AbSqlBasic(DbConnectionInfo databaseConnectionInfoInterface)
    {
        this.databaseConnectionInfoInterface = databaseConnectionInfoInterface;
        this.connectAttemptCounter = 0;
        this.conn = null;
    }

    // throws SQLException
    public virtual ResultSet executeSQLStatement(string statement)
    {
        try {
            this.initialize();
            Statement stmt = this.conn.createStatement();
            stmt.execute(statement);
            ResultSet rset = stmt.getResultSet();
            stmt.close();
            Connection tempConnection = this.conn;
            this.conn = null;
            this.sqlConnectionPool.add(this.getDatabaseConnectionInfoInterface().getUrl(), tempConnection);
            return rset;
        } catch (SQLException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + statement, this, METHOD_EXECUTED_SQL_STATEMENT, e);
            }
            this.conn.close();
            this.conn = null;
            throw e;
        }
    }

    public virtual string create(string databaseName)
    {
        try {
            this.executeSQLStatement(this.sqlStrings.CREATE_DATABASE + databaseName);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.DATABASE_CREATED_LABEL + databaseName, this, this.METHOD_CREATE);
            }
            return databaseName + this.sqlStrings.CREATE_RETURN;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.DATABASE_CREATION_FAILED_LABEL + databaseName, this, this.METHOD_CREATE, e);
            }
            return this.DATABASE_CREATION_FAILED_LABEL + databaseName;
        }
    }

    private void createConnection()
    {
        try {
            this.conn = this.sqlConnectionPool.get(this.getDatabaseConnectionInfoInterface().getUrl());
        } catch (SQLException se) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.SQL_CONNECTION_RETRYING, this, METHOD_CREATE_CONNECTION, se);
            }
            try {
                Thread.currentThread().sleep(2000);
                if (this.connectAttemptCounter < 10) {
                    this.connectAttemptCounter++;
                    this.initialize();
                }
            } catch (Exception e) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                    this.logUtil.put(this.SQL_CONNECTION_RETRY + se.Message, this, this.METHOD_CREATE_CONNECTION, e);
                }
            }
        }
    }

    private void initialize()
    {
        try {
            {
                try {
                    ClassLoader loader = Thread.currentThread().getContextClassLoader();
                    Type jdbcDriverClass = loader.loadClass(this.getDatabaseConnectionInfoInterface().getJdbcDriver());
                    jdbcDriverClass.newInstance();
                } catch (Exception e) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                        this.logUtil.put(this.LOAD_JDBC_DRIVER_FAILED_LABEL + this.getDatabaseConnectionInfoInterface().getJdbcDriver(), this, METHOD_INITIALIZE, e);
                    }
                }
            }
            this.createConnection();
        } catch (Exception se) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.SQL_CONNECTION_FAILED, this, this.METHOD_INITIALIZE, se);
            }
        }
    }

    public virtual DatabaseConnectionInfoInterface getDatabaseConnectionInfoInterface()
    {
        return this.databaseConnectionInfoInterface;
    }

    public virtual void setDatabaseConnectionInfoInterface(DbConnectionInfo databaseConnectionInfoInterface)
    {
        this.databaseConnectionInfoInterface = databaseConnectionInfoInterface;
    }

}

