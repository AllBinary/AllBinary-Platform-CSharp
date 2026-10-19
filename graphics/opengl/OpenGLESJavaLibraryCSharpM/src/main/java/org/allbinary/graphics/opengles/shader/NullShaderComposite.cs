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
using NullOpenGLProcessorFactory = org.allbinary.graphics.opengles.NullOpenGLProcessorFactory;
using OpenGLCapabilities = org.allbinary.graphics.opengles.OpenGLCapabilities;
using OpenGLProcessor = org.allbinary.graphics.opengles.OpenGLProcessor;

namespace org.allbinary.graphics.opengles.shader;

public class NullShaderComposite : ShaderComposite
{
    private static readonly NullShaderComposite instance = new NullShaderComposite(OpenGLCapabilities.getInstance().VERSION_2_0, new Shader[] { new Shader(), new Shader() }, CompositeShaderUpdater.getInstance(), ShaderInitializer.getInstance(), ModelViewProjection.getInstance(), NullOpenGLProcessorFactory.getInstance(), NullOpenGLProcessorFactory.getInstance(), NullOpenGLProcessorFactory.getInstance())
#if JAVA_ANONYMOUS_CLASS_BODY
        public virtual void init(GL10 gl)
        {
        }

#endif
;
    public static ShaderComposite getInstance()
    {
        return NullShaderComposite.instance;
    }

    public NullShaderComposite(string requiresOpenGLVersion, Shader[] shaderArray, CompositeShaderUpdater compositeShaderUpdater, ShaderInitializer shaderInitializer, ModelViewProjection modelViewProjection, OpenGLProcessor colorOpenGLProcessor, OpenGLProcessor vertexOpenGLProcessor, OpenGLProcessor disableProgramShaderOpenGLProcessor) : base(requiresOpenGLVersion, shaderArray, compositeShaderUpdater, shaderInitializer, modelViewProjection, colorOpenGLProcessor, vertexOpenGLProcessor, disableProgramShaderOpenGLProcessor)
    {
        // base(requiresOpenGLVersion, shaderArray, compositeShaderUpdater, shaderInitializer, modelViewProjection, colorOpenGLProcessor, vertexOpenGLProcessor, disableProgramShaderOpenGLProcessor) is called from the constructor declaration
        this.useProgramShaderOpenGLProcessor = NullOpenGLProcessorFactory.getInstance();
    }

}

