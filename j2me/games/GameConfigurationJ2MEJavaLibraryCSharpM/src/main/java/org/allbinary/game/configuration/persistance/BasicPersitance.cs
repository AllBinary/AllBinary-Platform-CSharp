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
//using RecordStore = javax.microedition.rms.RecordStore;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using PlatformRecordIdUtil = org.allbinary.persistance.PlatformRecordIdUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.configuration.persistance;

public class BasicPersitance
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly PersistanceStrings persistanceStrings = PersistanceStrings.getInstance();
    private readonly PlatformRecordIdUtil platformRecordIdUtil = PlatformRecordIdUtil.getInstance();
    private readonly string recordId;
    public readonly BasicArrayList valueList = new BasicArrayListD();
    public readonly BasicArrayList idList = new BasicArrayListD();
    protected BasicPersitance(string recordId)
    {
        this.recordId = recordId;
    }

    // throws Exception
    public virtual void deleteRecoreStore(AbeClientInformationInterface abeClientInformation)
    {
        RecordStore.deleteRecordStore(this.getRecordId(abeClientInformation));
    }

    // throws Exception
    public virtual void deleteAll(AbeClientInformationInterface abeClientInformation)
    {
        int size = this.idList.size();
        for (int index = 0; index < size; index++) {
            int? integer = ((int?) this.idList.objectArray[index]);
            this.delete(abeClientInformation, ((int) integer));
        }
        this.clear();
    }

    // throws Exception
    public virtual void delete(AbeClientInformationInterface abeClientInformation, int deleteId)
    {
        RecordStore recordStore = NullRecordStore.NULL_RECORD_STORE;
        try {
            this.logUtil.putF(new StringMaker().append(this.persistanceStrings.DELETING_WITH_ID).appendint(deleteId).ToString(), this, this.commonStrings.delete);
            recordStore = RecordStore.openRecordStore(this.getRecordId(abeClientInformation), true);
            recordStore.deleteRecord(deleteId);
        } catch (Exception e) {
            throw e;
        } finally {
            if (recordStore != null) {
                PreLogUtil.put(this.persistanceStrings.CLOSING_RECORDSTORE, this, this.commonStrings.delete);
                recordStore.closeRecordStore();
            }
        }
    }

    public virtual string getRecordId(AbeClientInformationInterface abeClientInformation)
    {
        return this.platformRecordIdUtil.getRecordId(abeClientInformation, this.recordId);
    }

    public virtual BasicArrayList getList()
    {
        return this.valueList;
    }

    public virtual BasicArrayList getIds()
    {
        return this.idList;
    }

    public virtual void clear()
    {
        this.valueList.clear();
        this.idList.clear();
    }

}

