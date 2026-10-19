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
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using TagHelperFactoryInterface = admin.taghelpers.TagHelperFactoryInterface;
using HelperFactory = admin.taghelpers.HelperFactory;

namespace taghelpers.transform.info;

public class TransformInfoHelperFactory : TagHelperFactoryInterface
{
    private static readonly string CLASSNAME = "taghelpers.transform.info.TransformInfoHelper";
    private static readonly string FACTORYNAME = "TransformInfoHelperFactory";
    public TransformInfoHelperFactory()
    {
    }

    // throws LicensingException
    public virtual object getInstance(HashMap hashMap, PageContext pageContext)
    {
        return HelperFactory.getInstance(FACTORYNAME, CLASSNAME, hashMap, pageContext);
    }

}

