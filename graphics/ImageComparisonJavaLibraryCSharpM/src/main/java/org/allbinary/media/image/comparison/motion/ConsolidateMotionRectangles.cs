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
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.media.image.comparison.motion;

public class ConsolidateMotionRectangles : MotionRectangles
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly string NAME = "consolidatedMotionRectangles_";
    public ConsolidateMotionRectangles(MotionRectangles motionRectangles) : base(NAME, motionRectangles.getImageComparisonResult())
    {
        // base(NAME, motionRectangles.getImageComparisonResult()) is called from the constructor declaration
        BasicArrayList vector = motionRectangles.getVector();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            MotionRectangle motionRectangle = ((MotionRectangle) vector.get(index));
            vector.add(motionRectangle.clone());
        }
        this.consolidateMotionRectangles();
    }

    private void consolidateMotionRectangles()
    {
        BasicArrayList vector = this.getVector();
        this.logUtil.putF("Start - Size Before: " + vector.size(), this, "consolidateMotionRectangleConstraints");
        BasicArrayList removeVector = new BasicArrayListD();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            MotionRectangle motionRectangle = ((MotionRectangle) vector.get(index));
            for (int i = index + 1; i < vector.size(); i++) {
                MotionRectangle motionRectangle2 = ((MotionRectangle) vector.get(i));
                Rectangle rectangle = motionRectangle.getRectangle();
                Rectangle rectangle2 = motionRectangle2.getRectangle();
                int x2 = rectangle.x + rectangle.width;
                int y2 = rectangle.y + rectangle.height;
                int rightX = rectangle2.x + rectangle2.width;
                int bottomY = rectangle2.y + rectangle2.height;
                if (rectangle.x <= rectangle2.x && rectangle.y <= rectangle2.y && x2 >= rightX && y2 >= bottomY) {
                    removeVector.add(motionRectangle2);
                }
            }
        }
        this.remove(removeVector);
    }

    private void remove(BasicArrayList removeVector)
    {
        BasicArrayList vector = this.getVector();
        int size = removeVector.size();
        for (int index = 0; index < size; index++) {
            vector.remove(removeVector.get(index));
        }
    }

}

