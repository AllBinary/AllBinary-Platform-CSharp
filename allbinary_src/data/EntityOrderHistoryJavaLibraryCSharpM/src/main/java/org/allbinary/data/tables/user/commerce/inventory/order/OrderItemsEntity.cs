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
//using ListIterator = java.util.ListIterator;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using HistoryDbInitInfo = org.allbinary.business.init.db.HistoryDbInitInfo;
using StdUtil = org.allbinary.logic.StdUtil;
using UserData = org.allbinary.business.user.UserData;
using ShippingAddressData = org.allbinary.business.user.address.ShippingAddressData;
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;
using BasketReview = org.allbinary.business.user.commerce.inventory.basket.BasketReview;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using Item = org.allbinary.business.user.commerce.inventory.item.Item;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using OrderData = org.allbinary.business.user.commerce.inventory.order.OrderData;
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using OrderInterface = org.allbinary.business.user.commerce.inventory.order.OrderInterface;
using ShippingMethodData = org.allbinary.business.user.commerce.shipping.ShippingMethodData;
using OrderItemIdGenerator = org.allbinary.data.generator.OrderItemIdGenerator;
using TableDataFactory = org.allbinary.data.tables.TableDataFactory;
using InventoryEntity = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntity;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.data.tables.user.commerce.inventory.order;

