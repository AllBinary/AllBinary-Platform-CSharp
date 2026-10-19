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
using NullUtil = org.allbinary.logic.NullUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;

namespace org.allbinary.game.identification;

public class GroupCommonFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GroupCommonFactory getInstance()
    {
        if (GroupCommonFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            GroupCommonFactory.instance = new GroupCommonFactory();
        }
        return ((GroupCommonFactory) GroupCommonFactory.instance);
    }

    public readonly int? ID = SmallIntegerSingletonFactory.getInstance().getAt(10);
    public readonly string GROUP_NAME_LABEL = "Group Name: ";
    public readonly string ID_LABEL = " Id: ";
    public readonly string ADDING_LABEL = "Adding: ";
    public readonly string TO_LABEL = " to: ";
}

