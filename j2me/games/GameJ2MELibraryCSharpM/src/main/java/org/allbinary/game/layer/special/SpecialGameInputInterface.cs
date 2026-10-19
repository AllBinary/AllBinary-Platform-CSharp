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
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.game.layer.special;

public interface SpecialGameInputInterface : PaintableInterface
{
    // throws Exception
    void up();

    // throws Exception
    void down();

    // throws Exception
    void right();

    // throws Exception
    void left();

    // throws Exception
    void strafeLeft();

    // throws Exception
    void strafeRight();

    // throws Exception
    void fire(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent);

    // throws Exception
    void special1(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent);

    // throws Exception
    void special2(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent);

    // throws Exception
    void special3(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent);

    // throws Exception
    void special4(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent);

    // throws Exception
    void special5(AllBinaryLayerManager layerManager, GameKeyEvent gameKeyEvent);

}

