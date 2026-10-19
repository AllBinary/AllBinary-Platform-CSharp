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
using NullUtil = org.allbinary.logic.NullUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.input.@event;

public class GameKeyEvent : AllBinaryEventObject
{
    public static GameKeyEvent createEvent(object anyType, int sourceId, int key)
    {
        return new GameKeyEvent(anyType, sourceId, 0, 0, key, false);
    }

    public static readonly GameKeyEvent NONE = new GameKeyEvent(NullUtil.getInstance().NULL_OBJECT, -1, -1, -1, -1, false);
    private readonly int sourceId;
    private bool repeated = false;
    private int key;
    private int gameActionKey = 0;
    private int originalKey = 0;
    public GameKeyEvent(object anyType, int sourceId, int originalKey, int gameActionKey, int key, bool repeated) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
        this.sourceId = sourceId;
        this.setOriginalKey(originalKey);
        this.key = key;
        this.setGameActionKey(gameActionKey);
        this.setRepeatEvents(repeated);
    }

    public virtual void init(object anyType)
    {
        this.setSource(anyType);
    }

    private void setRepeatEvents(bool repeated)
    {
        this.repeated = repeated;
    }

    public virtual bool hasRepeatEvents()
    {
        return this.repeated;
    }

    public virtual int getKey()
    {
        return this.key;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("\nKey: ");
        stringBuffer.appendint(this.getKey());
        return stringBuffer.ToString();
    }

    public virtual int getOriginalKey()
    {
        return this.originalKey;
    }

    public virtual void setOriginalKey(int originalKey)
    {
        this.originalKey = originalKey;
    }

    public virtual int getGameActionKey()
    {
        return this.gameActionKey;
    }

    public virtual void setGameActionKey(int gameActionKey)
    {
        this.gameActionKey = gameActionKey;
    }

    public virtual int getSourceId()
    {
        return this.sourceId;
    }

}

