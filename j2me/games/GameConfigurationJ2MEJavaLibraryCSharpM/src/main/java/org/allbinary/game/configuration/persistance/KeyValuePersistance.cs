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
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using DataInputStream = java.io.DataInputStream;
//using DataOutputStream = java.io.DataOutputStream;
//using RecordEnumeration = javax.microedition.rms.RecordEnumeration;
//using RecordStore = javax.microedition.rms.RecordStore;
using TsUtil = org.allbinary.TsUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonSeps = org.allbinary.@string.CommonSeps;
using org.allbinary.util;
using HashtableUtil = org.allbinary.util.HashtableUtil;

namespace org.allbinary.game.configuration.persistance;

public class KeyValuePersistance : BasicPersitance
{
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    public KeyValuePersistance(string recordId) : base(recordId)
    {
        // base(recordId) is called from the constructor declaration
    }

    // throws Exception
    public virtual void loadAll(AbeClientInformationInterface abeClientInformation)
    {
        this.loadAllSize(abeClientInformation, 1);
    }

    // throws Exception
    public virtual void loadAllSize(AbeClientInformationInterface abeClientInformation, int size)
    {
        RecordStore recordStore = NullRecordStore.NULL_RECORD_STORE;
        try {
            recordStore = RecordStore.openRecordStore(this.getRecordId(abeClientInformation), true);
            RecordEnumeration recordEnum = recordStore.enumerateRecords(NullRecordFilter.NULL_RECORD_FILTER, NullRecordComparator.NULL_RECORD_COMPARATOR, true);
            ABHashtable<string, string> hashtable = null;
            string name = null;
            string value = null;
            SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
            StringMaker stringBuffer = new StringMaker();
            sbyte[] recordAsBytes = null;
            ByteArrayInputStream byteArrayInputStream = null;
            DataInputStream inputStream = null;
            while (recordEnum.hasNextElement()) {
                int id = recordEnum.nextRecordId();
                stringBuffer.delete(0, stringBuffer.length());
                this.logUtil.putF(stringBuffer.append(this.persistanceStrings.LOADING_ID).appendint(id).ToString(), this, this.persistanceStrings.LOAD_ALL);
                recordAsBytes = this.tsUtil.getRecord(recordStore, id);
                if (recordAsBytes != null) {
                    byteArrayInputStream = new ByteArrayInputStream(recordAsBytes);
                    inputStream = new DataInputStream(byteArrayInputStream);
                    hashtable = new ABHashtable<string, string>();
                    for (int index = 0; index < size; index++) {
                        name = inputStream.readUTF();
                        inputStream.readUTF();
                        value = inputStream.readUTF();
                        hashtable.put(name, value);
                    }
                    this.valueList.add(hashtable);
                    this.idList.add(smallIntegerSingletonFactory.getAt(id));
                }
            }
        } catch (Exception e) {
            throw e;
        } finally {
            if (recordStore != null) {
                PreLogUtil.put(this.persistanceStrings.CLOSING_RECORDSTORE, this, this.persistanceStrings.LOAD_ALL);
                recordStore.closeRecordStore();
            }
        }
    }

    // throws Exception
    public virtual void save(AbeClientInformationInterface abeClientInformation, ABHashtable<object, object> hashtable)
    {
        RecordStore recordStore = NullRecordStore.NULL_RECORD_STORE;
        try {
            this.logUtil.putF(new StringMaker().append(this.persistanceStrings.SAVING).append(StringUtil.getInstance().toString(hashtable)).ToString(), this, this.commonStrings.SAVE);
            recordStore = RecordStore.openRecordStore(this.getRecordId(abeClientInformation), true);
            System.IO.MemoryStream byteArrayOutputStream = new System.IO.MemoryStream();
            DataOutputStream outputStream = new DataOutputStream(byteArrayOutputStream);
            string value = null;
            CommonSeps commonSeps = CommonSeps.getInstance();
            object[] objectArray = HashtableUtil.getInstance().getKeysAsArray(hashtable);
            object anyType = null;
            int size = objectArray.Length;
            for (int index = 0; index < size; index++) {
                outputStream.writeUTF(((string) objectArray[index]));
                outputStream.writeUTF(commonSeps.EQUALS);
                anyType = ((object) objectArray[index]);
                value = ((string) hashtable.get(anyType));
                outputStream.writeUTF(value);
            }
            TsUtil tsUtil = TsUtil.getInstance();
            sbyte[] savedGameBytes = tsUtil.getByteArray(System.Text.Encoding.UTF8.GetString(byteArrayOutputStream.ToArray()));
            recordStore.addRecord(savedGameBytes, 0, savedGameBytes.Length);
        } catch (Exception e) {
            throw e;
        } finally {
            if (recordStore != null) {
                PreLogUtil.put(this.persistanceStrings.CLOSING_RECORDSTORE, this, this.commonStrings.SAVE);
                recordStore.closeRecordStore();
            }
        }
    }

    public virtual ABHashtable<object, object> get(int index)
    {
        ABHashtable<object, object> hashtable = ((ABHashtable<object, object>) this.valueList.objectArray[index]);
        return hashtable;
    }

}

