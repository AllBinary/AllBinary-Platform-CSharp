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
using BasicGroupItemsHelperFactory = admin.taghelpers.BasicGroupItemsHelperFactory;
using BasicGroupItemsRequestHelperFactory = admin.taghelpers.BasicGroupItemsRequestHelperFactory;

namespace admin.tags;

public class BasicGroupItemsTag : TableTag
{
    private HashMap propertiesHashMap = null;
    public BasicGroupItemsTag()
    {
        this.setTagHelperFactory(new BasicGroupItemsHelperFactory());
        this.setTagRequestHelperFactory(new BasicGroupItemsRequestHelperFactory());
    }

}

