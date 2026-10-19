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
using OpenGLProcessor = org.allbinary.graphics.opengles.OpenGLProcessor;
using NullOpenGLProcessorFactory = org.allbinary.graphics.opengles.NullOpenGLProcessorFactory;

namespace org.allbinary.graphics.opengles.shader;

public class ShaderComposite
{
    public readonly OpenGLProcessor disableProgramShaderOpenGLProcessor;
    public readonly string requiresOpenGLVersion;
    public readonly Shader[] shaderArray;
    public readonly ShaderInitializer shaderInitializer;
    public readonly CompositeShaderUpdater compositeShaderUpdater;
    public readonly ModelViewProjection modelViewProjection;
    public readonly OpenGLProcessor colorOpenGLProcessor;
    public readonly OpenGLProcessor vertexOpenGLProcessor;
    public OpenGLProcessor useProgramShaderOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    public OpenGLProcessor shaderMatrixOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    public OpenGLProcessor colorEnableVertexAttribArrayOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    public OpenGLProcessor normalEnableVertexAttribArrayOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    public OpenGLProcessor vertexEnableVertexAttribArrayOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    public OpenGLProcessor textureEnableVertexAttribArrayOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    public OpenGLProcessor colorDisableVertexAttribArrayOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    public OpenGLProcessor normalDisableVertexAttribArrayOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    public OpenGLProcessor vertexDisableVertexAttribArrayOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    public OpenGLProcessor textureDisableVertexAttribArrayOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    public OpenGLObject3dProcessor uniformLightPositionOpenGLProcessor = NullOpenGLTextureProcessor.getInstance();
    public OpenGLObject3dProcessor uniformLightColorOpenGLProcessor = NullOpenGLTextureProcessor.getInstance();
    public OpenGLObject3dProcessor uniformCameraPositionOpenGLProcessor = NullOpenGLTextureProcessor.getInstance();
    public OpenGLObject3dProcessor uniformTextureUnitOpenGLProcessor = NullOpenGLTextureProcessor.getInstance();
    public int programHandle = 0;
    public ShaderComposite(string requiresOpenGLVersion, Shader[] shaderArray, CompositeShaderUpdater compositeShaderUpdater, ShaderInitializer shaderInitializer, ModelViewProjection modelViewProjection, OpenGLProcessor colorOpenGLProcessor, OpenGLProcessor vertexOpenGLProcessor, OpenGLProcessor disableProgramShaderOpenGLProcessor)
    {
        this.requiresOpenGLVersion = requiresOpenGLVersion;
        this.shaderArray = shaderArray;
        this.shaderInitializer = shaderInitializer;
        this.compositeShaderUpdater = compositeShaderUpdater;
        this.modelViewProjection = modelViewProjection;
        this.colorOpenGLProcessor = colorOpenGLProcessor;
        this.vertexOpenGLProcessor = vertexOpenGLProcessor;
        this.disableProgramShaderOpenGLProcessor = disableProgramShaderOpenGLProcessor;
    }

    public virtual void init(GL10 gl)
    {
        this.programHandle = this.shaderInitializer.init(gl, this.shaderArray, this.compositeShaderUpdater.attributeArray);
    }

}

