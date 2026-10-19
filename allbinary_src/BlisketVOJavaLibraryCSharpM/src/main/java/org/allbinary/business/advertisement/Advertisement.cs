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
using AdvertisementImageInterface = org.allbinary.business.advertisement.image.AdvertisementImageInterface;
using AdvertisementProductInterface = org.allbinary.business.advertisement.product.AdvertisementProductInterface;
using AdvertisementThumbnailInterface = org.allbinary.business.advertisement.thumbnail.AdvertisementThumbnailInterface;
using Money = org.allbinary.business.user.commerce.money.Money;
using DisplayInBrowserContraintsInterface = org.allbinary.logic.control.contraints.display.browser.DisplayInBrowserContraintsInterface;

namespace org.allbinary.business.advertisement;

public class Advertisement : AdvertisementInterface
{
    private string artist = null;
    private string artistLink = null;
    private string title = null;
    private string dateAdded = null;
    private string directory = null;
    private string framedLink = null;
    private int rank = 0;
    private Money listPrice = null;
    private Money ourPrice = null;
    private AdvertisementImageInterface image = null;
    private AdvertisementProductInterface product = null;
    private AdvertisementThumbnailInterface thumbnail = null;
    private readonly DisplayInBrowserContraintsInterface displayInBrowserContraintsInterface;
    public Advertisement()
    {
        this.displayInBrowserContraintsInterface = null;
    }

    public virtual string getArtist()
    {
        return this.artist;
    }

    public virtual void setArtist(string artist)
    {
        this.artist = artist;
    }

    public virtual string getArtistLink()
    {
        return this.artistLink;
    }

    public virtual void setArtistLink(string artistLink)
    {
        this.artistLink = artistLink;
    }

    public virtual string getTitle()
    {
        return this.title;
    }

    public virtual void setTitle(string title)
    {
        this.title = title;
    }

    public virtual string getDateAdded()
    {
        return this.dateAdded;
    }

    public virtual void setDateAdded(string dateAdded)
    {
        this.dateAdded = dateAdded;
    }

    public virtual string getDirectory()
    {
        return this.directory;
    }

    public virtual void setDirectory(string directory)
    {
        this.directory = directory;
    }

    public virtual string getFramedLink()
    {
        return this.framedLink;
    }

    public virtual void setFramedLink(string framedLink)
    {
        this.framedLink = framedLink;
    }

    public virtual Money getListPrice()
    {
        return this.listPrice;
    }

    public virtual void setListPrice(Money listPrice)
    {
        this.listPrice = listPrice;
    }

    public virtual Money getOurPrice()
    {
        return this.ourPrice;
    }

    public virtual void setOurPrice(Money ourPrice)
    {
        this.ourPrice = ourPrice;
    }

    public virtual int getRank()
    {
        return this.rank;
    }

    public virtual void setRank(int rank)
    {
        this.rank = rank;
    }

    public virtual AdvertisementImageInterface getImage()
    {
        return this.image;
    }

    public virtual void setImage(AdvertisementImageInterface image)
    {
        this.image = image;
    }

    public virtual AdvertisementProductInterface getProduct()
    {
        return this.product;
    }

    public virtual void setProduct(AdvertisementProductInterface product)
    {
        this.product = product;
    }

    public virtual AdvertisementThumbnailInterface getThumbnail()
    {
        return this.thumbnail;
    }

    public virtual void setThumbnail(AdvertisementThumbnailInterface thumbnail)
    {
        this.thumbnail = thumbnail;
    }

    public virtual DisplayInBrowserContraintsInterface getDisplayInBrowserContraintsInterface()
    {
        return this.displayInBrowserContraintsInterface;
    }

}

