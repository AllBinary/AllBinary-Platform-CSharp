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
using InputFactory = org.allbinary.game.input.InputFactory;
using InputToGameKeyMapping = org.allbinary.game.input.mapping.InputToGameKeyMapping;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.input.motion.button;

public class BasicTouchInputFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static BasicTouchInputFactory getInstance()
    {
        if (BasicTouchInputFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            BasicTouchInputFactory.instance = new BasicTouchInputFactory();
        }
        return ((BasicTouchInputFactory) BasicTouchInputFactory.instance);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly TouchButtonInput SPECIAL_BUTTON_SEVEN_TESTING_ONLY;
    public readonly TouchButtonInput SPECIAL_BUTTON_EIGHT_TESTING_ONLY;
    public readonly TouchButtonInput SPECIAL_BUTTON_SIX;
    public readonly TouchButtonInput SPECIAL_BUTTON_FIVE;
    public readonly TouchButtonInput SPECIAL_BUTTON_FOUR;
    public readonly TouchButtonInput SPECIAL_BUTTON_THREE;
    public readonly TouchButtonInput SPECIAL_BUTTON_TWO;
    public readonly TouchButtonInput SPECIAL_BUTTON_ONE;
    public readonly TouchButtonInput UP;
    public readonly TouchButtonInput LEFT;
    public readonly TouchButtonInput RIGHT;
    public readonly TouchButtonInput DOWN;
    public readonly TouchButtonInput NONE;
    private bool initialized = false;
    private readonly BasicArrayList list = new BasicArrayListD();
    private BasicTouchInputFactory()
    {
        int MAX = InputFactory.getInstance().MAX;
        this.SPECIAL_BUTTON_SEVEN_TESTING_ONLY = new TouchButtonInput(MAX - 41, "Button 7 - Testing Only May Cross Over Key Values");
        this.SPECIAL_BUTTON_EIGHT_TESTING_ONLY = new TouchButtonInput(MAX - 42, "Button 8 - Testing Only May Cross Over Key Values");
        this.SPECIAL_BUTTON_SIX = new TouchButtonInput(MAX - 30, "Button 6");
        this.SPECIAL_BUTTON_FIVE = new TouchButtonInput(MAX - 31, "Button 5");
        this.SPECIAL_BUTTON_FOUR = new TouchButtonInput(MAX - 32, "Button 4");
        this.SPECIAL_BUTTON_THREE = new TouchButtonInput(MAX - 33, "Button 3");
        this.SPECIAL_BUTTON_TWO = new TouchButtonInput(MAX - 34, "Button 2");
        this.SPECIAL_BUTTON_ONE = new TouchButtonInput(MAX - 35, "Button 1");
        this.UP = new TouchButtonInput(MAX - 36, "Up Button");
        this.LEFT = new TouchButtonInput(MAX - 37, "Left Button");
        this.RIGHT = new TouchButtonInput(MAX - 38, "Right Button");
        this.DOWN = new TouchButtonInput(MAX - 39, "Down Button");
        this.NONE = new TouchButtonInput(MAX - 40, "No Button");
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void init(InputToGameKeyMapping inputToGameKeyMapping)
    {
        if (!this.initialized) {
            this.initialized = true;
            this.list.add(this.UP);
            this.list.add(this.LEFT);
            this.list.add(this.RIGHT);
            this.list.add(this.DOWN);
            this.list.add(this.SPECIAL_BUTTON_TWO);
            this.list.add(this.SPECIAL_BUTTON_FOUR);
            this.list.add(this.SPECIAL_BUTTON_THREE);
            this.list.add(this.SPECIAL_BUTTON_ONE);
            this.list.add(this.SPECIAL_BUTTON_FIVE);
            this.list.add(this.SPECIAL_BUTTON_SIX);
            this.list.add(this.SPECIAL_BUTTON_SIX);
            this.list.add(this.SPECIAL_BUTTON_SEVEN_TESTING_ONLY);
            this.list.add(this.SPECIAL_BUTTON_EIGHT_TESTING_ONLY);
            this.updateAllFromList(this.list, inputToGameKeyMapping);
        }
    }

    public virtual void updateAll(InputToGameKeyMapping inputToGameKeyMapping)
    {
        this.updateAllFromList(this.list, inputToGameKeyMapping);
    }

    public virtual void updateAllFromList(BasicArrayList list, InputToGameKeyMapping inputToGameKeyMapping)
    {
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().START_LABEL).appendint(list.size()).ToString(), this, "updateAll");
        TouchButtonInput touchButtonInput = null;
        for (int index = list.size() - 1; index >= 0; index--) {
            touchButtonInput = ((TouchButtonInput) list.objectArray[index]);
            touchButtonInput.update(inputToGameKeyMapping);
        }
    }

    public virtual BasicArrayList getList()
    {
        return this.list;
    }

}

