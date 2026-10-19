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
using ClientInformationFactory = org.allbinary.logic.system.security.licensing.ClientInformationFactory;
using LicenseServerInitFileUtil = org.allbinary.logic.system.security.licensing.LicenseServerInitFileUtil;

namespace org.allbinary.game.midlet;

public class SpecialDemoGameMidlet : DemoGameMidlet
{
    public SpecialDemoGameMidlet(ClientInformationFactory clientInformationFactory, LicenseLoadingType licenseLoadingType, LicensedDemoSetupFactory demoSetupFactory, LicenseCheckRunnableFactory licenseCheckRunnableFactory) : base(clientInformationFactory)
    {
        // base(clientInformationFactory) is called from the constructor declaration
    }

    public virtual void initView()
    {
    }

    public override void preInit()
    {
        new LicenseServerInitFileUtil().init();
    }

}

