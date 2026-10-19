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
//using Tag = javax.servlet.jsp.tagext.Tag;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace admin.tags;

public class ParentInventoryTagHelper
{
    private static readonly ParentInventoryTagHelper instance = new ParentInventoryTagHelper();
    public static ParentInventoryTagHelper getInstance()
    {
        return ParentInventoryTagHelper.instance;
    }

    // throws Exception
    public virtual void isValid(object tagClass, Tag parentTag)
    {
        if (parentTag == null) {
            throw new Exception("Must have parent tag.");
        } else if (!(parentTag is tags.HelperTag)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Must have at least a ");
            stringBuffer.append("tags.HelperTag");
            stringBuffer.append(" as parent");
            stringBuffer.append("and not: ");
            stringBuffer.append(parentTag.GetType().FullName);
            throw new Exception(stringBuffer.ToString());
        }
    }

}

