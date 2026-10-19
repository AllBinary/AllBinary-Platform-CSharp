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
using NullParcelable = org.allbinary.android.NullParcelable;
//using Command = javax.microedition.lcdui.Command;
using PendingIntent = android.app.PendingIntent;
using Context = android.content.Context;
using Parcelable = android.os.Parcelable;

namespace org.allbinary.content;

public class NotificationBuilder
{
    public static readonly NotificationBuilder NULL_NOTIFICATION_BUILDER = new NotificationBuilder();
    public virtual Parcelable build(Context context, Command command, string message, int? integer, PendingIntent pendingIntent)
    {
        return NullParcelable.NULL_PARCELABLE;
    }

}

