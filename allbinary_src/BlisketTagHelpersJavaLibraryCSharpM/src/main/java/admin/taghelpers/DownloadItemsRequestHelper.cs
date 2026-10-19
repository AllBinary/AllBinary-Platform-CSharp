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
//using PageContext = javax.servlet.jsp.PageContext;
using AbTagData = admin.tags.AbTagData;
using DownloadableItem = org.allbinary.business.user.commerce.inventory.item.download.DownloadableItem;
using DownloadItemsEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.downloads.DownloadItemsEntityFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using HelperTag = tags.HelperTag;
using DownloadableInventoryItemView = views.admin.inventory.download.DownloadableInventoryItemView;

namespace admin.taghelpers;

public class DownloadItemsRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly DownloadableItem downloadableItem;
    public DownloadItemsRequestHelper(HashMap hashMap, PageContext pageContext)
    {
        HelperTag inventoryTag = ((HelperTag) hashMap.get(AbTagData.PARENT));
        InventoryItemViewParentTagHelper inventoryItemViewParentTagHelper = InventoryItemViewParentTagHelper.getInstance();
        DownloadableInventoryItemView downloadableInventoryItemView = inventoryItemViewParentTagHelper.getDownloadableInventoryItemView(inventoryTag);
        this.downloadableItem = downloadableInventoryItemView.getDownloadableItem();
    }

    public virtual string insert()
    {
        try {
            BasicArrayList vector = this.downloadableItem.toVector();
            DownloadItemsEntityFactory.getInstance().getDownloadItemsEntityInstance().insert(vector);
            string success = "Successfully inserted " + this.downloadableItem.getId() + " into downloaditems table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "insert()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to insert " + this.downloadableItem.getId() + " into downloaditems table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "inserts()", e);
            }
            return error;
        }
    }

    public virtual string delete()
    {
        try {
            DownloadItemsEntityFactory.getInstance().getDownloadItemsEntityInstance().delete(this.downloadableItem.getId());
            string success = "Successfully deleted";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "delete()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to delete";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "delete()", e);
            }
            return error;
        }
    }

    public virtual string update()
    {
        try {
            string success = "Update Successful";
            HashMap values = this.downloadableItem.toHashMap();
            DownloadItemsEntityFactory.getInstance().getDownloadItemsEntityInstance().update(values);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(this.downloadableItem.getId() + CommonSeps.getInstance().SPACE + success, this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to update: " + this.downloadableItem.getId();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

}

