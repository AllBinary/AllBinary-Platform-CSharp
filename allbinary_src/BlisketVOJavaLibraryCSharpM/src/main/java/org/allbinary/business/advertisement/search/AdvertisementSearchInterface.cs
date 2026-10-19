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
using AdvertisementCategoryInterface = org.allbinary.business.advertisement.search.category.AdvertisementCategoryInterface;
using AdvertisementWebsiteInterface = org.allbinary.business.advertisement.search.website.AdvertisementWebsiteInterface;
using PriceConstraintInterface = org.allbinary.logic.control.contraints.price.PriceConstraintInterface;
using TwoDimensionalConstraintInterface = org.allbinary.logic.control.contraints.size.TwoDimensionalConstraintInterface;

namespace org.allbinary.business.advertisement.search;

public interface AdvertisementSearchInterface
{
    AdvertisementWebsiteInterface getWebSite();

    AdvertisementCategoryInterface getCategory();

    TwoDimensionalConstraintInterface getSizeConstraints();

    PriceConstraintInterface getPricingConstraints();

    int getPageNumber();

    int getProductsPerPage();

    HashMap getSearchParams();

    void setCategory(AdvertisementCategoryInterface advertisementCategoryInterface);

    void setSizeConstraints(TwoDimensionalConstraintInterface twoDimensionConstraintsInterface);

    void setPricingConstraints(PriceConstraintInterface priceConstraintInterface);

    void setPageNumber(int pageNumber);

    void setProductsPerPage(int productsPerPage);

    void setSearchParams(HashMap columnAndKeywordHashMap);

}

