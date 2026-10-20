/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace admin.taghelpers;

public class TagHelperFactory : TagHelperFactoryInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    // throws Exception, LicensingException
    public virtual object getInstance(HashMap<object, object> hashMap, PageContext pageContext)
    {
        throw new SystemException();
    }

}

