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
using PersistentInputMapping = org.allbinary.game.input.mapping.PersistentInputMapping;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.input;

public class PlatformInputMappingFactory
{
    private static readonly PlatformInputMappingFactory instance = new PlatformInputMappingFactory();
    public static PlatformInputMappingFactory getInstance()
    {
        return PlatformInputMappingFactory.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private PersistentInputMapping inputToGameKeyMapping = PersistentInputMapping.getNullInstance();
    public virtual PersistentInputMapping getPersistentInputMappingInstance()
    {
        try {
            if (this.inputToGameKeyMapping == PersistentInputMapping.getNullInstance()) {
                this.inputToGameKeyMapping = new LaptopGameInputMapping();
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
        }
        return this.inputToGameKeyMapping;
    }

}

