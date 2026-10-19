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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.graphics.opengles;

public class OpenGLCapabilities
{
    private static readonly OpenGLCapabilities instance = new OpenGLCapabilities();
    public static OpenGLCapabilities getInstance()
    {
        return OpenGLCapabilities.instance;
    }

    public readonly bool CUSTOM_GL_SURFACE_VIEW = true;
    public readonly string VERSION_1_0 = "1.0";
    public readonly string VERSION_1_1 = "1.1";
    public readonly string VERSION_2_0 = "2.0";
    public readonly string VERSION_3_0 = "3.0";
    public readonly string VERSION_3_1 = "3.1";
    public readonly string VERSION_3_2 = "3.2";
    public readonly string VERSION_HIGHER_THAN_EXISTS = "999.999";
    private string glVersion = StringUtil.getInstance().EMPTY_STRING;
    public int shaderVersion = 0;
    public string glInstanceVersion = StringUtil.getInstance().EMPTY_STRING;
    public int maxTextureSize = 64;
    private OpenGLCapabilities()
    {
    }

    public virtual bool isInitialized()
    {
        return true;
    }

    public virtual void initCapabilities(object gl)
    {
    }

    public virtual bool isGlExtensionDrawTexture()
    {
        return false;
    }

    public virtual string getGlVersion()
    {
        return this.glVersion;
    }

    public virtual bool isVertexBufferObjectSupport()
    {
        return false;
    }

    public virtual bool isTextureSizeValid(int widthAndHeight)
    {
        return true;
    }

}

