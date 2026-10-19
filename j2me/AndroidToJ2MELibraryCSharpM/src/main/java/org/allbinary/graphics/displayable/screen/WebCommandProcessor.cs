/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2022 AllBinary
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
using Context = android.content.Context;
//using Canvas = javax.microedition.lcdui.Canvas;
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;
using Intent = android.content.Intent;
using TsUtil = org.allbinary.TsUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.displayable.screen;

public class WebCommandProcessor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly WebCommandProcessor instance = new WebCommandProcessor();
    public static WebCommandProcessor getInstance()
    {
        return WebCommandProcessor.instance;
    }

    private readonly AboutCommandProcessor aboutCommandProcessor = AboutCommandProcessor.getInstance();
    private readonly string WEB_VIEW_ACTIVITY = "org.allbinary.android.activity.WebViewActivity";
    public readonly BasicArrayList list = new BasicArrayListD();
    public virtual void process(CommandListener midletCommandListener, Command command, Canvas canvas)
    {
        try {
            Context context = ((Context) this.aboutCommandProcessor.getContext());
            Intent intent = new Intent(context, TsUtil.getInstance().getClassClassLoader(this).loadClass(this.WEB_VIEW_ACTIVITY));
            intent.putExtra(this.aboutCommandProcessor.URL, ((string) this.list.removeAt(0)));
            intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            context.startActivity(intent);
        } catch (ClassNotFoundException e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "process", e);
        }
    }

}

