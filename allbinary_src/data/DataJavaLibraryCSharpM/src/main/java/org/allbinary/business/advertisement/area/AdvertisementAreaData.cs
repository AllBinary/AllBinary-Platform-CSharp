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

namespace org.allbinary.business.advertisement.area;

public class AdvertisementAreaData
{
    private static readonly AdvertisementAreaData instance = new AdvertisementAreaData();
    public static AdvertisementAreaData getInstance()
    {
        return AdvertisementAreaData.instance;
    }

    private AdvertisementAreaData()
    {
    }

    public readonly string NAME = "ADVERTISEMENT_NAME";
    public readonly string DESCRIPTION = "ADVERTISEMENT_DESCRIPTION";
    public readonly string CONSTRAINTS = "ADVERTISEMENT_CONSTRAINTS";
}

