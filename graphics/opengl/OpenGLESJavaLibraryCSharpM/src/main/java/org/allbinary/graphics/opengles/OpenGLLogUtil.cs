// Generated Code Do Not Modify

using System;
using System.Linq;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Image = javax.microedition.lcdui.Image;
using OpenGLStrings = org.allbinary.image.opengles.OpenGLStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;

namespace org.allbinary.graphics.opengles;

public class OpenGLLogUtil
{
    private static readonly OpenGLLogUtil instance = new OpenGLLogUtil();
    public static OpenGLLogUtil getInstance()
    {
        return OpenGLLogUtil.instance;
    }

    private readonly string MAX_TEXTURE = " Max Texture Size: ";
    public virtual void logError(GL10 gl)
    {
        int error = gl.glGetError();
        if (error != GL10.GL_NO_ERROR) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(OpenGLStrings.getInstance().GL_ERROR_LABEL);
            stringBuffer.appendint(error);
            if (error == 1281) {
                stringBuffer.append(this.MAX_TEXTURE);
                int[] maxTextureSize = new int[1];
                gl.glGetIntegerv(GL10.GL_MAX_TEXTURE_SIZE, maxTextureSize, 0);
                stringBuffer.appendint(maxTextureSize[0]);
            }
            if (error == 1280) {
                PreLogUtil.put(stringBuffer.ToString(), this, OpenGLStrings.getInstance().SET);
            } else {
                ForcedLogUtil.log(stringBuffer.ToString(), this);
            }
        }
    }

    private readonly string LOG_ERROR = "logError";
    private readonly string IMAGE = " Image: ";
    public virtual void logError(GL10 gl, Image image)
    {
        int error = gl.glGetError();
        if (error != GL10.GL_NO_ERROR) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(OpenGLStrings.getInstance().GL_ERROR_LABEL);
            stringBuffer.appendint(error);
            if (error == 1281) {
                stringBuffer.append(this.MAX_TEXTURE);
                int[] maxTextureSize = new int[1];
                gl.glGetIntegerv(GL10.GL_MAX_TEXTURE_SIZE, maxTextureSize, 0);
                stringBuffer.appendint(maxTextureSize[0]);
            }
            stringBuffer.append(this.IMAGE);
            stringBuffer.append(image.ToString());
            PreLogUtil.put(stringBuffer.ToString(), this, this.LOG_ERROR);
        }
    }

}

