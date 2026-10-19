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
//using CommandListener = javax.microedition.lcdui.CommandListener;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using CommandForm = org.allbinary.graphics.displayable.screen.CommandForm;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.configuration;

public class GameOptionsFormFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly GameOptionsFormFactory instance = new GameOptionsFormFactory();
    private GameOptionsFormFactory()
    {
    }

    public static GameOptionsFormFactory getInstance()
    {
        return GameOptionsFormFactory.instance;
    }

    public virtual CommandForm init(CommandListener commandListener, string title, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor)
    {
        try {
            return new GameOptionsForm(commandListener, title, backgrounBasicColor, foregroundBasicColor);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.INIT, e);
            return CommandForm.getNullCommandForm();
        }
    }

}

