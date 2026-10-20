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
using InventoryDbInitInfo = org.allbinary.business.init.db.InventoryDbInitInfo;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using BasicGroupItemData = org.allbinary.business.user.commerce.inventory.item.group.BasicGroupItemData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.user.commerce.inventory.item.groups;

public class BasicGroupItemsEntity : AbSqlBean, BasicGroupItemsEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    public readonly string tableName = "basicgroupeditems";
    public BasicGroupItemsEntity() : base(new InventoryDbInitInfo())
    {
        // base(new InventoryDbInitInfo()) is called from the constructor declaration
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

    public virtual void delete(string value)
    {
        try {
            base.deleteWhere(basicItemData.ID, value);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, this.commonStrings.delete);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.delete, e);
            }
        }
    }

    public string createTableStatement()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE).append(tableName).append(this.sqlStrings.START).append(basicItemData.ID).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(BasicGroupItemData.ITEM_ONE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(BasicGroupItemData.ITEM_TWO).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(BasicGroupItemData.ITEM_THREE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(BasicGroupItemData.ITEM_FOUR).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(BasicGroupItemData.ITEM_FIVE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(BasicGroupItemData.ITEM_SIX).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(BasicGroupItemData.ITEM_SEVEN).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(BasicGroupItemData.ITEM_EIGHT).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(BasicGroupItemData.ITEM_NINE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(BasicGroupItemData.ITEM_TEN).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(EntryData.getInstance().TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(EntryData.getInstance().LASTMODIFIED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(basicItemData.ID).append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

    public virtual void update(HashMap<object, object> updatedValues)
    {
        base.updateWhere(basicItemData.ID, ((string) updatedValues.get(basicItemData.ID)), updatedValues);
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

