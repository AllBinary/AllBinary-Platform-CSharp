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
//using java.awt;
//using BufferedImage = java.awt.image.BufferedImage;
using MotionRectangleConstraints = org.allbinary.input.automation.module.MotionRectangleConstraints;

namespace org.allbinary.input.automation.module.generic.constraints;

public class NoMotionRectangleConstraints : MotionRectangleConstraints
{
    public NoMotionRectangleConstraints()
    {
        this.setMinDimension(new Dimension(0, 0));
        this.setMinArea(0);
        this.setMaxDimension(new Dimension(int.MaxValue, int.MaxValue));
        this.setMaxMotionRectangles(int.MaxValue);
    }

    public virtual bool isValid(long? frame, BufferedImage bufferedImage, Rectangle rectangle)
    {
        return true;
    }

}

