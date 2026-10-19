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
using Builder = android.app.Notification.Builder;
using PendingIntent = android.app.PendingIntent;
using Context = android.content.Context;
using Parcelable = android.os.Parcelable;

namespace org.allbinary.content;

public class NotificationBuilderAPI23 : NotificationBuilder
{
    public override Parcelable build(Context context, Command command, string message, int? integer, PendingIntent pendingIntent)
    {
        Notification notification = new Builder(context).setSmallIcon(((int) integer)).setTicker(message).setWhen(DateTimeOffset.Now.ToUnixTimeMilliseconds()).setContentTitle(command.getLabel()).setContentText(message).setContentIntent(pendingIntent).build();
        return notification;
    }

}

