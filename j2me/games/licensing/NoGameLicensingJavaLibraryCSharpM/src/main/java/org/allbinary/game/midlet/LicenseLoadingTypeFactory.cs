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

namespace org.allbinary.game.midlet;

public class LicenseLoadingTypeFactory
{
    private static readonly LicenseLoadingTypeFactory instance = new LicenseLoadingTypeFactory();
    public static LicenseLoadingTypeFactory getIntance()
    {
        return LicenseLoadingTypeFactory.instance;
    }

    public readonly LicenseLoadingType INITIAL_LOADING = new LicenseLoadingType("Initial Loading");
    public readonly LicenseLoadingType GAME_START = new LicenseLoadingType("Game Start");
    public readonly LicenseLoadingType LOGIN = new LicenseLoadingType("Login");
    public readonly LicenseLoadingType OTHER = new LicenseLoadingType("Other/Usually The First Non Demo Level");
}

