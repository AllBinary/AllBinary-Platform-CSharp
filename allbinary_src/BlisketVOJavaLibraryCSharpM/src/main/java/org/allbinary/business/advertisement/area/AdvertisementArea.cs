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
using AdvertisementCampaignData = org.allbinary.business.advertisement.campaign.AdvertisementCampaignData;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using Document = org.w3c.dom.Document;

namespace org.allbinary.business.advertisement.area;

public class AdvertisementArea : AdvertisementAreaInterface
{
    private string name;
    private string storeName;
    private string description;
    private AdvertisementAreaConstraintsInterface advertisementAreaConstraintsInterface;
    private string campaign;
    public AdvertisementArea(HashMap<object, object> hashMap)
    {
        this.name = ((string) hashMap.get(AdvertisementAreaData.getInstance().NAME));
        this.storeName = ((string) hashMap.get(StoreFrontData.getInstance().NAME));
        this.description = ((string) hashMap.get(AdvertisementAreaData.getInstance().DESCRIPTION));
        string constraintsDomString = ((string) hashMap.get(AdvertisementAreaData.getInstance().CONSTRAINTS));
        Document document = DomDocumentHelper.create(constraintsDomString);
        this.advertisementAreaConstraintsInterface = new AdvertisementAreaConstraints(document);
        this.campaign = ((string) hashMap.get(AdvertisementCampaignData.getInstance().NAME));
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getStoreName()
    {
        return this.storeName;
    }

    public virtual string getDescription()
    {
        return this.description;
    }

    public virtual AdvertisementAreaConstraintsInterface getConstraints()
    {
        return this.advertisementAreaConstraintsInterface;
    }

    public virtual string getCampaign()
    {
        return this.campaign;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    public virtual void setStoreName(string storeName)
    {
        this.storeName = storeName;
    }

    public virtual void setDescription(string description)
    {
        this.description = description;
    }

    public virtual void setConstraints(AdvertisementAreaConstraintsInterface advertisementConstraintsInterface)
    {
        this.advertisementAreaConstraintsInterface = this.advertisementAreaConstraintsInterface;
    }

    public virtual void setCampaign(string campaign)
    {
        this.campaign = campaign;
    }

}

