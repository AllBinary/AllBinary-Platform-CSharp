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
using DynamicObjectData = org.allbinary.business.DynamicObjectData;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using GroupData = org.allbinary.business.user.group.GroupData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.data.tables.advertisement.sales;

public class AffiliateSalesEntity : AbSqlBean, AffiliateSalesEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string tableName = "affiliate";
    public AffiliateSalesEntity() : base(new UserDbInitInfo())
    {
        // Constructor invocation emitted in the initializer.
        this.setTableName(this.tableName);
    }

    public virtual void delete(string value)
    {
        try {
            base.deleteWhere(StoreFrontData.getInstance().NAME, value);
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, this.commonStrings.delete);
            }
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.delete, e);
            }
        }
    }

    public string createTableStatement()
    {
        EntryData entryData = EntryData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.START);
        stringBuffer.append(entryData.ID).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(StoreFrontData.getInstance().NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(GroupData.NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(DynamicObjectData.NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(entryData.TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(entryData.LASTMODIFIED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(entryData.ID).append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        string returnStr = base.createTable(this.createTableStatement());
        return returnStr;
    }

    public virtual void update(HashMap<object, object> updatedValues)
    {
        base.updateWhere(EntryData.getInstance().ID, ((string) updatedValues.get(EntryData.getInstance().ID)), updatedValues);
    }

    public override string dropTable()
    {
        return base.dropTable();
    }

    public override void insert(BasicArrayList values)
    {
        base.insert(values);
    }

}

