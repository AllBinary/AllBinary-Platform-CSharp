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
using InputToGameKeyMapping = org.allbinary.game.input.mapping.InputToGameKeyMapping;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.input;

public class PlatformFormInputMappingFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static PlatformFormInputMappingFactory getInstance()
    {
        if (PlatformFormInputMappingFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            PlatformFormInputMappingFactory.instance = new PlatformFormInputMappingFactory();
        }
        return ((PlatformFormInputMappingFactory) PlatformFormInputMappingFactory.instance);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private InputToGameKeyMapping inputToGameKeyMapping = InputToGameKeyMapping.getNullInstance();
    public virtual InputToGameKeyMapping getOrCreate()
    {
        try {
            if (this.inputToGameKeyMapping == InputToGameKeyMapping.getNullInstance()) {
                PCKeyFactory pcKeyFactory = PCKeyFactory.getInstance();
                InputToGameKeyMapping inputToGameKeyMapping = new InputToGameKeyMapping();
                GameKeyFactory gameKeyFactory = GameKeyFactory.getInstance();
                inputToGameKeyMapping.add(gameKeyFactory.UP, pcKeyFactory.DPAD_UP);
                inputToGameKeyMapping.add(gameKeyFactory.DOWN, pcKeyFactory.DPAD_DOWN);
                inputToGameKeyMapping.add(gameKeyFactory.LEFT, pcKeyFactory.DPAD_LEFT);
                inputToGameKeyMapping.add(gameKeyFactory.RIGHT, pcKeyFactory.DPAD_RIGHT);
                inputToGameKeyMapping.add(gameKeyFactory.KEY_NUM1, pcKeyFactory.ENTER);
                this.inputToGameKeyMapping = inputToGameKeyMapping;
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
        }
        return this.inputToGameKeyMapping;
    }

}

