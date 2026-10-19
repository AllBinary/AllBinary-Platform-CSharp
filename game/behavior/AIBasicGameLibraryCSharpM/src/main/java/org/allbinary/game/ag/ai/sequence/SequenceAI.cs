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
using ArtificialIntelligence = org.allbinary.ai.ArtificialIntelligence;
using ArtificialIntelligenceInterface = org.allbinary.ai.ArtificialIntelligenceInterface;
using ArtificialIntelligenceTransitionInterface = org.allbinary.ai.ArtificialIntelligenceTransitionInterface;
using ArrayAI = org.allbinary.game.ag.ai.ArrayAI;
using GameInput = org.allbinary.game.input.GameInput;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.ag.ai.sequence;

public class SequenceAI : ArrayAI
{
    private static readonly string SEQUENCE_AI = "Sequence AI";
    private int index = 0;
    public SequenceAI(ArtificialIntelligenceInterface[] artificialIntelligenceInterfaceArray, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(artificialIntelligenceInterfaceArray, ownerLayerInterface, gameInput)
    {
        // base(artificialIntelligenceInterfaceArray, ownerLayerInterface, gameInput) is called from the constructor declaration
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        this.getArtificialIntelligenceInterface()[this.index].processAI(allBinaryLayerManager);
    }

    public virtual void next()
    {
        this.index++;
        ArtificialIntelligenceInterface artificialIntelligenceInterface = this.getSelectedArtificialIntelligenceInterface();
        if (artificialIntelligenceInterface.getId() == ArtificialIntelligence.AI_ID) {
            ArtificialIntelligenceTransitionInterface artificialIntelligenceTransitionInterface = ((ArtificialIntelligenceTransitionInterface) artificialIntelligenceInterface);
            artificialIntelligenceTransitionInterface.transition();
        }
    }

    public virtual int getIndex()
    {
        return this.index;
    }

    public virtual void setIndex(int index)
    {
        this.index = index;
    }

    public virtual ArtificialIntelligenceInterface getSelectedArtificialIntelligenceInterface()
    {
        return this.getArtificialIntelligenceInterface()[this.index];
    }

    public override string getName()
    {
        return SequenceAI.SEQUENCE_AI;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(base.ToString());
        stringBuffer.append(" Selected AI: ");
        stringBuffer.append(StringUtil.getInstance().toString(this.getSelectedArtificialIntelligenceInterface()));
        return stringBuffer.ToString();
    }

}

