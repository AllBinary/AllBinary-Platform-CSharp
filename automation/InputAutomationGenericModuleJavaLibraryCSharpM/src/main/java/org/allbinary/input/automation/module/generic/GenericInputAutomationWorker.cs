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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using AbstractInputAutomationWorker = org.allbinary.input.automation.module.AbstractInputAutomationWorker;
using InputAutomationActionInterface = org.allbinary.input.automation.module.InputAutomationActionInterface;
using GenericProfile = org.allbinary.input.automation.module.generic.configuration.profile.GenericProfile;
using GenericProfileDataWorkerType = org.allbinary.input.automation.module.generic.configuration.profile.GenericProfileDataWorkerType;
using GenericProfileAction = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileAction;
using GenericProfileActionScript = org.allbinary.input.automation.module.generic.configuration.profile.actions.script.GenericProfileActionScript;
using CapturedBufferedImagesCacheSingleton = org.allbinary.input.media.image.capture.CapturedBufferedImagesCacheSingleton;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using J2SECacheInterface = org.allbinary.logic.util.cache.J2SECacheInterface;
using ImageComparatorConstraintsInterface = org.allbinary.media.image.comparison.ImageComparatorConstraintsInterface;
using ImageComparisonWorker = org.allbinary.media.image.comparison.ImageComparisonWorker;
using MotionRectangleConstraintsInterface = org.allbinary.media.image.comparison.motion.MotionRectangleConstraintsInterface;
using MotionRectanglesWorker = org.allbinary.media.image.comparison.motion.MotionRectanglesWorker;

namespace org.allbinary.input.automation.module.generic;

public class GenericInputAutomationWorker : AbstractInputAutomationWorker
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string PROCESS_DATA_WORKER_RESULTS = "processDataWorkerResults";
    private long? lastFrame = -1;
    private long? frame = null;
    private GenericProfile genericProfile = null;
    public GenericInputAutomationWorker(InputAutomationActionInterface inputAutomationActionInterface, GenericProfile genericProfile, MotionRectangleConstraintsInterface motionRectangleConstraintsInterface, ImageComparatorConstraintsInterface imageComparatorConstraintsInterface) : base(inputAutomationActionInterface)
    {
        // base(inputAutomationActionInterface) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.setCaptureWorker(GenericProfileCaptureWorkerFactory.getInstance(genericProfile));
        this.setInputAutomationActionInterface(inputAutomationActionInterface);
        this.setImageComparisonWorker(new ImageComparisonWorker(imageComparatorConstraintsInterface));
        this.setMotionRectanglesWorker(new MotionRectanglesWorker(motionRectangleConstraintsInterface));
        this.setGenericProfile(genericProfile);
        BasicArrayList vector = this.getGenericProfile().getGenericProfileDataWorkerTypeVector();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            GenericProfileDataWorkerType genericProfileDataWorkerType = ((GenericProfileDataWorkerType) vector.get(index));
            this.logUtil.putF("Adding Listener: " + genericProfileDataWorkerType, this, this.commonStrings.CONSTRUCTOR);
            if (genericProfileDataWorkerType == GenericProfileDataWorkerType.COMPARISON) {
                this.getCaptureWorker().addListenerInterface(this.getImageComparisonWorker());
            } else if (genericProfileDataWorkerType == GenericProfileDataWorkerType.MOTION) {
                this.getImageComparisonWorker().addListenerInterface(this.getMotionRectanglesWorker());
            }
        }
    }

    // throws Exception
    public virtual void processDataWorkerResults()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.PROCESS_DATA_WORKER_RESULTS);
        this.waitForDataWorkers();
        J2SECacheInterface cacheInterface = ((J2SECacheInterface) CapturedBufferedImagesCacheSingleton.getInstance());
        object[] keyArray = cacheInterface.keySet().toArray();
        if (keyArray.Length > 0) {
            this.logUtil.putF("Image Available", this, this.PROCESS_DATA_WORKER_RESULTS);
            this.setFrame(((long?) keyArray[keyArray.Length - 1]));
            if (getFrame() > this.lastFrame) {
                this.logUtil.putF("Processing new frame: " + getFrame(), this, this.PROCESS_DATA_WORKER_RESULTS);
                HashMap<object, object> hashMap = this.getGenericProfile().getGenericProfileActions().getHashMap();
                Set<object> set = hashMap.keySet();
                this.logUtil.putF("Processing " + set.size() + "Actions", this, this.PROCESS_DATA_WORKER_RESULTS);
                object[] actionNameArray = set.toArray();
                int size = actionNameArray.Length;
                for (int index = 0; index < size; index++) {
                    string actionNameString = ((string) actionNameArray[index]);
                    this.logUtil.putF("Processing Action: " + actionNameString, this, this.PROCESS_DATA_WORKER_RESULTS);
                    GenericProfileAction genericProfileAction = ((GenericProfileAction) hashMap.get(actionNameString));
                    GenericProfileActionScript genericProfileActionScript = genericProfileAction.getGenericProfileActionScript();
                    BasicArrayList vector = genericProfileActionScript.getProfileActionConditionInterfaceVector();
                    CaptureWorkerUtil.processProfileActionConditions(vector, getFrame());
                }
                this.lastFrame = this.getFrame();
            }
        } else {
            this.logUtil.putF("Image Not Available", this, this.PROCESS_DATA_WORKER_RESULTS);
        }
    }

    // throws Exception
    public virtual void process()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.PROCESS);
        this.startDataWorkers();
        this.processDataWorkerResults();
    }

    public virtual GenericProfile getGenericProfile()
    {
        return this.genericProfile;
    }

    public virtual void setGenericProfile(GenericProfile genericProfile)
    {
        this.genericProfile = genericProfile;
    }

    public virtual long? getFrame()
    {
        return this.frame;
    }

    public virtual void setFrame(long? frame)
    {
        this.frame = frame;
    }

}

