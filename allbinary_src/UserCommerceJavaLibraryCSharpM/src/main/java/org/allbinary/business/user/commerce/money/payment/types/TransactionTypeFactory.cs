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

namespace org.allbinary.business.user.commerce.money.payment.types;

public class TransactionTypeFactory
{
    private static readonly TransactionTypeFactory instance = new TransactionTypeFactory();
    public static TransactionTypeFactory getInstance()
    {
        return TransactionTypeFactory.instance;
    }

    public readonly TransactionType SALE = new TransactionType("Sale");
    public readonly TransactionType CREDIT = new TransactionType("Credit");
    public readonly TransactionType AUTHORIZATION = new TransactionType("Authorization");
    public readonly TransactionType DELAYEDCAPTURE = new TransactionType("Delayed Capture");
    public readonly TransactionType VOID = new TransactionType("Void");
    public readonly TransactionType INQUIRY = new TransactionType("Inquiry");
}

