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
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BasicColorSetUtil = org.allbinary.graphics.color.BasicColorSetUtil;
using OpenGLSurfaceChangedInterface = org.allbinary.image.opengles.OpenGLSurfaceChangedInterface;

namespace org.allbinary.animation;

public class Animation : AnimationInterface, OpenGLSurfaceChangedInterface
{
    public readonly BasicColorSetUtil basicSetColorUtil = BasicColorSetUtil.getInstance();
    public BasicColor basicColor = BasicColorFactory.getInstance().WHITE;
    public int colorP = 0;
    public BasicColor changeBasicColorP = BasicColorFactory.getInstance().NULL_COLOR;
    public int changeColorP = 0;
    public int alphaP = 0;
    public Animation()
    {
    }

    public virtual void setAlpha(int alpha)
    {
        this.alphaP = alpha;
    }

    // throws Exception
    public virtual void nextFrame()
    {
    }

    public virtual void paintXY(Graphics graphics, int x, int y)
    {
        this.basicSetColorUtil.setBasicColorP3(graphics, this.getBasicColorP(), this.getColor());
    }

    public virtual void paintThreedXYZ(Graphics graphics, int x, int y, int z)
    {
    }

    public virtual bool isThreed()
    {
        return false;
    }

    public virtual BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

    public virtual void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
        this.colorP = this.basicColor.intValue();
    }

    public virtual void setBackgroundBasicColorP(BasicColor basicColor)
    {
    }

    public virtual BasicColor getChangeBasicColor()
    {
        return this.changeBasicColorP;
    }

    public virtual void changeBasicColor(BasicColor basicColor)
    {
        this.changeBasicColorP = basicColor;
        this.changeColorP = this.changeBasicColorP.intValue();
    }

    public virtual int getChangeColor()
    {
        return this.changeColorP;
    }

    public virtual int getColor()
    {
        return this.colorP;
    }

    public virtual void setScale(float scaleX, float scaleY)
    {
    }

    public virtual void setMaxScale(float maxScaleX, float maxScaleY)
    {
    }

    // throws Exception
    public virtual void set(GL gl)
    {
    }

    public virtual void setDx(int dx)
    {
    }

    public virtual int getDx()
    {
        return 0;
    }

    public virtual void setDy(int dy)
    {
    }

    public virtual int getDy()
    {
        return 0;
    }

}

