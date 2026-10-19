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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.direction;

public class DirectionFactory
{
    private static readonly DirectionFactory instance = new DirectionFactory();
    public static DirectionFactory getInstance()
    {
        return DirectionFactory.instance;
    }

    public readonly string NAME = "DIRECTION";
    public readonly Direction LEFT = new Direction(CommonPhoneStrings.getInstance().LEFT, "WEST", 0, 1);
    public readonly Direction RIGHT = new Direction(CommonPhoneStrings.getInstance().RIGHT, "EAST", 1, 0);
    public readonly Direction DOWN = new Direction(CommonPhoneStrings.getInstance().DOWN, "SOUTH", 2, 0);
    public readonly Direction UP = new Direction(CommonPhoneStrings.getInstance().UP, "NORTH", 3, 0);
    public readonly Direction UP_LEFT;
    public readonly Direction UP_RIGHT;
    public readonly Direction DOWN_LEFT;
    public readonly Direction DOWN_RIGHT;
    public readonly Direction NOT_BORDERED_WITH = new Direction("NOT_BORDERED_WITH", "NOT_BORDERED_WITH", 8, 0);
    public readonly Direction NO_DIRECTION = new Direction("NO_DIRECTION", "NO_DIRECTION", 9, 0);
    public readonly Direction TOP = new Direction("TOP", "TOP", 10, 0);
    public readonly Direction BOTTOM = new Direction("BOTTOM", "BOTTOM", 11, 0);
    public readonly Direction ALL_DIRECTION = new Direction("ALL_DIRECTION", "ALL_DIRECTION", 12, 0);
    private DirectionFactory()
    {
        StringMaker stringBuffer = new StringMaker();
        CommonSeps commonSeps = CommonSeps.getInstance();
        this.UP_LEFT = new Direction("UP LEFT", stringBuffer.append(this.UP.getOtherName()).append(commonSeps.SPACE).append(this.LEFT.getOtherName()).ToString(), 4, 0);
        stringBuffer.delete(0, stringBuffer.length());
        this.UP_RIGHT = new Direction("UP RIGHT", stringBuffer.append(this.UP.getOtherName()).append(commonSeps.SPACE).append(this.RIGHT.getOtherName()).ToString(), 5, 0);
        stringBuffer.delete(0, stringBuffer.length());
        this.DOWN_LEFT = new Direction("DOWN LEFT", stringBuffer.append(this.DOWN.getOtherName()).append(commonSeps.SPACE).append(this.LEFT.getOtherName()).ToString(), 6, 0);
        stringBuffer.delete(0, stringBuffer.length());
        this.DOWN_RIGHT = new Direction("DOWN RIGHT", stringBuffer.append(this.DOWN.getOtherName()).append(commonSeps.SPACE).append(this.RIGHT.getOtherName()).ToString(), 7, 0);
    }

}

