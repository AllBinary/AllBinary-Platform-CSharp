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
//using Canvas = javax.microedition.lcdui.Canvas;
using GameKey = org.allbinary.game.input.GameKey;
using GameKeyFactory = org.allbinary.game.input.GameKeyFactory;
using Input = org.allbinary.game.input.Input;
using InputFactory = org.allbinary.game.input.InputFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input.mapping;

public class InputToGameKeyMapping : InputMapping
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static InputToGameKeyMapping getNullInstance()
    {
        if (InputToGameKeyMapping.instance == NullUtil.getInstance().NULL_OBJECT) {
            InputToGameKeyMapping.instance = new InputToGameKeyMapping();
        }
        return ((InputToGameKeyMapping) InputToGameKeyMapping.instance);
    }

    private readonly GameKeyFactory gameKeyFactory = GameKeyFactory.getInstance();
    private readonly GameKey[] mappedGameKeys;
    private readonly GameKey[] platformToGameKeyMapping = new GameKey[InputFactory.getInstance().MAX];
    public GameKey[] negativePlatformToGameKeyMapping = new GameKey[0];
    public InputToGameKeyMapping()
    {
        this.mappedGameKeys = new GameKey[] { this.gameKeyFactory.UP, this.gameKeyFactory.DOWN, this.gameKeyFactory.LEFT, this.gameKeyFactory.RIGHT };
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.clear();
    }

    private void clear()
    {
        for (int index = this.platformToGameKeyMapping.Length - 1; index >= 0; index--) {
            this.platformToGameKeyMapping[index] = this.gameKeyFactory.NONE;
        }
    }

    protected override void removeAll()
    {
        base.removeAll();
        this.clear();
    }

    public override void addMapping(InputToGameKeyMapping inputToGameKeyMapping)
    {
        for (int index = inputToGameKeyMapping.getMaxMappable() - 1; index >= 0; index--) {
            Input input = inputToGameKeyMapping.getInstance(index);
            if (input != this.gameKeyFactory.NONE) {
                this.addAll(input, inputToGameKeyMapping.getMappedInput(input));
            }
        }
    }

    private void addAll(Input input, BasicArrayList list)
    {
        for (int index = list.size() - 1; index >= 0; index--) {
            Input mappedToInput = ((Input) list.objectArray[index]);
            this.add(input, mappedToInput);
        }
    }

    public override void add(Input input, Input mappedToInput)
    {
        base.add(input, mappedToInput);
        this.set(input, mappedToInput);
    }

    public override void remove(Input input, Input mappedToInput)
    {
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().START_LABEL).append(StringUtil.getInstance().toString(input)).append(" == ").append(StringUtil.getInstance().toString(mappedToInput)).ToString(), this, "InputToGameKeyMapping::remove");
        base.remove(input, mappedToInput);
        this.set(input, this.gameKeyFactory.NONE);
    }

    private void set(Input input, Input mappedToInput)
    {
        int id = mappedToInput.getId();
        if (id >= 0 && id < this.platformToGameKeyMapping.Length) {
            this.platformToGameKeyMapping[id] = ((GameKey) input);
        }
    }

    public virtual int getMaxMappable()
    {
        return this.platformToGameKeyMapping.Length;
    }

    public virtual BasicArrayList getReverseInstance(int id)
    {
        BasicArrayList list = new BasicArrayListD();
        InputFactory inputFactory = InputFactory.getInstance();
        for (int index = 0; index < this.platformToGameKeyMapping.Length; index++) {
            if (this.platformToGameKeyMapping[index].getId() == id) {
                Input input = inputFactory.getInstanceById(index);
                if (input != null) {
                    list.add(input);
                }
            }
        }
        return list;
    }

    // throws Exception
    private void initGameKey(Canvas canvas, GameKey gameKey)
    {
        int key = canvas.getKeyCode(gameKey.getId());
        if (key < 0 && -key < this.negativePlatformToGameKeyMapping.Length) {
            this.negativePlatformToGameKeyMapping[-key] = gameKey;
        } else if (key > 0) {
            if (this.platformToGameKeyMapping[key] == this.gameKeyFactory.NONE) {
                this.platformToGameKeyMapping[key] = gameKey;
            }
        } else {
            PreLogUtil.putOE(new StringMaker().append(gameKey.ToString()).append(CommonSeps.getInstance().COLON_SEP).appendint(key).ToString(), this, this.commonStrings.INIT, new Exception());
        }
    }

    // throws Exception
    private int getSmallestCanvasGameKeyCode(Canvas canvas)
    {
        int nextKey = 0;
        int smallestKey = 0;
        for (int index = this.mappedGameKeys.Length; --index >= 0; ) {
            nextKey = canvas.getKeyCode(this.mappedGameKeys[index].getId());
            if (nextKey < smallestKey) {
                smallestKey = nextKey;
            }
        }
        return smallestKey;
    }

    public virtual void init(Canvas canvas)
    {
        try {
            GameKey[] negativePlatformToGameKeyMapping = new GameKey[0];
            int smallestKey = this.getSmallestCanvasGameKeyCode(canvas);
            if (smallestKey < 0) {
                smallestKey--;
                if (smallestKey < -256) {
                    smallestKey = -256;
                }
                negativePlatformToGameKeyMapping = new GameKey[-smallestKey];
                for (int index = negativePlatformToGameKeyMapping.Length; --index >= 0; ) {
                    negativePlatformToGameKeyMapping[index] = this.gameKeyFactory.NONE;
                }
                this.negativePlatformToGameKeyMapping = negativePlatformToGameKeyMapping;
            }
            for (int index = this.mappedGameKeys.Length; --index >= 0; ) {
                this.initGameKey(canvas, this.mappedGameKeys[index]);
            }
        } catch (Exception t) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.INIT, t);
        }
    }

    public virtual GameKey getInstanceForCanvas(Canvas canvas, int id)
    {
        if (id >= 0 && id < this.platformToGameKeyMapping.Length) {
            return this.platformToGameKeyMapping[id];
        } else if (id < 0 && -id < this.negativePlatformToGameKeyMapping.Length) {
            return this.negativePlatformToGameKeyMapping[-id];
        } else {
            return this.gameKeyFactory.NONE;
        }
    }

    public virtual GameKey getInstance(int id)
    {
        if (id >= 0 && id < this.platformToGameKeyMapping.Length) {
            return this.platformToGameKeyMapping[id];
        } else if (id < 0 && -id < this.negativePlatformToGameKeyMapping.Length) {
            return this.negativePlatformToGameKeyMapping[-id];
        } else {
            return this.gameKeyFactory.NONE;
        }
    }

}

