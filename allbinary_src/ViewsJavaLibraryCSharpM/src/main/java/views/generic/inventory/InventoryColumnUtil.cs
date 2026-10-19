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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using InventoryEntity = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntity;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace views.generic.inventory;

public class InventoryColumnUtil
{
    private static readonly InventoryColumnUtil instance = new InventoryColumnUtil();
    public static InventoryColumnUtil getInstance()
    {
        return InventoryColumnUtil.instance;
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    public virtual BasicArrayList getColumnWhereLike(InventoryEntity inventoryEntity, string category, string column)
    {
        this.logUtil.putF("Start Category: " + category, this, "getKeywords");
        BasicArrayList keywords = new BasicArrayListD();
        BasicArrayList vectorOfHashMaps = inventoryEntity.getAllRows();
        int size = vectorOfHashMaps.size();
        for (int index = 0; index < size; index++) {
            HashMap hashMap = ((HashMap) vectorOfHashMaps.get(index));
            string categoryName = ((string) hashMap.get(basicItemData.CATEGORY));
            if (!StringValidationUtil.getInstance().isEmpty(categoryName) && categoryName.StartsWith(category)) {
                keywords.add(hashMap.get(column));
            }
        }
        return keywords;
    }

}

