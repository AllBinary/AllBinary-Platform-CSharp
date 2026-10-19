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

namespace org.allbinary.graphics.j2me.workarea.canvas.@event;

public class MyCanvasEventService
{
    private static javax.swing.event.EventListenerList listenerList = new javax.swing.event.EventListenerList();
    public static string DELETE = "delete";
    public static string DUPLICATE = "duplicate";
    public static string SELECT = "select";
    public static string ROTATE = "rotate";
    public static string EXPLODE = "explode";
    public static string AUTOEXPLODE = "autoExplode";
    public static string CENTER = "center";
    private MyCanvasEventService()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void addListener(MyCanvasEventListener listener)
    {
        MyCanvasEventService.listenerList.add(((Type) listener.GetType()), ((java.util.EventListener) listener));
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void removeListener(MyCanvasEventListener listener)
    {
        MyCanvasEventService.listenerList.remove(((Type) listener.GetType()), ((java.util.EventListener) listener));
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void fire(MyCanvasEvent evt)
    {
        object[] listeners = listenerList.getListenerList();
        for (int i = 0; i < listeners.Length; i += 2) {
            if (listeners[i] == listeners[i + 1].GetType()) {
                if (evt.getCommand().compareTo(MyCanvasEventService.DELETE) == 0) {
                    (((MyCanvasEventListener) listeners[i + 1])).delete(evt);
                } else if (evt.getCommand().compareTo(MyCanvasEventService.DUPLICATE) == 0) {
                    (((MyCanvasEventListener) listeners[i + 1])).duplicate(evt);
                } else if (evt.getCommand().compareTo(MyCanvasEventService.SELECT) == 0) {
                    (((MyCanvasEventListener) listeners[i + 1])).select(evt);
                } else if (evt.getCommand().compareTo(MyCanvasEventService.ROTATE) == 0) {
                    (((MyCanvasEventListener) listeners[i + 1])).rotate(evt);
                } else if (evt.getCommand().compareTo(MyCanvasEventService.EXPLODE) == 0) {
                    (((MyCanvasEventListener) listeners[i + 1])).explode(evt);
                } else if (evt.getCommand().compareTo(MyCanvasEventService.AUTOEXPLODE) == 0) {
                    (((MyCanvasEventListener) listeners[i + 1])).autoExplode(evt);
                } else if (evt.getCommand().compareTo(MyCanvasEventService.CENTER) == 0) {
                    (((MyCanvasEventListener) listeners[i + 1])).center(evt);
                }
            }
        }
    }

}

