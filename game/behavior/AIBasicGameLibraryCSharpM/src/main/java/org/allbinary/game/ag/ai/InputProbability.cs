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
using StdUtil = org.allbinary.logic.StdUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai;

public class InputProbability
{
    public static int? INPUT_PROBABILITY = SmallIntegerSingletonFactory.getInstance().getAt(0);
    private readonly int?[][] likelyhoodIntegerArray;
    private readonly int?[] repeatLikelyhoodIntegerArray;
    private readonly int max;
    private readonly TimeDelayHelper timeDelayHelper;
    public InputProbability(int?[][] likelyhoodIntegerArray, int?[] repeatLikelyhoodIntegerArray, int max, TimeDelayHelper timeDelayHelper)
    {
        this.likelyhoodIntegerArray = likelyhoodIntegerArray;
        this.repeatLikelyhoodIntegerArray = repeatLikelyhoodIntegerArray;
        this.max = max;
        this.timeDelayHelper = timeDelayHelper;
    }

    public virtual int?[][] getLikelyhoodIntegerArray()
    {
        return this.likelyhoodIntegerArray;
    }

    public virtual int?[] getRepeatLikelyhoodIntegerArray()
    {
        return this.repeatLikelyhoodIntegerArray;
    }

    public virtual int getMax()
    {
        return this.max;
    }

    public virtual TimeDelayHelper getTimeDelayHelper()
    {
        return this.timeDelayHelper;
    }

    public virtual ABHashtable<object, object> toHashtable()
    {
        ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
        hashtable.put(InputProbability.INPUT_PROBABILITY, this);
        return hashtable;
    }

}

