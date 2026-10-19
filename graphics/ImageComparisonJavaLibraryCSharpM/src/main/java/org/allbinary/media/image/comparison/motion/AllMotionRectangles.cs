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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using ImageComparisonResult = org.allbinary.media.image.comparison.ImageComparisonResult;
using PixelDelta = org.allbinary.media.image.comparison.pixel.PixelDelta;

namespace org.allbinary.media.image.comparison.motion;

public class AllMotionRectangles : MotionRectangles
{
    private static readonly string NAME = "allMotionRectangles_";
    public AllMotionRectangles(ImageComparisonResult imageComparisonResult) : base(NAME, imageComparisonResult)
    {
        // base(NAME, imageComparisonResult) is called from the constructor declaration
        this.createMotionRectangles(imageComparisonResult);
    }

    // throws Exception
    private void createMotionRectangles(ImageComparisonResult imageComparisonInfo)
    {
        BasicArrayList vector = imageComparisonInfo.getNonMatchingPixelVector();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            PixelDelta pixelDelta = ((PixelDelta) vector.get(index));
            this.addPixelDeltaToAMotionRectangle(pixelDelta);
        }
    }

    // throws Exception
    private bool addPixelDeltaToExistingMotionRectangle(PixelDelta pixelDelta)
    {
        BasicArrayList vector = this.getVector();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            MotionRectangle motionRectangle = ((MotionRectangle) vector.get(index));
            if (shouldPixelDeltaPartOfMotionRectangle(motionRectangle, pixelDelta)) {
                int newWidth = pixelDelta.getPoint().getX() - motionRectangle.getRectangle().x;
                int newHeight = pixelDelta.getPoint().getY() - motionRectangle.getRectangle().y;
                if (newWidth < motionRectangle.getRectangle().width) {
                    newWidth = motionRectangle.getRectangle().width;
                }
                if (newHeight < motionRectangle.getRectangle().height) {
                    newHeight = motionRectangle.getRectangle().height;
                }
                motionRectangle.getRectangle().setSize(newWidth, newHeight);
                return true;
            }
        }
        return false;
    }

    // throws Exception
    private void addPixelDeltaToAMotionRectangle(PixelDelta pixelDelta)
    {
        if (!addPixelDeltaToExistingMotionRectangle(pixelDelta)) {
            Rectangle newRectangle = new Rectangle(pixelDelta.getPoint().getX(), pixelDelta.getPoint().getY(), 1, 1);
            MotionRectangle motionRectangle = new MotionRectangle(newRectangle);
            motionRectangle.getPixelDeltaVector().add(pixelDelta);
            this.getVector().add(motionRectangle);
        }
    }

    // throws Exception
    private bool shouldPixelDeltaPartOfMotionRectangle(MotionRectangle motionRectangle, PixelDelta pixelDelta)
    {
        bool isPixelLeftOfTheRectangle = false;
        if (motionRectangle.getRectangle().y > pixelDelta.getPoint().getY()) {
            throw new Exception("PixelAboveTheRectangle");
        }
        if (motionRectangle.getRectangle().x > pixelDelta.getPoint().getX()) {
            isPixelLeftOfTheRectangle = true;
        }
        if (!isPixelLeftOfTheRectangle) {
            return this.isPixelDeltaLikelyPartOfMotionRectangle(motionRectangle, pixelDelta);
        }
        return false;
    }

    // throws Exception
    private bool isPixelDeltaLikelyPartOfMotionRectangle(MotionRectangle motionRectangle, PixelDelta pixelDelta)
    {
        int maxX = motionRectangle.getRectangle().x + motionRectangle.getRectangle().width;
        int maxY = motionRectangle.getRectangle().y + motionRectangle.getRectangle().height;
        int horizontalDistance = pixelDelta.getPoint().getX() - maxX;
        int verticalDistance = pixelDelta.getPoint().getY() - maxY;
        if (horizontalDistance < this.MAX_PIXEL_DISTANCE_THRESHOLD && verticalDistance < this.MAX_PIXEL_DISTANCE_THRESHOLD) {
            return true;
        }
        return false;
    }

}

