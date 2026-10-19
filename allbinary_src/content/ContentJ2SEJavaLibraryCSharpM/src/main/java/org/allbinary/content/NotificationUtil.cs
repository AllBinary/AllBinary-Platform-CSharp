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
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using TsUtil = org.allbinary.TsUtil;

namespace org.allbinary.content;

public class NotificationUtil
{
    private static readonly NotificationUtil SINGLETON = new NotificationUtil();
    private NotificationManager notificationManager = ((NotificationManager) ResourceUtil.getInstance().getContext().getSystemService(Context.NOTIFICATION_SERVICE));
    public static NotificationUtil getInstance()
    {
        return NotificationUtil.SINGLETON;
    }

    public virtual void notify(Command command, string resource, string message)
    {
        Context context = ResourceUtil.getInstance().getContext();
        Intent intent = CommandUriAction.getInstance().getIntent(command);
        int? integer = ResourceUtil.getInstance().getResourceId(resource);
        Notification notification = new Notification(((int) integer), message, DateTimeOffset.Now.ToUnixTimeMilliseconds());
        PendingIntent pendingIntent = PendingIntent.getActivity(context, 0, intent, 0);
        notification.setLatestEventInfo(context, command.getLabel(), message, pendingIntent);
        this.notificationManager.notify(TsUtil.getInstance().hashCode(command), notification);
    }

}

