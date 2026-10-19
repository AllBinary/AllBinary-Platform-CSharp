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
using ProfileActionScriptItemInterface = org.allbinary.input.automation.actions.script.ProfileActionScriptItemInterface;
using ProfileActionScriptNodeInterface = org.allbinary.input.automation.actions.script.ProfileActionScriptNodeInterface;
using ProfileActionScriptProcessorInterface = org.allbinary.input.automation.actions.script.condition.processors.ProfileActionScriptProcessorInterface;

namespace org.allbinary.input.automation.actions.script.condition;

public interface ProfileActionScriptConditionInterface : ProfileActionScriptNodeInterface, CustomTreeNodeInterface, ProfileActionScriptItemInterface
{
    void addProcessor(ProfileActionScriptProcessorInterface profileActionProcessorInterface);

    void removeProcessor(ProfileActionScriptProcessorInterface profileActionProcessorInterface);

    // throws Exception
    bool shouldProcess(long? frame);

}

