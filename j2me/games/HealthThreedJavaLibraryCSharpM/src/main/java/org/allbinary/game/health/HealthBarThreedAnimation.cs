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
//using Graphics = javax.microedition.lcdui.Graphics;
using ColorBufferList = min3d.core.ColorBufferList;
using Number3dBufferList = min3d.core.Number3dBufferList;
using Rectangle = min3d.objectPrimitives.Rectangle;
using Number3d = min3d.vos.Number3d;
using OpenGLESGraphics = org.allbinary.device.OpenGLESGraphics;
using Object3dProcessor = org.allbinary.graphics.threed.min3d.renderer.Object3dProcessor;
using Object3dProcessorUtil = org.allbinary.graphics.threed.min3d.renderer.Object3dProcessorUtil;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.health;

public class HealthBarThreedAnimation : HealthBarAnimation
{
    private Rectangle rectangle;
    private readonly BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
    public HealthBarThreedAnimation(AllBinaryLayer layerInterface, int location) : base(layerInterface, location)
    {
        // base(layerInterface, location) is called from the constructor declaration
        this.basicColor = this.basicColorFactory.GREEN;
        this.colorP = ((int) this.basicColor);
        this.rectangle = new Rectangle(0, 0, 1, 1, this.basicColor);
        this.rectangle.setDoubleSidedEnabled(true);
        this.rectangle.setNormalsEnabled(false);
        this.rectangle.setTexturesEnabled(false);
    }

    private void updateColor()
    {
        ColorBufferList colorBufferList = this.rectangle.getVertices().getColor4BufferList();
        int size = colorBufferList.size();
        for (int index = size; --index >= 0; ) {
            colorBufferList.set(index, this.basicColor);
        }
    }

    private void updateSize()
    {
        Number3dBufferList number3dBufferList = this.rectangle.getVertices().getPointsOnFacesNumber3dBufferList();
        int width = this.x2;
        int height = this.thickness * 2;
        int segsH = 1;
        int segsW = 1;
        int row = 0;
        int col = 0;
        float w = ((float) (width / segsW));
        float h = ((float) (height / segsH));
        float width5 = ((float) width) / 2f;
        float height5 = ((float) height) / 2f;
        int index = 0;
        for (row = 0; row <= segsH; row++) {
            for (col = 0; col <= segsW; col++) {
                number3dBufferList.set(index++, ((float) col) * w - width5, ((float) row) * h - height5, 0f);
            }
        }
    }

    public virtual void onHealthChange(int newX2)
    {
        base.onHealthChange(newX2);
        this.updateColor();
        this.updateSize();
    }

    private readonly Object3dProcessor object3dProcessor = Object3dProcessorUtil.getInstance().getInstanceObject3dProcessor();
    public virtual void paintThreedXYZ(Graphics graphics, int x, int y, int z)
    {
        OpenGLESGraphics openGLESGraphics = ((OpenGLESGraphics) graphics);
        GL10 gl = openGLESGraphics.getGl10();
        ViewPositionBase viewPosition = this.allbinaryLayer.getViewPosition();
        Number3d positionNumber3d = this.rectangle.getPosition();
        positionNumber3d.x = -(((float) viewPosition.getX()));
        positionNumber3d.z = -(((float) viewPosition.getY()));
        positionNumber3d.y = viewPosition.getZ() + this.allbinaryLayer.getHeight();
        this.object3dProcessor.drawObject(gl, this.rectangle);
    }

}

