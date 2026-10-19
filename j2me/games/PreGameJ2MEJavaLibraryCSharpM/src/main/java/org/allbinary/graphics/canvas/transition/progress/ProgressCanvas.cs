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
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
//using NullCanvas = javax.microedition.lcdui.NullCanvas;
//using NullCommandListener = javax.microedition.lcdui.NullCommandListener;
using Processor = org.allbinary.canvas.Processor;
using RunnableCanvas = org.allbinary.canvas.RunnableCanvas;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using ABCustomGaugeItem = org.allbinary.graphics.form.item.ABCustomGaugeItem;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryMidlet = org.allbinary.midlet.AllBinaryMidlet;
using PathFindingThreadPool = org.allbinary.thread.PathFindingThreadPool;
using ThreadPool = org.allbinary.thread.ThreadPool;

namespace org.allbinary.graphics.canvas.transition.progress;

public class ProgressCanvas : RunnableCanvas, PaintableInterface, UpdateMyFontInterface
{
    public bool hasPainted = false;
    private readonly BasicColor backgroundBasicColor;
    public class ProgressPaintable : Paintable
    {
        public readonly ProgressCanvas progressCanvas;
        public ProgressPaintable(ProgressCanvas progressCanvas)
        {
            this.progressCanvas = progressCanvas;
        }

        public override void paint(Graphics graphics)
        {
            this.progressCanvas.paint2(graphics);
        }

    }
    public readonly Paintable GAUGE_PAINTABLE;
    private readonly float maxValue = 100.0f;
    public readonly ABCustomGaugeItem gauge;
    private readonly string TEXT;
    private readonly MyFontProcessor updateMyFontProcessor;
    private MyFontProcessor myFontProcessor;
    public AllBinaryMidlet allbinaryMidlet = AllBinaryMidlet.getNullInstance();
    private float value = 0f;
    private string text;
    private bool background = true;
    public PaintableInterface paintable;
    public bool inProgress = false;
    private readonly Processor IN_GAME_PROCESSOR = new Processor()
#if JAVA_ANONYMOUS_CLASS_BODY
        private readonly ThreadPool pathFindingThreadPool = PathFindingThreadPool.getInstance();
        // throws Exception
        public virtual void process()
        {
            this.pathFindingThreadPool.runAPriorityTask();
        }

#endif
;
    public Processor inGameProcessor = Processor.getInstance();
    public ProgressEndListener progressEndListener = ProgressEndListener.instance;
    public ProgressCanvas(string title, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(NullCommandListener.NULL_COMMAND_LISTENER, CanvasStrings.getInstance().EMPTY_CHILD_NAME_LIST, false)
    {
        this.GAUGE_PAINTABLE = new ProgressPaintable(this);
        this.TEXT = this.commonStrings.LOADING;
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        this.text = this.TEXT;
        this.paintable = this.GAUGE_PAINTABLE;
        // base(NullCommandListener.NULL_COMMAND_LISTENER, CanvasStrings.getInstance().EMPTY_CHILD_NAME_LIST, false) is called from the constructor declaration
        this.backgroundBasicColor = backgroundBasicColor;
        this.gauge = new ABCustomGaugeItem(StringUtil.getInstance().EMPTY_STRING, ((int) this.maxValue), 0, backgroundBasicColor, foregroundBasicColor);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.gauge.setHeight(font.getHeight() + 2);
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public virtual void init(AllBinaryMidlet gameMidlet)
    {
        this.allbinaryMidlet = gameMidlet;
    }

    // throws Exception
    public virtual void update(Graphics graphics)
    {
    }

    public override void initCommands(CommandListener cmdListener)
    {
    }

    protected float getMaxValue()
    {
        return this.maxValue;
    }

    public virtual void start()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.START_METHOD_NAME);
        this.setBackground(true);
        this.gauge.setHeight(30);
        this.gauge.setLabel(this.commonStrings.PLEASE_WAIT);
        this.setText(this.TEXT);
        this.setValue(0);
        this.inGameProcessor = Processor.getInstance();
        this.paintable = this.GAUGE_PAINTABLE;
        this.inProgress = true;
    }

