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
using DisplayChangeEventHandler = org.allbinary.graphics.displayable.@event.DisplayChangeEventHandler;
using DisplayChangeEventListener = org.allbinary.graphics.displayable.@event.DisplayChangeEventListener;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.displayable;

public class GameLevelDisplayChangeEventListenersFactory
{
    private static readonly GameLevelDisplayChangeEventListenersFactory instance = new GameLevelDisplayChangeEventListenersFactory();
    public static GameLevelDisplayChangeEventListenersFactory getInstance()
    {
        return GameLevelDisplayChangeEventListenersFactory.instance;
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    public void add(DisplayChangeEventListener displayChangeEventListener)
    {
        this.list.add(displayChangeEventListener);
        DisplayChangeEventHandler.getInstance().addListenerInterface(displayChangeEventListener);
    }

    public void clear()
    {
        BasicEventHandler displayChangeEventHandler = DisplayChangeEventHandler.getInstance();
        DisplayChangeEventListener displayChangeEventListener = null;
        for (int index = this.list.size(); --index >= 0; ) {
            displayChangeEventListener = ((DisplayChangeEventListener) this.list.objectArray[index]);
            displayChangeEventHandler.removeListener(displayChangeEventListener);
        }
        this.list.clear();
    }

}

