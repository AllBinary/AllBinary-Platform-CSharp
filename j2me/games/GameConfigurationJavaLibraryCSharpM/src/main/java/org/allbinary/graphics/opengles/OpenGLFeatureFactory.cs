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

namespace org.allbinary.graphics.opengles;

public class OpenGLFeatureFactory
{
    private static readonly OpenGLFeatureFactory instance = new OpenGLFeatureFactory();
    public static OpenGLFeatureFactory getInstance()
    {
        return OpenGLFeatureFactory.instance;
    }

    private OpenGLFeatureFactory()
    {
    }

    public readonly OpenGLFeature OPENGL_OPTIONS = new OpenGLFeature("OpenGL Options");
    public readonly OpenGLFeature OPENGL = new OpenGLFeature("OpenGL");
    public readonly OpenGLFeature OPENGL_SURFACE_VIEW = new OpenGLFeature("GLSurfaceView");
    public readonly OpenGLFeature OPENGL_2D = new OpenGLFeature("OpenGL 2D");
    public readonly OpenGLFeature OPENGL_3D = new OpenGLFeature("OpenGL 3D");
    public readonly OpenGLFeature OPENGL_2D_AND_3D = new OpenGLFeature("OpenGL 2D/3D");
    public readonly OpenGLFeature OPENGL_AUTO_SELECT = new OpenGLFeature("Auto Select");
    public readonly OpenGLFeature OPENGL_MINIMUM = new OpenGLFeature("Minimum");
    public readonly OpenGLFeature OPENGL_AS_GAME_THREAD = new OpenGLFeature("As game thread");
    public readonly OpenGLFeature OPENGL_AND_GAME_HAVE_DIFFERENT_THREADS = new OpenGLFeature("As different threads");
    public readonly OpenGLFeature IMAGE_COLOR_DEPTH_4444 = new OpenGLFeature("4444");
    public readonly OpenGLFeature IMAGE_COLOR_DEPTH_8888 = new OpenGLFeature("8888");
    public readonly OpenGLFeature IMAGE_COLOR_DEPTH_565 = new OpenGLFeature("565");
    public readonly OpenGLFeature OPENGL_COLOR_DEPTH_4444 = new OpenGLFeature("4444");
    public readonly OpenGLFeature OPENGL_COLOR_DEPTH_8888 = new OpenGLFeature("8888");
    public readonly OpenGLFeature OPENGL_COLOR_DEPTH_565 = new OpenGLFeature("565");
    public readonly OpenGLFeature OPENGL_DRAW_TEXTURE = new OpenGLFeature("GL_OES_draw_texture");
    public readonly OpenGLFeature OPENGL_VERTEX_BUFFER_OBJECT = new OpenGLFeature("vertex_buffer_object");
    public readonly OpenGLFeature OPENGL_SIMPLE_OBJECT3D_PROCESSOR = new OpenGLFeature("Simple Object3d Processor");
    public readonly OpenGLFeature OPENGL_COMPLEX_OBJECT3D_PROCESSOR = new OpenGLFeature("Complex Object3d Processor");
    public readonly OpenGLFeature OPENGL_SIMPLE_TEXTURE_PROCESSOR = new OpenGLFeature("Simple Texture Processor");
    public readonly OpenGLFeature OPENGL_COMPLEX_TEXTURE_PROCESSOR = new OpenGLFeature("Complex Texture Processor");
}

