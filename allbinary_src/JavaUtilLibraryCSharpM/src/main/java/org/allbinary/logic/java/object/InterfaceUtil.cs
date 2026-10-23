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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.java.anyType;

public class InterfaceUtil
{
    private InterfaceUtil()
    {
    }

    public static string viewAll(Type myClass, string lineBreak)
    {
        StringMaker stringBuffer = new StringMaker();
        Type[] interfaces = myClass.getInterfaces();
        stringBuffer.append(lineBreak);
        stringBuffer.append("Interfaces: ");
        stringBuffer.append(lineBreak);
        for (int index = 0; index < interfaces.Length; index++) {
            stringBuffer.append("Interface: ");
            stringBuffer.append(interfaces[index].getName());
            stringBuffer.append(lineBreak);
        }
        return stringBuffer.ToString();
    }

    public static Type getClass(string interfaceName, Type[] interfaces)
    {
        if (interfaceName != null && interfaces != null && interfaces.Length > 0) {
            for (int index = 0; index < interfaces.Length; index++) {
                if (interfaces[index].getName().IndexOf(interfaceName) >= 0) {
                    return interfaces[index];
                }
            }
        }
        return null;
    }

    public static bool isImplemented(Type clazz, object anyType)
    {
        Type[] classes = anyType.GetType().getInterfaces();
        for (int index = 0; index < classes.Length; index++) {
            if (string.CompareOrdinal(clazz.FullName, classes[index].getName()) == 0) {
                return true;
            }
        }
        return false;
    }

    public static bool isImplemented(string className, object anyType)
    {
        Type[] classes = anyType.GetType().getInterfaces();
        for (int index = 0; index < classes.Length; index++) {
            if (classes[index].getName().IndexOf(className) == 0) {
                return true;
            }
        }
        return false;
    }

    public static string isImplementedView(Type clazz, object anyType)
    {
        StringMaker stringBuffer = new StringMaker();
        Type[] classes = anyType.GetType().getInterfaces();
        stringBuffer.append("isImplementedView: \n");
        for (int index = 0; index < classes.Length; index++) {
            stringBuffer.append(clazz.FullName);
            stringBuffer.append(" should be = ");
            stringBuffer.append(classes[index].getName());
            stringBuffer.append(classes[index].getName());
            stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        }
        return stringBuffer.ToString();
    }

}

