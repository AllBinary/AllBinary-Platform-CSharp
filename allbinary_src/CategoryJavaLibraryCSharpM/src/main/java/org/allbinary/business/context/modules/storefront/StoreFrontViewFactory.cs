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
using StoreFrontsEntity = org.allbinary.data.tables.context.module.storefronts.StoreFrontsEntity;
using StoreFrontsEntityFactory = org.allbinary.data.tables.context.module.storefronts.StoreFrontsEntityFactory;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.context.modules.storefront;

public class StoreFrontViewFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private StoreFrontViewFactory()
    {
    }

    public static DomNodeInterface getInstance(string storeName)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            StoreFrontsEntity storeFronts = StoreFrontsEntityFactory.getInstance().getStoreFrontsEntityInstance();
            return ((DomNodeInterface) new StoreFrontView(storeFronts.getStoreFrontInterface(storeName)));
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().FACTORYERROR)) {
                logUtil.put(commonStrings.EXCEPTION, "StoreFrontFactory", commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

