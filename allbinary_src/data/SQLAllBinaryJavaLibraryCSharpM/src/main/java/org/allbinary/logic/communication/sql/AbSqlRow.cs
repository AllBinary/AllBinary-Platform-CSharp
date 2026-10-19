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
//using ResultSet = java.sql.ResultSet;
//using ResultSetMetaData = java.sql.ResultSetMetaData;
using java.util;
//using Set = java.util.Set;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DbConnectionInfo = org.allbinary.business.init.db.DbConnectionInfo;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;

namespace org.allbinary.logic.communication.sql;

public class AbSqlRow : AbSqlColumn
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string EQUAL_QUOTE = "=\"";
    private readonly string ESCAPE_QUOTES = "\\\"";
    private readonly string GET_ROW = "Row Value: ";
    private readonly string METHOD_GET_ROW = "getRow()";
    private readonly string METHOD_GET_ROWS = "getRows()";
    private readonly string METHOD_GET_ALL_ROWS = "getAllRows()";
    private readonly string METHOD_UPDATE_WHERE = "updateWhere()";
    private readonly string METHOD_GET_ROWS_WHERE_BETWEEN = "getRowsWhereBetween()";
    private readonly string METHOD_DELETE_WHERE = "deleteWhere()";
    private readonly string ROW_VALUE_LABEL = "Row Value: ";
    private readonly string ROW_VALUES_LABEL = "Row Values: ";
    private readonly string NO_RESULTS_IN_RESULT_SET = "No Results in ResultSet";
    private readonly string COLUMN_NAME_LABEL = "columnName: ";
    private readonly string INSERT_END = "')";
    public AbSqlRow(DbConnectionInfo databaseConnectionInfoInterface) : base(databaseConnectionInfoInterface)
    {
        // base(databaseConnectionInfoInterface) is called from the constructor declaration
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

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void updateWhere(string key, string value, HashMap updatedKeyValuePairs)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.UPDATE);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.SET);
        try {
            object[] keyArray = updatedKeyValuePairs.keySet().toArray();
            int size = keyArray.Length;
            for (int i = 0; i < size; i++) {
                string columnName = keyArray[i].ToString();
                stringBuffer.append(this.commonSeps.SPACE);
                stringBuffer.append(columnName);
                stringBuffer.append(this.EQUAL_QUOTE);
                string columnValue = ((string) updatedKeyValuePairs.get(columnName));
                if (columnValue == null) {
                    columnValue = this.stringUtil.EMPTY_STRING;
                } else {
                    columnValue = new Replace(this.sqlStrings.CLOSE_QUOTE, this.ESCAPE_QUOTES).all(columnValue);
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
                this.logUtil.putF(this.SUCCESS_SQL_STATEMENT + sqlStatement, this, this.METHOD_UPDATE_WHERE);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + stringBuffer, this, METHOD_UPDATE_WHERE, e);
            }
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void updateWhere(HashMap whereKeyValuePairs, HashMap updatedKeyValuePairs)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.UPDATE);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.SET);
        try {
            object[] keyArray = updatedKeyValuePairs.keySet().toArray();
            int size = keyArray.Length;
            for (int i = 0; i < size; i++) {
                string columnName = keyArray[i].ToString();
                stringBuffer.append(this.commonSeps.SPACE);
                stringBuffer.append(columnName);
                stringBuffer.append(this.EQUAL_QUOTE);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.COLUMN_NAME_LABEL + columnName, this, this.METHOD_UPDATE_WHERE);
                }
                string columnValue = ((string) updatedKeyValuePairs.get(columnName));
                if (columnValue == null) {
                    columnValue = this.stringUtil.EMPTY_STRING;
                } else {
                    columnValue = new Replace(this.sqlStrings.CLOSE_QUOTE, this.ESCAPE_QUOTES).all(columnValue);
                }
                stringBuffer.append(this.getValue(columnValue));
                stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
                if (i < size - 1) {
                    stringBuffer.append(this.commonSeps.COMMA);
                }
            }
            stringBuffer.append(this.sqlStrings.WHERE);
            Set set = whereKeyValuePairs.keySet();
            object[] keyArray2 = set.toArray();
            int size2 = keyArray2.Length;
            for (int i = 0; i < size2; i++) {
                string key = ((string) keyArray2[i]);
                string value = ((string) whereKeyValuePairs.get(key));
                {
                    stringBuffer.append(key);
                    stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
                    stringBuffer.append(this.getValue(value));
                    stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
                    if (i < size2 - 1) {
                        stringBuffer.append(this.sqlStrings.AND);
                    }
                }
            }
            string sqlStatement = stringBuffer.ToString();
            this.executeSQLStatement(sqlStatement);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.SUCCESS_SQL_STATEMENT + sqlStatement, this, this.METHOD_UPDATE_WHERE);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + stringBuffer, this, METHOD_UPDATE_WHERE, e);
            }
            throw e;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void deleteWhere(string key, string value)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.DELETE);
        stringBuffer.append(this.sqlStrings.FROM);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.WHERE);
        stringBuffer.append(key);
        stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
        stringBuffer.append(value);
        stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
        try {
            string sqlStatement = stringBuffer.ToString();
            this.executeSQLStatement(sqlStatement);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.SUCCESS_SQL_STATEMENT + sqlStatement, this, this.METHOD_DELETE_WHERE);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + stringBuffer.ToString(), this, this.METHOD_DELETE_WHERE, e);
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void deleteWhere(HashMap keysAndValues)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.DELETE);
        stringBuffer.append(this.sqlStrings.FROM);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.WHERE);
        try {
            Set set = keysAndValues.keySet();
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
            this.executeSQLStatement(sqlStatement);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.SUCCESS_SQL_STATEMENT + sqlStatement, this, this.METHOD_DELETE_WHERE);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + stringBuffer.ToString(), this, this.METHOD_DELETE_WHERE, e);
            }
        }
    }

    public virtual void insert(BasicArrayList values)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.INSERT_INTO);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.VALUES);
        try {
            for (int i = 0; i < values.size() - 1; i++) {
                string value = this.getValue(((string) values.get(i)));
                value = new Replace(this.sqlStrings.ESCAPE, this.sqlStrings.DOUBLE_ESCAPE).all(value);
                stringBuffer.append(value);
                stringBuffer.append(this.sqlStrings.SINGLE_QUOTE_COMMA_SEP);
            }
            string value = this.getValue(((string) values.get(values.size() - 1)));
            value = new Replace(this.sqlStrings.ESCAPE, this.sqlStrings.DOUBLE_ESCAPE).all(value);
            stringBuffer.append(value);
            stringBuffer.append(this.INSERT_END);
            string sqlStatement = stringBuffer.ToString();
            this.executeSQLStatement(sqlStatement);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.SUCCESS_SQL_STATEMENT + sqlStatement, this, this.INSERT);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + stringBuffer.ToString(), this, INSERT, e);
            }
        }
    }

    public virtual HashMap getRow(HashMap keysAndValues)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT_ALL_FROM);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.WHERE);
        try {
            HashMap result = null;
            Set set = keysAndValues.keySet();
            object[] keyArray = set.toArray();
            int size = keyArray.Length;
            for (int index = 0; index < size; index++) {
                string key = ((string) keyArray[index]);
                string value = new string((((string) keysAndValues.get(key))).ToCharArray());
                stringBuffer.append(key);
                stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
                stringBuffer.append(this.getValue(value));
                stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
                if (index < size - 1) {
                    stringBuffer.append(this.sqlStrings.AND);
                }
            }
            string sqlStatement = stringBuffer.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.sqlStrings.SQL_STATEMENT_LABEL + sqlStatement, this, this.METHOD_GET_ROW);
            }
            ResultSet rset = this.executeSQLStatement(sqlStatement);
            ResultSetMetaData resultSetMetaData = rset.getMetaData();
            while (rset.next()) {
                result = this.stdUtil.createHashMap();
                int columnCount = resultSetMetaData.getColumnCount();
                for (int index = 1; index <= columnCount; index++) {
                    string columnName = resultSetMetaData.getColumnName(index);
                    string field = rset.getString(columnName);
                    result.put(columnName, field);
                }
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.ROW_VALUE_LABEL + result.ToString(), this, this.METHOD_GET_ROW);
                }
                return result;
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.putF(this.NO_RESULTS_IN_RESULT_SET, this, this.METHOD_GET_ROW);
            }
            return null;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + stringBuffer, this, this.METHOD_GET_ROW, e);
            }
            return null;
        }
    }

    public virtual BasicArrayList getRows(HashMap keysAndValues)
    {
        return this.getRows(keysAndValues, StringUtil.getInstance().EMPTY_STRING);
    }

    public virtual BasicArrayList getRows(HashMap keysAndValues, string more)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT_ALL_FROM);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.WHERE);
        try {
            BasicArrayList rows = new BasicArrayListD();
            Set set = keysAndValues.keySet();
            object[] keyArray = set.toArray();
            int size = keyArray.Length;
            for (int index = 0; index < size; index++) {
                string key = ((string) keyArray[index]);
                string value = new string((((string) keysAndValues.get(key))).ToCharArray());
                stringBuffer.append(key);
                stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
                stringBuffer.append(this.getValue(value));
                stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
                if (index < size - 1) {
                    stringBuffer.append(this.sqlStrings.AND);
                }
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.sqlStrings.SQL_STATEMENT_LABEL + stringBuffer, this, this.METHOD_GET_ROWS);
            }
            stringBuffer.append(more);
            string sqlStatement = stringBuffer.ToString();
            ResultSet rset = this.executeSQLStatement(sqlStatement);
            ResultSetMetaData resultSetMetaData = rset.getMetaData();
            while (rset.next()) {
                HashMap result = this.stdUtil.createHashMap();
                int columnCount = resultSetMetaData.getColumnCount();
                for (int index = 1; index <= columnCount; index++) {
                    string columnName = resultSetMetaData.getColumnName(index);
                    string field = rset.getString(columnName);
                    result.put(columnName, field);
                }
                string resultAsString = result.ToString();
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.GET_ROW + resultAsString, this, this.METHOD_GET_ROWS);
                }
                rows.add(result);
            }
            return rows;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + stringBuffer, this, this.METHOD_GET_ROWS, e);
            }
            return null;
        }
    }

    public virtual BasicArrayList getAllRows()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT_ALL_FROM);
        stringBuffer.append(this.getTableName());
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.sqlStrings.SQL_STATEMENT_LABEL + stringBuffer, this, this.METHOD_GET_ALL_ROWS);
            }
            BasicArrayList rows = new BasicArrayListD();
            string sqlStatement = stringBuffer.ToString();
            ResultSet rset = this.executeSQLStatement(sqlStatement);
            ResultSetMetaData resultSetMetaData = rset.getMetaData();
            while (rset.next()) {
                HashMap result = this.stdUtil.createHashMap();
                int columnCount = resultSetMetaData.getColumnCount();
                for (int index = 1; index <= columnCount; index++) {
                    string columnName = resultSetMetaData.getColumnName(index);
                    string field = rset.getString(columnName);
                    result.put(columnName, field);
                }
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.ROW_VALUES_LABEL + result.ToString(), this, this.METHOD_GET_ALL_ROWS);
                }
                rows.add(result);
            }
            return rows;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + stringBuffer, this, this.METHOD_GET_ALL_ROWS, e);
            }
            return null;
        }
    }

    public virtual BasicArrayList getRowsWhereBetween(HashMap whereKeyValuePairs, string betweenColumn, string smallest, string largest)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT_ALL_FROM);
        stringBuffer.append(this.getTableName());
        try {
            BasicArrayList rows = new BasicArrayListD();
            stringBuffer.append(this.sqlStrings.WHERE);
            Set set = whereKeyValuePairs.keySet();
            string key = null;
            string value = null;
            object[] keyArray = set.toArray();
            int size = keyArray.Length;
            for (int index = 0; index < size; index++) {
                key = ((string) keyArray[index]);
                value = ((string) whereKeyValuePairs.get(key));
                stringBuffer.append(key);
                stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
                stringBuffer.append(this.getValue(value));
                stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
                stringBuffer.append(this.sqlStrings.AND);
            }
            stringBuffer.append(betweenColumn);
            stringBuffer.append(this.sqlStrings.MORE_THAN_QUOTE);
            stringBuffer.append(smallest);
            stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
            stringBuffer.append(this.sqlStrings.AND);
            stringBuffer.append(betweenColumn);
            stringBuffer.append(this.sqlStrings.LESS_THAN_QUOTE);
            stringBuffer.append(largest);
            stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
            string sqlStatement = stringBuffer.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.sqlStrings.SQL_STATEMENT_LABEL + sqlStatement, this, this.METHOD_GET_ROWS_WHERE_BETWEEN);
            }
            ResultSet rset = this.executeSQLStatement(sqlStatement);
            ResultSetMetaData resultSetMetaData = rset.getMetaData();
            HashMap result = null;
            BasicArrayList columnNames = null;
            int columnCount = 0;
            string columnName = null;
            string field = null;
            while (rset.next()) {
                result = this.stdUtil.createHashMap();
                columnNames = new BasicArrayListD();
                columnCount = resultSetMetaData.getColumnCount();
                for (int index = 1; index <= columnCount; index++) {
                    columnName = resultSetMetaData.getColumnName(index);
                    field = rset.getString(columnName);
                    result.put(columnName, field);
                }
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.ROW_VALUE_LABEL + result.ToString(), this, this.METHOD_GET_ROWS_WHERE_BETWEEN);
                }
                rows.add(result);
            }
            return rows;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + stringBuffer, this, METHOD_GET_ROWS_WHERE_BETWEEN, e);
            }
            return null;
        }
    }

    public virtual BasicArrayList getRowsWhereBetween(string betweenColumn, string smallest, string largest)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT_ALL_FROM);
        stringBuffer.append(this.getTableName());
        try {
            BasicArrayList rows = new BasicArrayListD();
            stringBuffer.append(this.sqlStrings.WHERE);
            stringBuffer.append(betweenColumn);
            stringBuffer.append(this.sqlStrings.MORE_THAN_QUOTE);
            stringBuffer.append(smallest);
            stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
            stringBuffer.append(this.sqlStrings.AND);
            stringBuffer.append(betweenColumn);
            stringBuffer.append(this.sqlStrings.LESS_THAN_QUOTE);
            stringBuffer.append(largest);
            stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
            string sqlStatement = stringBuffer.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.sqlStrings.SQL_STATEMENT_LABEL + sqlStatement, this, this.METHOD_GET_ROWS_WHERE_BETWEEN);
            }
            ResultSet rset = this.executeSQLStatement(sqlStatement);
            ResultSetMetaData resultSetMetaData = rset.getMetaData();
            string columnName = null;
            string field = null;
            HashMap result = null;
            BasicArrayList columnNames = null;
            int columnCount = 0;
            while (rset.next()) {
                result = this.stdUtil.createHashMap();
                columnNames = new BasicArrayListD();
                columnCount = resultSetMetaData.getColumnCount();
                for (int index = 1; index <= columnCount; index++) {
                    columnName = resultSetMetaData.getColumnName(index);
                    field = rset.getString(columnName);
                    result.put(columnName, field);
                }
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.ROW_VALUE_LABEL + result.ToString(), this, this.METHOD_GET_ROWS_WHERE_BETWEEN);
                }
                rows.add(result);
            }
            return rows;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + stringBuffer, this, METHOD_GET_ROWS_WHERE_BETWEEN, e);
            }
            return null;
        }
    }

}

