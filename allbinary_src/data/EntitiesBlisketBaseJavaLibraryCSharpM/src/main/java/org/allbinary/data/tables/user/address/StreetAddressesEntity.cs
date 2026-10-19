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
//using Calendar = java.util.Calendar;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using UserData = org.allbinary.business.user.UserData;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using StreetAddressData = org.allbinary.business.user.address.StreetAddressData;
using TableDataFactory = org.allbinary.data.tables.TableDataFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.data.tables.user.address;

public class StreetAddressesEntity : AbSqlBean, StreetAddressesEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string userName;
    public StreetAddressesEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
    }

    public StreetAddressesEntity(string userName) : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.userName = userName;
    }

    public virtual void remove(int? index)
    {
        try {
            HashMap whereHashMap = StdUtil.getInstance().createHashMap();
            whereHashMap.put(UserData.USERNAME, this.userName);
            whereHashMap.put(StreetAddressData.ID, ((string) index.ToString()));
            base.deleteWhere(whereHashMap);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, "remove");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "remove", e);
            }
        }
    }

    public virtual void add(StreetAddress address)
    {
        this.add(address, TableDataFactory.getInstance().INTEGER_MAX_VALUE_STRING);
    }

    private void add(StreetAddress address, string index)
    {
        try {
            BasicArrayList values = new BasicArrayListD();
            values.add(index);
            values.add(this.userName);
            values.add(StringUtil.getInstance().EMPTY_STRING);
            values.add(address.getName());
            values.add(address.getStreet());
            values.add(address.getCity());
            values.add(address.getState());
            values.add(address.getCode());
            values.add(address.getCountry());
            Calendar calendar = Calendar.getInstance();
            string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
            values.add(time);
            base.insert(values);
            this.setDefault(getLastId());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, "add");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "add", e);
            }
        }
    }

    public virtual void update(StreetAddress address)
    {
        try {
            HashMap addressHashMap = address.toHashMap();
            HashMap whereKeyValuePairs = StdUtil.getInstance().createHashMap();
            whereKeyValuePairs.put(StreetAddressData.ID, address.getId());
            whereKeyValuePairs.put(UserData.USERNAME, this.userName);
            base.updateWhere(whereKeyValuePairs, addressHashMap);
            this.setDefault(address.getId());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, "update");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "add", e);
            }
        }
    }

    public virtual string getLastId()
    {
        return base.getLargestIntegerInColumnWhere(StreetAddressData.ID, UserData.USERNAME, userName);
    }

    public virtual BasicArrayList get()
    {
        try {
            BasicArrayList streetAddressVector = new BasicArrayListD();
            HashMap keyAndValue = StdUtil.getInstance().createHashMap();
            keyAndValue.put(UserData.USERNAME, this.userName);
            BasicArrayList addressList = base.getRows(keyAndValue);
            int size = addressList.size();
            for (int index = 0; index < size; index++) {
                HashMap addressHashMap = ((HashMap) addressList.get(index));
                StreetAddress streetAddress = new StreetAddress(addressHashMap);
                if (streetAddress != null) {
                    streetAddressVector.add(streetAddress);
                }
            }
            return streetAddressVector;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.GET, e);
            }
            return null;
        }
    }

    public virtual StreetAddress get(int? index)
    {
        try {
            HashMap keyAndValue = StdUtil.getInstance().createHashMap();
            keyAndValue.put(UserData.USERNAME, this.userName);
            keyAndValue.put(StreetAddressData.ID, index.ToString());
            HashMap addressHashMap = base.getRow(keyAndValue);
            if (addressHashMap != null) {
                return new StreetAddress(addressHashMap);
            } else {
                return null;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.GET, e);
            }
            return null;
        }
    }

    public virtual StreetAddress getDefault()
    {
        try {
            HashMap addressHashMap = StdUtil.getInstance().createHashMap();
            HashMap updateKeyAndValue = StdUtil.getInstance().createHashMap();
            updateKeyAndValue.put(StreetAddressData.DEFAULT, StreetAddressData.DEFAULT);
            updateKeyAndValue.put(UserData.USERNAME, this.userName);
            addressHashMap = base.getRow(updateKeyAndValue);
            if (addressHashMap != null) {
                StreetAddress streetAddress = new StreetAddress(addressHashMap);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.commonStrings.SUCCESS, this, "getDefault");
                }
                return streetAddress;
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF("No Default Address Found", this, "getDefault");
                }
                return null;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "getDefault", e);
            }
            return null;
        }
    }

    public virtual void setDefault(string value)
    {
        try {
            HashMap updateKeyAndValue = StdUtil.getInstance().createHashMap();
            HashMap whereKeyAndValue = StdUtil.getInstance().createHashMap();
            whereKeyAndValue.put(UserData.USERNAME, this.userName);
            StreetAddress streetAddress = this.getDefault();
            if (streetAddress != null) {
                updateKeyAndValue.put(StreetAddressData.DEFAULT, StringUtil.getInstance().EMPTY_STRING);
                whereKeyAndValue.put(StreetAddressData.ID, streetAddress.getId());
                base.updateWhere(whereKeyAndValue, updateKeyAndValue);
            }
            whereKeyAndValue.put(StreetAddressData.ID, value);
            updateKeyAndValue.put(StreetAddressData.DEFAULT, StreetAddressData.DEFAULT);
            base.updateWhere(whereKeyAndValue, updateKeyAndValue);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, "setDefault");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "setShippingAddress", e);
            }
        }
    }

    protected virtual string getUserName()
    {
        return this.userName;
    }

    public string createTableStatement()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE).append(this.getTableName()).append(this.sqlStrings.START).append(StreetAddressData.ID).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_AUTO_INCREMENT_NOT_NULL).append(UserData.USERNAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(StreetAddressData.DEFAULT).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(StreetAddressData.NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(StreetAddressData.STREET).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(StreetAddressData.CITY).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(StreetAddressData.STATE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(StreetAddressData.CODE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(StreetAddressData.COUNTRY).append(this.sqlTypeStrings.MAX_CHAR_COLUMN).append(EntryData.getInstance().TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(StreetAddressData.ID).append(this.sqlStrings.END);
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

    public virtual string drop()
    {
        return base.dropTable();
    }

}

