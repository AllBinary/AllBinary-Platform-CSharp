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
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFront = org.allbinary.business.context.modules.storefront.StoreFront;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace admin.taghelpers;

public class StoreFrontHelper : TagHelper
{
    private readonly StoreFrontInterface storeFrontInterface = null;
    private readonly string currentLocation = null;
    private readonly string currentHomeLocation = null;
    public StoreFrontHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        string storeName = ((string) hashMap.get(StoreFrontData.getInstance().NAME));
        if (storeName != null) {
            this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
            this.currentLocation = new Replace(CommonSeps.getInstance().SPACE, "%20").all(this.storeFrontInterface.getCurrentHostName() + this.storeFrontInterface.getCurrentHostNamePath());
            this.currentHomeLocation = new Replace(CommonSeps.getInstance().SPACE, "%20").all(this.storeFrontInterface.getCurrentHomeHostName() + this.storeFrontInterface.getCurrentHomeHostNamePath());
        } else {
            StringUtil stringUtil = StringUtil.getInstance();
            this.storeFrontInterface = new StoreFront();
            this.currentLocation = stringUtil.EMPTY_STRING;
            this.currentHomeLocation = stringUtil.EMPTY_STRING;
        }
    }

    public virtual string getCurrentLocation()
    {
        return this.currentLocation;
    }

    public virtual string getCurrentHomeLocation()
    {
        return this.currentHomeLocation;
    }

}

