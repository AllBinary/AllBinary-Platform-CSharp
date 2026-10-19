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
//using Rectangle = java.awt.Rectangle;
//using BufferedImage = java.awt.image.BufferedImage;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.media.image.comparison.motion;

public class ConstrainedMotionRectangles : MotionRectangles
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly string NAME = "constrainedMotionRectangles_";
    private MotionRectangleConstraintsInterface motionRectangleConstraintsInterface = null;
    public ConstrainedMotionRectangles(MotionRectangleConstraintsInterface motionRectangleConstraintsInterface, MotionRectangles motionRectangles) : base(NAME, motionRectangles.getImageComparisonResult())
    {
        // base(NAME, motionRectangles.getImageComparisonResult()) is called from the constructor declaration
        this.setMotionRectangleConstraintsInterface(motionRectangleConstraintsInterface);
    }

    // throws Exception
    public virtual void applyMotionRectangleConstraints(MotionRectangles motionRectangles)
    {
        this.logUtil.putF("Start - Size Before: " + motionRectangles.getVector().size(), this, "applyMotionRectangleConstraints");
        BufferedImage[] bufferedImageArray = motionRectangles.getImageComparisonResult().getBufferedImages();
        BufferedImage bufferedImage = bufferedImageArray[1];
        BasicArrayList vector = new BasicArrayListD();
        BasicArrayList vector2 = motionRectangles.getVector();
        int size = vector2.size();
        for (int index = 0; index < size; index++) {
            MotionRectangle motionRectangle = ((MotionRectangle) vector2.get(index));
            Rectangle rectangle = motionRectangle.getRectangle();
            bool isTooSmall = this.getMotionRectangleConstraintsInterface().isTooSmall(rectangle);
            if (isTooSmall) {
                continue;
            }
            bool isAreaTooSmall = this.getMotionRectangleConstraintsInterface().isAreaTooSmall(rectangle);
            if (isAreaTooSmall) {
                continue;
            }
            bool isTooBig = this.getMotionRectangleConstraintsInterface().isTooBig(rectangle);
            if (isTooBig) {
                continue;
            }
            bool isValid = this.getMotionRectangleConstraintsInterface().isValid(this.getImageComparisonResult().getFrameTwo(), bufferedImage, motionRectangle.getRectangle());
            if (!isValid) {
                continue;
            }
            if (!isTooSmall && !isAreaTooSmall && !isTooBig && isValid) {
                vector.add(motionRectangle);
            }
        }
        this.setVector(vector);
    }

    public virtual MotionRectangleConstraintsInterface getMotionRectangleConstraintsInterface()
    {
        return this.motionRectangleConstraintsInterface;
    }

    public virtual void setMotionRectangleConstraintsInterface(MotionRectangleConstraintsInterface motionRectangleConstraintsInterface)
    {
        this.motionRectangleConstraintsInterface = motionRectangleConstraintsInterface;
    }

}

