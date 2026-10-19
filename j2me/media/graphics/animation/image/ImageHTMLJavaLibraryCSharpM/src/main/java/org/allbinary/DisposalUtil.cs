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
using Resource = org.eclipse.swt.graphics.Resource;

namespace org.allbinary;

public class DisposalUtil
{
    private static readonly DisposalUtil instance = new DisposalUtil();
    public static DisposalUtil getInstance()
    {
        return DisposalUtil.instance;
    }

    public virtual void dispose(Resource resource)
    {
        if (!resource.isDisposed()) {
            resource.dispose();
        }
    }

}

