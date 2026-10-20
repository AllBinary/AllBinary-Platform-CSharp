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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using QuoteRequestData = org.allbinary.business.quoterequest.QuoteRequestData;
using UserData = org.allbinary.business.user.UserData;
using QuoteRequest = org.allbinary.business.user.quoterequest.QuoteRequest;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.user.quoterequest;

public class QuoteRequestEntity : AbSqlBean, QuoteRequestEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string tableName = "quoterequest";
    public QuoteRequestEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public virtual void insert(BasicArrayList values)
    {
        try {
            base.insert(values);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, INSERT);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, INSERT, e);
            }
        }
    }

    // throws Exception
    public virtual QuoteRequest get(string userName, int id)
    {
        HashMap<object, object> row = StdUtil.getInstance().createHashMap();
        row.put(UserData.USERNAME, userName);
        row.put(QuoteRequestData.getInstance().ID, (id).ToString());
        HashMap<object, object> quoteRequestHashMap = base.getRow(row);
        if (quoteRequestHashMap != null) {
            return new org.allbinary.business.user.quoterequest.QuoteRequest(quoteRequestHashMap);
        } else {
            return null;
        }
    }

    public virtual BasicArrayList getIds(string userName)
    {
        return base.getColumnWhere(QuoteRequestData.getInstance().ID, UserData.USERNAME, userName);
    }

    public virtual void deleteWhere(string key, string value)
    {
        try {
            base.deleteWhere(key, value);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, "deleteWhere");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "deleteWhere", e);
            }
        }
    }

    public string createTableStatement()
    {
        QuoteRequestData quoteRequestData = QuoteRequestData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE).append(tableName).append(this.sqlStrings.START);
        stringBuffer.append(quoteRequestData.ID).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(UserData.USERNAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(quoteRequestData.PROJECT_INFO);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(quoteRequestData.CUSTOMER_COMMENTS);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(quoteRequestData.BUDGET);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(quoteRequestData.TIMEFRAME);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(quoteRequestData.COMMENTS);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(EntryData.getInstance().TIMECREATED);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(EntryData.getInstance().LASTMODIFIED);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(this.sqlStrings.PRIMARY_KEY);
        stringBuffer.append(quoteRequestData.ID);
        stringBuffer.append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

    public virtual string dropTable()
    {
        string result = new string((base.dropTable()).ToCharArray());
        return result;
    }

    public virtual void update(string userName, HashMap<object, object> updatedValues)
    {
        base.updateWhere(UserData.USERNAME, userName, updatedValues);
    }

}

