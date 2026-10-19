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
using System.Runtime.CompilerServices;
using InitInfo = org.allbinary.business.init.InitInfo;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace org.allbinary.globals;

public class WebAppUrlGlobals : UrlGlobalsInterface
{
    private string path = null;
    private bool isWebappPathSet = false;
    public virtual bool isTestingMode()
    {
        return InitInfo.getInstance().isTesting();
    }

    public virtual string getWebappPath()
    {
        return this.path;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setWebappPath(string path)
    {
        path = path;
        this.isWebappPathSet = true;
    }

    public virtual string getTestHtmlPath()
    {
        return InitInfo.getInstance().getTestHtmlPath();
    }

    // throws Exception
    public virtual string getMainPath()
    {
        string mainPath = InitInfo.getInstance().getMainPath();
        if (!StringValidationUtil.getInstance().isEmpty(mainPath)) {
            return mainPath;
        } else if (this.isWebappPathSet) {
            return this.getWebappPath();
        } else {
            throw new Exception("Webapp Path is not set");
        }
    }

}

