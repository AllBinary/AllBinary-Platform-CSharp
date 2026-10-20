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
using System.Runtime.CompilerServices;
//using Connection = java.sql.Connection;
//using DriverManager = java.sql.DriverManager;
//using ResultSet = java.sql.ResultSet;
//using ResultSetMetaData = java.sql.ResultSetMetaData;
//using SQLException = java.sql.SQLException;
//using Statement = java.sql.Statement;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DatabaseConnectionInfoInterface = org.allbinary.business.init.db.DatabaseConnectionInfoInterface;
using DbConnectionInfo = org.allbinary.business.init.db.DbConnectionInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using SqlStrings = org.allbinary.logic.communication.sql.SqlStrings;
using SqlTypeStrings = org.allbinary.logic.communication.sql.SqlTypeStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.init;

public class InitSql
{
    public readonly StringUtil stringUtil = StringUtil.getInstance();
    public readonly CommonSeps commonSeps = CommonSeps.getInstance();
    public readonly SqlTypeStrings sqlTypeStrings = SqlTypeStrings.getInstance();
    public readonly SqlStrings sqlStrings = SqlStrings.getInstance();
    public readonly StdUtil stdUtil = StdUtil.getInstance();
    public readonly string INSERT = "insert";
    public readonly string UPDATE = "update";
    private DbConnectionInfo databaseConnectionInfoInterface = null;
    private string userid = null;
    private string password = null;
    private string tableName = null;
    private Connection conn = null;
    private bool useridAndPassword = false;
    public readonly string SUCCESS_SQL_STATEMENT = "Success\nSQL Statement: ";
    public readonly string FAILED_SQL_STATEMENT = "Failed\nSQL Statement: ";
    private readonly string INIT_SQL = "InitSql";
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string EQUAL_QUOTE = "=\"";
    private readonly string METHOD_GET_ROW = "getRow()";
    private readonly string METHOD_UPDATE_WHERE = "updateWhere()";
    private readonly string ROW_VALUE_LABEL = "Row Value: ";
    private readonly string NO_RESULTS_IN_RESULT_SET = "No Results in ResultSet";
    private readonly string INSERT_END = "')";
    public InitSql(DbConnectionInfo databaseConnectionInfoInterface)
    {
        this.setDatabaseConnectionInfoInterface(databaseConnectionInfoInterface);
    }

    public virtual void setTable(string tableName)
    {
        this.tableName = tableName;
    }

    public virtual void setDatabaseConnectionInfoInterface(DbConnectionInfo databaseConnectionInfoInterface)
    {
        this.databaseConnectionInfoInterface = databaseConnectionInfoInterface;
    }

