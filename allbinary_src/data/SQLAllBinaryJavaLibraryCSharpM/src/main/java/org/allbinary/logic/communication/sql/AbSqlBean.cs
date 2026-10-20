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
//using ResultSet = java.sql.ResultSet;
using java.util;
using DbConnectionInfo = org.allbinary.business.init.db.DbConnectionInfo;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.logic.communication.sql;

public class AbSqlBean : AbSqlRow
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string METHOD_GET_FIELD = "getField";
    private readonly string METHOD_IS_SUBSET_OF_ENTRY = "isSubsetOfEntry";
    public AbSqlBean(DbConnectionInfo databaseConnectionInfoInterface) : base(databaseConnectionInfoInterface)
    {
        // base(databaseConnectionInfoInterface) is called from the constructor declaration
    }

    public virtual string getField(string key, string value, string requestedField)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT);
        stringBuffer.append(requestedField);
        stringBuffer.append(this.sqlStrings.FROM);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.WHERE);
        stringBuffer.append(key);
        stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
        stringBuffer.append(value);
        stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
        string sqlStatement = stringBuffer.ToString();
        try {
            string field = this.stringUtil.EMPTY_STRING;
            ResultSet rset = executeSQLStatement(sqlStatement);
            while (rset.next()) {
                field = rset.getString(requestedField);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.append(this.sqlStrings.SQL_STATEMENT_LABEL);
                    stringBuffer.append(sqlStatement);
                    stringBuffer.append(this.sqlStrings.FIELD_VALUE);
                    stringBuffer.append(field);
                    this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD_GET_FIELD);
                }
                return field;
            }
            return null;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + sqlStatement, this, METHOD_GET_FIELD, e);
            }
            return this.FAILED_SQL_STATEMENT + sqlStatement;
        }
    }

    public virtual string getField(HashMap<object, object> keysAndValues, string requestedField)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT);
        stringBuffer.append(requestedField);
        stringBuffer.append(this.sqlStrings.FROM);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.WHERE);
        try {
            string field = this.stringUtil.EMPTY_STRING;
            Set<object> set = keysAndValues.keySet();
            object[] keyArray = set.toArray();
            int size = keyArray.Length;
            string key = null;
            string value = null;
            for (int i = 0; i < size; i++) {
                key = ((string) keyArray[i]);
                value = new string((((string) keysAndValues.get(key))).ToCharArray());
                stringBuffer.append(key);
                stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
                stringBuffer.append(value);
                stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
                if (i < size - 1) {
                    stringBuffer.append(this.sqlStrings.AND);
                }
            }
            string sqlStatement = stringBuffer.ToString();
            ResultSet rset = executeSQLStatement(sqlStatement);
            while (rset.next()) {
                field = rset.getString(requestedField);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.append(this.sqlStrings.SQL_STATEMENT_LABEL);
                    stringBuffer.append(sqlStatement);
                    stringBuffer.append(this.sqlStrings.FIELD_VALUE);
                    stringBuffer.append(field);
                    this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD_GET_FIELD);
                }
                return field;
            }
            return null;
        } catch (Exception e) {
            string sqlStatement = stringBuffer.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + sqlStatement, this, METHOD_GET_FIELD, e);
            }
            return this.FAILED_SQL_STATEMENT + sqlStatement;
        }
    }

    public virtual string isSubsetOfEntry(string key, string value, HashMap<object, object> columnsAndValues)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT);
        try {
            object[] keyArray = columnsAndValues.keySet().toArray();
            int size = keyArray.Length;
            stringBuffer.append(this.commonSeps.SPACE);
            stringBuffer.append(key);
            for (int i = 0; i < size; i++) {
                stringBuffer.append(this.commonSeps.SPACE);
                stringBuffer.append(keyArray[i].ToString());
            }
            stringBuffer.append(this.sqlStrings.FROM);
            stringBuffer.append(this.getTableName());
            stringBuffer.append(this.sqlStrings.WHERE);
            stringBuffer.append(key);
            stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
            stringBuffer.append(value);
            stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
            string sqlStatement = stringBuffer.ToString();
            ResultSet rset = executeSQLStatement(sqlStatement);
            string columnName = null;
            string field = null;
            while (rset.next()) {
                object[] keyArray2 = columnsAndValues.keySet().toArray();
                int size2 = keyArray2.Length;
                for (int i = 0; i < size2; i++) {
                    columnName = keyArray2[i].ToString();
                    field = rset.getObject(columnName).ToString();
                    if (string.CompareOrdinal(field, ((string) columnsAndValues.get(columnName))) != 0) {
                        return org.allbinary.globals.GLOBALS2.NOTASUBSET;
                    }
                }
            }
            if (rset.getRow() != 1) {
                return org.allbinary.globals.GLOBALS2.NOTASUBSET;
            } else {
                return org.allbinary.globals.GLOBALS2.ISASUBSET;
            }
        } catch (Exception e) {
            string sqlStatement = stringBuffer.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + sqlStatement, this, METHOD_IS_SUBSET_OF_ENTRY, e);
            }
            return this.FAILED_SQL_STATEMENT + sqlStatement;
        }
    }

}

