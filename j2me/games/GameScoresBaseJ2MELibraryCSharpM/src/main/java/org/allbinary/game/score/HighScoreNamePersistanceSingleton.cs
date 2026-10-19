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
//using RecordStoreException = javax.microedition.rms.RecordStoreException;
using TsUtil = org.allbinary.TsUtil;
using GameInfo = org.allbinary.game.GameInfo;
using NullRecordComparator = org.allbinary.game.configuration.persistance.NullRecordComparator;
using NullRecordFilter = org.allbinary.game.configuration.persistance.NullRecordFilter;
using NullRecordStore = org.allbinary.game.configuration.persistance.NullRecordStore;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using ExceptionUtil = org.allbinary.logic.java.exception.ExceptionUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using PlatformRecordIdUtil = org.allbinary.persistance.PlatformRecordIdUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.score;

public class HighScoreNamePersistanceSingleton
{
    private static HighScoreNamePersistanceSingleton SINGLETON = new HighScoreNamePersistanceSingleton();
    public static HighScoreNamePersistanceSingleton getInstance()
    {
        return HighScoreNamePersistanceSingleton.SINGLETON;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly PlatformRecordIdUtil platformRecordIdUtil = PlatformRecordIdUtil.getInstance();
    private readonly string RECORD_ID = "_SN";
    private string name = StringUtil.getInstance().EMPTY_STRING;
    private BasicArrayList nameBasicArrayList = new BasicArrayListD();
    public virtual void clear()
    {
        this.name = StringUtil.getInstance().EMPTY_STRING;
    }

    // throws Exception
    public virtual void deleteAll(AbeClientInformationInterface abeClientInformation, GameInfo gameInfo)
    {
        int size = this.nameBasicArrayList.size();
        for (int index = 0; index < size; index++) {
            int? integer = ((int?) this.nameBasicArrayList.objectArray[index]);
            this.delete(abeClientInformation, gameInfo, ((int) integer));
        }
        this.clear();
    }

    private string getRecordId(AbeClientInformationInterface abeClientInformation)
    {
        return this.platformRecordIdUtil.getRecordId(abeClientInformation, this.RECORD_ID);
    }

    // throws Exception
    public virtual void delete(AbeClientInformationInterface abeClientInformation, GameInfo gameInfo, int deleteId)
    {
        RecordStore recordStore = NullRecordStore.NULL_RECORD_STORE;
        try {
            this.logUtil.putF(new StringMaker().append("Deleting: ").appendint(deleteId).ToString(), this, this.commonStrings.delete);
            recordStore = RecordStore.openRecordStore(this.getRecordId(abeClientInformation), true);
            recordStore.deleteRecord(deleteId);
        } catch (Exception e) {
            throw e;
        } finally {
            if (recordStore != null) {
                PreLogUtil.put("Closing RecordStore", this, this.commonStrings.delete);
                recordStore.closeRecordStore();
            }
        }
    }

    public virtual BasicArrayList getIds()
    {
        return this.nameBasicArrayList;
    }

    public virtual string load(AbeClientInformationInterface abeClientInformation, GameInfo gameInfo)
    {
        RecordStore recordStore = NullRecordStore.NULL_RECORD_STORE;
        try {
            if (this.name == StringUtil.getInstance().EMPTY_STRING) {
                string LOADING_ID = "Loading id: ";
                recordStore = RecordStore.openRecordStore(this.getRecordId(abeClientInformation), true);
                RecordEnumeration recordEnum = recordStore.enumerateRecords(NullRecordFilter.NULL_RECORD_FILTER, NullRecordComparator.NULL_RECORD_COMPARATOR, true);
                SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
                sbyte[] recordAsBytes = null;
                ByteArrayInputStream byteArrayInputStream = null;
                DataInputStream inputStream = null;
                while (recordEnum.hasNextElement()) {
                    int id = recordEnum.nextRecordId();
                    this.logUtil.putF(new StringMaker().append(LOADING_ID).appendint(id).ToString(), this, this.commonStrings.LOAD);
                    recordAsBytes = this.tsUtil.getRecord(recordStore, id);
                    byteArrayInputStream = new ByteArrayInputStream(recordAsBytes);
                    inputStream = new DataInputStream(byteArrayInputStream);
                    while (inputStream.available() > 0) {
                        this.name = inputStream.readUTF();
                    }
                    this.nameBasicArrayList.add(smallIntegerSingletonFactory.getAt(id));
                }
            }
        } catch (Exception e) {
            this.save(abeClientInformation, gameInfo, this.name);
            this.logUtil.putF(new StringMaker().append(this.commonStrings.EXCEPTION_LABEL).append(ExceptionUtil.getInstance().getStackTrace(e)).ToString(), this, this.commonStrings.LOAD);
        } finally {
            try {
                if (recordStore != null) {
                    PreLogUtil.put("Closing RecordStore", this, this.commonStrings.LOAD);
                    recordStore.closeRecordStore();
                }
            } catch (RecordStoreException e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.LOAD, e);
            }
        }
        return this.name;
    }

    public virtual void save(AbeClientInformationInterface abeClientInformation, GameInfo gameInfo, string name)
    {
        RecordStore recordStore = NullRecordStore.NULL_RECORD_STORE;
        try {
            this.logUtil.putF(new StringMaker().append("Saving: ").append(name).ToString(), this, this.commonStrings.SAVE);
            recordStore = RecordStore.openRecordStore(this.getRecordId(abeClientInformation), true);
            System.IO.MemoryStream byteArrayOutputStream = new System.IO.MemoryStream();
            DataOutputStream outputStream = new DataOutputStream(byteArrayOutputStream);
            outputStream.writeUTF(name);
            sbyte[] savedGameBytes = ((sbyte[]) (Array) byteArrayOutputStream.ToArray());
            recordStore.addRecord(savedGameBytes, 0, savedGameBytes.Length);
            this.name = name;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.SAVE, e);
        } finally {
            try {
                if (recordStore != null) {
                    PreLogUtil.put("Closing RecordStore", this, this.commonStrings.SAVE);
                    recordStore.closeRecordStore();
                }
            } catch (RecordStoreException e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.SAVE, e);
            }
        }
    }

}

