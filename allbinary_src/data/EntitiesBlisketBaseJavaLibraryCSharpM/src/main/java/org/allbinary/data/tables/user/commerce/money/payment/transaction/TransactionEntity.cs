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
using OrderData = org.allbinary.business.user.commerce.inventory.order.OrderData;
using PaymentTransactionInterface = org.allbinary.business.user.commerce.money.payment.gateway.transaction.PaymentTransactionInterface;
using PaymentTransactionKeysFactory = org.allbinary.business.user.commerce.money.payment.gateway.transaction.PaymentTransactionKeysFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.user.commerce.money.payment.transaction;

public class TransactionEntity : AbSqlBean, TransactionEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string tableName = "vtrans";
    public TransactionEntity() : base(new UserDbInitInfo())
    {
        // base(new UserDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public virtual void remove(string userName, string orderNumber)
    {
        try {
            HashMap whereHashMap = StdUtil.getInstance().createHashMap();
            whereHashMap.put(OrderData.ID, ((string) orderNumber));
            whereHashMap.put(UserData.USERNAME, userName);
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

    public virtual void add(string userName, string orderNumber, PaymentTransactionInterface paymentTransactionInterface)
    {
        try {
            BasicArrayList values = new BasicArrayListD();
            values.add(orderNumber);
            values.add(userName);
            values.addAllList(paymentTransactionInterface.toVector());
            Calendar calendar = Calendar.getInstance();
            string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
            values.add(time);
            values.add(time);
            base.insert(values);
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
        PaymentTransactionKeysFactory paymentTransactionKeysFactory = PaymentTransactionKeysFactory.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE);
        stringBuffer.append(this.tableName);
        stringBuffer.append(this.sqlStrings.START);
        stringBuffer.append(OrderData.ID).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(UserData.USERNAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.TRXTYPE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.TENDER.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.ACCT.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.EXPDATE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.AMT.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.AUTHCODE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.MICR.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.CHECKNUM.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.NAME.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.STREET.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.CITY.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.STATE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.ZIP.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.DL.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.EMAIL.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.COMMENT1.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.COMMENT2.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.ORIGID.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.PONUM.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.DESC.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.DESC1TO4.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.INVNUM.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SHIPTOZIP.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SWIPE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.TAXAMT.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.COMMCARD.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.DUTYAMT.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.FREIGHTAMT.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.ORDERDATE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.TAXEXEMPT.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.COUNTRYCODE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.CUSTCODE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.CVV2.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.ABA.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.ACCTTYPE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.DISCOUNT.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.FIRSTNAME.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.LASTNAME.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SHIPFROMZIP.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.PRENOTE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.CHKTYPE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.DOB.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.PHONENUM.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SS.ToString()).append(" VARCHAR(30) NOT NULL,").append(paymentTransactionKeysFactory.COMPANYNAME.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.COUNTRY.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SHIPTOCITY.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SHIPTOFIRSTNAME.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SHIPTOLASTNAME.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SHIPTOSTATE.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SHIPTOSTREET.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SPECIAL1.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SPECIAL2.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.SPECIAL3.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(EntryData.getInstance().LASTMODIFIED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(EntryData.getInstance().TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(OrderData.ID).append(this.sqlStrings.END);
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

