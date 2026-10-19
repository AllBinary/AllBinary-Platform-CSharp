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

namespace org.allbinary.game.ag.ai;

public class NumberInSameGroupSequence
{
    public static NumberInSameGroupSequence getInstance()
    {
        return new NumberInSameGroupSequence();
    }

    public int? NUMBER_ON_SAME_TEAM_SEQUENCE_ZERO;
    public int? NUMBER_ON_SAME_TEAM_SEQUENCE_ONE;
    public int? NUMBER_ON_SAME_TEAM_SEQUENCE_TWO;
    public int? NUMBER_ON_SAME_TEAM_SEQUENCE_THREE;
    public int? NUMBER_ON_SAME_TEAM_SEQUENCE_FOUR;
    public int? NUMBER_ON_SAME_TEAM_SEQUENCE_FIVE;
    public int? NUMBER_ON_SAME_TEAM_SEQUENCE_SIX;
    public int? NUMBER_ON_SAME_TEAM_SEQUENCE_SEVEN;
    public int? NUMBER_ON_SAME_TEAM_SEQUENCE_EIGHT;
    public int? NUMBER_ON_SAME_TEAM_SEQUENCE_NINE;
    public int?[] NUMBER_ON_SAME_TEAM_SEQUENCE;
    private NumberInSameGroupSequence()
    {
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        this.NUMBER_ON_SAME_TEAM_SEQUENCE_ZERO = smallIntegerSingletonFactory.getAt(100);
        this.NUMBER_ON_SAME_TEAM_SEQUENCE_ONE = smallIntegerSingletonFactory.getAt(101);
        this.NUMBER_ON_SAME_TEAM_SEQUENCE_TWO = smallIntegerSingletonFactory.getAt(102);
        this.NUMBER_ON_SAME_TEAM_SEQUENCE_THREE = smallIntegerSingletonFactory.getAt(103);
        this.NUMBER_ON_SAME_TEAM_SEQUENCE_FOUR = smallIntegerSingletonFactory.getAt(104);
        this.NUMBER_ON_SAME_TEAM_SEQUENCE_FIVE = smallIntegerSingletonFactory.getAt(105);
        this.NUMBER_ON_SAME_TEAM_SEQUENCE_SIX = smallIntegerSingletonFactory.getAt(106);
        this.NUMBER_ON_SAME_TEAM_SEQUENCE_SEVEN = smallIntegerSingletonFactory.getAt(107);
        this.NUMBER_ON_SAME_TEAM_SEQUENCE_EIGHT = smallIntegerSingletonFactory.getAt(108);
        this.NUMBER_ON_SAME_TEAM_SEQUENCE_NINE = smallIntegerSingletonFactory.getAt(109);
        this.NUMBER_ON_SAME_TEAM_SEQUENCE = new int?[] { this.NUMBER_ON_SAME_TEAM_SEQUENCE_ZERO, this.NUMBER_ON_SAME_TEAM_SEQUENCE_ONE, this.NUMBER_ON_SAME_TEAM_SEQUENCE_THREE, this.NUMBER_ON_SAME_TEAM_SEQUENCE_FOUR, this.NUMBER_ON_SAME_TEAM_SEQUENCE_FIVE, this.NUMBER_ON_SAME_TEAM_SEQUENCE_SIX, this.NUMBER_ON_SAME_TEAM_SEQUENCE_SEVEN, this.NUMBER_ON_SAME_TEAM_SEQUENCE_EIGHT, this.NUMBER_ON_SAME_TEAM_SEQUENCE_NINE };
    }

}

