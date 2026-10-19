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

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public interface KeyboardActionScriptInputInterface : ProfileActionScriptInputInterface
{
    int getDelayBetweenKeys();

    int?[] getKeyArray();

    bool isPress();

    bool isRelease();

    bool isNormal();

    void setPress(bool press);

    void setRelease(bool release);

    void setNormal();

    string getText();

    void setText(string text);

    void log();

}

