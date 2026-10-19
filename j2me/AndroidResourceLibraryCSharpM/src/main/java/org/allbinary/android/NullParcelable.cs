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
using Parcelable = android.os.Parcelable;
using Parcel = android.os.Parcel;

namespace org.allbinary.android;

public class NullParcelable : Parcelable
{
    public static readonly NullParcelable NULL_PARCELABLE = new NullParcelable();
    public virtual int describeContents()
    {
        throw new SystemException();
    }

    public virtual void writeToParcel(Parcel dest, int flags)
    {
    }

}

