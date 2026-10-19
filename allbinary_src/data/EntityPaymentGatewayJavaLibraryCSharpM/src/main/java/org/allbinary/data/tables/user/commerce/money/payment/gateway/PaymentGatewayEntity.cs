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
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using UserData = org.allbinary.business.user.UserData;
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using PaymentGatewayData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayData;
using PaymentGatewayEncryptedMapping = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayEncryptedMapping;
using PaymentGatewayInterface = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayInterface;
using PaymentGatewayInterfaceFactory = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayInterfaceFactory;
using BasicPaymentType = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentType;
using BasicPaymentTypeUtil = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentTypeUtil;
using PaymentGatewayIdGenerator = org.allbinary.data.generator.PaymentGatewayIdGenerator;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using SuperCrypt = org.allbinary.logic.control.crypt.SuperCrypt;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.user.commerce.money.payment.gateway;

public class PaymentGatewayEntity : AbSqlBean, PaymentGatewayEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string tableName = "paymentgateways";
    public PaymentGatewayEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
            this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public virtual void add(PaymentGatewayInterface paymentGatewayInterface)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.START, this, "add");
            }
            BasicArrayList vector = new BasicArrayListD();
            vector.add(new PaymentGatewayIdGenerator().getNext());
            vector.addAllList(new PaymentGatewayEncryptedMapping(paymentGatewayInterface).toVector());
            Calendar calendar = Calendar.getInstance();
            string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
            vector.add(time);
            vector.add(time);
            base.insert(vector);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.END, this, "add");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "add", e);
            }
        }
    }

    public virtual void update(PaymentGatewayInterface paymentGatewayInterface)
    {
        try {
            Calendar calendar = Calendar.getInstance();
            string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
            paymentGatewayInterface.setLastModified(time);
            HashMap whereKeyValuePairs = StdUtil.getInstance().createHashMap();
            whereKeyValuePairs.put(StoreFrontData.getInstance().NAME.ToString(), paymentGatewayInterface.getStoreName());
            whereKeyValuePairs.put(PaymentGatewayData.NAME.ToString(), paymentGatewayInterface.getName());
            if (whereKeyValuePairs.get(EntryData.getInstance().TIMECREATED) != null) {
                throw new Exception("Don't update TimeCreated for update");
            }
            HashMap updateHashMap = new PaymentGatewayEncryptedMapping(paymentGatewayInterface).toHashMap();
            base.updateWhere(whereKeyValuePairs, updateHashMap);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, "update");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "update", e);
            }
        }
    }

    public virtual PaymentGatewayInterface getPaymentGatewayInterface(string storeName, BasicPaymentType paymentType)
    {
        try {
            HashMap paymentGatewayHashMap = StdUtil.getInstance().createHashMap();
            HashMap whereKeyAndValue = StdUtil.getInstance().createHashMap();
            whereKeyAndValue.put(StoreFrontData.getInstance().NAME.ToString(), storeName);
            whereKeyAndValue.put(PaymentGatewayData.NAME.ToString(), paymentType.getName());
            paymentGatewayHashMap = base.getRow(whereKeyAndValue);
            if (paymentGatewayHashMap != null) {
                string userName = ((string) paymentGatewayHashMap.get(UserData.USERNAME.ToString()));
                string password = ((string) paymentGatewayHashMap.get(UserData.PASSWORD.ToString()));
                string special1 = ((string) paymentGatewayHashMap.get(PaymentGatewayData.SPECIAL1.ToString()));
                string special2 = ((string) paymentGatewayHashMap.get(PaymentGatewayData.SPECIAL2.ToString()));
                string special3 = ((string) paymentGatewayHashMap.get(PaymentGatewayData.SPECIAL3.ToString()));
                string special4 = ((string) paymentGatewayHashMap.get(PaymentGatewayData.SPECIAL4.ToString()));
                string special5 = ((string) paymentGatewayHashMap.get(PaymentGatewayData.SPECIAL5.ToString()));
                string special6 = ((string) paymentGatewayHashMap.get(PaymentGatewayData.SPECIAL6.ToString()));
                string special7 = ((string) paymentGatewayHashMap.get(PaymentGatewayData.SPECIAL7.ToString()));
                string special8 = ((string) paymentGatewayHashMap.get(PaymentGatewayData.SPECIAL8.ToString()));
                string special9 = ((string) paymentGatewayHashMap.get(PaymentGatewayData.SPECIAL9.ToString()));
                SuperCrypt superCrypt = new SuperCrypt(PaymentGatewayData.CRYPTNUM);
                paymentGatewayHashMap.put(UserData.USERNAME.ToString(), superCrypt.decrypt(userName));
                paymentGatewayHashMap.put(UserData.PASSWORD.ToString(), superCrypt.decrypt(password));
                paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL1.ToString(), superCrypt.decrypt(special1));
                paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL2.ToString(), superCrypt.decrypt(special2));
                paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL3.ToString(), superCrypt.decrypt(special3));
                paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL4.ToString(), superCrypt.decrypt(special4));
                paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL5.ToString(), superCrypt.decrypt(special5));
                paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL6.ToString(), superCrypt.decrypt(special6));
                paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL7.ToString(), superCrypt.decrypt(special7));
                paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL8.ToString(), superCrypt.decrypt(special8));
                paymentGatewayHashMap.put(PaymentGatewayData.SPECIAL9.ToString(), superCrypt.decrypt(special9));
                PaymentGatewayInterface paymentGatewayInterface = new PaymentGatewayInterfaceFactory().getInstance(paymentGatewayHashMap);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.commonStrings.SUCCESS, this, "getPaymentGatewayInterface()");
                }
                return paymentGatewayInterface;
            } else {
                return new PaymentGatewayInterfaceFactory().getInstance(paymentType);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put("Command Failed for paymentType: " + paymentType.getName(), this, "getPaymentGatewayInterface", e);
            }
            return null;
        }
    }

    public virtual BasicArrayList findPaymentTypeVectorByStore(string storeName)
    {
        try {
            BasicArrayList paymentGatewayNameVector = new BasicArrayListD();
            paymentGatewayNameVector = base.getColumnWhere(PaymentGatewayData.NAME.ToString(), StoreFrontData.getInstance().NAME.ToString(), storeName);
            if (paymentGatewayNameVector != null) {
                BasicArrayList paymentGatewayVector = new BasicArrayListD();
                int size = paymentGatewayNameVector.size();
                for (int i = 0; i < size; i++) {
                    string paymentTypeString = ((string) paymentGatewayNameVector.get(i));
                    BasicPaymentType paymentType = BasicPaymentTypeUtil.getInstance().get(paymentTypeString);
                    paymentGatewayVector.add(paymentType);
                }
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.commonStrings.SUCCESS, this, "findPaymentTypeVectorByStore()");
                }
                return paymentGatewayVector;
            } else {
                return new BasicArrayListD();
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "findPaymentTypeVectorByStore", e);
            }
            return null;
        }
    }

    public virtual void remove(string storeName, BasicPaymentType paymentType)
    {
        try {
            HashMap whereHashMap = StdUtil.getInstance().createHashMap();
            whereHashMap.put(StoreFrontData.getInstance().NAME.ToString(), storeName);
            whereHashMap.put(PaymentGatewayData.NAME.ToString(), paymentType.getName());
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

    public string createTableStatement()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.tableName);
        stringBuffer.append(this.sqlStrings.START);
        stringBuffer.append(PaymentGatewayData.ID.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_AUTO_INCREMENT_NOT_NULL);
        stringBuffer.append(EntryData.getInstance().ENABLE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(StoreFrontData.getInstance().NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.NAME.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentData.METHOD);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.MODE.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.TESTPROTOCOL.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.TESTSERVER.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.TESTPORT.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.TESTPATH.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SERVERPROTOCOL.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SERVER.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SERVERPORT.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SERVERPATH.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(UserData.USERNAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(UserData.PASSWORD);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.TIMEOUT.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.PROXYPROTOCOL.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.PROXYSERVER.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.PROXYPORT.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.PROXYPATH.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.PROXYUSERNAME.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.PROXYPASSWORD.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.PROXYTIMEOUT.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SPECIAL1.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SPECIAL2.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SPECIAL3.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SPECIAL4.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SPECIAL5.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SPECIAL6.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SPECIAL7.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SPECIAL8.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentGatewayData.SPECIAL9.ToString());
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(EntryData.getInstance().LASTMODIFIED);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(EntryData.getInstance().TIMECREATED);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(this.sqlStrings.PRIMARY_KEY);
        stringBuffer.append(PaymentGatewayData.ID.ToString());
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

