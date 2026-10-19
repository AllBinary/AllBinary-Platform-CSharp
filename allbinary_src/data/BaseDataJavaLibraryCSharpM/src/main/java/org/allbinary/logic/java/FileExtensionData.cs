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

namespace org.allbinary.logic.java;

public class FileExtensionData
{
    private static readonly FileExtensionData instance = new FileExtensionData();
    public static FileExtensionData getInstance()
    {
        return FileExtensionData.instance;
    }

    private FileExtensionData()
    {
    }

    public readonly string DOT_JAVA_SOURCE = ".java";
    public readonly string JAVA_SOURCE = "java";
}

