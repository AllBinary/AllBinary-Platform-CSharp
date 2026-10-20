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
using StoreFront = org.allbinary.business.context.modules.storefront.StoreFront;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.context.module.storefronts;

public class StoreFrontsEntity : AbSqlBean, StoreFrontsEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string tableName = "storefronts";
    public StoreFrontsEntity() : base(new UserDbInitInfo())
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

    // throws Exception
    public virtual StoreFront getStoreFrontInterface(string name)
    {
        HashMap<object, object> keysAndValues = StdUtil.getInstance().createHashMap();
        keysAndValues.put(StoreFrontData.getInstance().NAME, name);
        HashMap<object, object> storeHashMap = base.getRow(keysAndValues);
        if (storeHashMap != null) {
            return new StoreFront(storeHashMap);
        } else {
            return new StoreFront();
        }
    }

    public virtual BasicArrayList getStoreFrontNames()
    {
        BasicArrayList storeFrontNames = base.getColumn(StoreFrontData.getInstance().NAME);
        return storeFrontNames;
    }

    public virtual void update(HashMap<object, object> updatedValues)
    {
        base.updateWhere(StoreFrontData.getInstance().NAME, ((string) updatedValues.get(StoreFrontData.getInstance().NAME)), updatedValues);
    }

    public string createTableStatement()
    {
        StoreFrontData storeFrontData = StoreFrontData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.tableName);
        stringBuffer.append(this.sqlStrings.START);
        stringBuffer.append(storeFrontData.NAME);
        stringBuffer.append(this.sqlTypeStrings.SIXTY_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.HOMEHOSTNAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.HOMEHOSTNAMEPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.HOSTNAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.HOSTNAMEPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.TESTHOMEHOSTNAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.TESTHOMEHOSTNAMEPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.TESTHOSTNAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.TESTHOSTNAMEPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.IMAGEPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.STATICPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.CATEGORYPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.INVENTORYCONTROL);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.CONFIGURATION);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(storeFrontData.SUBSTORES);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.TAGLOCATION);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.PACKAGELOCATION);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.FTP);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.FTPPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.FTPUSERNAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.FTPPASSWORD);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.TESTFTP);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.TESTFTPPATH);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.TESTFTPUSERNAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(storeFrontData.TESTFTPPASSWORD);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(EntryData.getInstance().TIMECREATED);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(EntryData.getInstance().getInstance().LASTMODIFIED);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(this.sqlStrings.PRIMARY_KEY);
        stringBuffer.append(storeFrontData.NAME);
        stringBuffer.append(this.sqlStrings.END);
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

