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

public class CreditCardTypeFactory
{
    private static readonly CreditCardTypeFactory instance = new CreditCardTypeFactory();
    public static CreditCardTypeFactory getInstance()
    {
        return CreditCardTypeFactory.instance;
    }

    public readonly CreditCardType VISA = new CreditCardType("Visa");
    public readonly CreditCardType MASTERCARD = new CreditCardType("MasterCard");
    public readonly CreditCardType DISCOVER = new CreditCardType("Discover");
    public readonly CreditCardType AMERICANEXPRESS = new CreditCardType("AMX");
}

