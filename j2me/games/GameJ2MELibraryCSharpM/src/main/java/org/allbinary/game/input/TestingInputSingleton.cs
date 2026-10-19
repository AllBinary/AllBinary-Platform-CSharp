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
//using Graphics = javax.microedition.lcdui.Graphics;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using AllBinaryGameLayer = org.allbinary.game.layer.AllBinaryGameLayer;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using ViewPosition = org.allbinary.view.ViewPosition;

namespace org.allbinary.game.input;

public class TestingInputSingleton : AllBinaryGameLayer, GameInputInterface
{
    private static readonly TestingInputSingleton instance = new TestingInputSingleton();
    public static TestingInputSingleton getInstance()
    {
        return TestingInputSingleton.instance;
    }

    public readonly GameInputProcessor[] inputProcessorArray = new GameInputProcessor[InputFactory.getInstance().MAX];
    private TestingInputSingleton() : base(StringUtil.getInstance().EMPTY_STRING, RectangleFactory.SINGLETON, ViewPosition.getInstanceD())
    {
        // base(StringUtil.getInstance().EMPTY_STRING, RectangleFactory.SINGLETON, ViewPosition.getInstanceD()) is called from the constructor declaration
        GameInputProcessorUtil.init(this.inputProcessorArray);
    }

    private PaintableInterface paintable = NullPaintable.getInstance();
    public override void initInputProcessors()
    {
    }

    public virtual void initInputProcessorsForTestInput(TestInputInterface aTestInputInterface)
    {
        TestInputInterface testInputInterface = aTestInputInterface;
        this.paintable = testInputInterface;
        this.inputProcessorArray[Canvas.UP] = new GameInputProcessor()
#if JAVA_ANONYMOUS_CLASS_BODY
            // throws Exception
            public virtual void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent)
            {
                testInputInterface.up();
            }

#endif
;
        this.inputProcessorArray[Canvas.DOWN] = new GameInputProcessor()
#if JAVA_ANONYMOUS_CLASS_BODY
            // throws Exception
            public virtual void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent)
            {
                testInputInterface.down();
            }

#endif
;
        this.inputProcessorArray[Canvas.LEFT] = new GameInputProcessor()
#if JAVA_ANONYMOUS_CLASS_BODY
            // throws Exception
            public virtual void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent)
            {
                testInputInterface.left();
            }

#endif
;
        this.inputProcessorArray[Canvas.RIGHT] = new GameInputProcessor()
#if JAVA_ANONYMOUS_CLASS_BODY
            // throws Exception
            public virtual void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent)
            {
                testInputInterface.right();
            }

#endif
;
        this.inputProcessorArray[Canvas.KEY_NUM7] = new GameInputProcessor()
#if JAVA_ANONYMOUS_CLASS_BODY
            // throws Exception
            public virtual void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent)
            {
                testInputInterface.strafeLeft();
            }

#endif
;
        this.inputProcessorArray[Canvas.KEY_NUM9] = new GameInputProcessor()
#if JAVA_ANONYMOUS_CLASS_BODY
            // throws Exception
            public virtual void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent)
            {
                testInputInterface.strafeRight();
            }

#endif
;
        GameInputProcessorUtil.init(this.inputProcessorArray);
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void processInputList(AllBinaryLayerManager allbinaryLayerManager, BasicArrayList list)
    {
        int key = 0;
        GameKeyEvent gameKeyEvent = null;
        int size = list.size();
        for (int index = 0; index < size; index++) {
            gameKeyEvent = (((GameKeyEvent) list.objectArray[index]));
            key = gameKeyEvent.getKey();
            this.inputProcessorArray[key].processEvent(allbinaryLayerManager, GameKeyEvent.NONE);
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void processInput(AllBinaryLayerManager allbinaryLayerManager)
    {
        this.processInputList(allbinaryLayerManager, this.getGameKeyEventList());
        this.getGameKeyEventList().clear();
    }

    public override void paint(Graphics graphics)
    {
        this.paintable.paint(graphics);
    }

    public override bool implmentsGameInputInterface()
    {
        return true;
    }

}

