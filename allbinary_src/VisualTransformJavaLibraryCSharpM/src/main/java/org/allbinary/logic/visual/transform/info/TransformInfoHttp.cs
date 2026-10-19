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
//using PageContext = javax.servlet.jsp.PageContext;
using AbContext = org.allbinary.business.context.AbContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using WeblisketSessionInterface = org.allbinary.logic.communication.http.request.session.WeblisketSessionInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlData = org.allbinary.logic.communication.sql.AbSqlData;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoObjectConfig = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfig;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoHttp : TransformInfo, TransformInfoHttpInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbContext abContext;
    public TransformInfoHttp(HashMap propertiesHashMap, PageContext pageContext, bool crud) : base()
    {
        // base() is called from the constructor declaration
        this.abContext = new AbContext(propertiesHashMap, pageContext);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Properties HashMap: " + propertiesHashMap.ToString(), this, "Constructor(HashMap, PageContext, boolean)");
        }
        this.@override(propertiesHashMap);
    }

    public TransformInfoHttp(HttpServletRequest request, HashMap propertiesHashMap, PageContext pageContext) : base()
    {
        // base() is called from the constructor declaration
        this.abContext = new AbContext(propertiesHashMap, pageContext);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Properties HashMap: " + propertiesHashMap.ToString(), this, "Constructor(HttpServletRequest, HashMap, PageContext)");
        }
        this.set(new RequestParams(((HttpServletRequest) request)).toHashMap());
        this.@override(propertiesHashMap);
    }

    public TransformInfoHttp(HashMap databaseHashMap, HashMap propertiesHashMap, PageContext pageContext) : base()
    {
        // base() is called from the constructor declaration
        this.abContext = new AbContext(propertiesHashMap, pageContext);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Properties HashMap: " + propertiesHashMap.ToString(), this, "Constructor(HashMap, HashMap, PageContext)");
        }
        this.set(databaseHashMap);
    }

    public TransformInfoHttp(HashMap propertiesHashMap, PageContext pageContext) : base()
    {
        // base() is called from the constructor declaration
        this.abContext = new AbContext(propertiesHashMap, pageContext);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Properties HashMap: " + propertiesHashMap.ToString(), this, "Constructor(HashMap, PageContext)");
        }
        this.set(propertiesHashMap);
    }

    public TransformInfoHttp(TransformInfoHttp parentViewOfThisTransformInfoInterface) : base()
    {
        // base() is called from the constructor declaration
        this.abContext = new AbContext(parentViewOfThisTransformInfoInterface.getPropertiesHashMap(), parentViewOfThisTransformInfoInterface.getPageContext());
    }

    // throws Exception
    private void set(HashMap hashMap)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Properties HashMap: " + hashMap.ToString(), this, "set()");
        }
        TransformInfoData transformInfoData = TransformInfoData.getInstance();
        this.setName(((string) hashMap.get(transformInfoData.NAME)));
        this.setStoreName(((string) hashMap.get(StoreFrontData.getInstance().NAME)));
        this.setObjectFile(((string) hashMap.get(transformInfoData.OBJECTFILENAME)));
        this.setObject(((string) hashMap.get(transformInfoData.OBJECT)));
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        string objectConfigString = ((string) hashMap.get(transformInfoData.OBJECTCONFIG));
        if (stringValidationUtil.isValidRequired(objectConfigString, 10, AbSqlData.MAXBLOB)) {
            this.setObjectConfig(objectConfigString);
        } else {
            this.setObjectConfig(new TransformInfoObjectConfig(this).ToString());
        }
        if (!stringValidationUtil.isEmpty(((string) hashMap.get(transformInfoData.OBJECTCONFIGFILENAME)))) {
            this.setObjectConfigFile(((string) hashMap.get(transformInfoData.OBJECTCONFIGFILENAME)));
        }
        this.setTemplateFile(((string) hashMap.get(transformInfoData.TEMPLATEFILENAME)));
        this.setTemplate(((string) hashMap.get(transformInfoData.TEMPLATE)));
        this.setDataFile(((string) hashMap.get(transformInfoData.DATAFILENAME)));
        this.setData(((string) hashMap.get(transformInfoData.DATA)));
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORY)) {
            this.logUtil.putF(this.log(), this, "set()");
        }
    }

    public virtual WeblisketSessionInterface getWeblisketSession()
    {
        return this.abContext.getWeblisketSession();
    }

    public virtual PageContext getPageContext()
    {
        return this.abContext.getPageContext();
    }

    public virtual HashMap getPropertiesHashMap()
    {
        return this.abContext.getPropertiesHashMap();
    }

    // throws Exception
    public virtual AbPath getTemplateFilePath()
    {
        return new AbPath(URLGLOBALS.getMainPath() + FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH, this.getTemplateFile());
    }

    // throws Exception
    public virtual AbPath getObjectConfigFilePath()
    {
        return new AbPath(URLGLOBALS.getMainPath() + FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH, this.getObjectConfigFile());
    }

    // throws Exception
    public virtual AbPath getDataFilePath()
    {
        return new AbPath(URLGLOBALS.getMainPath() + FREEBLISKET_PATH_GLOBALS.getInstance().XSLPATH, this.getDataFile());
    }

}

