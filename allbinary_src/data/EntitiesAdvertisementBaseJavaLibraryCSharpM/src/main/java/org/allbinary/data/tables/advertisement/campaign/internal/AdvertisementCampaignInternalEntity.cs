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
using AdvertisementCampaign = org.allbinary.business.advertisement.campaign.AdvertisementCampaign;
using AdvertisementCampaignData = org.allbinary.business.advertisement.campaign.AdvertisementCampaignData;
using AdvertisementCampaignInterface = org.allbinary.business.advertisement.campaign.AdvertisementCampaignInterface;
using AdvertisementCampaigns = org.allbinary.business.advertisement.campaign.AdvertisementCampaigns;
using AdvertisementCampaignsInterface = org.allbinary.business.advertisement.campaign.AdvertisementCampaignsInterface;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using TimeData = org.allbinary.business.time.TimeData;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.advertisement.campaign.@internal;

public class AdvertisementCampaignInternalEntity : AbSqlBean, AdvertisementCampaignInternalEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string tableName = "adCampaignInternal";
    public AdvertisementCampaignInternalEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public virtual void delete(string value)
    {
        try {
            base.deleteWhere(StoreFrontData.getInstance().NAME, value);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, this.commonStrings.delete);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.delete, e);
            }
        }
    }

    public virtual AdvertisementCampaignsInterface getCampaignsInStore(string storeName)
    {
        HashMap<object, object> keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(StoreFrontData.getInstance().NAME, storeName);
        BasicArrayList hashMapVector = base.getRows(keysAndValues);
        BasicArrayList vector = new BasicArrayListD();
        int size = hashMapVector.size();
        for (int index = 0; index < size; index++) {
            HashMap<object, object> hashMap = ((HashMap<object, object>) hashMapVector.get(index));
            if (hashMap != null) {
                vector.add(((AdvertisementCampaignInterface) new AdvertisementCampaign(hashMap)));
            }
        }
        return ((AdvertisementCampaignsInterface) new AdvertisementCampaigns(vector));
    }

    public virtual AdvertisementCampaignInterface get(string storeName, string name)
    {
        HashMap<object, object> keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(StoreFrontData.getInstance().NAME, storeName);
        keysAndValues.put(AdvertisementCampaignData.getInstance().NAME, name);
        HashMap<object, object> hashMap = base.getRow(keysAndValues);
        if (hashMap != null) {
            return ((AdvertisementCampaignInterface) new AdvertisementCampaign(hashMap));
        } else {
            return null;
        }
    }

    public virtual void update(HashMap<object, object> updatedValues)
    {
        base.updateWhere(EntryData.getInstance().getInstance().ID, ((string) updatedValues.get(EntryData.getInstance().getInstance().ID)), updatedValues);
    }

    public string createTableStatement()
    {
        EntryData entryData = EntryData.getInstance().getInstance();
        AdvertisementCampaignData advertisementCampaignData = AdvertisementCampaignData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.getTableName());
        stringBuffer.append(this.sqlStrings.START);
        stringBuffer.append(entryData.ID).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(StoreFrontData.getInstance().NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(advertisementCampaignData.NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(advertisementCampaignData.DESCRIPTION).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(advertisementCampaignData.CONFIG).append(this.sqlTypeStrings.BLOB_NOT_NULL).append(TimeData.getInstance().START).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(TimeData.getInstance().END).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(entryData.TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(entryData.LASTMODIFIED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(entryData.ID).append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        string returnStr = base.createTable(this.createTableStatement());
        return returnStr;
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

