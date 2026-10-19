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
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.logic.util.visitor;

public class Visitor : VisitorInterface
{
    private static readonly Visitor instance = new Visitor();
    public readonly NullUtil nullUtil = NullUtil.getInstance();
    public virtual object visit(object anyType)
    {
        return this.nullUtil.NULL_OBJECT;
    }

    public static Visitor getInstance()
    {
        return Visitor.instance;
    }

}

