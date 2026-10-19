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

public class MainFeatureFactory
{
    private static readonly MainFeatureFactory instance = new MainFeatureFactory();
    public static MainFeatureFactory getInstance()
    {
        return MainFeatureFactory.instance;
    }

    public readonly Feature FULL_SCREEN = new Feature("Full Screen");
    public readonly Feature TITLE_BAR = new Feature("Title Bar");
    public readonly Feature STATIC = new Feature("Static Dependent Feature");
    public readonly Feature LOAD_ONDEMAND = new Feature("Load OnDemand");
    public readonly Feature LOAD_ALL = new Feature("Load All");
}

