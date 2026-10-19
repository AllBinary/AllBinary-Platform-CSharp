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
//using JsType = jsinterop.annotations.JsType;

namespace org.allbinary.util;

public class HashtableUtil
{
    private static readonly HashtableUtil instance = new HashtableUtil();
    public static HashtableUtil getInstance()
    {
        return HashtableUtil.instance;
    }

    private readonly EnumerationUtil enumerationUtil = EnumerationUtil.getInstance();
    public virtual void putAll(ABHashtable<object, object> fromHashtable, ABHashtable<object, object> hashtable)
    {
        Enumeration enumeration = fromHashtable.keys();
        object keyCanBeNull = null;
        object valueCanBeNull = null;
        while (this.enumerationUtil.hasMoreElements(enumeration)) {
            keyCanBeNull = this.enumerationUtil.nextElement(enumeration);
            valueCanBeNull = hashtable.get(keyCanBeNull);
            if (valueCanBeNull == null) {
            } else {
                hashtable.put(keyCanBeNull, valueCanBeNull);
            }
        }
    }

    public virtual object[] getKeysAsArray(ABHashtable<object, object> hashtable)
    {
        object[] objectArray = new object[hashtable.size()];
        int index = 0;
        Enumeration enumeration = hashtable.keys();
        while (this.enumerationUtil.hasMoreElements(enumeration)) {
            objectArray[index++] = this.enumerationUtil.nextElement(enumeration);
        }
        return objectArray;
    }

    public virtual BasicArrayList getKeysAsList(ABHashtable<object, object> hashtable)
    {
        BasicArrayList list = new BasicArrayListS(hashtable.size());
        Enumeration enumeration = hashtable.keys();
        while (this.enumerationUtil.hasMoreElements(enumeration)) {
            list.add(this.enumerationUtil.nextElement(enumeration));
        }
        return list;
    }

}

