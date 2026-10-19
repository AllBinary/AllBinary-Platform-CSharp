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
//using File = java.io.File;

namespace org.allbinary.media.image;

public class ImageProcessorInput
{
    private BufferedImage[] bufferedImageArray;
    private File[] files;
    public ImageProcessorInput(File[] files, BufferedImage[] bufferedImageArray) : base()
    {
        // base() is called from the constructor declaration
        this.bufferedImageArray = bufferedImageArray;
        this.files = files;
    }

    public virtual BufferedImage[] getBufferedImageArray()
    {
        return this.bufferedImageArray;
    }

    public virtual File[] getFiles()
    {
        return this.files;
    }

}

