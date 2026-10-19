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
using System.Runtime.CompilerServices;
//using BufferedImage = java.awt.image.BufferedImage;
//using File = java.io.File;
//using ImageIO = javax.imageio.ImageIO;
using SavedCaptureGenericProfileDataWorkerType = org.allbinary.input.automation.module.generic.configuration.profile.SavedCaptureGenericProfileDataWorkerType;
using CaptureWorkerInterface = org.allbinary.input.media.image.capture.CaptureWorkerInterface;
using CapturedBufferedImagesCacheSingleton = org.allbinary.input.media.image.capture.CapturedBufferedImagesCacheSingleton;
using CapturedImageWorkerResultsEvent = org.allbinary.input.media.image.capture.CapturedImageWorkerResultsEvent;
using ProcessingFrameIndexFactory = org.allbinary.input.media.image.capture.ProcessingFrameIndexFactory;
using ScreenScavangerRobot = org.allbinary.input.media.image.capture.ScreenScavangerRobot;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LongUtil = org.allbinary.logic.java.number.LongUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using MediaDataFactory = org.allbinary.logic.visual.media.MediaDataFactory;
using BufferedImageFrameCacheable = org.allbinary.media.image.cache.BufferedImageFrameCacheable;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.input.automation.module.generic;

public class SavedCaptureImagesWorker : BasicEventHandler, CaptureWorkerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private static long index;
    private bool running = false;
    private ScreenScavangerRobot screenScavangerRobot;
    private SavedCaptureGenericProfileDataWorkerType savedCaptureGenericProfileDataWorkerType;
    public SavedCaptureImagesWorker(SavedCaptureGenericProfileDataWorkerType savedCaptureGenericProfileDataWorkerType)
    {
        this.savedCaptureGenericProfileDataWorkerType = savedCaptureGenericProfileDataWorkerType;
        this.screenScavangerRobot = new ScreenScavangerRobot();
        SavedCaptureImagesWorker.index = ProcessingFrameIndexFactory.next();
    }

    // throws Exception
    public virtual void setThread(Thread thread)
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool isRunning()
    {
        return this.running;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setRunning(bool running)
    {
        this.running = running;
    }

    public virtual void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.RUN);
            this.setRunning(true);
            TimeDelayHelper timeHelper = new TimeDelayHelper(1000);
            while (this.isRunning()) {
                timeHelper.setStartTimeTNT();
                long? frame = index;
                StringMaker filePathStringBuffer = new StringMaker();
                filePathStringBuffer.append(this.savedCaptureGenericProfileDataWorkerType.getPath());
                filePathStringBuffer.append(LongUtil.fillIn(frame.ToString()));
                filePathStringBuffer.append(MediaDataFactory.getInstance().JPG.getExtension());
                string filePath = filePathStringBuffer.ToString();
                this.logUtil.putF("Loading Image File Path: " + filePath, this, this.commonStrings.RUN);
                File file = new File(filePath);
                if (file.isFile()) {
                    BufferedImage bufferedImage = ImageIO.read(file);
                    SavedCaptureImagesWorker.index++;
                    CapturedBufferedImagesCacheSingleton.getInstance().add(new BufferedImageFrameCacheable(bufferedImage, frame));
                    CapturedImageWorkerResultsEvent capturedImageEvent = new CapturedImageWorkerResultsEvent(this, frame, bufferedImage);
                    this.fireEvent(capturedImageEvent);
                } else {
                    this.logUtil.putF("Could Not Load File: " + filePath, this, this.commonStrings.RUN);
                }
                this.logUtil.putF(CommonLabels.getInstance().ELAPSED + timeHelper.getElapsedTNT(), this, this.commonStrings.RUN);
                this.setRunning(false);
            }
            this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

}

