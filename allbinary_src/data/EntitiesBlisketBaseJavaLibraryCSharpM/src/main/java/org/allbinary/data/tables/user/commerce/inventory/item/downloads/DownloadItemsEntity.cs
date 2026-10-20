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
using DownloadItemData = org.allbinary.business.user.commerce.inventory.item.download.DownloadItemData;
using DownloadableItem = org.allbinary.business.user.commerce.inventory.item.download.DownloadableItem;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.user.commerce.inventory.item.downloads;

public class DownloadItemsEntity : AbSqlBean, DownloadItemsEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    public readonly string tableName = "downloaditems";
    public DownloadItemsEntity() : base(new InventoryDbInitInfo())
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
            base.deleteWhere(DownloadItemData.ID, value);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, this.commonStrings.delete);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.delete, e);
            }
        }
    }

    public virtual void update(HashMap<object, object> updatedValues)
    {
        base.updateWhere(DownloadItemData.ID, ((string) updatedValues.get(DownloadItemData.ID)), updatedValues);
    }

    public virtual BasicArrayList getForItem(string id)
    {
        BasicArrayList returnVector = new BasicArrayListD();
        HashMap<object, object> keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(basicItemData.ID, id);
        BasicArrayList vector = base.getRows(keysAndValues);
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            HashMap<object, object> hashMap = ((HashMap<object, object>) vector.get(index));
            returnVector.add(new DownloadableItem(hashMap));
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
            this.logUtil.putF("Found: " + size, this, "getForItem");
        }
        return returnVector;
    }

    public virtual BasicArrayList getForItem(string id, string downloadItemId)
    {
        BasicArrayList returnVector = new BasicArrayListD();
        HashMap<object, object> keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(basicItemData.ID, id);
        keysAndValues.put(DownloadItemData.ID, downloadItemId);
        BasicArrayList vector = base.getRows(keysAndValues);
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            HashMap<object, object> hashMap = ((HashMap<object, object>) vector.get(index));
            returnVector.add(new DownloadableItem(hashMap));
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
            this.logUtil.putF("Found: " + size, this, "getForItem");
        }
        return returnVector;
    }

    public string createTableStatement()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE).append(tableName).append(this.sqlStrings.START).append(DownloadItemData.ID).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(basicItemData.ID).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(EntryData.getInstance().ENABLE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(DownloadItemData.SPECIAL_NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(DownloadItemData.VERSION).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(DownloadItemData.CHANGES).append(this.sqlTypeStrings.BLOB_NOT_NULL).append(DownloadItemData.SYSTEM).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(DownloadItemData.PLATFORM).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(DownloadItemData.LICENSE_FILE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(DownloadItemData.FILE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(DownloadItemData.SIZE).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(DownloadItemData.VALID_TIME).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(DownloadItemData.RETRIES).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(EntryData.getInstance().TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(EntryData.getInstance().LASTMODIFIED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(DownloadItemData.ID).append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

