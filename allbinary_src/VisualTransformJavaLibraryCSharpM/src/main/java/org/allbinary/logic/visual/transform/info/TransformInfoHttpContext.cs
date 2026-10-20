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
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoHttpContext : TransformInfoHttp
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public TransformInfoHttpContext(HashMap<object, object> databaseHashMap, HashMap<object, object> propertiesHashMap, PageContext pageContext) : base(databaseHashMap, propertiesHashMap, pageContext)
    {
        // base(databaseHashMap, propertiesHashMap, pageContext) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Database HashMap: ");
            stringBuffer.append(databaseHashMap.ToString());
            stringBuffer.append("\nProperties HashMap: ");
            stringBuffer.append(propertiesHashMap.ToString());
            this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.CONSTRUCTOR);
        }
        this.setStoreName(StringUtil.getInstance().EMPTY_STRING);
    }

    public TransformInfoHttpContext(HashMap<object, object> propertiesHashMap, PageContext pageContext) : base(propertiesHashMap, pageContext)
    {
        // base(propertiesHashMap, pageContext) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Properties HashMap: " + propertiesHashMap.ToString(), this, this.commonStrings.CONSTRUCTOR);
        }
        this.setStoreName(StringUtil.getInstance().EMPTY_STRING);
    }

    // throws Exception
    private string getPath()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getMainPath());
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH);
        stringBuffer.append(FREEBLISKET_PATH_GLOBALS.getInstance().INSTALLPATH);
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

