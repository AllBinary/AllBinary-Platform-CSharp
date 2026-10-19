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
//using Calendar = java.util.Calendar;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using EntryData = org.allbinary.business.entry.EntryData;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using ProductIdGenerator = org.allbinary.data.generator.ProductIdGenerator;
using StdUtil = org.allbinary.logic.StdUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TimeUtil = org.allbinary.time.TimeUtil;

namespace org.allbinary.business.user.commerce.inventory.item.download;

public class DownloadableItem
{
    private readonly string id;
    private readonly string basicItemId;
    private readonly string enabled;
    private readonly string system;
    private readonly string platform;
    private readonly string specialName;
    private readonly string version;
    private readonly string changes;
    private readonly string licenseFile;
    private readonly string file;
    private readonly long? size;
    private readonly long? validTime;
    private readonly string retries;
    public DownloadableItem(string id)
    {
        string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
        this.id = new ProductIdGenerator().getNext();
        this.basicItemId = id;
        this.enabled = EntryData.getInstance().YES;
        this.system = "Java";
        this.platform = "Android";
        this.specialName = EMPTY_STRING;
        this.version = EMPTY_STRING;
        this.changes = EMPTY_STRING;
        this.licenseFile = EMPTY_STRING;
        this.file = EMPTY_STRING;
        this.size = (0).ToString();
        this.validTime = (0).ToString();
        this.retries = EMPTY_STRING;
    }

    public DownloadableItem(HashMap hashMap)
    {
        this.id = ((string) hashMap.get(DownloadItemData.ID));
        this.basicItemId = ((string) hashMap.get(BasicItemData.getInstance().ID));
        this.enabled = ((string) hashMap.get(EntryData.getInstance().ENABLE));
        this.system = ((string) hashMap.get(DownloadItemData.SYSTEM));
        this.platform = ((string) hashMap.get(DownloadItemData.PLATFORM));
        this.specialName = ((string) hashMap.get(DownloadItemData.SPECIAL_NAME));
        this.version = ((string) hashMap.get(DownloadItemData.VERSION));
        this.changes = ((string) hashMap.get(DownloadItemData.CHANGES));
        this.licenseFile = ((string) hashMap.get(DownloadItemData.LICENSE_FILE));
        this.file = ((string) hashMap.get(DownloadItemData.FILE));
        string value = ((string) hashMap.get(DownloadItemData.SIZE));
        if (!StringValidationUtil.getInstance().isEmpty(value)) {
            this.size = (value).ToString();
        } else {
            this.size = 0;
        }
        string validTime = ((string) hashMap.get(DownloadItemData.VALID_TIME));
        if (!StringValidationUtil.getInstance().isEmpty(validTime)) {
            this.validTime = (validTime).ToString();
        } else {
            string totalYears = ((string) hashMap.get(DownloadItemData.VALID_TIME_YEARS));
            string totalMonths = ((string) hashMap.get(DownloadItemData.VALID_TIME_MONTHS));
            string totalDays = ((string) hashMap.get(DownloadItemData.VALID_TIME_DAYS));
            string totalHours = ((string) hashMap.get(DownloadItemData.VALID_TIME_HOURS));
            string totalMinutes = ((string) hashMap.get(DownloadItemData.VALID_TIME_MINUTES));
            string totalSeconds = ((string) hashMap.get(DownloadItemData.VALID_TIME_SECONDS));
            long totalTime = TimeUtil.getInstance().getTotalTime(totalYears, totalMonths, totalDays, totalHours, totalMinutes, totalSeconds);
            this.validTime = totalTime;
        }
        this.retries = ((string) hashMap.get(DownloadItemData.RETRIES));
    }

    public virtual BasicArrayList toVector()
    {
        Calendar calendar = Calendar.getInstance();
        string time = calendar.getTimeInMillis().ToString();
        BasicArrayList values = new BasicArrayListD();
        values.add(getId());
        values.add(this.basicItemId);
        values.add(this.enabled);
        values.add(this.getSpecialName());
        values.add(this.getVersion());
        values.add(this.getChanges());
        values.add(this.getSystem());
        values.add(this.getPlatform());
        values.add(this.getLicenseFile());
        values.add(this.getFile());
        values.add(this.getSize().ToString());
        values.add(this.getValidTime().ToString());
        values.add(this.getRetries());
        values.add(time);
        values.add(time);
        return values;
    }

    public virtual HashMap toHashMap()
    {
        HashMap values = StdUtil.getInstance().createHashMap();
        values.put(DownloadItemData.ID, this.getId());
        values.put(BasicItemData.getInstance().ID, this.basicItemId);
        values.put(EntryData.getInstance().ENABLE, this.enabled);
        values.put(DownloadItemData.SYSTEM, this.getSystem());
        values.put(DownloadItemData.PLATFORM, this.getPlatform());
        values.put(DownloadItemData.SPECIAL_NAME, this.getSpecialName());
        values.put(DownloadItemData.VERSION, this.getVersion());
        values.put(DownloadItemData.CHANGES, this.getChanges());
        values.put(DownloadItemData.LICENSE_FILE, this.getLicenseFile());
        values.put(DownloadItemData.FILE, this.getFile());
        values.put(DownloadItemData.SIZE, this.getSize().ToString());
        values.put(DownloadItemData.VALID_TIME, this.getValidTime().ToString());
        values.put(DownloadItemData.RETRIES, this.getRetries());
        Calendar calendar = Calendar.getInstance();
        string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
        values.put(EntryData.getInstance().LASTMODIFIED, time);
        return values;
    }

    public virtual string getId()
    {
        return this.id;
    }

    public virtual string getSystem()
    {
        return this.system;
    }

    public virtual string getPlatform()
    {
        return this.platform;
    }

    public virtual string getSpecialName()
    {
        return this.specialName;
    }

    public virtual string getVersion()
    {
        return this.version;
    }

    public virtual string getChanges()
    {
        return this.changes;
    }

    public virtual string getLicenseFile()
    {
        return this.licenseFile;
    }

    public virtual string getFile()
    {
        return this.file;
    }

    public virtual long? getSize()
    {
        return this.size;
    }

    public virtual long? getValidTime()
    {
        return this.validTime;
    }

    public virtual string getRetries()
    {
        return this.retries;
    }

}

