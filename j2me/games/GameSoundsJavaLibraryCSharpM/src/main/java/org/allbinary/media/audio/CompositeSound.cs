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

namespace org.allbinary.media.audio;

public class CompositeSound : Sound
{
    public CompositeSound(string resource) : base(resource)
    {
        // base(resource) is called from the constructor declaration
    }

    // throws Exception
    public override void init()
    {
        this.setPlayerP(new PlayerComposite(AllBinaryMediaManager.createPlayer(this.getResource()), 570));
    }

}

