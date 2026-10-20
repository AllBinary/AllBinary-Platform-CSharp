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
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;

namespace org.allbinary.data.tables;

public class TableDataFactory
{
    private static readonly TableDataFactory instance = new TableDataFactory();
    public static TableDataFactory getInstance()
    {
        return TableDataFactory.instance;
    }

    public readonly string INTEGER_MAX_VALUE_STRING = (int.MaxValue).ToString();
    public readonly string ZERO_STRING = CommonPhoneStrings.getInstance().ZERO;
}

