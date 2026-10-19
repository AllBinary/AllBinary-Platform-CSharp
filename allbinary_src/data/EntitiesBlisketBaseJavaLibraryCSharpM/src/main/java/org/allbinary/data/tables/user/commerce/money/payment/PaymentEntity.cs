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
//using Random = java.util.Random;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using UserData = org.allbinary.business.user.UserData;
using Payment = org.allbinary.business.user.commerce.money.payment.Payment;
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using PaymentInterface = org.allbinary.business.user.commerce.money.payment.PaymentInterface;
using PaymentIdGenerator = org.allbinary.data.generator.PaymentIdGenerator;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using SuperCrypt = org.allbinary.logic.control.crypt.SuperCrypt;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.data.tables.user.commerce.money.payment;

public class PaymentEntity : AbSqlBean, PaymentEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string tableName = "payment";
    public PaymentEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public virtual string getLastId(string userName)
    {
        return base.getLargestIntegerInColumnWhere(PaymentData.ID, UserData.USERNAME, userName);
    }

    public virtual void setDefault(string userName, int? index)
    {
        try {
            HashMap updateKeyAndValue = StdUtil.getInstance().createHashMap();
            HashMap whereKeyAndValue = StdUtil.getInstance().createHashMap();
            whereKeyAndValue.put(UserData.USERNAME, userName);
            PaymentInterface paymentInterface = this.getDefault(userName);
            if (paymentInterface != null) {
                updateKeyAndValue.put(EntryData.getInstance().DEFAULT, StringUtil.getInstance().EMPTY_STRING);
                whereKeyAndValue.put(PaymentData.ID, paymentInterface.getId());
                base.updateWhere(whereKeyAndValue, updateKeyAndValue);
            }
            updateKeyAndValue.put(EntryData.getInstance().DEFAULT, EntryData.getInstance().DEFAULT);
            whereKeyAndValue.put(PaymentData.ID, index.ToString());
            base.updateWhere(whereKeyAndValue, updateKeyAndValue);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, "setDefault");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "setDefault", e);
            }
        }
    }

    public virtual BasicArrayList get(string userName)
    {
        try {
            BasicArrayList paymentVector = new BasicArrayListD();
            HashMap keyAndValue = StdUtil.getInstance().createHashMap();
            keyAndValue.put(UserData.USERNAME, userName);
            BasicArrayList paymentList = base.getRows(keyAndValue);
            int size = paymentList.size();
            for (int index = 0; index < size; index++) {
                HashMap paymentHashMap = ((HashMap) paymentList.get(index));
                Payment payment = new Payment(paymentHashMap);
                if (payment != null) {
                    paymentVector.add(payment);
                }
            }
            return paymentVector;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, this.commonStrings.GET, e);
            }
            return null;
        }
    }

    public virtual PaymentInterface getDefault(string userName)
    {
        try {
            HashMap paymentHashMap = StdUtil.getInstance().createHashMap();
            HashMap updateKeyAndValue = StdUtil.getInstance().createHashMap();
            updateKeyAndValue.put(EntryData.getInstance().DEFAULT, EntryData.getInstance().DEFAULT);
            updateKeyAndValue.put(UserData.USERNAME, userName);
            paymentHashMap = base.getRow(updateKeyAndValue);
            if (paymentHashMap != null) {
                Payment payment = new Payment(paymentHashMap);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.commonStrings.SUCCESS, this, "getDefault");
                }
                return ((PaymentInterface) payment);
            } else {
                return null;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "getDefault", e);
            }
            return null;
        }
    }

    public virtual void remove(string userName, int? index)
    {
        try {
            HashMap whereHashMap = StdUtil.getInstance().createHashMap();
            whereHashMap.put(UserData.USERNAME, userName);
            whereHashMap.put(PaymentData.ID, ((string) index.ToString()));
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

    public virtual void add(string userName, PaymentInterface paymentInterface)
    {
        try {
            BasicArrayList vector = new BasicArrayListD();
            vector.add(new PaymentIdGenerator().getNext());
            vector.add(userName);
            vector.add(StringUtil.getInstance().EMPTY_STRING);
            vector.add(paymentInterface.getName());
            vector.add(paymentInterface.getType());
            vector.add(paymentInterface.getExpiration());
            int random = new Random().nextInt(SuperCrypt.KEYMAX);
            vector.add(new SuperCrypt(random).encrypt(paymentInterface.getNumber()));
            vector.add(random.ToString());
            Calendar calendar = Calendar.getInstance();
            string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
            vector.add(time);
            base.insert(vector);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, "add");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "add", e);
            }
        }
    }

    public string createTableStatement()
    {
        EntryData entryData = EntryData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE).append(tableName).append(this.sqlStrings.START).append(PaymentData.ID).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_AUTO_INCREMENT_NOT_NULL).append(UserData.USERNAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(entryData.DEFAULT).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(PaymentData.NAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(PaymentData.TYPE).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(PaymentData.EXPIRATION).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(PaymentData.NUMBER).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(entryData.ENCRYPTION).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(entryData.TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(PaymentData.ID).append(this.sqlStrings.END);
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

