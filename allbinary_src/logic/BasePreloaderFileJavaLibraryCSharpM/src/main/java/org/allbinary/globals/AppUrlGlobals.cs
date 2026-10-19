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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.globals;

//implements
public class AppUrlGlobals : UrlGlobalsInterface
{
    public static readonly AppUrlGlobals NULL_APP_URL_GLOBALS = new AppUrlGlobals();
    private string path = StringUtil.getInstance().EMPTY_STRING;
    public override bool isTestingMode()
    {
        return false;
    }

    public override string getWebappPath()
    {
        return this.path;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setWebappPath(string path)
    {
        this.path = path;
        if (!(this.path.EndsWith("\\") || this.path.EndsWith("/"))) {
            this.path = this.path + "\\";
        }
    }

    public override string getTestHtmlPath()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    // throws Exception
    public override string getMainPath()
    {
        return this.path;
    }

}

