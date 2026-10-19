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

public class AppRendererShaderUpdaterFactory : ShaderUpdater
{
    private static readonly AppRendererShaderUpdaterFactory instanceC = new AppRendererShaderUpdaterFactory();
    public static AppRendererShaderUpdaterFactory getInstance()
    {
        return AppRendererShaderUpdaterFactory.instanceC;
    }

    private readonly ShaderComposite[] NULL_SHADER_COMPOSITE_ARRAY = new ShaderComposite[0];
    public readonly ShaderComposite[] shaderCompositeArray;
    private readonly ShaderOpenGLProcessor[] shaderOpenGLProcessorArray = new ShaderOpenGLProcessor[0];
    public virtual ShaderOpenGLProcessor[] getTestShaders()
    {
        return this.shaderOpenGLProcessorArray;
    }

    public virtual void setShaderComposite(object object3d)
    {
    }

    public AppRendererShaderUpdaterFactory()
    {
        this.shaderCompositeArray = this.NULL_SHADER_COMPOSITE_ARRAY;
    }

}

