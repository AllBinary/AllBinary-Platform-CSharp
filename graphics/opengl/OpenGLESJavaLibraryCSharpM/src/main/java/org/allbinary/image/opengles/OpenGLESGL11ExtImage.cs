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
//using GL = javax.microedition.khronos.opengles.GL;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using GL11 = javax.microedition.khronos.opengles.GL11;
//using GL11Ext = javax.microedition.khronos.opengles.GL11Ext;
//using Image = javax.microedition.lcdui.Image;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using DisplayChangeEvent = org.allbinary.graphics.displayable.@event.DisplayChangeEvent;
using OpenGLLogUtil = org.allbinary.graphics.opengles.OpenGLLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PlatformBitmapBaseFactory = org.allbinary.platform.graphics.PlatformBitmapBaseFactory;
using PlatformTextureBaseFactory = org.allbinary.platform.opengles.PlatformTextureBaseFactory;

namespace org.allbinary.image.opengles;

//Many devices don't support this even though it is supposed to
public class OpenGLESGL11ExtImage : OpenGLESImage
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private int a = 0;
    private readonly int[] rectangle;
    public OpenGLESGL11ExtImage(Image image, PlatformBitmapBaseFactory bitmapFactory, PlatformTextureBaseFactory textureFactory) : base(image, bitmapFactory, textureFactory)
    {
        // base(image, bitmapFactory, textureFactory) is called from the constructor declaration
        this.onDisplayChangeEvent(DisplayInfoSingleton.getInstance().displayChangeEvent);
        this.rectangle = new int[] { 0, this.getHeight(), this.getWidth(), -this.getHeight() };
    }

    public virtual void onDisplayChangeEvent(DisplayChangeEvent displayChangeEvent)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "onResize");
            this.a = DisplayInfoSingleton.getInstance().getLastHeight() - this.getHeight();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onResize", e);
        }
    }

    public override void set(GL gl)
    {
        this.onDisplayChangeEvent(DisplayInfoSingleton.getInstance().displayChangeEvent);
        GL11 gl11 = ((GL11) gl);
        if (base.initTexture(gl11)) {
            this.textureFactory.load(gl11, GL10.GL_TEXTURE_2D, 0, this, 0, true);
            gl11.glTexParameteriv(GL10.GL_TEXTURE_2D, GL11Ext.GL_TEXTURE_CROP_RECT_OES, this.rectangle, 0);
            gl11.glDisable(GL10.GL_TEXTURE_2D);
            OpenGLLogUtil.getInstance().logError(gl11, this);
        }
    }

    public override void draw(GL10 gl, int x, int y, int z)
    {
        gl.glEnable(GL10.GL_TEXTURE_2D);
        gl.glBindTexture(GL10.GL_TEXTURE_2D, this.openGLESImageProperties.textureID);
        GL11Ext gl11Ext = ((GL11Ext) gl);
        gl11Ext.glDrawTexfOES(((float) x), ((float) (this.a - y)), ((float) z), ((float) this.getWidth()), ((float) this.getHeight()));
        gl.glDisable(GL10.GL_TEXTURE_2D);
    }

}

