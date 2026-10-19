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

public interface AdvertisementInterface
{
    string getArtist();

    string getArtistLink();

    string getTitle();

    string getDateAdded();

    string getDirectory();

    string getFramedLink();

    Money getListPrice();

    Money getOurPrice();

    int getRank();

    AdvertisementImageInterface getImage();

    AdvertisementProductInterface getProduct();

    AdvertisementThumbnailInterface getThumbnail();

    DisplayInBrowserContraintsInterface getDisplayInBrowserContraintsInterface();

    void setArtist(string artist);

    void setArtistLink(string artistLink);

    void setTitle(string title);

    void setDateAdded(string dateAdded);

    void setDirectory(string directory);

    void setFramedLink(string framedLink);

    void setRank(int rank);

    void setImage(AdvertisementImageInterface AdvertisementImageInterface);

    void setProduct(AdvertisementProductInterface AdvertisementProductInterface);

    void setThumbnail(AdvertisementThumbnailInterface AdvertisementThumbnailInterface);

}

