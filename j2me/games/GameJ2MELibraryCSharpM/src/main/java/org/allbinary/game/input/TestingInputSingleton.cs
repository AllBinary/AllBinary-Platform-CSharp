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

extern alias GameLicensingNullJavaLibraryCSharp;
extern alias OpenGLNoneOtherJavaLibraryCSharp;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Canvas = javax.microedition.lcdui.Canvas;
using Graphics = javax.microedition.lcdui.Graphics;
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
        // Constructor invocation emitted in the initializer.
        GameInputProcessorUtil.init(this.inputProcessorArray);
    }

    private PaintableInterface testInputPaintable = NullPaintable.getInstance();
    public virtual void initInputProcessors()
    {
    }

    public virtual void initInputProcessorsForTestInput(TestInputInterface aTestInputInterface)
    {
        TestInputInterface testInputInterface = aTestInputInterface;
        this.testInputPaintable = testInputInterface;
        this.inputProcessorArray[Canvas.UP] = new __SwtClosure_N66430((__swtSelf_N66430, allbinaryLayerManager, gameKeyEvent) => {
                testInputInterface.up();
            });
        this.inputProcessorArray[Canvas.DOWN] = new __SwtClosure_N66578((__swtSelf_N66578, allbinaryLayerManager, gameKeyEvent) => {
                testInputInterface.down();
            });
        this.inputProcessorArray[Canvas.LEFT] = new __SwtClosure_N66726((__swtSelf_N66726, allbinaryLayerManager, gameKeyEvent) => {
                testInputInterface.left();
            });
        this.inputProcessorArray[Canvas.RIGHT] = new __SwtClosure_N66874((__swtSelf_N66874, allbinaryLayerManager, gameKeyEvent) => {
                testInputInterface.right();
            });
        this.inputProcessorArray[Canvas.KEY_NUM7] = new __SwtClosure_N67022((__swtSelf_N67022, allbinaryLayerManager, gameKeyEvent) => {
                testInputInterface.strafeLeft();
            });
        this.inputProcessorArray[Canvas.KEY_NUM9] = new __SwtClosure_N67170((__swtSelf_N67170, allbinaryLayerManager, gameKeyEvent) => {
                testInputInterface.strafeRight();
            });
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
        this.testInputPaintable.paint(graphics);
    }

    public override bool implmentsGameInputInterface()
    {
        return true;
    }

    private sealed class __SwtClosure_N66430 : GameInputProcessor
    {
        private readonly global::System.Action<__SwtClosure_N66430, AllBinaryLayerManager, GameKeyEvent> callback1;

        public __SwtClosure_N66430(global::System.Action<__SwtClosure_N66430, AllBinaryLayerManager, GameKeyEvent> callback1)
        {
            this.callback1 = callback1;
        }

        public override void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent) => callback1(this, allbinaryLayerManager, gameKeyEvent);
    }

    private sealed class __SwtClosure_N66578 : GameInputProcessor
    {
        private readonly global::System.Action<__SwtClosure_N66578, AllBinaryLayerManager, GameKeyEvent> callback1;

        public __SwtClosure_N66578(global::System.Action<__SwtClosure_N66578, AllBinaryLayerManager, GameKeyEvent> callback1)
        {
            this.callback1 = callback1;
        }

        public override void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent) => callback1(this, allbinaryLayerManager, gameKeyEvent);
    }

    private sealed class __SwtClosure_N66726 : GameInputProcessor
    {
        private readonly global::System.Action<__SwtClosure_N66726, AllBinaryLayerManager, GameKeyEvent> callback1;

        public __SwtClosure_N66726(global::System.Action<__SwtClosure_N66726, AllBinaryLayerManager, GameKeyEvent> callback1)
        {
            this.callback1 = callback1;
        }

        public override void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent) => callback1(this, allbinaryLayerManager, gameKeyEvent);
    }

    private sealed class __SwtClosure_N66874 : GameInputProcessor
    {
        private readonly global::System.Action<__SwtClosure_N66874, AllBinaryLayerManager, GameKeyEvent> callback1;

        public __SwtClosure_N66874(global::System.Action<__SwtClosure_N66874, AllBinaryLayerManager, GameKeyEvent> callback1)
        {
            this.callback1 = callback1;
        }

        public override void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent) => callback1(this, allbinaryLayerManager, gameKeyEvent);
    }

    private sealed class __SwtClosure_N67022 : GameInputProcessor
    {
        private readonly global::System.Action<__SwtClosure_N67022, AllBinaryLayerManager, GameKeyEvent> callback1;

        public __SwtClosure_N67022(global::System.Action<__SwtClosure_N67022, AllBinaryLayerManager, GameKeyEvent> callback1)
        {
            this.callback1 = callback1;
        }

        public override void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent) => callback1(this, allbinaryLayerManager, gameKeyEvent);
    }

    private sealed class __SwtClosure_N67170 : GameInputProcessor
    {
        private readonly global::System.Action<__SwtClosure_N67170, AllBinaryLayerManager, GameKeyEvent> callback1;

        public __SwtClosure_N67170(global::System.Action<__SwtClosure_N67170, AllBinaryLayerManager, GameKeyEvent> callback1)
        {
            this.callback1 = callback1;
        }

        public override void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent) => callback1(this, allbinaryLayerManager, gameKeyEvent);
    }

}

