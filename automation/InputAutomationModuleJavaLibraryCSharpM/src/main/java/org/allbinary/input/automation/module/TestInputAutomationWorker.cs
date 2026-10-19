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
using ScreenCaptureImagesWorker = org.allbinary.input.media.image.capture.ScreenCaptureImagesWorker;
using ImageComparisonWorker = org.allbinary.media.image.comparison.ImageComparisonWorker;
using SaveImageComparisonWorker = org.allbinary.media.image.comparison.SaveImageComparisonWorker;
using MotionRectanglesWorker = org.allbinary.media.image.comparison.motion.MotionRectanglesWorker;
using SaveMotionRectanglesResultsWorker = org.allbinary.media.image.comparison.motion.SaveMotionRectanglesResultsWorker;
using TestInputForMotionRectanglesResultsWorker = org.allbinary.media.image.comparison.motion.TestInputForMotionRectanglesResultsWorker;

namespace org.allbinary.input.automation.module;

public class TestInputAutomationWorker
{
    private ScreenCaptureImagesWorker captureWorker;
    private ImageComparisonWorker imageComparisonWorker = null;
    private MotionRectanglesWorker motionRectanglesWorker = null;
    private SaveImageComparisonWorker changedPixelsImageComparisonResultsWorker;
    private SaveMotionRectanglesResultsWorker saveMotionRectanglesAsImagesWorker;
    private TestInputForMotionRectanglesResultsWorker moveMouseToFirstMotionRectanglesResultsWorker;
    public TestInputAutomationWorker()
    {
        this.captureWorker = new ScreenCaptureImagesWorker();
        this.changedPixelsImageComparisonResultsWorker = new SaveImageComparisonWorker();
        this.saveMotionRectanglesAsImagesWorker = new SaveMotionRectanglesResultsWorker();
        this.moveMouseToFirstMotionRectanglesResultsWorker = new TestInputForMotionRectanglesResultsWorker();
        this.motionRectanglesWorker.addListenerInterface(this.saveMotionRectanglesAsImagesWorker);
        this.motionRectanglesWorker.addListenerInterface(this.moveMouseToFirstMotionRectanglesResultsWorker);
        this.imageComparisonWorker.addListenerInterface(this.changedPixelsImageComparisonResultsWorker);
        this.imageComparisonWorker.addListenerInterface(this.motionRectanglesWorker);
        this.captureWorker.addListenerInterface(this.imageComparisonWorker);
    }

}

