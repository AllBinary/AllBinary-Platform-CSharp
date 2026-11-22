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
//using Method = java.lang.reflect.Method;
using Proxy = java.lang.reflect.Proxy;
using InvocationHandler = java.lang.reflect.InvocationHandler;

namespace org.allbinary.logic.java.proxy;

public class InterfaceCastProxy : InvocationHandler
{
    private object anyType;
    private InterfaceCastProxy(object anyType)
    {
        this.anyType = anyType;
    }

    public static object newInstance(object anyType)
    {
        return Proxy.newProxyInstance(global::java.lang.ClassLoader.getSystemClassLoader(), anyType.GetType().getInterfaces(), new InterfaceCastProxy(anyType));
    }

    // throws Throwable
    public virtual object invoke(object proxyObject, global::System.Reflection.MethodInfo proxyMethod, object[] proxyArgs)
    {
        string methodName = proxyMethod.getName();
        global::System.Reflection.MethodInfo realMethod = this.anyType.GetType().getMethod(methodName, proxyMethod.getParameterTypes());
        if (!realMethod.isAccessible()) {
            realMethod.setAccessible(true);
        }
        return proxyMethod.invoke(this.anyType, proxyArgs);
    }

}

