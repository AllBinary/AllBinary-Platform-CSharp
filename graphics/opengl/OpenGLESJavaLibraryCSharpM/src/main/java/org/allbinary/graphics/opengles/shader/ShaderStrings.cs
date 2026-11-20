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

namespace org.allbinary.graphics.opengles.shader;

public class ShaderStrings
{
    private static readonly ShaderStrings instance = new ShaderStrings();
    public static ShaderStrings getInstance()
    {
        return ShaderStrings.instance;
    }

    public readonly string NO_PROGRAM_HANDLE = "No program handle";
    public readonly string UNIFORM_BLOCK_HANDLE = "Uniform Block Handle: ";
    public readonly string UNIFORM_HANDLE = "Uniform Handle: ";
    public readonly string UNIFORM_ATTRIBUTE_HANDLE = "Uniform Attribute Handle: ";
}

