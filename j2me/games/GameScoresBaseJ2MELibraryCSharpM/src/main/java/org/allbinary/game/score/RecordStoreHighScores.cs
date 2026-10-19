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
using System.Runtime.CompilerServices;
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
//using DataInputStream = java.io.DataInputStream;
//using EOFException = java.io.EOFException;
//using IOException = java.io.IOException;
//using RecordComparator = javax.microedition.rms.RecordComparator;
//using RecordEnumeration = javax.microedition.rms.RecordEnumeration;
//using RecordStore = javax.microedition.rms.RecordStore;
//using RecordStoreException = javax.microedition.rms.RecordStoreException;
//using RecordStoreNotFoundException = javax.microedition.rms.RecordStoreNotFoundException;
using TsUtil = org.allbinary.TsUtil;
using GameInfo = org.allbinary.game.GameInfo;
using NullRecordComparator = org.allbinary.game.configuration.persistance.NullRecordComparator;
using NullRecordFilter = org.allbinary.game.configuration.persistance.NullRecordFilter;
using NullRecordStore = org.allbinary.game.configuration.persistance.NullRecordStore;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using PlatformRecordIdUtil = org.allbinary.persistance.PlatformRecordIdUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.score;

public class RecordStoreHighScores : HighScores
{
    private static readonly ABHashtable<object, object> hashTable = StdUtil.getInstance().createHashtable();
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly PlatformRecordIdUtil platformRecordIdUtil = PlatformRecordIdUtil.getInstance();
    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private readonly string RECORD_ID = "_HS";
    private readonly int MAXHIGHSCORES = 100;
    private readonly GameInfo gameInfo;
    private readonly AbeClientInformationInterface abeClientInformation;
    private readonly RecordComparator recordComparatorInterface;
    private RecordStoreHighScores(AbeClientInformationInterface abeClientInformation, GameInfo gameInfo, string name, string heading, string columnTwoHeading, RecordComparator recordComparatorInterface) : base(name, heading, columnTwoHeading)
    {
        // base(name, heading, columnTwoHeading) is called from the constructor declaration
        this.abeClientInformation = abeClientInformation;
        this.gameInfo = gameInfo;
        this.recordComparatorInterface = recordComparatorInterface;
        this.load();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static HighScores getInstance(AbeClientInformationInterface abeClientInformation, GameInfo gameInfo, string highScoreName, string heading, string columnTwoHeading, RecordComparator recordComparatorInterface)
    {
        object highScoresCanBeNull = RecordStoreHighScores.hashTable.get(((object) highScoreName));
        if (highScoresCanBeNull == null) {
            HighScores highScores = new RecordStoreHighScores(abeClientInformation, gameInfo, highScoreName, heading, columnTwoHeading, recordComparatorInterface);
            RecordStoreHighScores.hashTable.put(highScores.getName(), highScores);
            return highScores;
        }
        return ((HighScores) highScoresCanBeNull);
    }

    private string getRecordId(AbeClientInformationInterface abeClientInformation)
    {
        return this.platformRecordIdUtil.getRecordId(abeClientInformation, new StringMaker().append(CommonSeps.getInstance().UNDERSCORE).append(this.getName()).append(this.RECORD_ID).ToString());
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void addHighScore(HighScore newHighScore)
    {
        RecordStore recordStore = NullRecordStore.NULL_RECORD_STORE;
        try {
            this.logUtil.putF(new StringMaker().append("Adding HighScore: ").appendlong(((long) newHighScore.getScore())).ToString(), this, this.commonStrings.ADD);
            if (this.isTooManyHighScores()) {
                this.logUtil.putF("Removing Lowest Score", this, this.commonStrings.ADD);
                this.removeLowestHighScore();
            }
            recordStore = RecordStore.openRecordStore(this.getRecordId(this.abeClientInformation), true);
            sbyte[] highScoreBytes = newHighScore.getAsBytes();
            int recordId = recordStore.addRecord(highScoreBytes, 0, highScoreBytes.Length);
            this.load();
        } catch (RecordStoreException e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.ADD, e);
        } catch (IOException e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.ADD, e);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.ADD, e);
        } finally {
            try {
                if (recordStore != null) {
                    PreLogUtil.put("Closing RecordStore", this, this.commonStrings.ADD);
                    recordStore.closeRecordStore();
                }
            } catch (RecordStoreException e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.ADD, e);
            }
        }
    }

    private void removeLowestHighScore()
    {
        RecordStore recordStore = NullRecordStore.NULL_RECORD_STORE;
        try {
            recordStore = RecordStore.openRecordStore(this.getRecordId(this.abeClientInformation), true);
            RecordEnumeration recordEnum = recordStore.enumerateRecords(NullRecordFilter.NULL_RECORD_FILTER, NullRecordComparator.NULL_RECORD_COMPARATOR, true);
            ScoreComparator scoreComparator = (((ScoreComparator) this.recordComparatorInterface));
            HighScore bestHighScore = new HighScore(-1, "none", GameInfo.NONE, scoreComparator.getBestScore());
            sbyte[] recordAsBytes = null;
            ByteArrayInputStream byteArrayInputStream = null;
            DataInputStream inputStream = null;
            while (recordEnum.hasNextElement()) {
                int id = recordEnum.nextRecordId();
                recordAsBytes = this.tsUtil.getRecord(recordStore, id);
                if (recordAsBytes != null) {
                    byteArrayInputStream = new ByteArrayInputStream(recordAsBytes);
                    inputStream = new DataInputStream(byteArrayInputStream);
                    string name = inputStream.readUTF();
                    long nextScore = inputStream.readLong();
                    HighScore nextCurrentHighScore = new HighScore(id, name, GameInfo.NONE, nextScore);
                    if (this.recordComparatorInterface.compare(nextCurrentHighScore.getAsBytes(), bestHighScore.getAsBytes()) == RecordComparator.FOLLOWS) {
                        bestHighScore = nextCurrentHighScore;
                    }
                }
            }
            if (bestHighScore.getId() != -1) {
                this.logUtil.putF(new StringMaker().append("Removing Lowest HighScore: ").appendlong(((long) bestHighScore.getScore())).ToString(), this, this.commonStrings.LOAD);
                recordStore.deleteRecord(bestHighScore.getId());
            }
        } catch (RecordStoreException e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "removeLowestHighScore", e);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "removeLowestHighScore", e);
        } finally {
            try {
                if (recordStore != null) {
                    PreLogUtil.put("Closing RecordStore", this, "removeLowestHighScore");
                    recordStore.closeRecordStore();
                }
            } catch (RecordStoreException e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "removeLowestHighScore", e);
            }
        }
    }

    private void load()
    {
        RecordStore recordStore = NullRecordStore.NULL_RECORD_STORE;
        try {
            recordStore = RecordStore.openRecordStore(this.getRecordId(this.abeClientInformation), true);
            this.setList(new BasicArrayListD());
            RecordEnumeration recordEnum = recordStore.enumerateRecords(NullRecordFilter.NULL_RECORD_FILTER, NullRecordComparator.NULL_RECORD_COMPARATOR, true);
            sbyte[] recordAsBytes = null;
            ByteArrayInputStream byteArrayInputStream = null;
            DataInputStream inputStream = null;
            while (recordEnum.hasNextElement()) {
                int id = recordEnum.nextRecordId();
                recordAsBytes = this.tsUtil.getRecord(recordStore, id);
                if (recordAsBytes != null) {
                    byteArrayInputStream = new ByteArrayInputStream(recordAsBytes);
                    inputStream = new DataInputStream(byteArrayInputStream);
                    try {
                        string name = inputStream.readUTF();
                        long score = inputStream.readLong();
                        HighScore newHighScore = new HighScore(id, name, GameInfo.NONE, score);
                        BasicArrayList list = this.getList();
                        int size = list.size();
                        int lastIndex = size;
                        for (int index = 0; index < size; index++) {
                            HighScore highScore = ((HighScore) list.objectArray[index]);
                            if (this.recordComparatorInterface.compare(newHighScore.getAsBytes(), highScore.getAsBytes()) == RecordComparator.PRECEDES) {
                                lastIndex = index;
                                break;
                            }
                        }
                        list.addAt(lastIndex, newHighScore);
                    } catch (EOFException e) {
                        this.logUtil.put("EOF", this, this.commonStrings.LOAD, e);
                        throw e;
                    }
                }
            }
        } catch (RecordStoreNotFoundException e) {
            this.logUtil.put("No High Scores", this, this.commonStrings.LOAD, e);
        } catch (RecordStoreException e) {
            this.logUtil.put(this.commonStrings.UNKNOWN, this, this.commonStrings.LOAD, e);
        } catch (IOException e) {
            this.logUtil.put(this.commonStrings.UNKNOWN, this, this.commonStrings.LOAD, e);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.UNKNOWN, this, this.commonStrings.LOAD, e);
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
    }

    private bool isTooManyHighScores()
    {
        if (this.getList() != null && this.getList().size() < this.MAXHIGHSCORES) {
            return false;
        } else {
            this.logUtil.putF(new StringMaker().append("HighScores RecordStore Max Reached: ").appendint(this.MAXHIGHSCORES).ToString(), this, "isTooManyHighScores");
            return true;
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override bool isBestScore(HighScore newHighScore)
    {
        try {
            if (!this.isTooManyHighScores()) {
                this.logUtil.putF("Slot Available for a High Score", this, "isBestScore");
                return true;
            } else {
                BasicArrayList list = this.getList();
                int size = list.size();
                for (int index = 0; index < size; index++) {
                    HighScore highScore = ((HighScore) list.objectArray[index]);
                    if (this.recordComparatorInterface.compare(newHighScore.getAsBytes(), highScore.getAsBytes()) == RecordComparator.FOLLOWS) {
                        this.logUtil.putF("Obtained a High Score", this, "isBestScore");
                        return true;
                    }
                }
            }
            this.logUtil.putF("Not a High Score", this, "isBestScore");
            return false;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.ADD, e);
            throw e;
        }
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(base.ToString());
        BasicArrayList list = this.getList();
        int size = list.size();
        for (int index = 0; index < size; index++) {
            HighScore highScore = ((HighScore) list.objectArray[index]);
            stringBuffer.append(highScore.getScoreString());
            stringBuffer.append(CommonSeps.getInstance().COMMA_SEP);
        }
        return stringBuffer.ToString();
    }

}

