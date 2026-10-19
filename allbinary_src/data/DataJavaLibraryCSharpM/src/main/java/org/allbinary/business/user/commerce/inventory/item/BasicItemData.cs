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

namespace org.allbinary.business.user.commerce.inventory.item;

public class BasicItemData
{
    private static readonly BasicItemData instance = new BasicItemData();
    public static BasicItemData getInstance()
    {
        return BasicItemData.instance;
    }

    public readonly string ITEM = "BASICITEM";
    public readonly string TOTAL = "BASICITEM_TOTAL";
    public readonly string ID = "BASICITEM_ID";
    public readonly string NUMBER = "BASICITEM_NUMBER";
    public readonly string INBASKETS = "BASICITEM_IN_BASKETS";
    public readonly string WEIGHT = "BASICITEM_WEIGHT";
    public readonly string NEWORUSED = "BASICITEM_NEW_OR_USED";
    public readonly string SUMMARY = "BASICITEM_SUMMARY";
    public readonly string DISTRIBUTOR = "BASICITEM_DISTRIBUTOR";
    public readonly string IDUSEDBYDISTRIBUTOR = "BASICITEM_IDUSEDBYDISTRIBUTOR";
    public readonly string PRODUCEDBY = "BASICITEM_PRODUCEDBY";
    public readonly string PRODUCTIONDATE = "BASICITEM_PRODUCTIONDATE";
    public readonly string STARTPRODUCTIONDATE = "BASICITEM_STARTPRODUCTIONDATE";
    public readonly string DESCRIPTION = "BASICITEM_DESCRIPTION";
    public readonly string KEYWORDS = "BASICITEM_KEYWORDS";
    public readonly string CATEGORY = "BASICITEM_CATEGORY";
    public readonly string TYPE = "BASICITEM_TYPE";
    public readonly string IMAGE = "BASICITEM_IMG";
    public readonly string SMALLIMAGE = "BASICITEM_SMALL_IMG";
    public readonly string MEDIUMIMAGE = "BASICITEM_MEDIUM_IMG";
    public readonly string LARGEIMAGE = "BASICITEM_LARGE_IMG";
    public readonly string PRICE = "BASICITEM_PRICE";
    public readonly string COMMENT = "BASICITEM_COMMENT";
    public readonly string CUSTOMS = "BASICITEM_CUSTOMS";
    public readonly string DOWNLOADS = "BASICITEM_DOWNLOADS";
    public readonly string GROUPS = "BASICITEM_GROUPS";
    public readonly string OPTIONS = "BASICITEM_OPTIONS";
    public readonly string PERMISSIONS = "BASICITEM_PERMISSIONS";
    public readonly string SPECIALS = "BASICITEM_SPECIALS";
}

