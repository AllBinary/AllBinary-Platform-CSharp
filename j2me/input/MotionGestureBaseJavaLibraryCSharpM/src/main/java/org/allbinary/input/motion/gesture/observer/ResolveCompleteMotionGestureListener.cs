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
using CompleteMotionGestureInputEventHandler = org.allbinary.game.input.CompleteMotionGestureInputEventHandler;
using GameKeyCompleteMotionGestureInputEvent = org.allbinary.game.input.motion.action.GameKeyCompleteMotionGestureInputEvent;
using GameKeyFromMotionGestureEventListener = org.allbinary.game.input.motion.action.GameKeyFromMotionGestureEventListener;
using MotionGestureToMotionGestureActionAssociation = org.allbinary.input.motion.gesture.MotionGestureToMotionGestureActionAssociation;
using MotionGestureConfiguration = org.allbinary.input.motion.gesture.configuration.MotionGestureConfiguration;
using MotionGestureConfigurationFactory = org.allbinary.input.motion.gesture.configuration.MotionGestureConfigurationFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.input.motion.gesture.observer;

public class ResolveCompleteMotionGestureListener : CompleteMotionGestureListenerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public ResolveCompleteMotionGestureListener()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF("MotionGesture to CompleteMotionGesture Reciever", this, commonStrings.CONSTRUCTOR);
        CompleteMotionGestureInputEventHandler.getInstance().addListener(new GameKeyFromMotionGestureEventListener());
    }

    // throws Exception
    public virtual void onMotionGestureCompleted(BasicArrayList list)
    {
        MotionGestureConfiguration configuration = MotionGestureConfigurationFactory.getInstance();
        BasicArrayList commandActionsList = configuration.getAssociateCommandActionsList();
        int size = commandActionsList.size();
        for (int index = size - 1; index >= 0; index--) {
            MotionGestureToMotionGestureActionAssociation association = ((MotionGestureToMotionGestureActionAssociation) commandActionsList.objectArray[index]);
            if (association.isMotionGestureArrayEquals(list) == true) {
                GameKeyCompleteMotionGestureInputEvent completeMotionGestureInputEvent = ((GameKeyCompleteMotionGestureInputEvent) association.getCommandAction());
                CompleteMotionGestureInputEventHandler.getInstance().fireEvent(completeMotionGestureInputEvent);
                break;
            }
        }
    }

}

