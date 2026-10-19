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
//using RecordComparator = javax.microedition.rms.RecordComparator;

namespace org.allbinary.game.configuration.persistance;

public class NullRecordComparator : RecordComparator
{
    public static readonly NullRecordComparator NULL_RECORD_COMPARATOR = new NullRecordComparator();
    public virtual int compare(sbyte[] rec1, sbyte[] rec2)
    {
        return 0;
    }

}

