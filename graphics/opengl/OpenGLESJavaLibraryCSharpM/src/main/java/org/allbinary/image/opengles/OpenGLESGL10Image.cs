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
//using ByteBuffer = java.nio.ByteBuffer;
//using ByteOrder = java.nio.ByteOrder;
//using FloatBuffer = java.nio.FloatBuffer;
//using GL = javax.microedition.khronos.opengles.GL;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Image = javax.microedition.lcdui.Image;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using OpenGLLogUtil = org.allbinary.graphics.opengles.OpenGLLogUtil;
using GLUtil = org.allbinary.opengles.GLUtil;
using PlatformBitmapBaseFactory = org.allbinary.platform.graphics.PlatformBitmapBaseFactory;
using PlatformTextureBaseFactory = org.allbinary.platform.opengles.PlatformTextureBaseFactory;

namespace org.allbinary.image.opengles;

public class OpenGLESGL10Image : OpenGLESImage
{
    private readonly FloatBuffer textureVertexFloatBuffer = ByteBuffer.allocateDirect(4 * 4 * 2).order(ByteOrder.nativeOrder()).asFloatBuffer();
    private readonly OpenGLESImageDraw realOpenGLESImageDraw = new OpenGLESImageDraw()
#if JAVA_ANONYMOUS_CLASS_BODY
        private readonly GLUtil glUtil = GLUtil.getInstance();
        private readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
        private readonly FloatBuffer textureVertexFloatBuffer = this.textureVertexFloatBuffer;
        private readonly float[] regionTextureRectangleFloatArray = new float[8];
        private readonly FloatBuffer regionTextureVertexFloatBuffer = ByteBuffer.allocateDirect(4 * 4 * 2).order(ByteOrder.nativeOrder()).asFloatBuffer();
        private readonly float[] regionRectangleFloatArray = new float[] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        public readonly FloatBuffer regionRectangleVertexFloatBuffer = ByteBuffer.allocateDirect(4 * 4 * 3).order(ByteOrder.nativeOrder()).asFloatBuffer();
        public readonly OpenGLESImageProperties openGLESImageProperties = this.openGLESImageProperties;
        public virtual void drawRegion(GL10 gl, int viewHeight, float x_src, float y_src, float width, float height, int x, int y, int z)
        {
            int imageWidth = this.getWidth();
            int imageHeight = this.getHeight();
            this.regionRectangleFloatArray[7] = ((float) viewHeight);
            this.regionRectangleFloatArray[1] = this.regionRectangleFloatArray[7] - height;
            this.regionRectangleFloatArray[3] = width;
            this.regionRectangleFloatArray[4] = this.regionRectangleFloatArray[1];
            this.regionRectangleFloatArray[9] = this.regionRectangleFloatArray[3];
            this.regionRectangleFloatArray[10] = this.regionRectangleFloatArray[7];
            this.regionTextureRectangleFloatArray[0] = x_src / imageWidth;
            this.regionTextureRectangleFloatArray[1] = (y_src + height) / imageHeight;
            this.regionTextureRectangleFloatArray[2] = (x_src + width) / imageWidth;
            this.regionTextureRectangleFloatArray[3] = this.regionTextureRectangleFloatArray[1];
            this.regionTextureRectangleFloatArray[4] = this.regionTextureRectangleFloatArray[0];
            this.regionTextureRectangleFloatArray[5] = y_src / imageHeight;
            this.regionTextureRectangleFloatArray[6] = this.regionTextureRectangleFloatArray[2];
            this.regionTextureRectangleFloatArray[7] = this.regionTextureRectangleFloatArray[5];
            float u_center = (this.regionTextureRectangleFloatArray[0] + this.regionTextureRectangleFloatArray[2]) / 2.0f;
            float v_center = (this.regionTextureRectangleFloatArray[5] + this.regionTextureRectangleFloatArray[1]) / 2.0f;
            this.glUtil.rotateUVs(this.regionTextureRectangleFloatArray, ((float) (-this.openGLESImageProperties.angle)), u_center, v_center);
            gl.glPushMatrix();
            OpenGLESImageProcessor imageProcessor = this.imageProcessor;
            this.openGLESImageTranslate.translate(gl, this, ((float) x), ((float) (-y)));
            imageProcessor.scale(gl, this.openGLESImageProperties.scaleX, this.openGLESImageProperties.scaleY);
            imageProcessor.colorMask(gl, this.openGLESImageProperties.redf, this.openGLESImageProperties.greenf, this.openGLESImageProperties.bluef, this.openGLESImageProperties.alphaf);
            this.openGLESImageTranslate.translate2(gl, this);
            this.regionRectangleVertexFloatBuffer.put(this.regionRectangleFloatArray);
            this.glUtil.position(this.regionRectangleVertexFloatBuffer, 0);
            gl.glVertexPointer(3, GL10.GL_FLOAT, 0, this.regionRectangleVertexFloatBuffer);
            gl.glEnableClientState(GL10.GL_VERTEX_ARRAY);
            gl.glEnable(GL10.GL_TEXTURE_2D);
            gl.glBindTexture(GL10.GL_TEXTURE_2D, this.openGLESImageProperties.textureID);
            gl.glEnableClientState(GL10.GL_TEXTURE_COORD_ARRAY);
            this.regionTextureVertexFloatBuffer.put(this.regionTextureRectangleFloatArray);
            this.glUtil.position(this.regionTextureVertexFloatBuffer, 0);
            gl.glTexCoordPointer(2, GL10.GL_FLOAT, 0, this.regionTextureVertexFloatBuffer);
            gl.glDrawArrays(GL10.GL_TRIANGLE_STRIP, 0, 4);
            gl.glDisableClientState(GL10.GL_VERTEX_ARRAY);
            gl.glDisableClientState(GL10.GL_TEXTURE_COORD_ARRAY);
            gl.glDisable(GL10.GL_TEXTURE_2D);
            gl.glPopMatrix();
        }

