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
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;

namespace org.allbinary.business.user.commerce.money.tax.modules;

public interface TaxModuleInterface
{
    // throws Exception
    float? getTaxRate(StreetAddress streetAddress, StoreFrontInterface storeFrontInterface);

    // throws Exception
    bool? isValid(StreetAddress streetAddress, StoreFrontInterface storeFrontInterface);

}

