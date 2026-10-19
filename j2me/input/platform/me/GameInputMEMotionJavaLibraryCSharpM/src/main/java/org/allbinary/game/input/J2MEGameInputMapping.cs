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
using GamePersistanceStrings = org.allbinary.game.configuration.persistance.GamePersistanceStrings;
using PersistentInputMapping = org.allbinary.game.input.mapping.PersistentInputMapping;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.game.input;

public class J2MEGameInputMapping : PersistentInputMapping
{
    public J2MEGameInputMapping() : base(GamePersistanceStrings.getInstance().SAVED_INPUT_CONFIGURATION_RECORD_ID)
    {
        // base(GamePersistanceStrings.getInstance().SAVED_INPUT_CONFIGURATION_RECORD_ID) is called from the constructor declaration
    }

    // throws Exception
    public override void init(AbeClientInformationInterface abeClientInformation)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.INIT);
        J2MEKeyFactory.getInstance().init();
        base.init(abeClientInformation);
        if (this.getTotalMapped() == 0 || this.isDefaultNew()) {
            this.getInputMapping().addMapping(this.getDefault());
            this.save(abeClientInformation);
        }
    }

    public override bool isDelete(Input input)
    {
        if (input == GameKeyFactory.getInstance().GAME_D) {
            return true;
        } else {
            return false;
        }
    }

    public override bool isSystemInput(Input input)
    {
        return false;
    }

}

