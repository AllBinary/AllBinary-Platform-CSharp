/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
//using Image = javax.microedition.lcdui.Image;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Resource = org.eclipse.swt.graphics.Resource;
using SwtMutableImage = org.microemu.device.swt.SwtMutableImage;

namespace org.allbinary;

public class DisposalUtil
{
    private static readonly DisposalUtil instance = new DisposalUtil();
    public static DisposalUtil getInstance()
    {
        return DisposalUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public virtual void disposeImage(Image image)
    {
        if (image == null) {
            return;
        }
        if (image.isMutable()) {
            SwtMutableImage mutableImage = ((SwtMutableImage) image);
            this.disposeResource(((Resource) mutableImage.getImage()));
        } else {
        }
    }

    public virtual void disposeResource(Resource resource)
    {
        if (!resource.isDisposed()) {
            Console.WriteLine(this.commonStrings.CLOSE);
            resource.dispose();
        }
    }

}

