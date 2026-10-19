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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using WebappClassLoaderInfo = org.allbinary.logic.system.loader.WebappClassLoaderInfo;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.globals;

public class Globals
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly Globals instance = new Globals();
    public static Globals getInstance()
    {
        return Globals.instance;
    }

    private Globals()
    {
    }

    public virtual void init(ClassLoader classLoader, string pathString)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        AppUrlGlobals appUrlGlobals = new AppUrlGlobals();
        appUrlGlobals.setWebappPath(pathString);
        URLGLOBALS.init(appUrlGlobals);
        WebappClassLoaderInfo.setLoader(classLoader);
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Setting Up AllBinary System Configuration Args: ");
        stringBuffer.append(pathString);
        stringBuffer.append(" ClassLoader: ");
        stringBuffer.append(classLoader.GetType().FullName);
        this.logUtil.putF(stringBuffer.ToString(), this, commonStrings.INIT);
        StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
        if (stringValidationUtil.isEmpty(pathString)) {
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append("No Path Provided. Using Process Path: ");
            stringBuffer.append(pathString);
            stringBuffer.append(CommonSeps.getInstance().SPACE);
            stringBuffer.append(CommonSeps.getInstance().EQUALS);
            stringBuffer.append(CommonSeps.getInstance().SPACE);
            stringBuffer.append(URLGLOBALS.getWebappPath());
            this.logUtil.putF(stringBuffer.ToString(), this, commonStrings.INIT);
        }
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append("Webapp Path Set To: ");
        stringBuffer.append(URLGLOBALS.getWebappPath());
        this.logUtil.putF(stringBuffer.ToString(), this, commonStrings.INIT);
    }

}

