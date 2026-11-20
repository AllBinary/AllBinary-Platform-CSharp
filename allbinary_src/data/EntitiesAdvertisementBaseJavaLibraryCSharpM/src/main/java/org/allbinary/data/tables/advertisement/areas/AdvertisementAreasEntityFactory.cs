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
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.data.tables.advertisement.areas;

public class AdvertisementAreasEntityFactory
{
    private const string CLASSNAME = "org.allbinary.data.tables.AdvertisementEntity";
    private AdvertisementAreasEntityFactory()
    {
    }

    public static AdvertisementAreasEntityInterface getInstance()
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            return ((AdvertisementAreasEntityInterface) new AdvertisementAreasEntity());
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, "AdvertisementAreasEntityFactory", commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

