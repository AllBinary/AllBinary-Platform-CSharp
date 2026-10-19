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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.context.modules.storefronts;

public class BasicStoreFrontFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly BasicStoreFrontFactory instance = new BasicStoreFrontFactory();
    public static BasicStoreFrontFactory getInstance()
    {
        return BasicStoreFrontFactory.instance;
    }

    private BasicStoreFrontFactory()
    {
    }

    // throws Exception
    public virtual BasicStoreFrontInterface getInstance(string storeName)
    {
        try {
            BasicStoreFrontsEntity storeFronts = new BasicStoreFrontsEntity();
            return storeFronts.getStoreFrontInterface(storeName);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().FACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

