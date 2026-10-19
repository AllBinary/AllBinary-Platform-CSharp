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
//using Comparator = java.util.Comparator;

namespace org.allbinary.business.category.store.theme;

public class ThemeComparator : Comparator
{
    public ThemeComparator()
    {
    }

    public virtual int compare(object anyType, object object2)
    {
        string @string = ((string) anyType);
        string string2 = ((string) object2);
        return string.CompareOrdinal(@string, string2);
    }

}

