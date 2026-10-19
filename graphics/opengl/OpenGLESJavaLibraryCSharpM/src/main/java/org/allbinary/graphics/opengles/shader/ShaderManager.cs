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
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.graphics.opengles.shader;

public class ShaderManager
{
    private static readonly ShaderManager instance = new ShaderManager(-1, -1);
    public static ShaderManager getInstance()
    {
        return ShaderManager.instance;
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly string LOAD_SHADER = "loadShader";
    public readonly string __VERSION__ = "__VERSION__";
    public readonly int GL_VERTEX_SHADER;
    public readonly int GL_FRAGMENT_SHADER;
    public ShaderManager(int GL_VERTEX_SHADER, int GL_FRAGMENT_SHADER)
    {
        this.GL_VERTEX_SHADER = GL_VERTEX_SHADER;
        this.GL_FRAGMENT_SHADER = GL_FRAGMENT_SHADER;
    }

    public virtual int load(GL10 gl, string resource, string[] shaderAsStringArray, int shaderType)
    {
        return -1;
    }

    public virtual int loadShader(GL10 gl, string resource, BasicArrayList stringList, int shaderType)
    {
        return -1;
    }

}

