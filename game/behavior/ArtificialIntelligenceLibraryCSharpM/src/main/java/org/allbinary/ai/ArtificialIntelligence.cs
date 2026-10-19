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

namespace org.allbinary.ai;

public class ArtificialIntelligence : ArtificialIntelligenceInterface
{
    public static readonly int AI_ID = 2;
    private static readonly ArtificialIntelligence instance = new ArtificialIntelligence();
    public static ArtificialIntelligence getInstance()
    {
        return ArtificialIntelligence.instance;
    }

    public ArtificialIntelligence()
    {
    }

    // throws Exception
    public virtual void processAI(AllBinaryLayerManager layerManager)
    {
    }

    public virtual int getId()
    {
        return 1;
    }

}

