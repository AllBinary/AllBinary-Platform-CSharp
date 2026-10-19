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
using StreetAddressesEntity = org.allbinary.data.tables.user.address.StreetAddressesEntity;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.data.tables.user.address.billing;

public class BillingAddressesEntityFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly BillingAddressesEntityFactory instance = new BillingAddressesEntityFactory();
    public static BillingAddressesEntityFactory getInstance()
    {
        return BillingAddressesEntityFactory.instance;
    }

    private BillingAddressesEntityFactory()
    {
    }

    public virtual StreetAddressesEntity getInstance(string userName)
    {
        try {
            return new BillingAddressesEntity(userName);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

