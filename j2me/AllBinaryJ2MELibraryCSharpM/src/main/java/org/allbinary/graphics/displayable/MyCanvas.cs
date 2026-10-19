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
//using Canvas = javax.microedition.lcdui.Canvas;
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Graphics = javax.microedition.lcdui.Graphics;
//using NullCommandListener = javax.microedition.lcdui.NullCommandListener;
using MyCommandInterface = org.allbinary.graphics.displayable.command.MyCommandInterface;
using MyCommandsFactory = org.allbinary.graphics.displayable.command.MyCommandsFactory;
using TouchJ2ME = org.allbinary.input.TouchJ2ME;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Sound = org.allbinary.media.audio.Sound;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.graphics.displayable;

public class MyCanvas : Canvas, DisplayableInterface, MyCommandInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly CanvasStrings canvasStrings = CanvasStrings.getInstance();
    public readonly StringUtil stringUtil = StringUtil.getInstance();
    public readonly DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
    private readonly string name;
    private readonly BasicArrayList childNameList;
    private readonly ABStack<object> commandStack;
    private CommandListener commandListener = NullCommandListener.NULL_COMMAND_LISTENER;
    private bool paused = false;
    public MyCanvas(string name, BasicArrayList childNameList)
    {
        this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, this.commonStrings.CONSTRUCTOR);
        this.displayInfo.update(this, this.canvasStrings.CONSTRUCTOR);
        this.name = name;
        this.childNameList = childNameList;
        this.commandStack = StdUtil.getInstance().createStack();
    }

    public override void setFullScreenMode(bool mode)
    {
        base.setFullScreenMode(mode);
        this.displayInfo.update(this, this.canvasStrings.SET_FULL_SCREEN_MODE);
    }

    protected override void sizeChanged(int w, int h)
    {
        this.displayInfo.update(this, this.canvasStrings.SIZE_CHANGED);
    }

    public virtual ABStack<object> getCommandStack()
    {
        return this.commandStack;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool isCommand(Command command)
    {
        return this.commandStack.contains(command);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void addCommand(Command command)
    {
        if (!this.commandStack.contains(command)) {
            this.commandStack.push(command);
            base.addCommand(command);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void removeCommand(Command command)
    {
        this.commandStack.removeElement(command);
        base.removeCommand(command);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void removeAllCommands()
    {
        int size = this.commandStack.size();
        for (int index = 0; index < size; index++) {
            base.removeCommand(((Command) this.commandStack.pop()));
        }
    }

    public override void setCommandListener(CommandListener l)
    {
        base.setCommandListener(l);
        this.commandListener = l;
    }

    public virtual CommandListener getCustomCommandListener()
    {
        return this.commandListener;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool isPaused()
    {
        return this.paused;
    }

    public virtual void removePauseCommand()
    {
        this.removeCommand(MyCommandsFactory.getInstance().PAUSE_COMMAND);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void pause()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.canvasStrings.PAUSE);
        this.removePauseCommand();
        this.addCommand(MyCommandsFactory.getInstance().RESUME_COMMAND);
        this.setPaused(true);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void unPause()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.canvasStrings.UN_PAUSE);
        this.removeCommand(MyCommandsFactory.getInstance().RESUME_COMMAND);
        this.addCommand(MyCommandsFactory.getInstance().PAUSE_COMMAND);
        this.setPaused(false);
    }

    // throws Exception
    protected virtual void process()
    {
        this.displayInfo.process();
    }

    protected override void paint(Graphics graphics)
    {
    }

    public virtual void draw(Graphics graphics)
    {
    }

    public virtual bool hasChild(MyCanvas displayable)
    {
        return this.childNameList.contains(displayable.name);
    }

    public virtual void destroy()
    {
        this.logUtil.putF("Destroyed MyCanvas", this, "destroy");
    }

    protected virtual void setPaused(bool isPaused)
    {
        this.paused = isPaused;
    }

    public virtual void keyPressedByDevice(int keyCode, int deviceId)
    {
    }

    public virtual void keyRepeatedByDevice(int keyCode, int deviceId)
    {
    }

    public virtual void keyReleasedByDevice(int keyCode, int deviceId)
    {
    }

    private readonly TouchJ2ME touchME = new TouchJ2ME();
    protected override void pointerDragged(int x, int y)
    {
        this.touchME.pointerDragged(x, y);
    }

    protected override void pointerPressed(int x, int y)
    {
        this.touchME.pointerPressed(x, y);
    }

    protected override void pointerReleased(int x, int y)
    {
        this.touchME.pointerReleased(x, y);
    }

    public virtual void nextSong(Sound nextSongSound, int leftVolume, int rightVolume)
    {
    }

}

