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
using Init = org.allbinary.init.Init;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.configuration;

public class InGameOptionsFormFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static InGameOptionsFormFactory getInstance()
    {
        if (InGameOptionsFormFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            InGameOptionsFormFactory.instance = new InGameOptionsFormFactory();
        }
        return ((InGameOptionsFormFactory) InGameOptionsFormFactory.instance);
    }

    private CommandForm SINGLETON = CommandForm.getNullCommandForm();
    public virtual void init(CommandListener commandListener, Init initInterface, string title, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor)
    {
        try {
            if (this.SINGLETON == CommandForm.getNullCommandForm()) {
                initInterface.init();
                this.SINGLETON = new InGameOptionsForm(commandListener, title, backgrounBasicColor, foregroundBasicColor);
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.INIT, e);
        }
    }

    public virtual CommandForm get()
    {
        return this.SINGLETON;
    }

}

