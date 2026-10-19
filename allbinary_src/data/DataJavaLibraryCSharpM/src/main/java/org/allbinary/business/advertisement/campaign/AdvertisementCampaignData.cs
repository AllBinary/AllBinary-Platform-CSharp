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

namespace org.allbinary.business.advertisement.campaign;

public class AdvertisementCampaignData
{
    private static readonly AdvertisementCampaignData instance = new AdvertisementCampaignData();
    public static AdvertisementCampaignData getInstance()
    {
        return AdvertisementCampaignData.instance;
    }

    private AdvertisementCampaignData()
    {
    }

    public readonly string NAME = "ADVERTISEMENTCAMPAIGN_NAME";
    public readonly string DESCRIPTION = "ADVERTISEMENTCAMPAIGN_DESCRIPTION";
    public readonly string CONFIG = "ADVERTISEMENTCAMPAIGN_CONFIG";
}

