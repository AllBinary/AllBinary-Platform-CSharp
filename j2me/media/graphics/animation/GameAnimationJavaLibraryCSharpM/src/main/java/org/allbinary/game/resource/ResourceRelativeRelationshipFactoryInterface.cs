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
using GameFeatureControlledInterface = org.allbinary.game.configuration.feature.GameFeatureControlledInterface;
using RelativeRelationship = org.allbinary.graphics.RelativeRelationship;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.resource;

public interface ResourceRelativeRelationshipFactoryInterface : GameFeatureControlledInterface
{
    // throws Exception
    BasicArrayList getResourceRelativeRelationshipList(string resource);

    // throws Exception
    void addResourceRelativeRelationship(string resource, RelativeRelationship relativeRelationship);

}

