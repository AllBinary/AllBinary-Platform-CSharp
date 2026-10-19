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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.business.context.modules.storefront.statistics.advertisements;

public class StoreFrontAdvertisementsStatistics : StoreFrontAdvertisementsStatisticsInterface
{
    public StoreFrontAdvertisementsStatistics(StoreFrontInterface storeFrontInterface)
    {
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        return hashMap;
    }

    public virtual BasicArrayList toVector()
    {
        return null;
    }

    public virtual object getKey()
    {
        return null;
    }

}

