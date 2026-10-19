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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StdUtil = org.allbinary.logic.StdUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using org.allbinary.util;

namespace org.allbinary.game;

public class GameInfo
{
    public static readonly GameInfo NONE = new GameInfo(GameTypeFactory.getInstance().NONE, GameMode.NONE, PlayerTypesFactory.getInstance().PLAYER_TYPE_ONE, -1, -1);
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static readonly string LEVEL_NAME = "LEVEL";
    private readonly GameInfoData gameInfoData = GameInfoData.getInstance();
    private readonly GameType gameType;
    private readonly GameMode gameMode;
    private readonly PlayerType playerType;
    private int highestLevel = 0;
    private int currentLevel;
    public GameInfo(GameType gameType, GameMode gameMode, PlayerType playerType, int highestLevel, int currentLevel)
    {
        this.gameType = gameType;
        this.gameMode = gameMode;
        this.setHighestLevel(highestLevel);
        this.currentLevel = currentLevel;
        this.playerType = playerType;
    }

    public virtual GameType getGameType()
    {
        return this.gameType;
    }

    public virtual GameMode getGameMode()
    {
        return this.gameMode;
    }

    public virtual PlayerType getPlayerType()
    {
        return this.playerType;
    }

    public virtual int getHighestLevel()
    {
        return this.highestLevel;
    }

    public virtual void setHighestLevel(int highestLevel)
    {
        this.highestLevel = highestLevel;
    }

    public virtual int getCurrentLevel()
    {
        return this.currentLevel;
    }

    private readonly string NEW_LEVEL = "New Level: ";
    private readonly string SET_CURRENT_LEVEL = "setCurrentLevel";
    public virtual void setCurrentLevel(int currentLevel)
    {
        this.currentLevel = currentLevel;
        this.logUtil.putF(new StringMaker().append(this.NEW_LEVEL).appendint(this.getCurrentLevel()).ToString(), this, this.SET_CURRENT_LEVEL);
    }

    private readonly string NEXT_GAME_LEVEL = "nextGameLevel";
    public virtual void nextGameLevel()
    {
        if (this.getCurrentLevel() < this.getHighestLevel()) {
            this.currentLevel++;
        }
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().NEXT).append(CommonSeps.getInstance().SPACE).append(this.NEW_LEVEL).appendint(this.getCurrentLevel()).ToString(), this, this.NEXT_GAME_LEVEL);
    }

    public virtual void previousGameLevel()
    {
        if (this.getCurrentLevel() > 1) {
            this.currentLevel--;
        }
    }

    public virtual bool isLastLevel()
    {
        if (this.getCurrentLevel() >= this.getHighestLevel()) {
            return true;
        } else {
            return false;
        }
    }

    public virtual ABHashtable<object, object> toHashtable()
    {
        ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
        hashtable.put(this.gameInfoData.GAME_TYPE, this.getGameType().ToString());
        hashtable.put(this.gameInfoData.GAME_MODE, this.gameMode.ToString());
        hashtable.put(this.gameInfoData.PLAYER_TYPE, this.playerType.ToString());
        hashtable.put(this.gameInfoData.HIGHEST_LEVEL, (this.getHighestLevel()).ToString());
        hashtable.put(this.gameInfoData.CURRENT_LEVEL, (this.currentLevel).ToString());
        return hashtable;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        CommonSeps commonSeps = CommonSeps.getInstance();
        stringBuffer.append(this.gameInfoData.GAME_TYPE);
        stringBuffer.append(commonSeps.EQUALS);
        stringBuffer.append(this.getGameType().ToString());
        stringBuffer.append(commonSeps.COMMA_SEP);
        stringBuffer.append(this.gameInfoData.GAME_MODE);
        stringBuffer.append(commonSeps.EQUALS);
        stringBuffer.append(this.gameMode.ToString());
        stringBuffer.append(commonSeps.COMMA_SEP);
        stringBuffer.append(this.gameInfoData.PLAYER_TYPE);
        stringBuffer.append(commonSeps.EQUALS);
        stringBuffer.append(StringUtil.getInstance().toString(this.playerType));
        stringBuffer.append(commonSeps.COMMA_SEP);
        stringBuffer.append(this.gameInfoData.HIGHEST_LEVEL);
        stringBuffer.append(commonSeps.EQUALS);
        stringBuffer.appendint(this.getHighestLevel());
        stringBuffer.append(commonSeps.COMMA_SEP);
        stringBuffer.append(this.gameInfoData.CURRENT_LEVEL);
        stringBuffer.append(commonSeps.EQUALS);
        stringBuffer.appendint(this.currentLevel);
        return stringBuffer.ToString();
    }

}

