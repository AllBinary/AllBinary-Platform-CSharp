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
//using javax.swing;

namespace org.allbinary.image.gui;

public class ImageIconUnique : ImageIcon
{
    private int id = 0;
    public ImageIconUnique(BufferedImage bufferedImage, int index) : base(bufferedImage)
    {
        // base(bufferedImage) is called from the constructor declaration
        this.setId(index);
    }

    public virtual int getId()
    {
        return this.id;
    }

    public virtual void setId(int id)
    {
        this.id = id;
    }

}

