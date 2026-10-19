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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.layer.hud.@event;

public class GameNotificationEvent : AllBinaryEventObject
{
    private string @string = StringUtil.getInstance().EMPTY_STRING;
    private readonly int? seconds;
    private BasicColor basicColor = BasicColorFactory.getInstance().BLACK;
    private readonly bool? removeable;
    public GameNotificationEvent(object anyType, string @string, int? seconds, BasicColor basicColor, bool? permanent) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
        this.setString(@string);
        this.seconds = seconds;
        this.setBasicColorP(basicColor);
        this.removeable = permanent;
    }

    public virtual string getString()
    {
        return this.@string;
    }

    public virtual int? getSeconds()
    {
        return this.seconds;
    }

    public virtual BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

    public virtual bool? getPermanent()
    {
        return this.removeable;
    }

    public virtual void setString(string @string)
    {
        this.@string = @string;
    }

    public virtual void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
    }

}

