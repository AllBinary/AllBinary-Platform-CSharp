/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using GameNotificationHudCompositeInterface = org.allbinary.game.ag.layer.hud.basic.notification.GameNotificationHudCompositeInterface;
using BuildMenuCompositeInterface = org.allbinary.game.input.BuildMenuCompositeInterface;
using RTSFormInput = org.allbinary.game.input.form.RTSFormInput;
using Capital = org.allbinary.game.layer.capital.Capital;
using DestroyedEventListenerInterface = org.allbinary.game.combat.destroy.@event.DestroyedEventListenerInterface;
using PlayerGameInputCompositeInterface = org.allbinary.game.input.PlayerGameInputCompositeInterface;
using TickableInterface = org.allbinary.game.tick.TickableInterface;
using Sound = org.allbinary.media.audio.Sound;

namespace org.allbinary.game.layer;

public interface RTSPlayerLayerInterface : GameNotificationHudCompositeInterface, BuildMenuCompositeInterface, PlayerGameInputCompositeInterface, DestroyedEventListenerInterface, TickableInterface, PathFindingLayerInterface
{
    Capital getCapital();

    RTSFormInput getRTSFormInput();

    void add(Sound sound);

    PlayerOwnedRTSLayers getPlayerOwnedRTSLayers();

    bool implmentsArtificialIntelligenceCompositeInterface();

}

