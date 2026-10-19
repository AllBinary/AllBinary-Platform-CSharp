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
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using EntryData = org.allbinary.business.entry.EntryData;
using InventoryDbInitInfo = org.allbinary.business.init.db.InventoryDbInitInfo;
using BasicItem = org.allbinary.business.user.commerce.inventory.item.BasicItem;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using MoneyException = org.allbinary.business.user.commerce.money.MoneyException;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace org.allbinary.data.tables.user.commerce.inventory.item;

public class InventoryEntity : AbSqlBean, InventoryEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private readonly string tableName = "basicinventory";
    public InventoryEntity() : base(new InventoryDbInitInfo())
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

    // throws Exception
    public virtual BasicArrayList getItems(StoreFrontInterface storeFrontInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
            this.logUtil.putF("Getting Items For: " + storeFrontInterface.getName(), this, "getItems");
        }
        BasicArrayList itemVector = new BasicArrayListD();
        HashMap keysAndValues = StdUtil.getInstance().createHashMap();
        BasicArrayList itemHashMapVector = base.getRows(keysAndValues);
        int size = itemHashMapVector.size();
        for (int i = 0; i < size; i++) {
            HashMap itemHashMap = ((HashMap) itemHashMapVector.get(i));
            if (itemHashMap != null) {
                string category = ((string) itemHashMap.get(basicItemData.CATEGORY));
                if (!StringValidationUtil.getInstance().isEmpty(category) && category.StartsWith(storeFrontInterface.getCategoryPath())) {
                    itemVector.add(new BasicItem(itemHashMap));
                }
            }
        }
        return itemVector;
    }

    // throws MoneyException
    public virtual ItemInterface getItem(string id)
    {
        HashMap keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(basicItemData.ID, id);
        HashMap itemHashMap = base.getRow(keysAndValues);
        if (itemHashMap != null) {
            return new BasicItem(itemHashMap);
        } else {
            return null;
        }
    }

    public virtual string getWeight(string id)
    {
        return base.getField(basicItemData.ID, id, basicItemData.WEIGHT);
    }

    public string createTableStatement()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.tableName);
        stringBuffer.append(this.sqlStrings.START);
        stringBuffer.append(basicItemData.ID);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(basicItemData.NUMBER);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(basicItemData.INBASKETS);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(basicItemData.WEIGHT);
        stringBuffer.append(" VARCHAR(20) NOT NULL,");
        stringBuffer.append(EntryData.getInstance().ENABLE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.NEWORUSED);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.SUMMARY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.DISTRIBUTOR);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.IDUSEDBYDISTRIBUTOR);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.PRODUCEDBY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.PRODUCTIONDATE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.STARTPRODUCTIONDATE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.DESCRIPTION);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(basicItemData.KEYWORDS);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.CATEGORY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.TYPE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.SMALLIMAGE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.MEDIUMIMAGE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.LARGEIMAGE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(EntryData.getInstance().LASTMODIFIED);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(EntryData.getInstance().TIMECREATED);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(basicItemData.PRICE);
        stringBuffer.append(" VARCHAR(20) NOT NULL,");
        stringBuffer.append(basicItemData.COMMENT);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(basicItemData.CUSTOMS);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(basicItemData.DOWNLOADS);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(basicItemData.GROUPS);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(basicItemData.OPTIONS);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(basicItemData.PERMISSIONS);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(basicItemData.SPECIALS);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(this.sqlStrings.PRIMARY_KEY);
        stringBuffer.append(basicItemData.ID);
        stringBuffer.append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

    public virtual void update(HashMap updatedValues)
    {
        base.updateWhere(basicItemData.ID, ((string) updatedValues.get(basicItemData.ID)), updatedValues);
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

