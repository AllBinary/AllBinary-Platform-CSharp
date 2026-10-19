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
using PaymentInterface = org.allbinary.business.user.commerce.money.payment.PaymentInterface;
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;

namespace org.allbinary.data.tables.user.commerce.money.payment;

public interface PaymentEntityInterface : BasicDataTableInterface
{
    string getLastId(string userName);

    void setDefault(string userName, int? index);

    PaymentInterface getDefault(string userName);

    BasicArrayList get(string userName);

    void add(string userName, PaymentInterface paymentInterface);

    void remove(string userName, int? index);

    void insert(BasicArrayList values);

}

