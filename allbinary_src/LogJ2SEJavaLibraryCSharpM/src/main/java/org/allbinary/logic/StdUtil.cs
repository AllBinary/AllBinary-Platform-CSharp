/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using org.allbinary.util;

namespace org.allbinary.logic;

//ActualPlatform
public class StdUtil
{
    private static readonly StdUtil instance = new StdUtil();
    public static StdUtil getInstance()
    {
        return StdUtil.instance;
    }

    public readonly ABVector<object> EMPTY_VECTOR;
    public readonly ABHashtable<object, object> NULL_TABLE;
    public readonly ABHashMap<object, object> NULL_MAP;
    public ABStack<object> createStack()
    {
        return new ABStack<object>();
    }

    public ABVector<object> createVector()
    {
        return new ABVector<object>();
    }

    public ABHashtable<object, object> createHashtable()
    {
        return new ABHashtable<object, object>();
    }

    public ABHashMap<object, object> createHashMap()
    {
        return new ABHashMap<object, object>();
    }

    public StdUtil()
    {
        this.EMPTY_VECTOR = this.createVector();
        this.NULL_TABLE = this.createHashtable();
        this.NULL_MAP = this.createHashMap();
    }

}

