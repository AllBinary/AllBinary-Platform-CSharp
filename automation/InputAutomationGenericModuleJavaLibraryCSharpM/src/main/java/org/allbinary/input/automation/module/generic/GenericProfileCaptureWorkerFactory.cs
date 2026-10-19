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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using GenericProfile = org.allbinary.input.automation.module.generic.configuration.profile.GenericProfile;
using GenericProfileDataWorkerType = org.allbinary.input.automation.module.generic.configuration.profile.GenericProfileDataWorkerType;
using SavedCaptureGenericProfileDataWorkerType = org.allbinary.input.automation.module.generic.configuration.profile.SavedCaptureGenericProfileDataWorkerType;
using CaptureWorkerInterface = org.allbinary.input.media.image.capture.CaptureWorkerInterface;
using ScreenCaptureImagesWorker = org.allbinary.input.media.image.capture.ScreenCaptureImagesWorker;

namespace org.allbinary.input.automation.module.generic;

public class GenericProfileCaptureWorkerFactory
{
    private GenericProfileCaptureWorkerFactory()
    {
    }

    // throws Exception
    public static CaptureWorkerInterface getInstance(GenericProfile genericProfile)
    {
        BasicArrayList vector = genericProfile.getGenericProfileDataWorkerTypeVector();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            GenericProfileDataWorkerType genericProfileDataWorkerType = ((GenericProfileDataWorkerType) vector.get(index));
            if (genericProfileDataWorkerType == GenericProfileDataWorkerType.SCREEN_CAPTURE) {
                return new ScreenCaptureImagesWorker();
            } else if (genericProfileDataWorkerType == GenericProfileDataWorkerType.SAVED_CAPTURE) {
                return new SavedCaptureImagesWorker(((SavedCaptureGenericProfileDataWorkerType) genericProfileDataWorkerType));
            }
        }
        throw new Exception("No CaptureWorkerInterface specified in GenericProfile");
    }

}

