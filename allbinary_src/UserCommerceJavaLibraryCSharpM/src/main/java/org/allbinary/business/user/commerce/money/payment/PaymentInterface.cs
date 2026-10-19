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

namespace org.allbinary.business.user.commerce.money.payment;

public interface PaymentInterface
{
    void setName(string value);

    void setType(string value);

    void setExpiration(string value);

    void setNumber(string value);

    string getId();

    string getName();

    string getType();

    string getExpiration();

    string getEncryption();

    string getNumber();

    string getLastFour();

    bool isDefault();

}

