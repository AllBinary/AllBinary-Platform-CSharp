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

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoHttpStoreFactory : TransformInfoFactoryInterface
{
    private static readonly TransformInfoHttpStoreFactory instance = new TransformInfoHttpStoreFactory();
    public static TransformInfoHttpStoreFactory getInstance()
    {
        return TransformInfoHttpStoreFactory.instance;
    }

    private TransformInfoHttpStoreFactory()
    {
    }

    // throws Exception
    public virtual TransformInfoInterface getInstance(HashMap databaseHashMap, HashMap propertiesHashMap, PageContext pageContext)
    {
        return new TransformInfoHttpStore(databaseHashMap, propertiesHashMap, pageContext);
    }

}

