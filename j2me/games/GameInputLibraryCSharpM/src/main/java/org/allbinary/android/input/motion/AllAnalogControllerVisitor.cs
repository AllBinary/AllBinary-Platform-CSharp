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
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.android.input.motion;

public class AllAnalogControllerVisitor : AnalogControllerVisitor
{
    public override void process(AllBinaryLayerManager allbinaryLayerManager, AnalogLocationInputProcessor analogLocationInputProcessor)
    {
        BasicArrayList analogLocationInputList = AnalogLocationInputFactory.getInstance().getList();
        AnalogLocationInput analogLocationInput = null;
        for (int index = analogLocationInputList.size() - 1; index >= 0; index--) {
            analogLocationInput = ((AnalogLocationInput) analogLocationInputList.get(index));
            analogLocationInputProcessor.process(allbinaryLayerManager, analogLocationInput);
        }
    }

}

