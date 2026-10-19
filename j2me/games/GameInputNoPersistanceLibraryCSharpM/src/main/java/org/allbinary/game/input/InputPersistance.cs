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
//using RecordEnumeration = javax.microedition.rms.RecordEnumeration;
//using RecordStore = javax.microedition.rms.RecordStore;
using BasicPersitance = org.allbinary.game.configuration.persistance.BasicPersitance;
using NullRecordComparator = org.allbinary.game.configuration.persistance.NullRecordComparator;
using NullRecordFilter = org.allbinary.game.configuration.persistance.NullRecordFilter;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using HashtableUtil = org.allbinary.util.HashtableUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.game.input;

//GameInputNoPersistanceLibrary
public class InputPersistance : BasicPersitance
{
    private readonly HashtableUtil hashtableUtil = HashtableUtil.getInstance();
    public InputPersistance(string name) : base(name)
    {
        // base(name) is called from the constructor declaration
    }

    // throws Exception
    public virtual void loadAll(AbeClientInformationInterface abeClientInformation)
    {
        RecordStore recordStore = RecordStore.openRecordStore(this.getRecordId(abeClientInformation), true);
        RecordEnumeration recordEnum = recordStore.enumerateRecords(NullRecordFilter.NULL_RECORD_FILTER, NullRecordComparator.NULL_RECORD_COMPARATOR, true);
        ABHashtable<object, object> hashtable = null;
        StringMaker stringBuffer = new StringMaker();
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        int id = 0;
        while (recordEnum.hasNextElement()) {
            id = recordEnum.nextRecordId();
            stringBuffer.delete(0, stringBuffer.length());
            this.logUtil.putF(stringBuffer.append(this.persistanceStrings.LOADING_ID).appendint(id).ToString(), this, this.persistanceStrings.LOAD_ALL);
            hashtable = StdUtil.getInstance().createHashtable();
            this.valueList.add(hashtable);
            this.idList.add(smallIntegerSingletonFactory.getAt(id));
        }
        recordStore.closeRecordStore();
    }

    // throws Exception
    public virtual void save(AbeClientInformationInterface abeClientInformation, ABHashtable<object, object> hashtable)
    {
        PreLogUtil.put(new StringMaker().append(this.persistanceStrings.NOT_SAVING).append(StringUtil.getInstance().toString(hashtable)).ToString(), this, this.commonStrings.SAVE);
        RecordStore recordStore = RecordStore.openRecordStore(this.getRecordId(abeClientInformation), true);
        Input gameActionInput = null;
        BasicArrayList list = null;
        Input input = null;
        object[] inputObjectArray = this.hashtableUtil.getKeysAsArray(hashtable);
        int size = inputObjectArray.Length;
        for (int index = 0; index < size; index++) {
            gameActionInput = ((Input) inputObjectArray[index]);
            list = ((BasicArrayList) hashtable.get(inputObjectArray[index]));
            for (int index2 = 0; index2 < list.size(); index2++) {
                input = ((Input) list.get(index2));
            }
        }
        recordStore.closeRecordStore();
    }

}

