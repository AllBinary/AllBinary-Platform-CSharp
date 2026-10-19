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
using Notification = android.app.Notification;
using NotificationManager = android.app.NotificationManager;
using PendingIntent = android.app.PendingIntent;
using Context = android.content.Context;
using Intent = android.content.Intent;
using AndroidInfoFactory = org.allbinary.android.AndroidInfoFactory;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.content;

public class NotificationUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly NotificationUtil SINGLETON = new NotificationUtil();
    private NotificationManager notificationManager = ((NotificationManager) ResourceUtil.getInstance().getContext().getSystemService(Context.NOTIFICATION_SERVICE));
    public static NotificationUtil getInstance()
    {
        return NotificationUtil.SINGLETON;
    }

    private readonly NotificationBuilder notificationBuilder = null;
    private NotificationUtil()
    {
        int SDK_VERSION = AndroidInfoFactory.getInstance().getVersion();
        if (SDK_VERSION > 22) {
            this.notificationBuilder = new NotificationBuilderAPI23();
        } else {
            this.notificationBuilder = NotificationBuilder.NULL_NOTIFICATION_BUILDER;
        }
    }

    public virtual void notify(Command command, string resource, string message)
    {
        Context context = ResourceUtil.getInstance().getContext();
        Intent intent = CommandUriAction.getInstance().getIntent(command);
        int? integer = ResourceUtil.getInstance().getResourceId(resource);
        int FLAG_IMMUTABLE = 1 << 26;
        int SDK_VERSION = AndroidInfoFactory.getInstance().getVersion();
        PendingIntent pendingIntent = PendingIntent.getActivity(context, 0, intent, (SDK_VERSION > 22 ? FLAG_IMMUTABLE : 0));
        if (this.notificationBuilder == null) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.EXCEPTION, this, commonStrings.NOT_IMPLEMENTED);
            return;
        }
        this.notificationBuilder.build(context, command, message, integer, pendingIntent);
    }

}

