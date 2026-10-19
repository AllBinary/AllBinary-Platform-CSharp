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
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace views.admin.inventory.listings;

public class ProductListingFactory
{
    private ProductListingFactory()
    {
    }

    public static ProductListingInterface getInstance(SearchRequest searchRequest)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            return ((ProductListingInterface) new views.admin.inventory.listings.ProductListing(searchRequest));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().FACTORYERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.put(commonStrings.EXCEPTION, "ProductListingFactory", commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

