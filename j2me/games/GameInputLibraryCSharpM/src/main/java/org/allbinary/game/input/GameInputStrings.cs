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

namespace org.allbinary.game.input;

public class GameInputStrings
{
    private static readonly GameInputStrings instance = new GameInputStrings();
    public static GameInputStrings getInstance()
    {
        return GameInputStrings.instance;
    }

    public readonly string PROCESS_INPUT = "processInput";
    public readonly string KEY_PRESSED = "keyPressed";
    public readonly string KEY_RELEASED = "keyReleased";
    public readonly string KEY_REPEATED = "keyRepeated";
    public readonly string ON_PRESS_GAME_KEY = "onPressGameKeyEvent";
    public readonly string ON_DOWN_GAME_KEY = "onDownGameKeyEvent";
    public readonly string ON_UP_GAME_KEY = "onUpGameKeyEvent";
    public readonly string NO_KEY = "Key Code Not Mapped For Game: ";
    public readonly string ADD_KEY_EVENT = "addGameKeyEvent";
    public readonly string REMOVE_KEY_EVENT = "removeGameKeyEvent";
    public readonly string STRAFE_LEFT = "strafeLeft";
    public readonly string STRAFE_RIGHT = "strafeRight";
    public readonly string PROCESS_MOTION_INPUT = "processMotionInput";
    public readonly string UDPATE_CURRENT_TOUCH_INPUT_FACTORY = "updateCurrentTouchInputFactory";
    public readonly string ENABLE_PLAYER_GAME_INPUTS = "Enabling PlayerGameInputs: ";
    public readonly string ENABLE_PLAYER_GAME_INPUT = "Enabling PlayerGameInput: ";
}

