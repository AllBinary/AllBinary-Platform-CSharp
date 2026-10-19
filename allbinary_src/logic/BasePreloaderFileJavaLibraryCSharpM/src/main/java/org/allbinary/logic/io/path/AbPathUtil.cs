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

namespace org.allbinary.logic.io.path;

public class AbPathUtil
{
    private static readonly AbPathUtil instance = new AbPathUtil();
    public static AbPathUtil getInstance()
    {
        return AbPathUtil.instance;
    }

    public readonly AbPath NO_ABPATH = AbPath.createAbPath();
}