    private readonly string backgroundLabel = "Background AI Game Loading...";
    private readonly string START_BACKGROUND = "startBackground";
    public virtual void startBackground(bool background)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.START_BACKGROUND);
        this.setBackground(background);
        this.myFontProcessor = this.updateMyFontProcessor;
        this.gauge.setLabel(this.backgroundLabel);
        this.setText(this.TEXT);
        this.setValue(0);
        this.inGameProcessor = Processor.getInstance();
        this.paintable = this.GAUGE_PAINTABLE;
    }

    public virtual void endActual()
    {
        this.allbinaryMidlet.commandAction(GameCommandsFactory.getInstance().SHOW_GAME_CANVAS, NullCanvas.NULL_CANVAS);
        this.inProgress = false;
        this.inGame();
    }

    public virtual void inGame()
    {
        this.progressEndListener.onEndEvent();
        this.inGameProcessor = this.IN_GAME_PROCESSOR;
    }

    public virtual void end()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.END_METHOD_NAME);
        this.gauge.setValue(this.getMaxValue());
        this.endActual();
        this.paintable = NullPaintable.getInstance();
    }

    public virtual void endFromInitialLazyLoadingComplete()
    {
        this.progressEndListener.onEndEvent();
        this.gauge.setValue(this.getMaxValue());
        this.inGameProcessor = this.IN_GAME_PROCESSOR;
    }

    public virtual bool isInGame()
    {
        if (this.inGameProcessor == this.IN_GAME_PROCESSOR) {
            return true;
        }
        return false;
    }

    public virtual void endIfPaintedSinceStart()
    {
    }

    public readonly string ADD_PORTION = "addPortion";
    public readonly string ADD_EARLY_PORTION = "addEarlyPortion";
    public virtual void addEarlyPortion(int value, string text, int index)
    {
        this.setText(new StringMaker().append(text).append(SmallIntegerSingletonFactory.getInstance().getAt(index).ToString()).ToString());
        this.gauge.setValue(this.gauge.getValue() + this.getMaxValue() / ((float) value));
    }

    public virtual void addPortion(int value, string text, int index)
    {
        this.setText(new StringMaker().append(text).append(SmallIntegerSingletonFactory.getInstance().getAt(index).ToString()).ToString());
        PreLogUtil.put(this.text, this, this.ADD_PORTION);
        this.gauge.setValue(this.gauge.getValue() + this.getMaxValue() / ((float) value));
    }

    public virtual void addNormalPortion(int value, string text)
    {
        if (this.text != text) {
            PreLogUtil.put(text, this, this.ADD_PORTION);
        }
        this.setText(text);
        this.gauge.setValue(this.gauge.getValue() + this.getMaxValue() / ((float) value));
    }

    protected virtual void setValue(int value)
    {
        this.value = ((float) value);
        this.gauge.setValue(((float) value));
    }

    public override void paint(Graphics graphics)
    {
        this.paintable.paint(graphics);
    }

    public virtual void paint2(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        graphics.setColor(((int) this.backgroundBasicColor));
        graphics.fillRect(0, 0, this.displayInfo.getLastWidth(), this.displayInfo.getLastHeight());
        this.gauge.paintXY(graphics, 0, 0);
        this.hasPainted = true;
    }

    public override void paintThreed(Graphics graphics)
    {
    }

    protected virtual float getValue()
    {
        return this.value;
    }

    public virtual void setText(string text)
    {
        this.text = text;
    }

    public virtual string getText()
    {
        return this.text;
    }

    protected virtual void setBackground(bool background)
    {
        this.background = background;
    }

    protected virtual bool isBackground()
    {
        return this.background;
    }

}

