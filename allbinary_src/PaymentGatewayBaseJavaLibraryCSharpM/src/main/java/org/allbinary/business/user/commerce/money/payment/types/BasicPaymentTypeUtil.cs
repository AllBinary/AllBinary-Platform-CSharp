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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.business.user.commerce.money.payment.types;

public class BasicPaymentTypeUtil
{
    private static readonly BasicPaymentTypeUtil instance = new BasicPaymentTypeUtil();
    static BasicPaymentTypeUtil()
    {
    }
    public static BasicPaymentTypeUtil getInstance()
    {
        return BasicPaymentTypeUtil.instance;
    }

    private BasicPaymentTypeUtil()
    {
    }

    private BasicArrayList paymentTypeVector = new BasicArrayListD();
    public virtual void add(BasicPaymentType paymentType)
    {
        this.paymentTypeVector.add(paymentType);
    }

    // throws Exception
    public virtual BasicPaymentType get(string paymentTypeString)
    {
        int size = this.paymentTypeVector.size();
        for (int i = 0; i < size; i++) {
            BasicPaymentType paymentType = ((BasicPaymentType) this.paymentTypeVector.get(i));
            if (paymentType.getName().compareTo(paymentTypeString) == 0) {
                return paymentType;
            }
        }
        throw new Exception("Unknown PaymentType: " + paymentTypeString);
    }

    public virtual bool isContain(BasicPaymentType paymentType)
    {
        return this.paymentTypeVector.contains(paymentType);
    }

    public virtual BasicArrayList difference(BasicArrayList a_PaymentTypeVector)
    {
        BasicArrayList diff = new BasicArrayListD();
        int size = this.paymentTypeVector.size();
        for (int i = 0; i < size; i++) {
            BasicPaymentType paymentType = ((BasicPaymentType) this.paymentTypeVector.get(i));
            if (!a_PaymentTypeVector.contains(paymentType)) {
                diff.add(paymentType);
            }
        }
        return diff;
    }

}

