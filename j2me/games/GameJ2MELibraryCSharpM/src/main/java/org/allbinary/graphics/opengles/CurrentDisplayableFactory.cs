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
//using Displayable = javax.microedition.lcdui.Displayable;
using J2MEUtil = org.allbinary.J2MEUtil;
using Features = org.allbinary.game.configuration.feature.Features;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using DemoCanvas = org.allbinary.game.displayable.canvas.DemoCanvas;
using GameInputMappingCanvas = org.allbinary.game.displayable.canvas.GameInputMappingCanvas;
using GameInputMappingInstructionsCanvas = org.allbinary.game.displayable.canvas.GameInputMappingInstructionsCanvas;
using GameRunnable = org.allbinary.game.displayable.canvas.GameRunnable;
using NullDisplayable = org.allbinary.game.displayable.canvas.NullDisplayable;
using NullWaitGameRunnable = org.allbinary.game.displayable.canvas.NullWaitGameRunnable;
using SWTUtil = org.allbinary.game.layer.SWTUtil;
using HighScoresCanvas = org.allbinary.game.score.displayable.HighScoresCanvas;
using GraphicsStrings = org.allbinary.graphics.GraphicsStrings;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using NullRunnable = org.allbinary.thread.NullRunnable;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.opengles;

public class CurrentDisplayableFactory
{
    private static readonly CurrentDisplayableFactory instance = new CurrentDisplayableFactory();
    public static CurrentDisplayableFactory getInstance()
    {
        return CurrentDisplayableFactory.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CanvasStrings canvasStrings = CanvasStrings.getInstance();
    private readonly StringUtil stringUtil = StringUtil.getInstance();
    private readonly string SET_DISPLAYABLE = "setDisplayable";
    private readonly string SET_RUNNABLE = "setRunnable";
    private readonly string CLEAR_RUNNABLE = "clearRunnable";
    private readonly string SET_USED_RUNNABLE = "setUsedRunnable";
    private readonly string RUNNABLE = "Runnable: ";
    private readonly string RUNNABLE_WAS_ALREADY_IN_USE = "Runnable was already in use: ";
    public readonly BasicArrayList DEFAULT_CHILD_NAME_LIST = new BasicArrayListD();
    private Displayable displayable = NullDisplayable.getInstance();
    private Displayable openGlReadydisplayable = NullDisplayable.getInstance();
    private GameRunnable runnable = NullWaitGameRunnable.getInstance();
    private GameRunnable usedRunnable = NullWaitGameRunnable.getInstance();
    private CurrentDisplayableFactory()
    {
        this.DEFAULT_CHILD_NAME_LIST.add(this.canvasStrings.ABOUT);
        this.DEFAULT_CHILD_NAME_LIST.add(this.canvasStrings.OPTIONS);
        this.DEFAULT_CHILD_NAME_LIST.add(GameInputMappingCanvas.NAME);
        this.DEFAULT_CHILD_NAME_LIST.add(GameInputMappingInstructionsCanvas.NAME);
        this.DEFAULT_CHILD_NAME_LIST.add(HighScoresCanvas.NAME);
    }

    public virtual void setMyCanvas(MyCanvas displayable)
    {
        if (this.displayable is MyCanvas) {
            if (displayable.hasChild(((MyCanvas) this.displayable))) {
                PreLogUtil.put(new StringMaker().append("Child Displayable is already set for: ").append(this.stringUtil.toString(displayable)).ToString(), this, this.SET_DISPLAYABLE);
                return;
            }
        }
        this.setDisplayable(displayable);
    }

    public virtual void setDisplayable(Displayable displayable)
    {
        this.displayable = displayable;
        this.setOpenGlReadydisplayable(displayable);
    }

    public virtual void setOpenGlReadydisplayable(Displayable openGlReadydisplayable)
    {
        this.openGlReadydisplayable = openGlReadydisplayable;
        this.update();
    }

    public virtual Displayable getOpenGlReadydisplayable()
    {
        return this.openGlReadydisplayable;
    }

    public virtual void setRunnable(GameRunnable runnable)
    {
        PreLogUtil.put(new StringMaker().append(this.RUNNABLE).append(this.stringUtil.toString(runnable)).ToString(), this, this.SET_RUNNABLE);
        this.runnable = runnable;
        if (this.usedRunnable != this.runnable) {
            this.update();
        } else {
            PreLogUtil.put(new StringMaker().append(this.RUNNABLE_WAS_ALREADY_IN_USE).append(this.stringUtil.toString(runnable)).ToString(), this, this.SET_RUNNABLE);
        }
    }

    public virtual void clearRunnable()
    {
        PreLogUtil.put(new StringMaker().append(this.RUNNABLE).append(this.stringUtil.toString(NullRunnable.getInstance())).ToString(), this, this.CLEAR_RUNNABLE);
        this.setUsedRunnable(NullWaitGameRunnable.getInstance());
    }

    private void update()
    {
        lock (this) {
            CommonSeps commonSeps = CommonSeps.getInstance();
            Features features = Features.getInstance();
            StringMaker stringMaker = new StringMaker();
            stringMaker.append(this.stringUtil.toString(this.openGlReadydisplayable));
            if (SWTUtil.isSWT && !features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL)) {
                PreLogUtil.put(stringMaker.append(commonSeps.SPACE).append(SWTUtil.SWT).append(commonSeps.SPACE).append(this.RUNNABLE).append(this.stringUtil.toString(NullRunnable.getInstance())).ToString(), this, this.commonStrings.UPDATE);
                this.setUsedRunnable(NullWaitGameRunnable.getInstance());
            } else if (J2MEUtil.isHTML()) {
                PreLogUtil.put(stringMaker.append(commonSeps.SPACE).append(GraphicsStrings.getInstance().HTML).append(commonSeps.SPACE).append(this.RUNNABLE).append(this.stringUtil.toString(this.runnable)).ToString(), this, this.commonStrings.UPDATE);
                this.setUsedRunnable(this.runnable);
            } else if (this.openGlReadydisplayable is DemoCanvas || this.openGlReadydisplayable is AllBinaryGameCanvas || features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL)) {
                PreLogUtil.put(stringMaker.append(commonSeps.SPACE).append(OpenGLFeatureFactory.getInstance().OPENGL.ToString()).append(commonSeps.SPACE).append(this.RUNNABLE).append(this.stringUtil.toString(this.runnable)).ToString(), this, this.commonStrings.UPDATE);
                this.setUsedRunnable(this.runnable);
            } else {
                PreLogUtil.put(stringMaker.append(this.RUNNABLE).append(this.stringUtil.toString(NullRunnable.getInstance())).ToString(), this, this.commonStrings.UPDATE);
                this.setUsedRunnable(NullWaitGameRunnable.getInstance());
            }
        }
    }

    public virtual Displayable getDisplayable()
    {
        return this.displayable;
    }

    public virtual GameRunnable getUsedRunnable()
    {
        return this.usedRunnable;
    }

    public virtual void setUsedRunnable(GameRunnable usedRunnable)
    {
        PreLogUtil.put(new StringMaker().append(this.RUNNABLE).append(this.stringUtil.toString(this.runnable)).append(CommonSeps.getInstance().COLON_SEP).append(this.stringUtil.toString(usedRunnable)).ToString(), this, this.SET_USED_RUNNABLE);
        this.usedRunnable = usedRunnable;
    }

}

