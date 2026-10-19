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
using NullUtil = org.allbinary.logic.NullUtil;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;

namespace org.allbinary.game.input;

public class GameKeyFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameKeyFactory getInstance()
    {
        if (GameKeyFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            GameKeyFactory.instance = new GameKeyFactory();
        }
        return ((GameKeyFactory) GameKeyFactory.instance);
    }

    public readonly GameKey NONE = new GameKey(InputFactory.getInstance().MAX - 1, "None");
    public readonly GameKey UP = new GameKey(Canvas.UP, CommonPhoneStrings.getInstance().UP);
    public readonly GameKey DOWN = new GameKey(Canvas.DOWN, CommonPhoneStrings.getInstance().DOWN);
    public readonly GameKey LEFT = new GameKey(Canvas.LEFT, CommonPhoneStrings.getInstance().LEFT);
    public readonly GameKey RIGHT = new GameKey(Canvas.RIGHT, CommonPhoneStrings.getInstance().RIGHT);
    public readonly GameKey KEY_POUND = new GameKey(Canvas.KEY_POUND, "POUND");
    public readonly GameKey KEY_STAR = new GameKey(Canvas.KEY_STAR, "STAR");
    public readonly GameKey KEY_NUM0 = new GameKey(Canvas.KEY_NUM0, CommonPhoneStrings.getInstance().ZERO);
    public readonly GameKey KEY_NUM1 = new GameKey(Canvas.KEY_NUM1, CommonPhoneStrings.getInstance().ONE);
    public readonly GameKey KEY_NUM2 = new GameKey(Canvas.KEY_NUM2, CommonPhoneStrings.getInstance().TWO);
    public readonly GameKey KEY_NUM3 = new GameKey(Canvas.KEY_NUM3, CommonPhoneStrings.getInstance().THREE);
    public readonly GameKey KEY_NUM4 = new GameKey(Canvas.KEY_NUM4, CommonPhoneStrings.getInstance().FOUR);
    public readonly GameKey KEY_NUM5 = new GameKey(Canvas.KEY_NUM5, CommonPhoneStrings.getInstance().FIVE);
    public readonly GameKey KEY_NUM6 = new GameKey(Canvas.KEY_NUM6, CommonPhoneStrings.getInstance().SIX);
    public readonly GameKey KEY_NUM7 = new GameKey(Canvas.KEY_NUM7, CommonPhoneStrings.getInstance().SEVEN);
    public readonly GameKey KEY_NUM8 = new GameKey(Canvas.KEY_NUM8, CommonPhoneStrings.getInstance().EIGHT);
    public readonly GameKey KEY_NUM9 = new GameKey(Canvas.KEY_NUM9, CommonPhoneStrings.getInstance().NINE);
    public readonly GameKey GAME_A = new GameKey(Canvas.GAME_A, "Game A");
    public readonly GameKey GAME_B = new GameKey(Canvas.GAME_B, "Game B");
    public readonly GameKey GAME_C = new GameKey(Canvas.GAME_C, "Game C");
    public readonly GameKey GAME_D = new GameKey(Canvas.GAME_D, "Game D");
    public readonly GameKey FIRE = new GameKey(Canvas.FIRE, CommonPhoneStrings.getInstance().FIRE);
    public GameKey LEVEL_DOWN = new GameKey(Canvas.KEY_NUM9 + 1, "Cheat Level Up");
    public GameKey LEVEL_UP = new GameKey(Canvas.KEY_NUM9 + 2, "Cheat Level Down");
}

