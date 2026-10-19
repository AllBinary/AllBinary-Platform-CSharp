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
//using java.awt;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public interface MouseActionScriptInputInterface : ProfileActionScriptInputInterface
{
    void setPoint(Point point);

    Point getPoint();

    int getButtonClicks();

    void setButtonClicks(int buttons);

    void log();

}

