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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using AdvertisementInterface = org.allbinary.business.advertisement.AdvertisementInterface;
using AdvertisementsInterface = org.allbinary.business.advertisement.AdvertisementsInterface;
using AdvertisementSearchInterface = org.allbinary.business.advertisement.search.AdvertisementSearchInterface;

namespace org.allbinary.business.advertisement.campaign;

public class AdvertisementCampaigns : AdvertisementCampaignsInterface
{
    private BasicArrayList advertisementsVector;
    public AdvertisementCampaigns(BasicArrayList vector)
    {
        this.advertisementsVector = this.advertisementsVector;
    }

    public virtual void add(AdvertisementInterface advertisementInterface)
    {
        this.advertisementsVector.add(advertisementInterface);
    }

    public virtual AdvertisementInterface get(int index)
    {
        return ((AdvertisementInterface) this.advertisementsVector.get(index));
    }

    public virtual int size()
    {
        return this.advertisementsVector.size();
    }

    public virtual bool isEnabled()
    {
        return true;
    }

    public virtual AdvertisementsInterface search(AdvertisementSearchInterface advertisementSearchInterface)
    {
        return null;
    }

}

