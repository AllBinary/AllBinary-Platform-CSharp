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
using Calendar = java.util.Calendar;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using EntryData = org.allbinary.business.entry.EntryData;
using Money = org.allbinary.business.user.commerce.money.Money;
using MoneyException = org.allbinary.business.user.commerce.money.MoneyException;
using ProductIdGenerator = org.allbinary.data.generator.ProductIdGenerator;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.commerce.inventory.item;

public class BasicItem : ItemInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    public string itemId;
    public string number;
    public string inBaskets;
    public string weight;
    public string enabled;
    public string newOrUsed;
    public string summary;
    public string distributor;
    public string idUsedByDistributor;
    public string producedBy;
    public string productionDate;
    public string startProductionDate;
    public string description;
    public string keywords;
    public string category;
    public string type;
    public string smallImage;
    public string mediumImage;
    public string largeImage;
    public Money price;
    public string comment;
    public string customs;
    private string downloads = null;
    public string groups;
    public string options;
    public string permissions;
    public string specials;
    private bool downloadable = false;
    public string timeEntered;
    public string lastModified;
    public BasicItem(HashMap itemHashMap)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGING)) {
            this.logUtil.putF(this.commonStrings.START, this, "Constructor(HashMap)");
        }
        this.itemId = ((string) itemHashMap.get(basicItemData.ID));
        this.number = ((string) itemHashMap.get(basicItemData.NUMBER));
        this.inBaskets = ((string) itemHashMap.get(basicItemData.INBASKETS));
        this.weight = ((string) itemHashMap.get(basicItemData.WEIGHT));
        this.enabled = ((string) itemHashMap.get(EntryData.getInstance().ENABLE));
        this.newOrUsed = ((string) itemHashMap.get(basicItemData.NEWORUSED));
        this.summary = ((string) itemHashMap.get(basicItemData.SUMMARY));
        this.distributor = ((string) itemHashMap.get(basicItemData.DISTRIBUTOR));
        this.idUsedByDistributor = ((string) itemHashMap.get(basicItemData.IDUSEDBYDISTRIBUTOR));
        this.producedBy = ((string) itemHashMap.get(basicItemData.PRODUCEDBY));
        this.productionDate = ((string) itemHashMap.get(basicItemData.PRODUCTIONDATE));
        this.startProductionDate = ((string) itemHashMap.get(basicItemData.STARTPRODUCTIONDATE));
        this.description = ((string) itemHashMap.get(basicItemData.DESCRIPTION));
        this.keywords = ((string) itemHashMap.get(basicItemData.KEYWORDS));
        this.category = ((string) itemHashMap.get(basicItemData.CATEGORY));
        this.type = ((string) itemHashMap.get(basicItemData.TYPE));
        this.smallImage = ((string) itemHashMap.get(basicItemData.SMALLIMAGE));
        this.mediumImage = ((string) itemHashMap.get(basicItemData.MEDIUMIMAGE));
        this.largeImage = ((string) itemHashMap.get(basicItemData.LARGEIMAGE));
        this.timeEntered = ((string) itemHashMap.get(EntryData.getInstance().TIMECREATED));
        this.lastModified = ((string) itemHashMap.get(EntryData.getInstance().LASTMODIFIED));
        this.price = new Money(((string) itemHashMap.get(basicItemData.PRICE)));
        this.comment = ((string) itemHashMap.get(basicItemData.COMMENT));
        this.customs = ((string) itemHashMap.get(basicItemData.CUSTOMS));
        this.setDownloads(((string) itemHashMap.get(basicItemData.DOWNLOADS)));
        this.groups = ((string) itemHashMap.get(basicItemData.GROUPS));
        this.options = ((string) itemHashMap.get(basicItemData.OPTIONS));
        this.permissions = ((string) itemHashMap.get(basicItemData.PERMISSIONS));
        this.specials = ((string) itemHashMap.get(basicItemData.SPECIALS));
    }

    public BasicItem()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGING)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
        string EMPTY = StringUtil.getInstance().EMPTY_STRING;
        this.itemId = new ProductIdGenerator().getNext();
        this.number = CommonPhoneStrings.getInstance().ZERO;
        this.inBaskets = EMPTY;
        this.weight = EMPTY;
        this.enabled = EMPTY;
        this.newOrUsed = EMPTY;
        this.summary = EMPTY;
        this.distributor = EMPTY;
        this.idUsedByDistributor = EMPTY;
        this.producedBy = EMPTY;
        this.productionDate = EMPTY;
        this.startProductionDate = EMPTY;
        this.description = EMPTY;
        this.keywords = EMPTY;
        this.category = EMPTY;
        this.type = EMPTY;
        this.smallImage = EMPTY;
        this.mediumImage = EMPTY;
        this.largeImage = EMPTY;
        this.timeEntered = EMPTY;
        this.lastModified = EMPTY;
        this.price = new Money();
        this.comment = EMPTY;
        this.customs = EMPTY;
        this.setDownloads(EMPTY);
        this.groups = EMPTY;
        this.options = EMPTY;
        this.permissions = EMPTY;
        this.specials = EMPTY;
    }

    public virtual void setId(string itemId)
    {
        this.itemId = itemId;
    }

    public virtual void setNumber(string number)
    {
        this.number = number;
    }

    public virtual void setInBaskets(string value)
    {
        this.inBaskets = value;
    }

    public virtual void setWeight(string value)
    {
        this.weight = value;
    }

    public virtual void setNewOrUsed(string value)
    {
        this.newOrUsed = value;
    }

    public virtual void setSummary(string value)
    {
        this.summary = value;
    }

    public virtual void setDistributor(string value)
    {
        this.distributor = value;
    }

    public virtual void setIdUsedByDistributor(string value)
    {
        this.idUsedByDistributor = value;
    }

    public virtual void setProducedBy(string value)
    {
        this.producedBy = value;
    }

    public virtual void setProductionDate(string value)
    {
        this.productionDate = value;
    }

    public virtual void setStartProductionDate(string value)
    {
        this.startProductionDate = value;
    }

    public virtual void setDescription(string value)
    {
        this.description = value;
    }

    public virtual void setKeywords(string value)
    {
        this.keywords = value;
    }

    public virtual void setCategory(string value)
    {
        this.category = value;
    }

    public virtual void setType(string value)
    {
        this.type = value;
    }

    public virtual void setSmallImage(string value)
    {
        this.smallImage = value;
    }

    public virtual void setMediumImage(string value)
    {
        this.mediumImage = value;
    }

    public virtual void setLargeImage(string value)
    {
        this.largeImage = value;
    }

    public virtual void setTimeEntered(string value)
    {
        this.timeEntered = value;
    }

    public virtual void setLastModified(string value)
    {
        this.lastModified = value;
    }

    public virtual void setPrice(Money value)
    {
        this.price = value;
    }

    public virtual void setComment(string value)
    {
        this.comment = value;
    }

    public virtual void setCustoms(string value)
    {
        this.customs = value;
    }

    public virtual void setDownloads(string value)
    {
        this.downloads = value;
        if (!StringValidationUtil.getInstance().isEmpty(this.downloads)) {
            int? downloadInteger = (this.downloads).ToString();
            if (((int) downloadInteger) != 0) {
                this.setDownloadable(true);
            }
        }
    }

    public virtual void setGroups(string value)
    {
        this.groups = value;
    }

    public virtual void setOptions(string value)
    {
        this.options = value;
    }

    public virtual void setPermissions(string value)
    {
        this.permissions = value;
    }

    public virtual void setSpecials(string value)
    {
        this.specials = value;
    }

    public virtual void setEnabled(string value)
    {
        this.enabled = value;
    }

    public virtual string getId()
    {
        return this.itemId;
    }

    public virtual string getNumber()
    {
        return this.number;
    }

    public virtual string getInBaskets()
    {
        return this.inBaskets;
    }

    public virtual string getWeight()
    {
        return this.weight;
    }

    public virtual string getNewOrUsed()
    {
        return this.newOrUsed;
    }

    public virtual string getSummary()
    {
        return this.summary;
    }

    public virtual string getDistributor()
    {
        return this.distributor;
    }

    public virtual string getIdUsedByDistributor()
    {
        return this.idUsedByDistributor;
    }

    public virtual string getProducedBy()
    {
        return this.producedBy;
    }

    public virtual string getProductionDate()
    {
        return this.productionDate;
    }

    public virtual string getStartProductionDate()
    {
        return this.startProductionDate;
    }

    public virtual string getDescription()
    {
        return this.description;
    }

    public virtual string getKeywords()
    {
        return this.keywords;
    }

    public virtual string getCategory()
    {
        return this.category;
    }

    public virtual string getType()
    {
        return this.type;
    }

    public virtual string getSmallImage()
    {
        return this.smallImage;
    }

    public virtual string getMediumImage()
    {
        return this.mediumImage;
    }

    public virtual string getLargeImage()
    {
        return this.largeImage;
    }

    public virtual string getTimeEntered()
    {
        return this.timeEntered;
    }

    public virtual string getLastModified()
    {
        return this.lastModified;
    }

    public virtual Money getPrice()
    {
        return this.price;
    }

    public virtual string getComment()
    {
        return this.comment;
    }

    public virtual string getCustoms()
    {
        return this.customs;
    }

    public virtual string getDownloads()
    {
        return this.downloads;
    }

    public virtual string getGroups()
    {
        return this.groups;
    }

    public virtual string getOptions()
    {
        return this.options;
    }

    public virtual string getPermissions()
    {
        return this.permissions;
    }

    public virtual string getSpecials()
    {
        return this.specials;
    }

    public virtual void setDownloadable(bool downloadable)
    {
        this.downloadable = downloadable;
    }

    public virtual bool isDownloadable()
    {
        return this.downloadable;
    }

    public virtual string getEnabled()
    {
        return this.enabled;
    }

    public virtual Money getTotal()
    {
        Money itemTotal = new Money(this.price);
        itemTotal.multiply(((int) this.number));
        return itemTotal;
    }

    public virtual HashMap toHashMap()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGING)) {
            this.logUtil.putF(this.commonStrings.START, this, "toHashMap");
        }
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(basicItemData.ID, this.itemId);
        hashMap.put(basicItemData.NUMBER, this.number);
        hashMap.put(basicItemData.INBASKETS, this.inBaskets);
        hashMap.put(basicItemData.WEIGHT, this.weight);
        hashMap.put(EntryData.getInstance().ENABLE, this.enabled);
        hashMap.put(basicItemData.NEWORUSED, this.newOrUsed);
        hashMap.put(basicItemData.SUMMARY, this.summary);
        hashMap.put(basicItemData.DISTRIBUTOR, this.distributor);
        hashMap.put(basicItemData.IDUSEDBYDISTRIBUTOR, this.idUsedByDistributor);
        hashMap.put(basicItemData.PRODUCEDBY, this.producedBy);
        hashMap.put(basicItemData.PRODUCTIONDATE, this.productionDate);
        hashMap.put(basicItemData.STARTPRODUCTIONDATE, this.startProductionDate);
        hashMap.put(basicItemData.DESCRIPTION, this.description);
        hashMap.put(basicItemData.KEYWORDS, this.keywords);
        hashMap.put(basicItemData.CATEGORY, this.category);
        hashMap.put(basicItemData.TYPE, this.type);
        hashMap.put(basicItemData.SMALLIMAGE, this.smallImage);
        hashMap.put(basicItemData.MEDIUMIMAGE, this.mediumImage);
        hashMap.put(basicItemData.LARGEIMAGE, this.largeImage);
        Calendar calendar = Calendar.getInstance();
        string time = calendar.getTimeInMillis().ToString();
        hashMap.put(EntryData.getInstance().LASTMODIFIED, time);
        hashMap.put(basicItemData.PRICE, this.price.ToString());
        hashMap.put(basicItemData.COMMENT, this.comment);
        hashMap.put(basicItemData.CUSTOMS, this.customs);
        hashMap.put(basicItemData.DOWNLOADS, this.getDownloads());
        hashMap.put(basicItemData.GROUPS, this.groups);
        hashMap.put(basicItemData.OPTIONS, this.options);
        hashMap.put(basicItemData.PERMISSIONS, this.permissions);
        hashMap.put(basicItemData.SPECIALS, this.specials);
        return hashMap;
    }

    public virtual BasicArrayList toVector()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGING)) {
            this.logUtil.putF(this.commonStrings.START, this, "toVector");
        }
        BasicArrayList values = new BasicArrayListD();
        values.add(this.itemId);
        values.add(this.number);
        values.add(this.inBaskets);
        values.add(this.weight);
        values.add(this.enabled);
        values.add(this.newOrUsed);
        values.add(this.summary);
        values.add(this.distributor);
        values.add(this.idUsedByDistributor);
        values.add(this.producedBy);
        values.add(this.productionDate);
        values.add(this.startProductionDate);
        values.add(this.description);
        values.add(this.keywords);
        values.add(this.category);
        values.add(this.type);
        values.add(this.getSmallImage());
        values.add(this.getMediumImage());
        values.add(this.getLargeImage());
        Calendar calendar = Calendar.getInstance();
        string time = calendar.getTimeInMillis().ToString();
        values.add(time);
        values.add(time);
        values.add(this.price.ToString());
        values.add(this.comment);
        values.add(this.customs);
        values.add(this.getDownloads());
        values.add(this.groups);
        values.add(this.options);
        values.add(this.permissions);
        values.add(this.specials);
        return values;
    }

    // throws Exception
    public virtual object getKey()
    {
        return ((object) this.getId());
    }

}

