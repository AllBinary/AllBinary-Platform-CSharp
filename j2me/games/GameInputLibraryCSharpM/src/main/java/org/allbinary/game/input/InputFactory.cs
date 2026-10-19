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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.input;

public class InputFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static InputFactory getInstance()
    {
        if (InputFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            InputFactory.instance = new InputFactory();
        }
        return ((InputFactory) InputFactory.instance);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly string KEY_CODE_LABEL = "KeyCode: ";
    public readonly string DEVICE_ID_LABEL = "DeviceId: ";
    public readonly int MAX = SmallIntegerSingletonFactory.getInstance().getMin();
    public readonly Input[] inputIntegerArray;
    public readonly Input NO_INPUT;
    private InputFactory()
    {
        this.inputIntegerArray = new Input[this.MAX];
        this.NO_INPUT = new Input(0, this.commonStrings.UNKNOWN);
        int size = this.inputIntegerArray.Length;
        for (int index = 0; index < size; index++) {
            this.inputIntegerArray[index] = this.NO_INPUT;
        }
    }

    public virtual void add(int id, Input input)
    {
        this.inputIntegerArray[id] = input;
    }

    public virtual Input getInstanceById(int id)
    {
        if (id < 0) {
            id = -id;
        }
        if (id > this.inputIntegerArray.Length) {
            this.logUtil.putF(new StringMaker().append("Warning id: ").appendint(id).ToString(), this, this.commonStrings.GET_INSTANCE);
            return this.NO_INPUT;
        }
        return this.inputIntegerArray[id];
    }

}

