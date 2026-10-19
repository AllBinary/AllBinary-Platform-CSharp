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
//using GL10 = javax.microedition.khronos.opengles.GL10;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.graphics.opengles.shader;

public class ShaderInitializer
{
    private static readonly ShaderInitializer instance = new ShaderInitializer();
    public static ShaderInitializer getInstance()
    {
        return ShaderInitializer.instance;
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public virtual int init(GL10 gl, Shader[] shader, string[] attributeArray)
    {
        return -1;
    }

}

