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

public class TenderTypeFactory
{
    private static readonly TenderTypeFactory instance = new TenderTypeFactory();
    public static TenderTypeFactory getInstance()
    {
        return TenderTypeFactory.instance;
    }

    public readonly TenderType CREDITCARD = new TenderType("Credit Card");
    public readonly TenderType CHECK = new TenderType("Check");
    public readonly TenderType ACH = new TenderType("Ach");
}

