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
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using GL11 = javax.microedition.khronos.opengles.GL11;
using AndroidUtil = org.allbinary.AndroidUtil;
using OpenGLESGL10ImageFactory = org.allbinary.image.opengles.OpenGLESGL10ImageFactory;
using OpenGLESGL11VBOImageFactory = org.allbinary.image.opengles.OpenGLESGL11VBOImageFactory;
using OpenGLImageSpecificFactory = org.allbinary.image.opengles.OpenGLImageSpecificFactory;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Tokenizer = org.allbinary.logic.@string.tokens.Tokenizer;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using Features = org.allbinary.game.configuration.feature.Features;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.graphics.opengles;

public class OpenGLCapabilities
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly OpenGLCapabilities instance = new OpenGLCapabilities();
    public static OpenGLCapabilities getInstance()
    {
        return OpenGLCapabilities.instance;
    }

    public readonly bool CUSTOM_GL_SURFACE_VIEW = true;
    private readonly StringUtil stringUtil = StringUtil.getInstance();
    private bool initialized = false;
    private string glVersionString;
    private string glShaderVersionString;
    public int shaderVersion = 0;
    private string glRenderer;
    private string glVendor;
    private string glExtensions;
    private bool possiblyAccelerated = false;
    private string acceleratedString;
    public int maxTextureSize = 64;
    public readonly string VERSION_1_0 = "1.0";
    public readonly string VERSION_1_1 = "1.1";
    public readonly string VERSION_2_0 = "2.0";
    public readonly string VERSION_3_0 = "3.0";
    public readonly string VERSION_3_1 = "3.1";
    public readonly string VERSION_3_2 = "3.2";
    public readonly string VERSION_HIGHER_THAN_EXISTS = "999.999";
    public readonly string VERSION_UNK = "Unk";
    public readonly string GL_EXT_GPU_SHADER_100 = "GL_ARB_shading_language_100";
    public readonly string GL_EXT_GPU_SHADER4 = "GL_EXT_gpu_shader4";
    private string glVersion;
    public string glInstanceVersion;
    private bool glExtensionDrawTexture = false;
    private bool glThreedDrawTexture = false;
    private bool glExtensionGPUShader4 = false;
    private bool glExtensionGPUShader100 = false;
    private bool vertexBufferObjectSupport = false;
    private OpenGLCapabilities()
    {
        this.glVersionString = this.stringUtil.EMPTY_STRING;
        this.glShaderVersionString = this.stringUtil.EMPTY_STRING;
        this.glRenderer = this.stringUtil.EMPTY_STRING;
        this.glVendor = this.stringUtil.EMPTY_STRING;
        this.glExtensions = this.stringUtil.EMPTY_STRING;
        this.acceleratedString = this.stringUtil.EMPTY_STRING;
        this.glVersion = this.glVersionString;
        this.glInstanceVersion = this.VERSION_UNK;
    }

    public virtual bool isInitialized()
    {
        return this.initialized;
    }

    private void requireInitialization()
    {
    }

    public virtual void initCapabilities(GL10 gl)
    {
        string METHOD_NAME = "initGLCapabilities";
        try {
            Features features = Features.getInstance();
            OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
            OpenGLImageSpecificFactory openGLImageSpecificFactory = OpenGLImageSpecificFactory.getInstance();
            StringMaker stringBuffer = new StringMaker();
            this.glVersionString = gl.glGetString(GL10.GL_VERSION);
            int GL_SHADING_LANGUAGE_VERSION = 0x8b8c;
            this.glShaderVersionString = gl.glGetString(GL_SHADING_LANGUAGE_VERSION);
            if (this.glShaderVersionString == null) {
                this.glShaderVersionString = this.stringUtil.EMPTY_STRING;
            }
            try {
                if (this.glShaderVersionString != null && this.glShaderVersionString.IndexOf('.') >= 0) {
                    int startIndex = this.glShaderVersionString.LastIndexOf(' ');
                    if (startIndex >= 0) {
                        this.glShaderVersionString = this.glShaderVersionString.Substring(startIndex + 1);
                    }
                    this.shaderVersion = int.Parse(this.glShaderVersionString.Replace(CommonSeps.getInstance().PERIOD, StringUtil.getInstance().EMPTY_STRING));
                }
            } catch (Exception e) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, METHOD_NAME, e);
            }
            this.glRenderer = gl.glGetString(GL10.GL_RENDERER);
            this.glVendor = gl.glGetString(GL10.GL_VENDOR);
            this.glExtensions = gl.glGetString(GL10.GL_EXTENSIONS);
            if (this.glExtensions.IndexOf(this.GL_EXT_GPU_SHADER_100) >= 0) {
                this.glExtensionGPUShader100 = true;
            } else {
                this.glExtensionGPUShader100 = false;
            }
            if (this.glExtensions.IndexOf(this.GL_EXT_GPU_SHADER4) >= 0) {
                this.glExtensionGPUShader4 = true;
            } else {
                this.glExtensionGPUShader4 = false;
            }
            if (this.glRenderer == null) {
                this.glRenderer = this.stringUtil.EMPTY_STRING;
            }
            if (this.glRenderer.ToLower().IndexOf("pixelflinger") >= 0) {
                this.acceleratedString = "Probably Not for " + this.glRenderer;
                this.possiblyAccelerated = false;
            } else {
                this.acceleratedString = "Probably for " + this.glRenderer;
                this.possiblyAccelerated = true;
            }
            this.glExtensionDrawTexture = false;
            if (this.glVersionString == null) {
                this.glVersionString = this.stringUtil.EMPTY_STRING;
                this.glVersion = this.VERSION_UNK;
            } else if (this.glVersionString.IndexOf(" 1.0") >= 0) {
                this.glVersion = this.VERSION_1_0;
            } else if (this.glVersionString.IndexOf(" 1.1") >= 0) {
                this.glVersion = this.VERSION_1_1;
            } else {
                this.glVersion = this.VERSION_UNK;
            }
            if (gl is GL11) {
                this.glInstanceVersion = this.VERSION_1_1;
            } else if (gl is GL10) {
                this.glInstanceVersion = this.VERSION_1_0;
            }
            if (this.glVendor == null) {
                this.glVendor = this.stringUtil.EMPTY_STRING;
            }
            if (this.glExtensions == null) {
                this.glExtensions = this.stringUtil.EMPTY_STRING;
            }
            if (this.possiblyAccelerated) {
                PreLogUtil.put(new StringMaker().append("VBO:?").appendboolean((this.glInstanceVersion == this.VERSION_1_1)).append("||").appendboolean(this.isExtension(openGLFeatureFactory.OPENGL_VERTEX_BUFFER_OBJECT)).ToString(), this, METHOD_NAME);
                if ((this.glInstanceVersion == this.VERSION_1_1 || this.isExtension(openGLFeatureFactory.OPENGL_VERTEX_BUFFER_OBJECT))) {
                    if (AndroidUtil.isAndroid()) {
                        PreLogUtil.put("VBO implementation was detected, but disabled by default for Android", this, METHOD_NAME);
                    } else {
                        PreLogUtil.put("VBO implementation was detected, but disabled for now", this, METHOD_NAME);
                    }
                }
            }
            StringUtil stringUtil = StringUtil.getInstance();
            if (features.isDefault(openGLFeatureFactory.OPENGL_AUTO_SELECT)) {
                if (this.vertexBufferObjectSupport) {
                    openGLImageSpecificFactory.setImageFactory(new OpenGLESGL11VBOImageFactory());
                } else {
                    stringBuffer.append("OpenGL is on but ");
                    stringBuffer.append(stringUtil.toString(openGLFeatureFactory.OPENGL_DRAW_TEXTURE));
                    stringBuffer.append(" was not available");
                    PreLogUtil.put(stringBuffer.ToString(), this, METHOD_NAME);
                    openGLImageSpecificFactory.setImageFactory(new OpenGLESGL10ImageFactory());
                }
            } else {
                stringBuffer.append(stringUtil.toString(openGLFeatureFactory.OPENGL_AUTO_SELECT));
                stringBuffer.append(" is not on");
                PreLogUtil.put(stringBuffer.ToString(), this, METHOD_NAME);
                openGLImageSpecificFactory.setImageFactory(new OpenGLESGL10ImageFactory());
            }
            int[] maxTextureSizeArray = new int[1];
            gl.glGetIntegerv(GL10.GL_MAX_TEXTURE_SIZE, maxTextureSizeArray, 0);
            this.maxTextureSize = maxTextureSizeArray[0];
            this.initialized = true;
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, METHOD_NAME, e);
        }
    }

    private bool isExtension(OpenGLFeature gameFeature)
    {
        int index = this.glExtensions.IndexOf(gameFeature.getName());
        if (index >= 0) {
            return true;
        } else {
            return false;
        }
    }

    public virtual bool isGlExtensionDrawTexture()
    {
        this.requireInitialization();
        return this.glExtensionDrawTexture;
    }

    public virtual bool isGlExtensionGPUShader100()
    {
        return this.glExtensionGPUShader100;
    }

    public virtual bool isGlExtensionGPUShader4()
    {
        this.requireInitialization();
        return this.glExtensionGPUShader4;
    }

    public virtual string getGlVersion()
    {
        this.requireInitialization();
        return this.glVersion;
    }

    public virtual string getGlVersionString()
    {
        this.requireInitialization();
        return this.glVersionString;
    }

    public virtual string getGlShaderVersion()
    {
        this.requireInitialization();
        return this.glShaderVersionString;
    }

    public virtual bool isGlThreedDrawTexture()
    {
        this.requireInitialization();
        return this.glThreedDrawTexture;
    }

    public virtual string getGlRenderer()
    {
        this.requireInitialization();
        return this.glRenderer;
    }

    public virtual bool isVertexBufferObjectSupport()
    {
        this.requireInitialization();
        return this.vertexBufferObjectSupport;
    }

    public virtual bool isTextureSizeValid(int widthAndHeight)
    {
        this.requireInitialization();
        if (this.maxTextureSize >= widthAndHeight) {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("GL_VERSION: ");
        stringBuffer.append(this.glVersionString);
        stringBuffer.append(" GL_SHADING_LANGUAGE_VERSION: ");
        stringBuffer.append(this.glShaderVersionString);
        stringBuffer.append(" GL_RENDERER: ");
        stringBuffer.append(this.glRenderer);
        stringBuffer.append(" GL_VENDOR: ");
        stringBuffer.append(this.glVendor);
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(" Is Accelerated: ");
        stringBuffer.append(this.acceleratedString);
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(" VBO Support: ");
        stringBuffer.appendboolean(this.isVertexBufferObjectSupport());
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(" Max Texture Size: ");
        stringBuffer.appendint(this.maxTextureSize);
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(" GL_EXTENSIONS: ");
        try {
            Tokenizer tokenizer = new Tokenizer(commonSeps.SPACE);
            BasicArrayList list = tokenizer.getTokensFromString(this.glExtensions, new BasicArrayListD());
            int size = list.size();
            for (int index = 0; index < size; index++) {
                stringBuffer.append(commonSeps.NEW_LINE);
                stringBuffer.append(this.stringUtil.toString(list.objectArray[index]));
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.putOE(commonStrings.EXCEPTION, this, commonStrings.TOSTRING, e);
        }
        return stringBuffer.ToString();
    }

}

