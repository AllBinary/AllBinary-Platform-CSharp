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
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using NamedInterface = org.allbinary.layer.NamedInterface;

namespace org.allbinary.game.input;

public interface GameInputInterface : NamedInterface
{
    // throws Exception
    void processInput(AllBinaryLayerManager layerManager);

    void initInputProcessors();

}

