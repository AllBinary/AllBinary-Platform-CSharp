/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.input;

public class NullPlayerGameInputComposite : PlayerGameInputCompositeInterface
{
    public static readonly NullPlayerGameInputComposite NULL_PLAYER_GAME_INPUT_COMPOSITE = new NullPlayerGameInputComposite();
    public virtual string getName()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    // throws Exception
    public virtual void processInput(AllBinaryLayerManager layerManager)
    {
    }

    public virtual void initInputProcessors()
    {
    }

    public virtual PlayerGameInput getPlayerGameInput()
    {
        return NoPlayerGameInput.getInstance();
    }

}

