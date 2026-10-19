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
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.logic.math;

public class MathData
{
    private static readonly MathData instance = new MathData();
    public static MathData getInstance()
    {
        return MathData.instance;
    }

    public readonly string EQUALS;
    public readonly string PLUS = "+";
    public readonly string GREATER_THAN = ">";
    public readonly string MINUS;
    public readonly string DIVIDE;
    public readonly string MULTIPLY;
    private MathData()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        this.EQUALS = commonSeps.EQUALS;
        this.MINUS = commonSeps.DASH;
        this.DIVIDE = commonSeps.FORWARD_SLASH;
        this.MULTIPLY = CommonPhoneStrings.getInstance().STAR;
    }

}

