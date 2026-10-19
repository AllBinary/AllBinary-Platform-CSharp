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

namespace org.allbinary.logic.control.contraints.display.browser;

public interface DisplayInBrowserContraintsInterface
{
    bool isMountable();

    bool isFrameable();

    bool isQuickFrameable();

    void setMountable(bool canBeMounted);

    void setFrameable(bool canBeFramed);

    void setQuickFrameable(bool canBeQuickFramed);

    void setMountedLink(string mountedLink);

    string getMountedLink();

}