public class OrderItemsEntity : AbSqlBean, OrderItemsEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    public readonly string tableName = "orderitems";
    public OrderItemsEntity() : base(new HistoryDbInitInfo())
    {
        // base(new HistoryDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public virtual void insert(string userName, OrderInterface order)
    {
        BasicArrayList vector = new BasicArrayListD();
        try {
            BasketInterface basket = order.getBasket();
            Set items = basket.getIds();
            string ZERO_STRING = TableDataFactory.getInstance().ZERO_STRING;
            string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
            InventoryEntity inventoryEntity = InventoryEntityFactory.getInstance().getInventoryEntityInstance();
            object[] itemsArray = items.toArray();
            int itemsSize = itemsArray.Length;
            for (int i = 0; i < itemsSize; i++) {
                string item = ((string) itemsArray[i]);
                ItemInterface itemInterface = inventoryEntity.getItem(item);
                vector = new BasicArrayListD();
                vector.add(new OrderItemIdGenerator().getNext());
                vector.add(order.getId());
                vector.add(TableDataFactory.getInstance().INTEGER_MAX_VALUE_STRING);
                vector.add(userName);
                vector.add(order.getStoreName());
                vector.add(itemInterface.getId());
                vector.add(basket.getNumberOf(item).ToString());
                vector.add(itemInterface.getNewOrUsed());
                vector.add(itemInterface.getSummary());
                vector.add(itemInterface.getDistributor());
                vector.add(itemInterface.getIdUsedByDistributor());
                vector.add(itemInterface.getProducedBy());
                vector.add(itemInterface.getProductionDate());
                vector.add(itemInterface.getStartProductionDate());
                vector.add(itemInterface.getDescription());
                vector.add(itemInterface.getKeywords());
                vector.add(itemInterface.getCategory());
                vector.add(itemInterface.getType());
                vector.add(itemInterface.getSmallImage());
                vector.add(itemInterface.getMediumImage());
                vector.add(itemInterface.getLargeImage());
                vector.add(itemInterface.getWeight());
                vector.add(itemInterface.getPrice().ToString());
                vector.add(itemInterface.getComment());
                vector.add(itemInterface.getCustoms());
                vector.add(itemInterface.getDownloads());
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(EMPTY_STRING);
                vector.add(ZERO_STRING);
                vector.add(ZERO_STRING);
                vector.add(ZERO_STRING);
                vector.add(ZERO_STRING);
                this.insert(vector);
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF("Command Success Added: " + items.size(), this, INSERT);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put("Command Failed: " + vector.ToString(), this, INSERT, e);
            }
        }
    }

    public virtual void setStatus(string orderId, string groupId, string status)
    {
        try {
            HashMap whereHashMap = StdUtil.getInstance().createHashMap();
            HashMap updateHashMap = StdUtil.getInstance().createHashMap();
            whereHashMap.put(OrderData.ID, orderId);
            whereHashMap.put(ShippingMethodData.GROUP, groupId);
            updateHashMap.put(OrderHistoryData.STATUS, status);
            base.updateWhere(whereHashMap, updateHashMap);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "setStatus", e);
            }
        }
    }

    public virtual bool isEverythingShipped(string orderId)
    {
        try {
            BasicArrayList itemStatusVector = base.getColumnWhere(OrderHistoryData.STATUS, OrderData.ID, orderId);
            int size = itemStatusVector.size();
            for (int index = 0; index < size; index++) {
                string status = ((string) itemStatusVector.get(index));
                if (string.CompareOrdinal(status, OrderHistoryData.SHIPPED) != 0) {
                    return false;
                }
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "isEverythingShipped", e);
            }
            return false;
        }
    }

    public virtual BasketReview getBasketReview(string orderId)
    {
        try {
            BasketReview basketReview = new BasketReview();
            HashMap keyValues = StdUtil.getInstance().createHashMap();
            keyValues.put(OrderData.ID, orderId);
            BasicArrayList items = base.getRows(keyValues);
            EntryData entryData = EntryData.getInstance();
            if (items != null && items.size() > 0) {
                string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
                object[] itemsArray = items.toArray();
                int itemsSize = itemsArray.Length;
                for (int i = 0; i < itemsSize; i++) {
                    HashMap itemHashMap = ((HashMap) itemsArray[i]);
                    itemHashMap.put(basicItemData.INBASKETS, EMPTY_STRING);
                    itemHashMap.put(entryData.ENABLE, EMPTY_STRING);
                    itemHashMap.put(entryData.TIMECREATED, EMPTY_STRING);
                    itemHashMap.put(entryData.LASTMODIFIED, EMPTY_STRING);
                    itemHashMap.put(basicItemData.GROUPS, EMPTY_STRING);
                    itemHashMap.put(basicItemData.OPTIONS, EMPTY_STRING);
                    itemHashMap.put(basicItemData.PERMISSIONS, EMPTY_STRING);
                    itemHashMap.put(basicItemData.SPECIALS, EMPTY_STRING);
                    Item item = new Item(itemHashMap);
                    basketReview.addItem(item);
                }
                return basketReview;
            } else {
                return null;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "getBasketReview", e);
            }
            return null;
        }
    }

    public string createTableStatement()
    {
        EntryData entryData = EntryData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("CREATE TABLE ");
        stringBuffer.append(this.tableName);
        stringBuffer.append(" (");
        stringBuffer.append(entryData.ID);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(OrderData.ID);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(ShippingMethodData.GROUP);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(UserData.USERNAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(StoreFrontData.getInstance().NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.ID);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.NUMBER);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.NEWORUSED);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.SUMMARY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.DISTRIBUTOR);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.IDUSEDBYDISTRIBUTOR);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.PRODUCEDBY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.PRODUCTIONDATE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.STARTPRODUCTIONDATE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.DESCRIPTION);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(basicItemData.KEYWORDS);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.CATEGORY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.TYPE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.SMALLIMAGE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.MEDIUMIMAGE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.LARGEIMAGE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.WEIGHT);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(basicItemData.PRICE);
        stringBuffer.append(" VARCHAR(20) NOT NULL,");
        stringBuffer.append(basicItemData.COMMENT);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(basicItemData.CUSTOMS);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(basicItemData.DOWNLOADS);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(ShippingMethodData.COST);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(OrderHistoryData.TAX);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.STREET);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.CITY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.STATE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.CODE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.COUNTRY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingMethodData.NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(entryData.SPECIAL);
        stringBuffer.append(" VARCHAR(255) ,");
        stringBuffer.append(OrderHistoryData.STATUS);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(OrderHistoryData.CANCELINFO);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(OrderHistoryData.CANCELTYPE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(OrderHistoryData.SHIPPEDDATE);
        stringBuffer.append(" BIGINT(19) UNSIGNED ,");
        stringBuffer.append(OrderHistoryData.ORDERDATE);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(OrderHistoryData.TRANSDATE);
        stringBuffer.append(" BIGINT(19) UNSIGNED ,");
        stringBuffer.append(OrderHistoryData.CANCELDATE);
        stringBuffer.append(" BIGINT(19) UNSIGNED ,");
        stringBuffer.append("PRIMARY KEY(");
        stringBuffer.append(entryData.ID);
        stringBuffer.append(") )");
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

}

