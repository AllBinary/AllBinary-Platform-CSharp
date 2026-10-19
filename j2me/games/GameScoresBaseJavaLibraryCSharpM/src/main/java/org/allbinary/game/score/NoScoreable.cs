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

namespace org.allbinary.game.score;

public class NoScoreable : Scoreable
{
    private static readonly NoScoreable SINGLETON = new NoScoreable();
    public static NoScoreable getInstance()
    {
        return NoScoreable.SINGLETON;
    }

    private NoScoreable() : base(0)
    {
        // base(0) is called from the constructor declaration
    }

    public override void addPoints(int points)
    {
    }

    public override void removePoints(int points)
    {
    }

}

