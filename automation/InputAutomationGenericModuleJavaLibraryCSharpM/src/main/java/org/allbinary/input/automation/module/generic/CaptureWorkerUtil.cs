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
using ProfileActionScriptConditionInterface = org.allbinary.input.automation.actions.script.condition.ProfileActionScriptConditionInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.module.generic;

public class CaptureWorkerUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public CaptureWorkerUtil()
    {
    }

    // throws Exception
    public static void processProfileActionConditions(BasicArrayList vector, long? frame)
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        logUtil.putF(commonStrings.START, "CaptureWorkerUtil", "processProfileActionConditions");
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            ProfileActionScriptConditionInterface profileActionConditionInterface = ((ProfileActionScriptConditionInterface) vector.get(index));
            if (profileActionConditionInterface.shouldProcess(frame)) {
                profileActionConditionInterface.process(frame);
            } else {
            }
        }
    }

}

