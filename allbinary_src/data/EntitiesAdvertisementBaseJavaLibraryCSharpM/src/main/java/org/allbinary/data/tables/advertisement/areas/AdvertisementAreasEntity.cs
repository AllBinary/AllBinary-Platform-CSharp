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
using AdvertisementArea = org.allbinary.business.advertisement.area.AdvertisementArea;
using AdvertisementAreaData = org.allbinary.business.advertisement.area.AdvertisementAreaData;
using AdvertisementAreaInterface = org.allbinary.business.advertisement.area.AdvertisementAreaInterface;
using AdvertisementCampaignData = org.allbinary.business.advertisement.campaign.AdvertisementCampaignData;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.advertisement.areas;

public class AdvertisementAreasEntity : AbSqlBean, AdvertisementAreasEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string tableName = "advertisements";
    public AdvertisementAreasEntity() : base(new UserDbInitInfo())
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

    // throws Exception
    public virtual BasicArrayList get(string storeName)
    {
        HashMap keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(StoreFrontData.getInstance().NAME, storeName);
        BasicArrayList hashMapVector = base.getRows(keysAndValues);
        BasicArrayList vector = new BasicArrayListD();
        int size = hashMapVector.size();
        for (int index = 0; index < size; index++) {
            HashMap hashMap = ((HashMap) hashMapVector.get(index));
            if (hashMap != null) {
                vector.add(((AdvertisementAreaInterface) new AdvertisementArea(hashMap)));
            }
        }
        return vector;
    }

    // throws Exception
    public virtual AdvertisementAreaInterface get(string storeName, string advertisementAreaName)
    {
        HashMap keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(StoreFrontData.getInstance().NAME, storeName);
        keysAndValues.put(AdvertisementAreaData.getInstance().NAME, advertisementAreaName);
        HashMap hashMap = base.getRow(keysAndValues);
        if (hashMap != null) {
            return ((AdvertisementAreaInterface) new AdvertisementArea(hashMap));
        } else {
            return null;
        }
    }

    public string createTableStatement()
    {
        AdvertisementAreaData advertisementAreaData = AdvertisementAreaData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.START);
        stringBuffer.append(advertisementAreaData.NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(StoreFrontData.getInstance().NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(advertisementAreaData.DESCRIPTION).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(advertisementAreaData.CONSTRAINTS).append(this.sqlTypeStrings.BLOB_NOT_NULL).append(AdvertisementCampaignData.getInstance().NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(EntryData.getInstance().TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(EntryData.getInstance().LASTMODIFIED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(advertisementAreaData.NAME).append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        string returnStr = base.createTable(this.createTableStatement());
        return returnStr;
    }

    public virtual void update(HashMap updatedValues)
    {
        base.updateWhere(AdvertisementAreaData.getInstance().NAME, ((string) updatedValues.get(AdvertisementAreaData.getInstance().NAME)), updatedValues);
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

