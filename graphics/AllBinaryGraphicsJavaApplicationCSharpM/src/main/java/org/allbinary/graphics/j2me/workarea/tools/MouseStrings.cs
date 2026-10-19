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
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class MouseStrings
{
    private static readonly MouseStrings instance = new MouseStrings();
    public static MouseStrings getInstance()
    {
        return MouseStrings.instance;
    }

    public readonly string MOUSE_PRESSED = "mousePressed";
    public readonly string MOUSE_RELEASED = "mouseReleased";
    public readonly string MOUSE_CLICKED = "mouseClicked";
    public readonly string MOUSE_DRAGGED = "mouseDragged";
    public readonly string MOUSE_MOVED = "mouseMoved";
    public readonly string MOUSE_PRESSED_LABEL = "MousePressed" + CommonSeps.getInstance().COLON_SEP;
    public readonly string MOUSE_RELEASED_LABEL = "MouseReleased" + CommonSeps.getInstance().COLON_SEP;
    public readonly string MOUSE_CLICKED_LABEL = "MouseClicked" + CommonSeps.getInstance().COLON_SEP;
    public readonly string MOUSE_DRAGGED_LABEL = "MouseDragged" + CommonSeps.getInstance().COLON_SEP;
    public readonly string MOUSE_MOVED_LABEL = "MouseMoved" + CommonSeps.getInstance().COLON_SEP;
}

