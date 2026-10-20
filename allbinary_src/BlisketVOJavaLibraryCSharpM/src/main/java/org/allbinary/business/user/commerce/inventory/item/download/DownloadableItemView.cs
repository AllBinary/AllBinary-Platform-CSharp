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
using Calendar = java.util.Calendar;
using java.util;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.commerce.inventory.item.download;

public class DownloadableItemView : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private DownloadableItem downloadableItem;
    public DownloadableItemView(DownloadableItem downloadableItem)
    {
        this.downloadableItem = downloadableItem;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGING)) {
            this.logUtil.putF(this.commonStrings.START, this, "toXmlNode");
        }
        HashMap<object, object> hashMap = this.downloadableItem.toHashMap();
        long totalTime = ((long) this.downloadableItem.getValidTime());
        Calendar calendar = Calendar.getInstance();
        int year = calendar.get(Calendar.YEAR);
        int month = calendar.get(Calendar.MONTH);
        int day = calendar.get(Calendar.DAY_OF_MONTH);
        int hour = calendar.get(Calendar.HOUR);
        int minute = calendar.get(Calendar.MINUTE);
        int second = calendar.get(Calendar.SECOND);
        calendar.setTimeInMillis(calendar.getTimeInMillis() + totalTime);
        int yearDelta = calendar.get(Calendar.YEAR);
        int monthDelta = calendar.get(Calendar.MONTH);
        int dayDelta = calendar.get(Calendar.DAY_OF_MONTH);
        int hourDelta = calendar.get(Calendar.HOUR);
        int minuteDelta = calendar.get(Calendar.MINUTE);
        int secondDelta = calendar.get(Calendar.SECOND);
        hashMap.put(DownloadItemData.VALID_TIME_YEARS, (yearDelta - year).ToString());
        hashMap.put(DownloadItemData.VALID_TIME_MONTHS, (monthDelta - month).ToString());
        hashMap.put(DownloadItemData.VALID_TIME_DAYS, (dayDelta - day).ToString());
        hashMap.put(DownloadItemData.VALID_TIME_HOURS, (hourDelta - hour).ToString());
        hashMap.put(DownloadItemData.VALID_TIME_MINUTES, (minuteDelta - minute).ToString());
        hashMap.put(DownloadItemData.VALID_TIME_SECONDS, (secondDelta - second).ToString());
        Set<object> keySet = hashMap.keySet();
        Node node = document.createElement(DownloadItemData.NAME);
        StringUtil stringUtil = StringUtil.getInstance();
        object[] nameArray = keySet.toArray();
        int size = nameArray.Length;
        for (int index = 0; index < size; index++) {
            string name = ((string) nameArray[index]);
            string value = ((string) hashMap.get(name));
            value = stringUtil.getNonNull(value);
            node.appendChild(ModDomHelper.createNameValueNodes(document, name, value));
        }
        return node;
    }

    public virtual Document toXmlDoc()
    {
        return null;
    }

    public virtual string view()
    {
        return null;
    }

}

