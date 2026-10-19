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
using GameConfiguration = org.allbinary.game.configuration.GameConfiguration;

namespace org.allbinary.game.configuration.@event;

public class ChangedGameFeatureListener : BaseChangedGameFeatureListener
{
    private static readonly ChangedGameFeatureListener gameFeatureListener = new ChangedGameFeatureListener();
    public static ChangedGameFeatureListener getInstance()
    {
        return ChangedGameFeatureListener.gameFeatureListener;
    }

    public virtual bool isChangedGameConfiguration(GameConfiguration gameConfiguration)
    {
        return this.list.contains(gameConfiguration);
    }

}

