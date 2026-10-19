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
using DynamicObjectData = org.allbinary.business.DynamicObjectData;
using AdvertisementData = org.allbinary.business.advertisement.AdvertisementData;
using AdvertisementInterface = org.allbinary.business.advertisement.AdvertisementInterface;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.advertisement;

public class AdvertisementsEntity : AbSqlBean, AdvertisementsEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string tableName = "advertisements";
    private readonly string _INDEX = "_index";
    public AdvertisementsEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public virtual void delete(string value)
    {
        try {
            base.deleteWhere(EntryData.getInstance().ID, value);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, this.commonStrings.delete);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.delete, e);
            }
        }
    }

    public virtual BasicArrayList get(string storeName)
    {
        HashMap keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(StoreFrontData.getInstance().NAME, storeName);
        BasicArrayList hashMapVector = base.getRows(keysAndValues);
        BasicArrayList vector = new BasicArrayListD();
        int size = hashMapVector.size();
        for (int index = 0; index < size; index++) {
            HashMap hashMap = ((HashMap) hashMapVector.get(index));
        }
        return vector;
    }

    public virtual AdvertisementInterface get(string storeName, string advertismentName)
    {
        HashMap keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(StoreFrontData.getInstance().NAME, storeName);
        keysAndValues.put(AdvertisementData.getInstance().NAME, advertismentName);
        HashMap hashMap = base.getRow(keysAndValues);
        return null;
    }

    public string createTableStatement()
    {
        AdvertisementData advertisementData = AdvertisementData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.getTableName()).append(this.sqlStrings.START).append(advertisementData.NAME).append(_INDEX).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(advertisementData.NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(StoreFrontData.getInstance().NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(advertisementData.DESCRIPTION).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(DynamicObjectData.NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(EntryData.getInstance().TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(EntryData.getInstance().LASTMODIFIED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(advertisementData.NAME).append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        string returnStr = base.createTable(this.createTableStatement());
        return returnStr;
    }

    public virtual void update(HashMap updatedValues)
    {
        base.updateWhere(EntryData.getInstance().ID, ((string) updatedValues.get(EntryData.getInstance().ID)), updatedValues);
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

