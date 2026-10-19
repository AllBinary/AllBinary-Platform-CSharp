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
using TransactionResultInterface = org.allbinary.business.user.commerce.money.payment.gateway.transaction.TransactionResultInterface;
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;

namespace org.allbinary.data.tables.user.commerce.money.payment.transaction;

public interface TransactionResultEntityInterface : BasicDataTableInterface
{
    TransactionResultInterface getTransactionResultInterface(string orderNumber);

    void remove(string userName, string orderNumber);

    void add(string userName, string orderNumber, TransactionResultInterface resultInterface);

}

