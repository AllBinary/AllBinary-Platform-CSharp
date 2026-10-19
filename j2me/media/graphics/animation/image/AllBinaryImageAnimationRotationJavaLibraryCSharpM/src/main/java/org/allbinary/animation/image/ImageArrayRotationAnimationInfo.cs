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
//using Image = javax.microedition.lcdui.Image;
using AngleInfo = org.allbinary.math.AngleInfo;

namespace org.allbinary.animation.image;

public class ImageArrayRotationAnimationInfo
{
    private Image[] imageArray;
    private int angleIncrement;
    private int totalAngle;
    private int dx;
    private int dy;
    public ImageArrayRotationAnimationInfo(Image[] imageArray, int angleIncrement, int totalAngle, int dx, int dy)
    {
        this.imageArray = imageArray;
        this.angleIncrement = angleIncrement;
        this.totalAngle = totalAngle;
        this.dx = dx;
        this.dy = dy;
    }

    public virtual void setImageArray(Image[] imageArray)
    {
        this.imageArray = imageArray;
    }

    public virtual Image[] getImageArray()
    {
        return this.imageArray;
    }

    public virtual AngleInfo getAngleInfoP()
    {
        return AngleInfo.getInstance(((short) this.angleIncrement));
    }

    public virtual void setTotalAngle(int totalAngle)
    {
        this.totalAngle = totalAngle;
    }

    public virtual int getTotalAngle()
    {
        return this.totalAngle;
    }

    public virtual void setDx(int dx)
    {
        this.dx = dx;
    }

    public virtual int getDx()
    {
        return this.dx;
    }

    public virtual void setDy(int dy)
    {
        this.dy = dy;
    }

    public virtual int getDy()
    {
        return this.dy;
    }

}

