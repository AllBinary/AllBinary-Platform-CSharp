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
//using Constructor = java.lang.reflect.Constructor;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.java.anyType;

public class ConstructorUtil
{
    private ConstructorUtil()
    {
    }

    public static string viewAll(Type myClass, string lineBreak)
    {
        StringMaker stringBuffer = new StringMaker();
        Constructor[] constructor = myClass.getConstructors();
        stringBuffer.append("Constructors: ");
        stringBuffer.append(lineBreak);
        for (int index = 0; index < constructor.Length; index++) {
            stringBuffer.append(ConstructorUtil.view(constructor[index], lineBreak));
        }
        return stringBuffer.ToString();
    }

    public static string view(Constructor constructor, string lineBreak)
    {
        if (constructor != null) {
            CommonSeps commonSeps = CommonSeps.getInstance();
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(constructor.getName());
            Type[] classes = constructor.getParameterTypes();
            for (int index = 0; index < classes.Length; index++) {
                stringBuffer.append(commonSeps.SPACE);
                stringBuffer.append(classes[index].getName());
                stringBuffer.append(commonSeps.COLON);
                stringBuffer.appendint(index);
            }
            stringBuffer.append(lineBreak);
            return stringBuffer.ToString();
        } else {
            return "Constructor Null";
        }
    }

}

