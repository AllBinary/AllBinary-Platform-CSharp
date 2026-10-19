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

namespace org.allbinary.logic.util.cache;

public class ImageCacheable
{
    private string name = StringUtil.getInstance().EMPTY_STRING;
    public ImageCacheable(string name, object anyType)
    {
    }

    public virtual object getKey()
    {
        return this.name;
    }

    public override string ToString()
    {
        return this.name;
    }

}

