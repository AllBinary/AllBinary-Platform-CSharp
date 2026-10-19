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

namespace org.allbinary.logic.io.path;

public class AbFilePath : AbPath
{
    public AbFilePath(string aPath) : base(StringUtil.getInstance().EMPTY_STRING, StringUtil.getInstance().EMPTY_STRING)
    {
        // base(StringUtil.getInstance().EMPTY_STRING, StringUtil.getInstance().EMPTY_STRING) is called from the constructor declaration
        AbPathData pathData = AbPathData.getInstance();
        PathUtil abPathUtil = PathUtil.getInstance();
        this.schema = this.getSchema(aPath);
        this.setName(pathData.getNameFromPath(aPath));
        this.setPath(abPathUtil.adjust(this.getPathFromPath(abPathUtil.removeNameFromPath(aPath).ToString())));
    }

}

