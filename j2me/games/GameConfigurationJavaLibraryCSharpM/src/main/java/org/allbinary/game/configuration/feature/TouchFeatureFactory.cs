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

namespace org.allbinary.game.configuration.feature;

public class TouchFeatureFactory
{
    private static readonly TouchFeatureFactory instance = new TouchFeatureFactory();
    public static TouchFeatureFactory getInstance()
    {
        return TouchFeatureFactory.instance;
    }

    private TouchFeatureFactory()
    {
    }

    public readonly TouchFeature TOUCH_ENABLED = new TouchFeature("Touch Enabled");
    public readonly TouchFeature SHOW_SCREEN_BUTTONS = new TouchFeature("Show");
    public readonly TouchFeature AUTO_HIDE_SHOW_SCREEN_BUTTONS = new TouchFeature("Auto Hide (One Level)");
    public readonly TouchFeature HIDE_SCREEN_BUTTONS = new TouchFeature("Hide");
}

