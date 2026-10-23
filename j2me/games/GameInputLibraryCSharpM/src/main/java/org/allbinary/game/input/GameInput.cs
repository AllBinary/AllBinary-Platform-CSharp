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
using Features = org.allbinary.game.configuration.feature.Features;
using InputFeatureFactory = org.allbinary.game.configuration.feature.InputFeatureFactory;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.input;

public class GameInput
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly BasicArrayList gameKeyEventList;
    private readonly BasicArrayList removalGameKeyEventList;
    public readonly bool isRemoveDuplicateKeyPresses;
    public GameInput(BasicArrayList gameKeyEventList, BasicArrayList removalGameKeyEventList)
    {
        this.gameKeyEventList = gameKeyEventList;
        this.removalGameKeyEventList = removalGameKeyEventList;
        this.isRemoveDuplicateKeyPresses = Features.getInstance().isFeature(InputFeatureFactory.getInstance().REMOVE_DUPLICATE_KEY_PRESSES);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void add(GameKeyEvent gameKeyEvent)
    {
        if (this.isRemoveDuplicateKeyPresses && this.gameKeyEventList.contains(gameKeyEvent)) {
            return;
        }
        if (gameKeyEvent != null) {
            this.gameKeyEventList.add(gameKeyEvent);
        } else {
            this.logUtil.putF("Danger Passed Null GameKeyEvent", this, this.commonStrings.ADD);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void addForRemoval(GameKeyEvent gameKeyEvent)
    {
        this.removalGameKeyEventList.add(gameKeyEvent);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool isForRemoval(GameKeyEvent gameKeyEvent)
    {
        return this.removalGameKeyEventList.contains(gameKeyEvent);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void clear()
    {
        this.gameKeyEventList.clear();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void removeNonAIInputGameKeyEvents()
    {
        BasicArrayList list = this.gameKeyEventList;
        GameKeyEvent gameKeyEvent = null;
        for (int index = list.size(); --index >= 0; ) {
            gameKeyEvent = ((GameKeyEvent) list.objectArray[index]);
            if (gameKeyEvent.getSourceId() != 1) {
                list.removeAt(index);
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void update()
    {
        BasicArrayList removeList = this.removalGameKeyEventList;
        BasicArrayList list = this.gameKeyEventList;
        int size = removeList.size();
        for (int index = 0; index < size; index++) {
            object anyType = removeList.objectArray[index];
            for (int index2 = list.size(); --index2 >= 0; ) {
                if (list.objectArray[index2] == anyType) {
                    list.removeAt(index2);
                }
            }
        }
        removeList.clear();
    }

    public virtual BasicArrayList getRemovalGameKeyEventList()
    {
        return this.removalGameKeyEventList;
    }

    public virtual BasicArrayList getGameKeyEventList()
    {
        return this.gameKeyEventList;
    }

}

