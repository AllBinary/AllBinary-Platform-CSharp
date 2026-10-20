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
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.logic.visual.dhtml.html;

public class HtmlTag
{
    public HashMap<object, object> otherAttributes;
    public HtmlTag()
    {
        this.otherAttributes = StdUtil.getInstance().createHashMap();
    }

    public virtual void addAttribute(string key, string value)
    {
        this.otherAttributes.put(key, value);
    }

}

