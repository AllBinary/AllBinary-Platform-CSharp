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
using CapturedImageInputOutput = org.allbinary.input.media.image.capture.CapturedImageInputOutput;
using ComparisonImageInputOutput = org.allbinary.media.image.comparison.ComparisonImageInputOutput;
using MotionRectanglesImageInputOutput = org.allbinary.media.image.comparison.motion.MotionRectanglesImageInputOutput;
using ImageIOInterface = org.allbinary.media.image.io.ImageIOInterface;

namespace org.allbinary.input.media.image;

public class InputImageIOInterfaceFactory
{
    private InputImageIOInterfaceFactory()
    {
    }

    // throws Exception
    public static ImageIOInterface getInstance(InputImageType imageType)
    {
        if (imageType == InputImageType.CAPTURE) {
            return new CapturedImageInputOutput();
        } else if (imageType == InputImageType.COMPARISON) {
            return new ComparisonImageInputOutput();
        } else if (imageType == InputImageType.MOTION) {
            return new MotionRectanglesImageInputOutput();
        } else {
            throw new Exception("No ImageIOInterface for: " + imageType.ToString());
        }
    }

}

