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

namespace org.allbinary.game.configuration.persistance;

public class PersistanceStrings
{
    private static readonly PersistanceStrings instance = new PersistanceStrings();
    public static PersistanceStrings getInstance()
    {
        return PersistanceStrings.instance;
    }

    public readonly string SAVING = "Saving: ";
    public readonly string NUMBER_OF_RECORDS = "Number of records: ";
    public readonly string LOADING_ID = "Loading data with id: ";
    public readonly string LOAD_ALL = "loadAll";
    public readonly string DELETING_WITH_ID = "Deleting data with id: ";
    public readonly string CLOSING_RECORDSTORE = "Closing RecordStore";
    public readonly string NOT_SAVING = "Not Saving: ";
    public readonly string ERROR_LOADING = "Error Loading gameActionInput: ";
    public readonly string ERROR_LOADING_ID = "Error Loading id: ";
    public readonly string ID = " id: ";
    public readonly string GAME_ACTION_INPUT = " GameActionInput: ";
}

