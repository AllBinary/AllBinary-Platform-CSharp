/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using Activity = android.app.Activity;
using MotionEvent = android.view.MotionEvent;
using View = android.view.View;
using GenericMotionEventVerifyInterface = org.allbinary.android.GenericMotionEventVerifyInterface;
using GameFeatureEvent = org.allbinary.game.configuration.@event.GameFeatureEvent;
using GameFeatureListenerInterface = org.allbinary.game.configuration.@event.GameFeatureListenerInterface;
using GameInitializedEvent = org.allbinary.game.configuration.@event.GameInitializedEvent;
using GameInitializedListenerInterface = org.allbinary.game.configuration.@event.GameInitializedListenerInterface;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.android.activity;

public class MidletActivityBase : Activity, GameFeatureListenerInterface, GameInitializedListenerInterface, SimpleProgressActivityInterface, KeyInputViewCompositeInterface, GenericMotionEventVerifyInterface
{
    public override void onGameFeatureChange(GameFeatureEvent gameFeatureEvent)
    {
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
    }

    public override void onGameInitialized(GameInitializedEvent gameInitializedEvent)
    {
    }

    // throws Exception
    public override void onSetProgress(int value, string text)
    {
    }

    // throws Exception
    public override void onDismissProgress(int[] animationSequence)
    {
    }

    // throws Exception
    public override void onShowProgress(bool indeterminate, int[] animationSequence)
    {
    }

    public override View getRootView()
    {
        throw new SystemException();
    }

    public override View getView()
    {
        throw new SystemException();
    }

    public override void setKeyInputView(View keyInputView)
    {
    }

    public override bool onGenericMotionEvent(MotionEvent @event)
    {
        throw new SystemException();
    }

}

