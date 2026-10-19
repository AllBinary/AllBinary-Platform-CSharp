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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.logic.visual.dhtml.html;

public class HtmlTags
{
    private BasicArrayList htmlTagVector;
    public HtmlTags()
    {
        this.htmlTagVector = new BasicArrayListD();
    }

    public virtual HtmlTag get(int index)
    {
        return ((HtmlTag) this.htmlTagVector.get(index));
    }

    public virtual void add(HtmlTag htmlTag)
    {
        this.htmlTagVector.add(htmlTag);
    }

    public virtual int size()
    {
        return this.htmlTagVector.size();
    }

}

