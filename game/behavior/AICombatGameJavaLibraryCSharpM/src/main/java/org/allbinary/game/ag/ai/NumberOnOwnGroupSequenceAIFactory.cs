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
using ArtificialIntelligenceInterface = org.allbinary.ai.ArtificialIntelligenceInterface;
using GameInput = org.allbinary.game.input.GameInput;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.ag.ai;

public class NumberOnOwnGroupSequenceAIFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    // throws Exception
    public virtual ArtificialIntelligenceInterface getInstance(ABHashtable<object, object> hashtable, ArtificialIntelligenceInterface[] artificialIntelligenceInterface, AllBinaryLayer ownerLayerInterface, GameInput gameInput)
    {
        int?[] integerArray = NumberInSameGroupSequence.getInstance().NUMBER_ON_SAME_TEAM_SEQUENCE;
        BasicArrayList list = new BasicArrayListD();
        for (int index = 0; index < integerArray.Length; index++) {
            object integerCanBeNull = hashtable.get(((object) integerArray[index]));
            if (integerCanBeNull == null) {
                break;
            }
            list.add(integerCanBeNull);
        }
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Total AI Properties: ");
        stringBuffer.appendint(list.size());
        stringBuffer.append(" == Total AI: ");
        stringBuffer.appendint(artificialIntelligenceInterface.Length);
        stringBuffer.append(" + 1");
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF(stringBuffer.ToString(), this, commonStrings.GET_INSTANCE);
        if (artificialIntelligenceInterface.Length - 1 > list.size()) {
            throw new Exception("Not enough AI properties.");
        }
        if (artificialIntelligenceInterface.Length - 1 < list.size()) {
            throw new Exception("Too Many AI properties.");
        }
        int?[] numberOnSameTeam = new int?[list.size()];
        for (int index = 0; index < numberOnSameTeam.Length; index++) {
            numberOnSameTeam[index] = ((int?) list.objectArray[index]);
        }
        return new NumberOnOwnGroupSequenceAI(numberOnSameTeam, artificialIntelligenceInterface, ownerLayerInterface, gameInput);
    }

}

