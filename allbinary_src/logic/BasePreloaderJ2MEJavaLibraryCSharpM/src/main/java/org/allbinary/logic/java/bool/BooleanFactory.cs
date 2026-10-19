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

namespace org.allbinary.logic.java.@bool;

public class BooleanFactory
{
    private static readonly BooleanFactory instance = new BooleanFactory();
    public static BooleanFactory getInstance()
    {
        return BooleanFactory.instance;
    }

    public readonly bool? TRUE = true;
    public readonly bool? FALSE = false;
    public readonly string TRUE_STRING;
    public readonly string FALSE_STRING;
    public readonly string YES = "yes";
    public readonly string NO = "no";
    public virtual string toStringb(bool @bool)
    {
        if (@bool) {
            return this.TRUE_STRING;
        } else {
            return this.FALSE_STRING;
        }
    }

    public BooleanFactory()
    {
        this.TRUE_STRING = this.TRUE.ToString();
        this.FALSE_STRING = this.FALSE.ToString();
    }

}

