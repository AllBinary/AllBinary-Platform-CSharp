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
using org.allbinary.util;

namespace org.allbinary.resources;

public class KeyValueFactory
{
    private static readonly KeyValueFactory instance = new KeyValueFactory();
    public static KeyValueFactory getInstance()
    {
        return KeyValueFactory.instance;
    }

    public readonly ABHashtable<object, object> MAP = StdUtil.getInstance().createHashtable();
    public virtual string get(string key)
    {
        string value = ((string) this.MAP.get(((object) key)));
        if (value == null) {
            return key;
        }
        return value;
    }

}

