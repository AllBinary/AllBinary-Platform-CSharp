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
using StdUtil = org.allbinary.logic.StdUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;
using org.allbinary.util;

namespace org.allbinary.logic.control.validate;

public class ValidatorBase : ValidatorBaseInterface
{
    private static readonly ValidatorBase instance = new ValidatorBase();
    public static ValidatorBase getInstance()
    {
        return ValidatorBase.instance;
    }

    public ValidatorBase()
    {
    }

    public virtual bool? isValid()
    {
        return BooleanFactory.getInstance().TRUE;
    }

    public virtual string validationInfo()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual ABHashtable<object, object> toHashtable()
    {
        return StdUtil.getInstance().NULL_TABLE;
    }

    public virtual BasicArrayList toList()
    {
        return BasicArrayListUtil.getInstance().getImmutableInstance();
    }

}

