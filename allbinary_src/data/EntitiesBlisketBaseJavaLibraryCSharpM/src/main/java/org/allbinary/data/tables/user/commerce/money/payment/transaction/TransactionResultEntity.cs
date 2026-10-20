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
using Calendar = java.util.Calendar;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using EntryData = org.allbinary.business.entry.EntryData;
using UserDbInitInfo = org.allbinary.business.init.db.UserDbInitInfo;
using UserData = org.allbinary.business.user.UserData;
using OrderData = org.allbinary.business.user.commerce.inventory.order.OrderData;
using PaymentTransactionKeysFactory = org.allbinary.business.user.commerce.money.payment.gateway.transaction.PaymentTransactionKeysFactory;
using TransactionResult = org.allbinary.business.user.commerce.money.payment.gateway.transaction.TransactionResult;
using TransactionResultInterface = org.allbinary.business.user.commerce.money.payment.gateway.transaction.TransactionResultInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.data.tables.user.commerce.money.payment.transaction;

public class TransactionResultEntity : AbSqlBean, TransactionResultEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly string tableName = "vresults";
    public TransactionResultEntity() : base(new UserDbInitInfo())
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

    public virtual void add(string userName, string orderNumber, TransactionResultInterface transactionResultInterface)
    {
        try {
            BasicArrayList values = new BasicArrayListD();
            values.add(orderNumber);
            values.add(userName);
            values.addAllList(transactionResultInterface.getValues());
            Calendar calendar = Calendar.getInstance();
            string time = calendar.getTimeInMillis().ToString();
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

    public virtual TransactionResultInterface getTransactionResultInterface(string orderNumber)
    {
        try {
            HashMap resultHashMap = StdUtil.getInstance().createHashMap();
            HashMap updateKeyAndValue = StdUtil.getInstance().createHashMap();
            updateKeyAndValue.put(OrderData.ID, orderNumber);
            resultHashMap = base.getRow(updateKeyAndValue);
            if (resultHashMap != null) {
                TransactionResult transactionResult = new TransactionResult(resultHashMap);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                    this.logUtil.putF(this.commonStrings.SUCCESS, this, "getTransactionResultInterface");
                }
                return ((TransactionResultInterface) transactionResult);
            } else {
                return null;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "getTransactionResultInterface", e);
            }
            return null;
        }
    }

    public string createTableStatement()
    {
        PaymentTransactionKeysFactory paymentTransactionKeysFactory = PaymentTransactionKeysFactory.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.sqlStrings.CREATE_TABLE).append(tableName).append(this.sqlStrings.START).append(OrderData.ID).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(UserData.USERNAME).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(paymentTransactionKeysFactory.RESULT.ToString()).append(this.sqlTypeStrings.MAX_INT_NOT_NULL).append(paymentTransactionKeysFactory.PNREF.ToString()).append(this.sqlTypeStrings.TWELVE_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(paymentTransactionKeysFactory.RESPMSG.ToString()).append(this.sqlTypeStrings.BLOB_NOT_NULL).append(paymentTransactionKeysFactory.AUTHCODE.ToString()).append(this.sqlTypeStrings.SIX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.AVSADDR.ToString()).append(this.sqlTypeStrings.ONE_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(paymentTransactionKeysFactory.AVSZIP.ToString()).append(this.sqlTypeStrings.ONE_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.ORIGRESULT.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL).append(paymentTransactionKeysFactory.STATUS.ToString()).append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(paymentTransactionKeysFactory.FRAUDCODE.ToString()).append(this.sqlTypeStrings.TWO_INT_NOT_NULL);
        stringBuffer.append(paymentTransactionKeysFactory.FRAUDMSG.ToString()).append(this.sqlTypeStrings.MAX_INT_NOT_NULL);
        stringBuffer.append(paymentTransactionKeysFactory.ERRCODE.ToString()).append(this.sqlTypeStrings.MAX_INT_NOT_NULL);
        stringBuffer.append(paymentTransactionKeysFactory.SCORE.ToString()).append(this.sqlTypeStrings.THREE_INT_NOT_NULL);
        stringBuffer.append(paymentTransactionKeysFactory.REASON1.ToString()).append(this.sqlTypeStrings.FOUR_INT_NOT_NULL).append(paymentTransactionKeysFactory.REASON2.ToString()).append(this.sqlTypeStrings.FOUR_INT_NOT_NULL).append(paymentTransactionKeysFactory.REASON3.ToString());
        stringBuffer.append(this.sqlTypeStrings.FOUR_INT_NOT_NULL).append(paymentTransactionKeysFactory.EXCEPTION1.ToString()).append(this.sqlTypeStrings.FOUR_INT_NOT_NULL).append(paymentTransactionKeysFactory.EXCEPTION2.ToString()).append(this.sqlTypeStrings.FOUR_INT_NOT_NULL).append(paymentTransactionKeysFactory.EXCEPTION3.ToString()).append(this.sqlTypeStrings.FOUR_INT_NOT_NULL).append(paymentTransactionKeysFactory.EXCEPTION4.ToString()).append(this.sqlTypeStrings.FOUR_INT_NOT_NULL).append(paymentTransactionKeysFactory.EXCEPTION5.ToString()).append(this.sqlTypeStrings.FOUR_INT_NOT_NULL).append(paymentTransactionKeysFactory.EXCEPTION6.ToString()).append(this.sqlTypeStrings.FOUR_INT_NOT_NULL).append(paymentTransactionKeysFactory.EXCEPTION7.ToString()).append(this.sqlTypeStrings.FOUR_INT_NOT_NULL).append(EntryData.getInstance().LASTMODIFIED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(EntryData.getInstance().TIMECREATED).append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL).append(this.sqlStrings.PRIMARY_KEY).append(OrderData.ID).append(this.sqlStrings.END);
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

