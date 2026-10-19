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

namespace org.allbinary.logic.visual.dhtml.html.head.meta;

public class HtmlMetaAttributeData
{
    private int id;
    private string name;
    public HtmlMetaAttributeData(int id, string value)
    {
        this.name = value;
        this.id = id;
    }

    public override bool Equals(HtmlMetaAttributeData htmlMetaAttributeData)
    {
        if (htmlMetaAttributeData.id == this.id) {
            return true;
        } else {
            return false;
        }
    }

    public override string ToString()
    {
        return this.name;
    }

}

