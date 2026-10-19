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

namespace org.allbinary.media.image.comparison;

public interface ImageComparatorConstraintsInterface
{
    int getMaxNonMatchingPixelDeltas();

    bool isCollisionWithAvoidRectangles(Rectangle rectangle);

    bool isCollisionWithAvoidRectangles(GPoint point);

    bool isColorAllowed(int frame, GPoint point, Color color);

    // throws Exception
    bool isImageValid(BufferedImage bufferedImage);

    bool isFrameAllowed(int frame);

}

