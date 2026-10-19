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
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.input.motion.button;

public class BaseTouchInput
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    public BaseTouchInput()
    {
    }

    public virtual BasicArrayList getList()
    {
        return this.basicArrayListUtil.getImmutableInstance();
    }

    public override string ToString()
    {
        return this.GetType().FullName;
    }

}

