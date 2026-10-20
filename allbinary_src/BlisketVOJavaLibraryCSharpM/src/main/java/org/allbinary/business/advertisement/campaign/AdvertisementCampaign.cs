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
using java.util;
using DynamicObjectData = org.allbinary.business.DynamicObjectData;
using AdvertisementsInterface = org.allbinary.business.advertisement.AdvertisementsInterface;
using AdvertisementSearchInterface = org.allbinary.business.advertisement.search.AdvertisementSearchInterface;

namespace org.allbinary.business.advertisement.campaign;

public class AdvertisementCampaign : AdvertisementCampaignInterface
{
    private HashMap<object, object> hashMap;
    public AdvertisementCampaign(HashMap<object, object> hashMap)
    {
        this.hashMap = hashMap;
    }

    public virtual object getComponent()
    {
        return null;
    }

    public virtual string getName()
    {
        return ((string) this.hashMap.get(AdvertisementCampaignData.getInstance().NAME));
    }

    public virtual void setComponentName(string name)
    {
        this.hashMap.put(DynamicObjectData.NAME, name);
    }

    public virtual void setName(string name)
    {
        this.hashMap.put(AdvertisementCampaignData.getInstance().NAME, name);
    }

    public virtual AdvertisementsInterface search(AdvertisementSearchInterface advertisementSearchInterface)
    {
        return null;
    }

}

