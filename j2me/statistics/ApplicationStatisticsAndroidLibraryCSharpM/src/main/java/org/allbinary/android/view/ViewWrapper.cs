/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using View = android.view.View;

namespace org.allbinary.android.view;

public class ViewWrapper : BaseViewWrapper
{
    private readonly View view;
    public ViewWrapper(View view)
    {
        this.view = view;
    }

    public override void invalidate()
    {
        this.view.invalidate();
    }

    public override void postInvalidate()
    {
        this.view.postInvalidate();
    }

}

