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
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using HelperTag = tags.HelperTag;
using InventoryItemView = views.admin.inventory.InventoryItemView;

namespace admin.taghelpers;

public class InventoryRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private readonly ItemInterface itemInterface;
    public InventoryRequestHelper(HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        HelperTag inventoryTag = ((HelperTag) propertiesHashMap.get(AbTagData.PARENT));
        InventoryItemView itemView = InventoryItemViewParentTagHelper.getInstance().getInventoryItemView(inventoryTag);
        this.itemInterface = itemView.getItemInterface();
    }

    // throws Exception
    public virtual string insert()
    {
        try {
            TableMappingInterface dataMappingInterface = ((TableMappingInterface) this.getItemInterface());
            BasicArrayList values = dataMappingInterface.toVector();
            InventoryEntityFactory.getInstance().getInventoryEntityInstance().insert(values);
            string success = "Successfully Added Product";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "insert()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to add item to Inventory";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "insert()", e);
            }
            return error;
        }
    }

    public virtual string delete()
    {
        try {
            TableMappingInterface dataMappingInterface = ((TableMappingInterface) this.getItemInterface());
            string id = ((string) dataMappingInterface.getKey());
            InventoryEntityFactory.getInstance().getInventoryEntityInstance().deleteWhere(basicItemData.ID, id);
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Successfully Removed the item with ");
            stringBuffer.append(basicItemData.ID);
            stringBuffer.append("=");
            stringBuffer.append(id);
            stringBuffer.append(" from to the Inventory table");
            string success = stringBuffer.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, tagStrings.DO_START_TAG);
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to remove item with from Inventory";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, tagStrings.DO_START_TAG, e);
            }
            return error;
        }
    }

    public virtual string update()
    {
        try {
            this.delete();
            this.insert();
            string success = "Item Successfully Updated";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed To Update Item";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

    public virtual ItemInterface getItemInterface()
    {
        return this.itemInterface;
    }

}

