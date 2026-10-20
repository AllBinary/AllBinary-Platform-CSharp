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
using GPoint = org.allbinary.graphics.GPoint;
using ImageComparatorConstraints = org.allbinary.input.automation.module.ImageComparatorConstraints;

namespace org.allbinary.input.automation.module.generic.constraints;

public class NoImageComparatorConstraints : ImageComparatorConstraints
{
    public NoImageComparatorConstraints() : base(1)
    {
        // base(1) is called from the constructor declaration
        this.setMaxNonMatchingPixelDeltas(int.MaxValue);
    }

    public virtual bool isColorAllowed(int frame, GPoint point, Color color)
    {
        return true;
    }

    public virtual bool isImageValid(BufferedImage bufferedImage)
    {
        return true;
    }

}

