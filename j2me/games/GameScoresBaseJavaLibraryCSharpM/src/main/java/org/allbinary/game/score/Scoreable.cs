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
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;

namespace org.allbinary.game.score;

public class Scoreable : ScoreableInterface
{
    public static int? ID = SmallIntegerSingletonFactory.getInstance().getAt(3);
    private int points;
    public Scoreable(int points)
    {
        this.points = points;
    }

    public virtual void addPoints(int points)
    {
        this.points += points;
    }

    public virtual void removePoints(int points)
    {
        this.points -= points;
    }

    public virtual void setPoints(int points)
    {
        this.points = points;
    }

    public virtual int getPoints()
    {
        return this.points;
    }

}

