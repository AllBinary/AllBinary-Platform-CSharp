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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Tokenizer = org.allbinary.logic.@string.tokens.Tokenizer;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.business.user.commerce.money.payment.gateway.transaction;

public class TransactionResult : TransactionResultInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private HashMap keyValuePairs;
    private string result;
    public TransactionResult(string result)
    {
        try {
            this.result = result;
            Tokenizer tokenizer = new Tokenizer(CommonSeps.getInstance().AMPERSAND);
            BasicArrayList tokens = tokenizer.getTokensFromString(result, new BasicArrayListD());
            Tokenizer tokenizer2 = new Tokenizer(CommonSeps.getInstance().EQUALS);
            ABHashtable<object, object> hashtable = tokenizer2.getTokens(tokens);
            this.keyValuePairs.putAll(hashtable);
        } catch (Exception e) {
            string exceptionMessage = "TransactionResult Constructor Failed";
            this.logUtil.putF(exceptionMessage, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public TransactionResult(HashMap keyValuePairs)
    {
        keyValuePairs = keyValuePairs;
        this.result = "Needs to have the hashmap converted to string for other constructor";
    }

    public override string ToString()
    {
        return this.result;
    }

    public virtual HashMap toHashMap()
    {
        return this.keyValuePairs;
    }

    private BasicArrayList getAllPossibleKeys()
    {
        PaymentTransactionKeysFactory paymentTransactionKeysFactory = PaymentTransactionKeysFactory.getInstance();
        BasicArrayList verisignResponseKeys = new BasicArrayListD();
        verisignResponseKeys.add(paymentTransactionKeysFactory.RESULT.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.PNREF.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.RESPMSG.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.AUTHCODE.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.AVSADDR.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.AVSZIP.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.ORIGRESULT.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.STATUS.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.FRAUDCODE.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.FRAUDMSG.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.ERRCODE.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.SCORE.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.REASON1.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.REASON2.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.REASON3.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.EXCEPTION1.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.EXCEPTION2.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.EXCEPTION3.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.EXCEPTION4.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.EXCEPTION5.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.EXCEPTION6.ToString());
        verisignResponseKeys.add(paymentTransactionKeysFactory.EXCEPTION7.ToString());
        return verisignResponseKeys;
    }

    public virtual BasicArrayList getValues()
    {
        BasicArrayList keyVector = this.getAllPossibleKeys();
        BasicArrayList valueVector = new BasicArrayListD();
        int size = keyVector.size();
        for (int i = 0; i < size; i++) {
            string key = ((string) keyVector.get(i));
            if (this.keyValuePairs.containsKey(key)) {
                valueVector.add(this.keyValuePairs.get(key));
            } else {
                StringUtil stringUtil = StringUtil.getInstance();
                valueVector.add(stringUtil.EMPTY_STRING);
            }
        }
        return valueVector;
    }

    public virtual string getPnRef()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().PNREF.ToString()));
    }

    public virtual string getRespMsg()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().RESPMSG.ToString()));
    }

    public virtual string getResult()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().RESULT.ToString()));
    }

    public virtual string getScore()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().SCORE.ToString()));
    }

    public virtual string getStatus()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().STATUS.ToString()));
    }

    public virtual string getFraudCode()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().FRAUDCODE.ToString()));
    }

    public virtual string getFraudMsg()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().FRAUDMSG.ToString()));
    }

    public virtual string getOrigResult()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().ORIGRESULT.ToString()));
    }

    public virtual string getAvsAddr()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().AVSADDR.ToString()));
    }

    public virtual string getAvsZip()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().AVSZIP.ToString()));
    }

    public virtual string getErrCode()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().ERRCODE.ToString()));
    }

    public virtual string getException1()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().EXCEPTION1.ToString()));
    }

    public virtual string getException2()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().EXCEPTION2.ToString()));
    }

    public virtual string getException3()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().EXCEPTION3.ToString()));
    }

    public virtual string getException4()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().EXCEPTION4.ToString()));
    }

    public virtual string getException5()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().EXCEPTION5.ToString()));
    }

    public virtual string getException6()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().EXCEPTION6.ToString()));
    }

    public virtual string getException7()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().EXCEPTION7.ToString()));
    }

    public virtual string getReason1()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().REASON1.ToString()));
    }

    public virtual string getReason2()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().REASON2.ToString()));
    }

    public virtual string getReason3()
    {
        return ((string) this.keyValuePairs.get(PaymentTransactionKeysFactory.getInstance().REASON3.ToString()));
    }

}

