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
//using java.util;
using java.util;
//using Set = java.util.Set;
using ServiceReference = org.osgi.framework.ServiceReference;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace bundle.input.automation;

public class ServiceReferenceMap : Map
{
    private ServiceReference serviceReference;
    public ServiceReferenceMap(ServiceReference serviceReference)
    {
        this.serviceReference = serviceReference;
    }

    public virtual int size()
    {
        return -1;
    }

    public virtual bool isEmpty()
    {
        return false;
    }

    public virtual bool containsKey(object key)
    {
        return false;
    }

    public virtual bool containsValue(object value)
    {
        return false;
    }

    public virtual object get(object key)
    {
        return this.serviceReference.getProperty(((string) key));
    }

    public virtual object put(object key, object value)
    {
        return null;
    }

    public virtual object remove(object key)
    {
        return null;
    }

    public virtual void putAll(Map m)
    {
    }

    public virtual void clear()
    {
    }

    public virtual Set keySet()
    {
        string[] keyStringArray = this.serviceReference.getPropertyKeys();
        return null;
    }

    public virtual Collection<object> values()
    {
        return null;
    }

    public virtual Set entrySet()
    {
        return null;
    }

    public static string toString(Map map)
    {
        StringMaker stringBuffer = new StringMaker();
        return stringBuffer.ToString();
    }

}

