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
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoHttpStore : TransformInfoHttp, TransformInfoHttpStoreInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public TransformInfoHttpStore(HashMap<object, object> propertiesHashMap, PageContext pageContext) : base(propertiesHashMap, pageContext, true)
    {
        // base(propertiesHashMap, pageContext, true) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Properties HashMap: " + propertiesHashMap.ToString(), this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public TransformInfoHttpStore(HashMap<object, object> databaseHashMap, HashMap<object, object> propertiesHashMap, PageContext pageContext) : base(databaseHashMap, propertiesHashMap, pageContext)
    {
        // base(databaseHashMap, propertiesHashMap, pageContext) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Database HashMap: ");
            stringBuffer.append(databaseHashMap.ToString());
            stringBuffer.append("\nProperties HashMap: ");
            stringBuffer.append(propertiesHashMap.ToString());
            this.logUtil.putF(stringBuffer.ToString(), this, "Constructor(HashMap, HashMap , PageContext)");
        }
        this.setStoreName(((string) databaseHashMap.get(StoreFrontData.getInstance().NAME)));
    }

    public TransformInfoHttpStore(StoreFrontInterface storeFrontInterface, HashMap<object, object> propertiesHashMap, PageContext pageContext) : base(propertiesHashMap, pageContext)
    {
        // base(propertiesHashMap, pageContext) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Properties HashMap: " + propertiesHashMap.ToString(), this, this.commonStrings.CONSTRUCTOR);
        }
        this.setStoreName(storeFrontInterface.getName());
    }

    // throws Exception
    private string getPath()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getMainPath());
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
        stringBuffer.append(this.getStoreName());
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        return stringBuffer.ToString();
    }

    // throws Exception
    public virtual AbPath getTemplateFilePath()
    {
        return new AbPath(this.getPath(), this.getTemplateFile());
    }

    // throws Exception
    public virtual AbPath getObjectConfigFilePath()
    {
        return new AbPath(this.getPath(), this.getObjectConfigFile());
    }

    // throws Exception
    public virtual AbPath getDataFilePath()
    {
        return new AbPath(this.getPath(), this.getDataFile());
    }

}

