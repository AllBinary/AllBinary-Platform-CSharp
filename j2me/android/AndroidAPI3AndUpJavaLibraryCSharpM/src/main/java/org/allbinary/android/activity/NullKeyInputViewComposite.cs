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

namespace org.allbinary.android.activity;

public class NullKeyInputViewComposite : KeyInputViewCompositeInterface
{
    public static readonly NullKeyInputViewComposite NULL_KEY_INPUT_VIEW_COMPOSITE = new NullKeyInputViewComposite();
    public virtual void setKeyInputView(View keyInputView)
    {
    }

    public virtual View getRootView()
    {
        throw new SystemException();
    }

    public virtual View getView()
    {
        throw new SystemException();
    }

    public virtual void runOnUiThread(global::java.lang.Runnable action)
    {
    }

}

