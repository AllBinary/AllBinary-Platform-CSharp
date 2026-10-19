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
using ConstructorUtil = org.allbinary.logic.java.anyType.ConstructorUtil;
using InterfaceUtil = org.allbinary.logic.java.anyType.InterfaceUtil;
using MethodUtil = org.allbinary.logic.java.anyType.MethodUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.logic.java.anyType.clazz;

public class ClassUtil
{
    private ClassUtil()
    {
    }

    public static string viewAll(object anyType, string lineBreak)
    {
        if (anyType != null) {
            return ClassUtil.viewAll(anyType.GetType(), lineBreak);
        } else {
            return "Object Null";
        }
    }

    public static string viewAll(Type myClass, string lineBreak)
    {
        if (myClass != null) {
            StringMaker stringBuffer = new StringMaker();
            Type[] classes = myClass.getClasses();
            stringBuffer.append(lineBreak);
            stringBuffer.append("Class: ");
            stringBuffer.append(myClass.getName());
            stringBuffer.append(" uses ");
            stringBuffer.appendint(classes.Length);
            stringBuffer.append(" other classes");
            stringBuffer.append(lineBreak);
            stringBuffer.append(lineBreak);
            stringBuffer.append("Classes: ");
            stringBuffer.append(lineBreak);
            for (int index = 0; index < classes.Length; index++) {
                stringBuffer.append("Class: ");
                stringBuffer.append(classes[index].getName());
                stringBuffer.append(lineBreak);
            }
            stringBuffer.append(InterfaceUtil.viewAll(myClass, lineBreak));
            stringBuffer.append(lineBreak);
            stringBuffer.append(ConstructorUtil.viewAll(myClass, lineBreak));
            stringBuffer.append(lineBreak);
            stringBuffer.append(MethodUtil.viewAll(myClass, lineBreak));
            return stringBuffer.ToString();
        } else {
            return "Class Null";
        }
    }

}

