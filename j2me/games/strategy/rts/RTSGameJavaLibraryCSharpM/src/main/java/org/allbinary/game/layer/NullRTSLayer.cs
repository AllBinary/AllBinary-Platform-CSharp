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
using GameNotificationHud = org.allbinary.game.ag.layer.hud.basic.notification.GameNotificationHud;
using DestroyedEvent = org.allbinary.game.combat.destroy.@event.DestroyedEvent;
using PlayerGameInput = org.allbinary.game.input.PlayerGameInput;
using NullRTSFormInputFactory = org.allbinary.game.input.form.NullRTSFormInputFactory;
using RTSFormInput = org.allbinary.game.input.form.RTSFormInput;
using Capital = org.allbinary.game.layer.capital.Capital;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using Sound = org.allbinary.media.audio.Sound;

namespace org.allbinary.game.layer;

public class NullRTSLayer : NullPathFindingLayer, RTSPlayerLayerInterface
{
    public static readonly NullRTSLayer NULL_RTS_LAYER = new NullRTSLayer();
    public override string getName()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void processInput(AllBinaryLayerManager layerManager)
    {
        throw new SystemException();
    }

    public virtual void initInputProcessors()
    {
        throw new SystemException();
    }

    public virtual GameNotificationHud getGameNotificationHud()
    {
        throw new SystemException();
    }

    public virtual ScrollSelectionForm getCurrentScrollSelectionForm()
    {
        throw new SystemException();
    }

    public virtual void setCurrentScrollSelectionForm(ScrollSelectionForm currentScrollSelectionForm)
    {
        throw new SystemException();
    }

    public virtual ScrollSelectionForm getBuildingScrollSelectionForm()
    {
        throw new SystemException();
    }

    public virtual PlayerGameInput getPlayerGameInput()
    {
        throw new SystemException();
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void onDestroyed(DestroyedEvent destroyedEvent)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        throw new SystemException();
    }

    public virtual Capital getCapital()
    {
        throw new SystemException();
    }

    public virtual RTSFormInput getRTSFormInput()
    {
        return NullRTSFormInputFactory.getInstance();
    }

    public virtual void add(Sound sound)
    {
        throw new SystemException();
    }

    public virtual PlayerOwnedRTSLayers getPlayerOwnedRTSLayers()
    {
        throw new SystemException();
    }

    public virtual bool implmentsArtificialIntelligenceCompositeInterface()
    {
        throw new SystemException();
    }

}

