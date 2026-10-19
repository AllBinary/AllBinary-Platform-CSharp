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
using AbPath = org.allbinary.logic.io.path.AbPath;

namespace org.allbinary.business.init;

public interface InitInfoInterface
{
    bool isTesting();

    string getTesting();

    string getTestHtmlPath();

    string getMainPath();

    void setTesting(string value);

    void setTestHtmlPath(AbPath value);

    void setMainPath(AbPath value);

    // throws Exception
    bool isTestingValid(string testing);

    bool isTestHtmlPathValid(AbPath value);

    bool isMainPathValid(AbPath value);

}

