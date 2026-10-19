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
using AdvertisementsInterface = org.allbinary.business.advertisement.AdvertisementsInterface;
using AdvertisementSearchInterface = org.allbinary.business.advertisement.search.AdvertisementSearchInterface;

namespace org.allbinary.business.advertisement.campaign;

public interface AdvertisementCampaignInterface
{
    string getName();

    object getComponent();

    void setName(string name);

    void setComponentName(string name);

    AdvertisementsInterface search(AdvertisementSearchInterface advertisementSearchInterface);

}

