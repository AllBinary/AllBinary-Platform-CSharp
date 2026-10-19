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

namespace org.allbinary.android.activity;

public class NullProgressActivity : ProgressActivityInterface
{
    public static readonly NullProgressActivity NULL_PROGRESS_ACTIVITY = new NullProgressActivity();
    public virtual void runOnUiThread(Runnable action)
    {
    }

    public virtual void onDismissTitleProgressBar()
    {
    }

    public virtual void onShowTitleProgressBar(int value, bool indeterminate)
    {
    }

    public virtual void onTitleProgressBarSetProgress(int value)
    {
    }

}

