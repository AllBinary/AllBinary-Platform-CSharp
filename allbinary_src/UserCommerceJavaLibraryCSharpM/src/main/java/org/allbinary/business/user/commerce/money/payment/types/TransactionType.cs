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

public class TransactionType
{
    private string name;
    public TransactionType(string name)
    {
        this.name = name;
    }

    public virtual bool isEqual(TransactionType transactionType)
    {
        if (string.CompareOrdinal(this.ToString(), transactionType.ToString()) == 0) {
            return true;
        } else {
            return false;
        }
    }

    public override string ToString()
    {
        return this.name;
    }

}

