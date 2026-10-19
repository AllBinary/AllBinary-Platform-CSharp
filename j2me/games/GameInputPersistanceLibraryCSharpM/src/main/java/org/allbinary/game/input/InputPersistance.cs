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
using BasicPersitance = org.allbinary.game.configuration.persistance.BasicPersitance;
using NullRecordComparator = org.allbinary.game.configuration.persistance.NullRecordComparator;
using NullRecordFilter = org.allbinary.game.configuration.persistance.NullRecordFilter;
using NullRecordStore = org.allbinary.game.configuration.persistance.NullRecordStore;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using HashtableUtil = org.allbinary.util.HashtableUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.game.input;

//GameInputPersistanceLibrary
public class InputPersistance : BasicPersitance
{
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private readonly HashtableUtil hashtableUtil = HashtableUtil.getInstance();
    public InputPersistance(string name) : base(name)
    {
        // base(name) is called from the constructor declaration
    }

    // throws Exception
    public virtual void loadAll(AbeClientInformationInterface abeClientInformation)
    {
        RecordStore recordStore = NullRecordStore.NULL_RECORD_STORE;
        try {
            recordStore = RecordStore.openRecordStore(this.getRecordId(abeClientInformation), true);
            RecordEnumeration recordEnum = recordStore.enumerateRecords(NullRecordFilter.NULL_RECORD_FILTER, NullRecordComparator.NULL_RECORD_COMPARATOR, true);
            long gameActionInputId = 0L;
            long inputId = 0L;
            Input gameActionInput = null;
            Input input = null;
            ABHashtable<object, object> hashtable = null;
            GameKeyMappingFactory gameKeyFactory = GameKeyMappingFactory.getInstance();
            StringMaker stringBuffer = new StringMaker();
            InputFactory inputFactory = InputFactory.getInstance();
            SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
            StdUtil stdUtil = StdUtil.getInstance();
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
                    hashtable = stdUtil.createHashtable();
                    int value = 0;
                    while (inputStream.available() > 0) {
                        string gameActionInputIdAsString = inputStream.readUTF();
                        value = int.Parse(gameActionInputIdAsString);
                        gameActionInputId = ((long) value);
                        inputStream.readUTF();
                        value = int.Parse(inputStream.readUTF());
                        inputId = ((long) value);
                        gameActionInput = gameKeyFactory.getGameKey(((int) gameActionInputId));
                        input = inputFactory.getInstanceById(((int) inputId));
                        if (input == inputFactory.NO_INPUT || gameActionInput == null) {
                            stringBuffer.delete(0, stringBuffer.length());
                            if (input == inputFactory.NO_INPUT) {
                                stringBuffer.append(this.persistanceStrings.ERROR_LOADING_ID);
                                stringBuffer.appendlong(inputId);
                                stringBuffer.append(this.persistanceStrings.GAME_ACTION_INPUT);
                                stringBuffer.appendlong(gameActionInputId);
                                PreLogUtil.put(stringBuffer.ToString(), this, this.persistanceStrings.LOAD_ALL);
                            }
                            if (gameActionInput == null) {
                                stringBuffer.delete(0, stringBuffer.length());
                                stringBuffer.append(this.persistanceStrings.ERROR_LOADING);
                                stringBuffer.appendlong(gameActionInputId);
                                stringBuffer.append(this.persistanceStrings.ID);
                                stringBuffer.appendlong(inputId);
                                PreLogUtil.put(stringBuffer.ToString(), this, this.persistanceStrings.LOAD_ALL);
                            }
                        } else {
                        }
                        hashtable.put(input, gameActionInput);
                    }
                    this.valueList.add(hashtable);
                    this.idList.add(smallIntegerSingletonFactory.getAt(id));
                } else {
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
            StringMaker stringBuffer = new StringMaker();
            PreLogUtil.put(stringBuffer.append(this.persistanceStrings.SAVING).append(StringUtil.getInstance().toString(hashtable)).ToString(), this, this.commonStrings.SAVE);
            recordStore = RecordStore.openRecordStore(this.getRecordId(abeClientInformation), true);
            System.IO.MemoryStream byteArrayOutputStream = new System.IO.MemoryStream();
            DataOutputStream outputStream = new DataOutputStream(byteArrayOutputStream);
            Input gameActionInput = null;
            BasicArrayList list = null;
            Input input = null;
            sbyte[] savedGameBytes = null;
            CommonSeps commonSeps = CommonSeps.getInstance();
            SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
            object[] inputObjectArray = this.hashtableUtil.getKeysAsArray(hashtable);
            int size = inputObjectArray.Length;
            for (int index = 0; index < size; index++) {
                gameActionInput = ((Input) inputObjectArray[index]);
                list = ((BasicArrayList) hashtable.get(((object) inputObjectArray[index])));
                for (int index2 = 0; index2 < list.size(); index2++) {
                    string gameActionInputIdAsString = smallIntegerSingletonFactory.getAt(gameActionInput.getId()).ToString();
                    outputStream.writeUTF(gameActionInputIdAsString);
                    outputStream.writeUTF(commonSeps.EQUALS);
                    input = ((Input) list.objectArray[index2]);
                    string inputIdAsString = smallIntegerSingletonFactory.getAt(input.getId()).ToString();
                    outputStream.writeUTF(inputIdAsString);
                }
            }
            savedGameBytes = ((sbyte[]) (Array) byteArrayOutputStream.ToArray());
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

}

