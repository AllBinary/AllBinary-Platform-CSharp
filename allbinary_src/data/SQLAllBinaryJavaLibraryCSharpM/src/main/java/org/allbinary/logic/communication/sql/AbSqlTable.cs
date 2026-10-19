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
using DbConnectionInfo = org.allbinary.business.init.db.DbConnectionInfo;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.logic.communication.sql;

public class AbSqlTable : AbSqlBasic
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string tableName = null;
    private readonly string METHOD_CREATED_TABLE = "createTable()";
    private readonly string METHOD_DROP_TABLE = "dropTable()";
    private readonly string TABLE_CREATION_SUCCESS = "Table Creation Successful: ";
    private readonly string DROPPED_SUCCESS = " Dropped Successfully";
    public AbSqlTable(DbConnectionInfo databaseConnectionInfoInterface) : base(databaseConnectionInfoInterface)
    {
        // base(databaseConnectionInfoInterface) is called from the constructor declaration
    }

    public virtual void setTableName(string tableName)
    {
        this.tableName = tableName;
    }

    public virtual string getTableName()
    {
        return this.tableName;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string createTable(string data)
    {
        try {
            this.executeSQLStatement(data);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.TABLE_CREATION_SUCCESS + this.tableName + " with statement: " + data, this, this.METHOD_CREATED_TABLE);
            }
            return this.tableName + this.sqlStrings.CREATE_RETURN;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put("Table Creation Failed: " + this.tableName + " with statement: " + data, this, this.METHOD_CREATED_TABLE, e);
            }
            return "Failed to Create " + this.tableName + " table.";
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string dropTable()
    {
        string sqlStatement = this.sqlStrings.DROP_TABLE + this.tableName;
        try {
            this.executeSQLStatement(sqlStatement);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.SUCCESS_SQL_STATEMENT + sqlStatement, this, this.METHOD_DROP_TABLE);
            }
            return tableName + this.DROPPED_SUCCESS;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGINGERROR)) {
                this.logUtil.put(this.FAILED_SQL_STATEMENT + sqlStatement, this, this.METHOD_DROP_TABLE, e);
            }
            return "Failed to Drop " + tableName + " table.";
        }
    }

}

