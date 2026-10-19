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
using System.Runtime.CompilerServices;

namespace org.allbinary.graphics.j2me.workarea.tools.@event;

public class MyGraphicItemEventService
{
    private static javax.swing.event.EventListenerList listenerList = new javax.swing.event.EventListenerList();
    public static string DELETE = "delete";
    public static string DESELECT = "deselect";
    public static string SELECT = "select";
    public static string DUPLICATE = "duplicate";
    public static string ROTATE = "rotate";
    private MyGraphicItemEventService()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void addListener(MyGraphicItemEventListener listener)
    {
        MyGraphicItemEventService.listenerList.add(((Type) listener.GetType()), ((java.util.EventListener) listener));
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void removeListener(MyGraphicItemEventListener listener)
    {
        MyGraphicItemEventService.listenerList.remove(((Type) listener.GetType()), ((java.util.EventListener) listener));
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void fire(MyGraphicItemEvent evt)
    {
        object[] listeners = listenerList.getListenerList();
        for (int i = 0; i < listeners.Length; i += 2) {
            if (listeners[i] == listeners[i + 1].GetType()) {
                if (evt.getCommand().compareTo(MyGraphicItemEventService.SELECT) == 0) {
                    (((MyGraphicItemEventListener) listeners[i + 1])).highlight(evt);
                } else if (evt.getCommand().compareTo(MyGraphicItemEventService.DESELECT) == 0) {
                    (((MyGraphicItemEventListener) listeners[i + 1])).deselect(evt);
                } else if (evt.getCommand().compareTo(MyGraphicItemEventService.DELETE) == 0) {
                    (((MyGraphicItemEventListener) listeners[i + 1])).delete(evt);
                } else if (evt.getCommand().compareTo(MyGraphicItemEventService.DUPLICATE) == 0) {
                    (((MyGraphicItemEventListener) listeners[i + 1])).duplicate(evt);
                } else if (evt.getCommand().compareTo(MyGraphicItemEventService.ROTATE) == 0) {
                    (((MyGraphicItemEventListener) listeners[i + 1])).rotate(evt);
                }
            }
        }
    }

}

