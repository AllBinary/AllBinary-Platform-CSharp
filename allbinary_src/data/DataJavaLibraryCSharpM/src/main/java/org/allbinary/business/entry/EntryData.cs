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

namespace org.allbinary.business.entry;

public class EntryData
{
    private static readonly EntryData instance = new EntryData();
    public static EntryData getInstance()
    {
        return EntryData.instance;
    }

    private EntryData()
    {
    }

    public readonly string ID = "ENTRY_ID";
    public readonly string ENCRYPTION = "ENTRY_ENCRYPTION";
    public readonly string TIMECREATED = "ENTRY_TIMECREATED";
    public readonly string LASTMODIFIED = "ENTRY_LASTMODIFIED";
    public readonly string DEFAULT = "ENTRY_DEFAULT";
    public readonly string SPECIAL = "ENTRY_SPECIAL";
    public readonly string ENABLE = "ENTRY_ENABLE";
    public readonly string YES = "Yes";
    public readonly string NO = "No";
}

