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
using Context = android.content.Context;
using Vibrator = android.os.Vibrator;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;

namespace org.allbinary.media;

public class AllBinaryVibration : AllBinaryVibrationME
{
    private static AllBinaryVibrationME VIBRATION = AllBinaryNoVibration.NO_VIBRATION;
    private readonly Vibrator vibrator = ((Vibrator) ResourceUtil.getInstance().getContext().getSystemService(Context.VIBRATOR_SERVICE));
    public AllBinaryVibration()
    {
    }

    public static AllBinaryVibrationME getInstance()
    {
        return AllBinaryVibration.VIBRATION;
    }

    public static void init()
    {
        if (((int) GameConfigurationCentral.getInstance().VIBRATION.getValue()) == 0) {
            AllBinaryVibration.VIBRATION = AllBinaryNoVibration.NO_VIBRATION;
        } else {
            AllBinaryVibration.VIBRATION = new AllBinaryVibration();
        }
    }

    public override void vibrate(int duration, int type, int volume)
    {
        this.vibrator.vibrate(((long) duration));
    }

}

