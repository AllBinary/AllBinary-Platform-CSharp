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
//using Set = java.util.Set;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using AbstractInputAutomationWorker = org.allbinary.input.automation.module.AbstractInputAutomationWorker;
using InputAutomationActionInterface = org.allbinary.input.automation.module.InputAutomationActionInterface;
using GenericProfileAction = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileAction;
using GenericProfileActions = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileActions;
using GenericProfileActionScript = org.allbinary.input.automation.module.generic.configuration.profile.actions.script.GenericProfileActionScript;
using CapturedBufferedImagesCacheSingleton = org.allbinary.input.media.image.capture.CapturedBufferedImagesCacheSingleton;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using J2SECacheInterface = org.allbinary.logic.util.cache.J2SECacheInterface;
using ImageComparatorConstraintsInterface = org.allbinary.media.image.comparison.ImageComparatorConstraintsInterface;
using MotionRectangleConstraintsInterface = org.allbinary.media.image.comparison.motion.MotionRectangleConstraintsInterface;

namespace org.allbinary.input.automation.module.game.test;

public class TestInputAutomationCaptureWorker : AbstractInputAutomationWorker
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private GenericProfileActions genericProfileActions = null;
    private readonly string MESSAGE = "GenericInputAutomationCaptureWorker";
    private readonly string PROCESS_DATA_WORKER_RESULTS = "processDataWorkerResults";
    private readonly string IMAGE_AVAILABLE_SO_PROCESSING = "Image Available so processing";
    private readonly string IMAGE_NOT_AVAILABLE = "Image Not Available";
    public TestInputAutomationCaptureWorker(InputAutomationActionInterface inputAutomationActionInterface, GenericProfileActions genericProfileActions, ImageComparatorConstraintsInterface imageComparatorConstraintsInterface, MotionRectangleConstraintsInterface motionRectangleConstraintsInterface) : base(inputAutomationActionInterface)
    {
        // base(inputAutomationActionInterface) is called from the constructor declaration
        this.logUtil.putF(this.MESSAGE, this, this.commonStrings.CONSTRUCTOR);
        this.setGenericProfileActions(genericProfileActions);
    }

    // throws Exception
    public virtual void processDataWorkerResults()
    {
        J2SECacheInterface cacheInterface = ((J2SECacheInterface) CapturedBufferedImagesCacheSingleton.getInstance());
        if (cacheInterface.keySet().size() > 0) {
            this.logUtil.putF(this.IMAGE_AVAILABLE_SO_PROCESSING, this, this.PROCESS_DATA_WORKER_RESULTS);
            object anyType = cacheInterface.keySet().toArray()[0];
            HashMap hashMap = this.getGenericProfileActions().getHashMap();
            Set set = hashMap.keySet();
            object[] actionNameArray = set.toArray();
            int size = actionNameArray.Length;
            for (int index = 0; index < size; index++) {
                string actionNameString = ((string) actionNameArray[index]);
                GenericProfileAction genericProfileAction = ((GenericProfileAction) hashMap.get(actionNameString));
                GenericProfileActionScript genericProfileActionScript = genericProfileAction.getGenericProfileActionScript();
                BasicArrayList vector = genericProfileActionScript.getProfileActionConditionInterfaceVector();
            }
            cacheInterface.get(anyType);
        } else {
            this.logUtil.putF(this.IMAGE_NOT_AVAILABLE, this, this.PROCESS_DATA_WORKER_RESULTS);
        }
    }

    // throws Exception
    public virtual void process()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.PROCESS);
        this.startDataWorkers();
        this.processDataWorkerResults();
    }

    public virtual GenericProfileActions getGenericProfileActions()
    {
        return this.genericProfileActions;
    }

    public virtual void setGenericProfileActions(GenericProfileActions genericProfileActions)
    {
        this.genericProfileActions = genericProfileActions;
    }

}

