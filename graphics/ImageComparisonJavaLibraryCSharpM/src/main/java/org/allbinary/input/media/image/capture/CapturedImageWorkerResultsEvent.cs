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
//using BufferedImage = java.awt.image.BufferedImage;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.input.media.image.capture;

public class CapturedImageWorkerResultsEvent : AllBinaryEventObject
{
    private readonly long? frame;
    private BufferedImage bufferedImage = null;
    public CapturedImageWorkerResultsEvent(object anyType, long? frame, BufferedImage bufferedImage) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
        this.frame = frame;
        this.setBufferedImage(bufferedImage);
    }

    public virtual BufferedImage getBufferedImage()
    {
        return this.bufferedImage;
    }

    private void setBufferedImage(BufferedImage bufferedImage)
    {
        this.bufferedImage = bufferedImage;
    }

    public virtual long? getFrame()
    {
        return this.frame;
    }

}

