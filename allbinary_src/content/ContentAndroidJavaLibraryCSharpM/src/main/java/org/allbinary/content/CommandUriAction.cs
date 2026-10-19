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
//using Command = javax.microedition.lcdui.Command;
using Intent = android.content.Intent;
using Uri = android.net.Uri;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;

namespace org.allbinary.content;

public class CommandUriAction
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly CommandUriAction instance = new CommandUriAction();
    public static CommandUriAction getInstance()
    {
        return CommandUriAction.instance;
    }

    private ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    public virtual void add(Command command, string url)
    {
        this.hashtable.put(command, url);
    }

    public virtual void process(Command command)
    {
        try {
            Intent intent = this.getIntent(command);
            ResourceUtil.getInstance().getContext().startActivity(intent);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.PROCESS, e);
        }
    }

    public virtual Intent getIntent(Command command)
    {
        string url = ((string) this.hashtable.get(command));
        Uri uri = Uri.parse(url);
        Intent intent = new Intent(Intent.ACTION_VIEW, uri);
        return intent;
    }

}

