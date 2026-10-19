/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
 *  
 * By agreeing to this license you and any business entity you represent are 
 * legally bound to the AllBinary Open License Version 1 legal agreement. 
 *  
 * You may obtain the AllBinary Open License Version 1 legal agreement from 
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository. 
 *  
 * Created By: Travis Berthelot  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.layer.capital.@event;

public class CapitalEvent : AllBinaryEventObject
{
    private int value = 0;
    public CapitalEvent(object anyType) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("CapitalEvent: Value: \n");
        stringBuffer.appendint(this.getValue());
        return stringBuffer.ToString();
    }

    public virtual int getValue()
    {
        return this.value;
    }

    public virtual void setValue(int value)
    {
        this.value = value;
    }

}

