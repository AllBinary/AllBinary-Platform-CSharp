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

namespace org.allbinary.data.tables.advertisement.campaign.@internal;

public class AdvertisementCampaignInternalEntityFactory
{
    private static readonly string CLASSNAME = "org.allbinary.data.tables.AdvertisementCampaignEntity";
    private AdvertisementCampaignInternalEntityFactory()
    {
    }

    public static AdvertisementCampaignInternalEntityInterface getInstance()
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            return ((AdvertisementCampaignInternalEntityInterface) new AdvertisementCampaignInternalEntity());
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().ENTITYFACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, "AdvertisementCampaignEntityFactory", commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

