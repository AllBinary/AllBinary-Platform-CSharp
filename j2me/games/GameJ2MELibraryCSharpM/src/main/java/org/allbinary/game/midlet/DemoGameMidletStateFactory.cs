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

namespace org.allbinary.game.midlet;

public class DemoGameMidletStateFactory
{
    private static DemoGameMidletStateFactory STATE = new DemoGameMidletStateFactory();
    public readonly DemoGameMidletState NONE = new DemoGameMidletState();
    public readonly DemoGameMidletState START_DEMO = new DemoGameMidletState();
    public readonly DemoGameMidletState START_GAME = new DemoGameMidletState();
    public readonly DemoGameMidletState START_INPUT_MAPPING = new DemoGameMidletState();
    private DemoGameMidletStateFactory()
    {
    }

    public static DemoGameMidletStateFactory getInstance()
    {
        return DemoGameMidletStateFactory.STATE;
    }

}

