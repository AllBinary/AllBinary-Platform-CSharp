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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.globals;

public class UrlGlobalsInterface
{
    // throws Exception
    public virtual string getMainPath()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual string getTestHtmlPath()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual string getWebappPath()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual bool isTestingMode()
    {
        return false;
    }

}

