/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using BasicHudFactory = org.allbinary.game.graphics.hud.BasicHudFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.ag.layer.hud.basic;

public class NumberStringHudFactory
{
    private static object instance = NullUtil.getInstance();
    public static NumberStringHudFactory getInstance()
    {
        if (NumberStringHudFactory.instance == NullUtil.getInstance()) {
            NumberStringHudFactory.instance = new NumberStringHudFactory();
        }
        return ((NumberStringHudFactory) NumberStringHudFactory.instance);
    }

    public virtual NumberStringHud createHud()
    {
        try {
            return new NumberStringHud(StringUtil.getInstance().EMPTY_STRING, 9, BasicHudFactory.getInstance().ABSOLUTE, 1, 0, BasicColorFactory.getInstance().NULL_COLOR);
        } catch (Exception e) {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
            throw new SystemException();
        }
    }

    public readonly NumberStringHud NULL_NUMBER_STRING_HUD;
    public NumberStringHudFactory()
    {
        this.NULL_NUMBER_STRING_HUD = this.createHud();
    }

}

