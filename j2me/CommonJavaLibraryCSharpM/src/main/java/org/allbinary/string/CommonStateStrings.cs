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

namespace org.allbinary.@string;

public class CommonStateStrings
{
    private static readonly CommonStateStrings instance = new CommonStateStrings();
    public static CommonStateStrings getInstance()
    {
        return CommonStateStrings.instance;
    }

    public readonly string CONTEXT = "Context: ";
    public readonly string FINISH = "finish";
    public readonly string CREATE = "onCreate";
    public readonly string START = "onStart";
    public readonly string RESTART = "onRestart";
    public readonly string RESUME = "onResume";
    public readonly string PAUSE = "onPause";
    public readonly string STOP = "onStop";
    public readonly string DESTROY = "onDestroy";
    public readonly string BIND = "onBind";
    public readonly string ON_SAVE_INSTANCE_STATE = "onSaveInstanceState";
    public readonly string ON_START_COMMAND = "onStartCommand";
}

