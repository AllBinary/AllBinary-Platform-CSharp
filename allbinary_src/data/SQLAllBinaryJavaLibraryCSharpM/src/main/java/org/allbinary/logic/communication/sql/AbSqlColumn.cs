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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DbConnectionInfo = org.allbinary.business.init.db.DbConnectionInfo;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.logic.communication.sql;

public class AbSqlColumn : AbSqlTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string LARGEST_INT_VALUE_IN_COLUMN = "\nLargest Int Value in column: ";
    private readonly string METHOD_GET_LARGETS_INTEGER_IN_COLUMN = "getLargestIntegerInColumn";
    private readonly string METHOD_GET_COLUMN = "getColumn";
    private readonly string METHOD_GET_COLUMN_WHERE = "getColumnWhere";
    private readonly string INVALID_RESULT = "-1";
    public AbSqlColumn(DbConnectionInfo databaseConnectionInfoInterface) : base(databaseConnectionInfoInterface)
    {
        // base(databaseConnectionInfoInterface) is called from the constructor declaration
    }

    public virtual string getLargestIntegerInColumnWhere(string columnName, string key, string value)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT);
        stringBuffer.append(columnName);
        stringBuffer.append(this.sqlStrings.FROM);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.WHERE);
        stringBuffer.append(key);
        stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
        stringBuffer.append(value);
        stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
        string sqlStatement = stringBuffer.ToString();
        try {
            int largest = 0;
            ResultSet rset = executeSQLStatement(sqlStatement);
            while (rset.next()) {
                int intValue = rset.getInt(columnName);
                if (intValue > largest) {
                    largest = intValue;
                }
            }
            string largestAsString = largest.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(this.sqlStrings.SQL_STATEMENT_LABEL);
                stringBuffer.append(sqlStatement);
                stringBuffer.append(this.LARGEST_INT_VALUE_IN_COLUMN);
                stringBuffer.append(largestAsString);
                this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD_GET_LARGETS_INTEGER_IN_COLUMN);
            }
            return largestAsString;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + sqlStatement, this, METHOD_GET_LARGETS_INTEGER_IN_COLUMN, e);
            }
            return this.INVALID_RESULT;
        }
    }

    public virtual BasicArrayList getColumn(string columnName)
    {
        BasicArrayList column = new BasicArrayListD();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT);
        stringBuffer.append(columnName);
        stringBuffer.append(this.sqlStrings.FROM);
        stringBuffer.append(this.getTableName());
        string sqlStatement = stringBuffer.ToString();
        try {
            ResultSet rset = executeSQLStatement(sqlStatement);
            while (rset.next()) {
                string field = rset.getObject(columnName).ToString();
                column.add(field);
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(this.sqlStrings.SQL_STATEMENT_LABEL);
                stringBuffer.append(sqlStatement);
                stringBuffer.append(this.sqlStrings.COLUMN_VALUE);
                stringBuffer.append(column.ToString());
                this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD_GET_COLUMN);
            }
            return column;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + sqlStatement, this, METHOD_GET_COLUMN, e);
            }
            return column;
        }
    }

    public virtual BasicArrayList getColumnWhere(string columnName, string key, string value)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.SELECT);
        stringBuffer.append(columnName);
        stringBuffer.append(this.sqlStrings.FROM);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.WHERE);
        stringBuffer.append(key);
        stringBuffer.append(this.sqlStrings.EQUAL_QUOTE);
        stringBuffer.append(value);
        stringBuffer.append(this.sqlStrings.CLOSE_QUOTE);
        string sqlStatement = stringBuffer.ToString();
        BasicArrayList column = new BasicArrayListD();
        ResultSet rset = null;
        string field = null;
        try {
            rset = executeSQLStatement(sqlStatement);
            while (rset.next()) {
                field = rset.getObject(columnName).ToString();
                column.add(field);
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(this.sqlStrings.SQL_STATEMENT_LABEL);
                stringBuffer.append(sqlStatement);
                stringBuffer.append(this.sqlStrings.COLUMN_VALUE);
                stringBuffer.append(column.ToString());
                this.logUtil.putF(stringBuffer.ToString(), this, this.METHOD_GET_COLUMN_WHERE);
            }
            return column;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + sqlStatement, this, this.METHOD_GET_COLUMN_WHERE, e);
            }
            return column;
        }
    }

}

