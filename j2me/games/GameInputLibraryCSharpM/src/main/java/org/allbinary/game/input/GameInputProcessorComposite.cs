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
using System.Runtime.CompilerServices;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input;

public class GameInputProcessorComposite : PlayerGameInput
{
    private readonly string name;
    private readonly GameInputProcessorInterface gameInputProcessorInterface;
    public GameInputProcessorComposite(string name, GameInputProcessorInterface gameInputProcessorInterface) : base(new BasicArrayListD(), new BasicArrayListD(), -1)
    {
        // base(new BasicArrayListD(), new BasicArrayListD(), -1) is called from the constructor declaration
        this.name = name;
        this.gameInputProcessorInterface = gameInputProcessorInterface;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void update()
    {
        try {
            BasicArrayList list = this.getGameKeyEventList();
            this.gameInputProcessorInterface.onInput(list);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.UPDATE, e);
        }
    }

    private readonly string NAME_LABEL = " GameInputProcessorInterface: ";
    public override string ToString()
    {
        return new StringMaker().append(base.ToString()).append(this.NAME_LABEL).append(this.name).ToString();
    }

}

