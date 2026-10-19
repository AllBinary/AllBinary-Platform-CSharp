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
using SpecialItemsHelperFactory = admin.taghelpers.SpecialItemsHelperFactory;
using SpecialItemsRequestHelperFactory = admin.taghelpers.SpecialItemsRequestHelperFactory;

namespace admin.tags;

public class SpecialItemsTag : TableTag
{
    public SpecialItemsTag()
    {
        this.setTagHelperFactory(new SpecialItemsHelperFactory());
        this.setTagRequestHelperFactory(new SpecialItemsRequestHelperFactory());
    }

}