        public virtual void draw(GL10 gl, int x, int y, int z)
        {
            int width = this.getWidth();
            int height = this.getHeight();
            this.regionRectangleFloatArray[7] = ((float) this.displayInfoSingleton.getLastHeight());
            this.regionRectangleFloatArray[1] = this.regionRectangleFloatArray[7] - height;
            this.regionRectangleFloatArray[3] = ((float) width);
            this.regionRectangleFloatArray[4] = this.regionRectangleFloatArray[1];
            this.regionRectangleFloatArray[9] = this.regionRectangleFloatArray[3];
            this.regionRectangleFloatArray[10] = this.regionRectangleFloatArray[7];
            this.regionTextureRectangleFloatArray[0] = 0f;
            this.regionTextureRectangleFloatArray[1] = 1f;
            this.regionTextureRectangleFloatArray[2] = 1f;
            this.regionTextureRectangleFloatArray[3] = 1f;
            this.regionTextureRectangleFloatArray[4] = 0f;
            this.regionTextureRectangleFloatArray[5] = 0f;
            this.regionTextureRectangleFloatArray[6] = 1f;
            this.regionTextureRectangleFloatArray[7] = 0f;
            gl.glPushMatrix();
            this.openGLESImageTranslate.translate(gl, this, ((float) x), ((float) (-y)));
            OpenGLESImageProcessor imageProcessor = this.imageProcessor;
            imageProcessor.scale(gl, this.openGLESImageProperties.scaleX, this.openGLESImageProperties.scaleY);
            imageProcessor.colorMask(gl, this.openGLESImageProperties.redf, this.openGLESImageProperties.greenf, this.openGLESImageProperties.bluef, this.openGLESImageProperties.alphaf);
            this.openGLESImageTranslate.translate2(gl, this);
            this.regionRectangleVertexFloatBuffer.put(this.regionRectangleFloatArray);
            this.glUtil.position(this.regionRectangleVertexFloatBuffer, 0);
            gl.glVertexPointer(3, GL10.GL_FLOAT, 0, this.regionRectangleVertexFloatBuffer);
            gl.glEnableClientState(GL10.GL_VERTEX_ARRAY);
            gl.glEnable(GL10.GL_TEXTURE_2D);
            gl.glBindTexture(GL10.GL_TEXTURE_2D, this.openGLESImageProperties.textureID);
            gl.glEnableClientState(GL10.GL_TEXTURE_COORD_ARRAY);
            this.glUtil.rotateUVs(this.regionTextureRectangleFloatArray, ((float) (-this.openGLESImageProperties.angle)), 0.5f, 0.5f);
            this.glUtil.position(this.textureVertexFloatBuffer, 0);
            this.textureVertexFloatBuffer.put(this.regionTextureRectangleFloatArray);
            this.glUtil.position(this.textureVertexFloatBuffer, 0);
            gl.glTexCoordPointer(2, GL10.GL_FLOAT, 0, this.textureVertexFloatBuffer);
            gl.glDrawArrays(GL10.GL_TRIANGLE_STRIP, 0, 4);
            gl.glDisableClientState(GL10.GL_VERTEX_ARRAY);
            gl.glDisableClientState(GL10.GL_TEXTURE_COORD_ARRAY);
            gl.glDisable(GL10.GL_TEXTURE_2D);
            gl.glPopMatrix();
        }

#endif
;
    private OpenGLESImageDraw openGLESImageDraw = OpenGLESImageDraw.getInstance();
    public OpenGLESGL10Image(Image image, PlatformBitmapBaseFactory bitmapFactory, PlatformTextureBaseFactory textureFactory) : base(image, bitmapFactory, textureFactory)
    {
        // base(image, bitmapFactory, textureFactory) is called from the constructor declaration
        this.initVertices();
    }

    protected virtual void initVertices()
    {
        this.textureVertexFloatBuffer.put(0f);
        this.textureVertexFloatBuffer.put(1f);
        this.textureVertexFloatBuffer.put(1f);
        this.textureVertexFloatBuffer.put(1f);
        this.textureVertexFloatBuffer.put(0f);
        this.textureVertexFloatBuffer.put(0f);
        this.textureVertexFloatBuffer.put(1f);
        this.textureVertexFloatBuffer.put(0f);
        this.textureVertexFloatBuffer.rewind();
    }

    public override void set(GL gl)
    {
        GL10 gl10 = ((GL10) gl);
        if (base.initTexture(gl10)) {
            this.textureFactory.load(gl10, GL10.GL_TEXTURE_2D, 0, this, 0, true);
            gl10.glDisable(GL10.GL_TEXTURE_2D);
            this.openGLESImageDraw = this.realOpenGLESImageDraw;
            OpenGLLogUtil.getInstance().logError(gl10, this);
        }
    }

    public override void drawRegion(GL10 gl, int viewHeight, float x_src, float y_src, float width, float height, int x, int y, int z)
    {
        this.openGLESImageDraw.drawRegion(gl, viewHeight, x_src, y_src, width, height, x, y, z);
    }

    public override void draw(GL10 gl, int x, int y, int z)
    {
        this.openGLESImageDraw.draw(gl, x, y, z);
    }

}

