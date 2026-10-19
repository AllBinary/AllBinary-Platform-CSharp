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
using AnalogLocationInput = org.allbinary.game.input.analog.AnalogLocationInput;
using AnalogLocationInputFactory = org.allbinary.game.input.analog.AnalogLocationInputFactory;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.android.input.motion;

public class SingleAnalogControllerVisitor : AnalogControllerVisitor
{
    private readonly int playerInputId;
    public SingleAnalogControllerVisitor(int playerInputId)
    {
        this.playerInputId = playerInputId;
    }

    public override void process(AllBinaryLayerManager allbinaryLayerManager, AnalogLocationInputProcessor analogLocationInputProcessor)
    {
        AnalogLocationInput analogLocationInput = AnalogLocationInputFactory.getInstance().getInstanceForPlayer(this.playerInputId);
        analogLocationInputProcessor.process(allbinaryLayerManager, analogLocationInput);
    }

}

