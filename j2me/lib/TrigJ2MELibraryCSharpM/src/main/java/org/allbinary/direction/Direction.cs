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

namespace org.allbinary.direction;

public class Direction
{
    private static Direction[] directionArray = new Direction[13];
    private string name;
    private string otherName;
    private int value;
    private int frameFactor;
    public Direction(string name, string otherName, int value, int frameFactor)
    {
        this.name = name;
        this.otherName = otherName;
        this.value = value;
        this.frameFactor = frameFactor;
        Direction.directionArray[value] = this;
    }

    public static Direction getInstance(int direction)
    {
        return Direction.directionArray[direction];
    }

    public virtual int getValue()
    {
        return this.value;
    }

    public virtual int getFrameFactor()
    {
        return this.frameFactor;
    }

    public virtual string getOtherName()
    {
        return this.otherName;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Direction: ");
        stringBuffer.append(this.getName());
        stringBuffer.append(" Or: ");
        stringBuffer.append(this.getOtherName());
        stringBuffer.append(" Value: ");
        stringBuffer.appendint(this.value);
        return stringBuffer.ToString();
    }

}

