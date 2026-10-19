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
using GameKey = org.allbinary.game.input.GameKey;
using GameKeyEventSourceInterface = org.allbinary.game.input.GameKeyEventSourceInterface;
using Input = org.allbinary.game.input.Input;
using InputFactory = org.allbinary.game.input.InputFactory;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using InputToGameKeyMapping = org.allbinary.game.input.mapping.InputToGameKeyMapping;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.motion.button;

public class TouchButtonInput : Input, GameKeyEventSourceInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly GameKeyEventFactory gameKeyEventFactory = GameKeyEventFactory.getInstance();
    private readonly int TOUCH_BUTTON_SOURCE_ID;
    private GameKeyEvent gameKeyEvent = GameKeyEvent.NONE;
    public TouchButtonInput(int id, string name) : base(id, name)
    {
        this.TOUCH_BUTTON_SOURCE_ID = this.gameKeyEventFactory.TOUCH_BUTTON_SOURCE_ID;
        // base(id, name) is called from the constructor declaration
        InputFactory inputFactory = InputFactory.getInstance();
        inputFactory.add(this.getId(), this);
    }

    public virtual void update(InputToGameKeyMapping inputToGameKeyMapping)
    {
        try {
            GameKey gameKey = inputToGameKeyMapping.getInstance(this.getId());
            this.gameKeyEvent = this.gameKeyEventFactory.getInstanceForInput(this, gameKey);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.UPDATE, e);
        }
    }

    public override int getSourceId()
    {
        return this.TOUCH_BUTTON_SOURCE_ID;
    }

    public virtual GameKeyEvent getGameKeyEvent()
    {
        return this.gameKeyEvent;
    }

}

