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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using RootStoreCategoryProperties = org.allbinary.business.category.properties.root.store.RootStoreCategoryProperties;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using TransformInfoHttpStoreInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpStoreInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.properties.root.store.theme;

public class RootStoreThemeCategoryProperties : RootStoreCategoryProperties
{
    public RootStoreThemeCategoryProperties(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public RootStoreThemeCategoryProperties(TransformInfoInterface transformInfoInterface, AbPath abPath) : base(transformInfoInterface, abPath)
    {
        // base(transformInfoInterface, abPath) is called from the constructor declaration
    }

    public RootStoreThemeCategoryProperties(TransformInfoInterface transformInfoInterface, Node node) : base(transformInfoInterface, node)
    {
        // base(transformInfoInterface, node) is called from the constructor declaration
    }

    public RootStoreThemeCategoryProperties(TransformInfoInterface transformInfoInterface, HashMap categoryPropertiesHashMap) : base(transformInfoInterface, categoryPropertiesHashMap)
    {
        // base(transformInfoInterface, categoryPropertiesHashMap) is called from the constructor declaration
    }

    // throws Exception
    public virtual void initPath()
    {
        TransformInfoHttpStoreInterface transformInfoHttpStoreInterface = ((TransformInfoHttpStoreInterface) this.transformInfoInterface);
        StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(transformInfoHttpStoreInterface.getStoreName());
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
        stringBuffer.append(storeFrontInterface.getName());
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().THEMEPATH);
        AbPath abPath = new AbPath(stringBuffer.ToString(), StringUtil.getInstance().EMPTY_STRING);
        HttpServletRequest httpServletRequest = ((HttpServletRequest) transformInfoHttpStoreInterface.getPageContext().getRequest());
        this.webAppAbPath = new AbPath(httpServletRequest.getContextPath() + abPath.ToString(), StringUtil.getInstance().EMPTY_STRING);
        this.setRootFilePath(new AbPath(URLGLOBALS.getMainPath() + abPath.ToString(), StringUtil.getInstance().EMPTY_STRING));
    }

}