    public virtual bool createTable(string tableData)
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Creating Table: ");
            stringBuffer.append(tableData);
            PreLogUtil.put(stringBuffer.ToString(), INIT_SQL, "createTable()");
            this.executeSQLStatement(tableData);
            return true;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                PreLogUtil.putOE(this.commonStrings.EXCEPTION, INIT_SQL, "createTable()", e);
            }
            return false;
        }
    }

    public virtual bool dropTable()
    {
        string sqlStatement = this.sqlStrings.DROP_TABLE + this.tableName;
        try {
            this.executeSQLStatement(sqlStatement);
            return true;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                PreLogUtil.putOE(this.commonStrings.EXCEPTION, INIT_SQL, "dropTables()", e);
            }
            return false;
        }
    }

    public virtual HashMap<object, object> getRow(HashMap<object, object> keysAndValues)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT_ALL_FROM);
        stringBuffer.append(this.tableName);
        stringBuffer.append(this.sqlStrings.WHERE);
        try {
            HashMap<object, object> result = null;
            Set<object> set = keysAndValues.keySet();
            object[] keyArray = set.toArray();
            int size = keyArray.Length;
            for (int i = 0; i < size; i++) {
                string key = ((string) keyArray[i]);
                string value = new string((((string) keysAndValues.get(key))).ToCharArray());
                stringBuffer.append(key);
                stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
                stringBuffer.append(this.getValue(value));
                stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
                if (i < size - 1) {
                    stringBuffer.append(this.sqlStrings.AND);
                }
            }
            string sqlStatement = stringBuffer.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                PreLogUtil.put(this.sqlStrings.SQL_STATEMENT_LABEL + sqlStatement, this.INIT_SQL, this.METHOD_GET_ROW);
            }
            ResultSet rset = this.executeSQLStatement(sqlStatement);
            ResultSetMetaData resultSetMetaData = rset.getMetaData();
            while (rset.next()) {
                result = stdUtil.createHashMap();
                int columnCount = resultSetMetaData.getColumnCount();
                for (int index = 1; index <= columnCount; index++) {
                    string columnName = resultSetMetaData.getColumnName(index);
                    string field = rset.getString(columnName);
                    result.put(columnName, field);
                }
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    PreLogUtil.put(this.ROW_VALUE_LABEL + result.ToString(), this.INIT_SQL, this.METHOD_GET_ROW);
                }
                return result;
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                PreLogUtil.put(this.NO_RESULTS_IN_RESULT_SET, this.INIT_SQL, this.METHOD_GET_ROW);
            }
            return null;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                PreLogUtil.putOE(this.FAILED_SQL_STATEMENT + stringBuffer, this.INIT_SQL, this.METHOD_GET_ROW, e);
            }
            return null;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void updateWhere(string key, string value, HashMap<object, object> updatedKeyValuePairs)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.UPDATE);
        stringBuffer.append(this.tableName);
        stringBuffer.append(this.sqlStrings.SET);
        try {
            object[] columnArray = updatedKeyValuePairs.keySet().toArray();
            int size = columnArray.Length;
            for (int i = 0; i < size; i++) {
                string columnName = columnArray[i].ToString();
                stringBuffer.append(this.commonSeps.SPACE);
                stringBuffer.append(columnName);
                stringBuffer.append(this.EQUAL_QUOTE);
                string columnValue = ((string) updatedKeyValuePairs.get(columnName));
                if (columnValue == null) {
                    columnValue = this.stringUtil.EMPTY_STRING;
                } else {
                }
                stringBuffer.append(this.getValue(columnValue));
                stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
                if (i < size - 1) {
                    stringBuffer.append(this.commonSeps.COMMA);
                }
            }
            stringBuffer.append(this.sqlStrings.WHERE);
            stringBuffer.append(key);
            stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
            stringBuffer.append(this.getValue(value));
            stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
            string sqlStatement = stringBuffer.ToString();
            this.executeSQLStatement(sqlStatement);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                PreLogUtil.put(this.SUCCESS_SQL_STATEMENT + sqlStatement, this.INIT_SQL, METHOD_UPDATE_WHERE);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                PreLogUtil.putOE(this.FAILED_SQL_STATEMENT + stringBuffer, this.INIT_SQL, METHOD_UPDATE_WHERE, e);
            }
        }
    }

    public virtual void insert(BasicArrayList values)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.INSERT_INTO);
        stringBuffer.append(this.tableName);
        stringBuffer.append(this.sqlStrings.VALUES);
        try {
            int size = values.size();
            for (int i = 0; i < size - 1; i++) {
                string value = this.getValue(((string) values.get(i)));
                stringBuffer.append(value);
                stringBuffer.append(this.sqlStrings.SINGLE_QUOTE_COMMA_SEP);
            }
            string value = this.getValue(((string) values.get(values.size() - 1)));
            stringBuffer.append(value);
            stringBuffer.append(this.INSERT_END);
            string sqlStatement = stringBuffer.ToString();
            this.executeSQLStatement(sqlStatement);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                PreLogUtil.put(this.SUCCESS_SQL_STATEMENT + sqlStatement, this.INIT_SQL, INSERT);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                PreLogUtil.putOE(this.FAILED_SQL_STATEMENT + stringBuffer.ToString(), this.INIT_SQL, INSERT, e);
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private string getValue(string value)
    {
        if (StringValidationUtil.getInstance().isEmpty(value)) {
            return this.stringUtil.EMPTY_STRING;
        } else {
            return value;
        }
    }

    // throws Exception, SQLException
    public virtual ResultSet executeSQLStatement(string statement)
    {
        try {
            if (this.conn == null) {
                this.initialize();
            }
            Statement stmt = this.conn.createStatement();
            stmt.execute(statement);
            ResultSet rset = stmt.getResultSet();
            stmt.close();
            return rset;
        } catch (SQLException e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                PreLogUtil.putOE(this.commonStrings.EXCEPTION, INIT_SQL, "executeSQLStatement()", e);
            }
            throw e;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                PreLogUtil.putOE(this.commonStrings.EXCEPTION, INIT_SQL, "executeSQLStatement()", e);
            }
            throw e;
        }
    }

    // throws SQLException
    private void createConnection()
    {
        try {
            if (this.useridAndPassword == true) {
                this.conn = DriverManager.getConnection(this.databaseConnectionInfoInterface.getUrl(), this.userid, this.password);
            } else {
                this.conn = DriverManager.getConnection(this.databaseConnectionInfoInterface.getUrl());
            }
        } catch (SQLException se) {
            PreLogUtil.putOE(this.commonStrings.EXCEPTION, INIT_SQL, "createConnection()", se);
            throw se;
        }
    }

    // throws Exception
    private void initialize()
    {
        try {
            try {
                string jdbcDriver = this.databaseConnectionInfoInterface.getJdbcDriver();
                PreLogUtil.put(new StringMaker().append("Loading DbConnnectionInfo: ").append(this.databaseConnectionInfoInterface.GetType().FullName).append(" Driver: ").append(jdbcDriver).ToString(), this.INIT_SQL, "initialize()");
                Class.forName(jdbcDriver).newInstance();
            } catch (Exception e) {
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                    PreLogUtil.putOE("LoadDriver Failed: " + this.databaseConnectionInfoInterface.getJdbcDriver(), this.INIT_SQL, "initialize()", e);
                }
                throw e;
            }
            if (this.userid == null && this.password == null) {
                this.useridAndPassword = true;
            }
            this.createConnection();
        } catch (Exception se) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                PreLogUtil.putOE(this.commonStrings.EXCEPTION, INIT_SQL, "initialize()", se);
            }
            throw se;
        }
    }

    public virtual DatabaseConnectionInfoInterface getDatabaseConnectionInfoInterface()
    {
        return this.databaseConnectionInfoInterface;
    }

}

