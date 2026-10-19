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
using AdvertisementAreaInterface = org.allbinary.business.advertisement.area.AdvertisementAreaInterface;
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;

namespace org.allbinary.data.tables.advertisement.areas;

public interface AdvertisementAreasEntityInterface : BasicDataTableInterface
{
    // throws Exception
    BasicArrayList get(string storeName);

    // throws Exception
    AdvertisementAreaInterface get(string storeName, string advertisementAreaName);

    void delete(string value);

    void insert(BasicArrayList values);

    void update(HashMap updatedValues);

}

