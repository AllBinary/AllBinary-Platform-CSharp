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
using AppUrlGlobals = org.allbinary.globals.AppUrlGlobals;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace admin.taghelpers;

public class CustomLoaderHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public CustomLoaderHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
    }

    public CustomLoaderHelper()
    {
    }

    // throws Exception
    public virtual string getWebappPath()
    {
        try {
            return org.allbinary.globals.URLGLOBALS.getWebappPath();
        } catch (Exception e) {
            return null;
        }
    }

    // throws Exception
    public virtual void setWebappPath(string path)
    {
        try {
            AppUrlGlobals urlGlobals = new AppUrlGlobals();
            urlGlobals.setWebappPath(path);
            URLGLOBALS.init(urlGlobals);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setWebappPath()", e);
            }
        }
    }

}

