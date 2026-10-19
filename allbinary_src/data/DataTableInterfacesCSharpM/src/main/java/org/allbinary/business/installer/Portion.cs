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

namespace org.allbinary.business.installer;

public class Portion
{
    private readonly int? current;
    private readonly int? total;
    public Portion(HashMap hashMap)
    {
        this.current = ((int?) hashMap.get("current"));
        this.total = ((int?) hashMap.get("total"));
    }

    public virtual int? getCurrent()
    {
        return this.current;
    }

    public virtual int? getTotal()
    {
        return this.total;
    }

}

