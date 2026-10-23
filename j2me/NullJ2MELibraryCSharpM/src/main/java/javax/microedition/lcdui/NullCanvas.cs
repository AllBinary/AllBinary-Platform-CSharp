// Generated Code Do Not Modify

using System;
using System.Linq;
using java.util;

namespace javax.microedition.lcdui;

public class NullCanvas : Canvas
{
    public static readonly NullCanvas NULL_CANVAS = new NullCanvas();
    public NullCanvas()
    {
    }

    public override void setFullScreenMode(bool mode)
    {
    }

    public override void sizeChanged(int w, int h)
    {
    }

    public virtual Stack<object> getCommandStack()
    {
        throw new SystemException();
    }

    public virtual bool isCommand(Command command)
    {
        throw new SystemException();
    }

    public override void addCommand(Command command)
    {
    }

    public override void removeCommand(Command command)
    {
    }

    public virtual void removeAllCommands()
    {
    }

    public override void setCommandListener(CommandListener l)
    {
    }

    public virtual CommandListener getCustomCommandListener()
    {
        throw new SystemException();
    }

    public virtual bool isPaused()
    {
        throw new SystemException();
    }

    public virtual void removePauseCommand()
    {
    }

    public virtual void pause()
    {
    }

    public virtual void unPause()
    {
    }

    // throws Exception
    public virtual void process()
    {
    }

    public override void paint(Graphics graphics)
    {
    }

    public virtual void destroy()
    {
    }

    public virtual void setPaused(bool isPaused)
    {
        throw new SystemException();
    }

    public override void pointerDragged(int x, int y)
    {
    }

    public override void pointerPressed(int x, int y)
    {
    }

    public override void pointerReleased(int x, int y)
    {
    }

}

