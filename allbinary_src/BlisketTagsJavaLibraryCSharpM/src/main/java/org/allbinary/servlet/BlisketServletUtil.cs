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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using AppUrlGlobals = org.allbinary.globals.AppUrlGlobals;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using WebappClassLoaderInfo = org.allbinary.logic.system.loader.WebappClassLoaderInfo;

namespace org.allbinary.servlet;

public class BlisketServletUtil
{
    private static readonly BlisketServletUtil instance = new BlisketServletUtil();
    public static BlisketServletUtil getInstance()
    {
        return BlisketServletUtil.instance;
    }

    public virtual void init(HttpServletRequest request)
    {
        AppUrlGlobals urlGlobals = new AppUrlGlobals();
        urlGlobals.setWebappPath(request.getServletContext().getRealPath(AbPathData.getInstance().SEPARATOR));
        URLGLOBALS.init(urlGlobals);
        WebappClassLoaderInfo.setLoader(GetType().getClassLoader());
    }

}

