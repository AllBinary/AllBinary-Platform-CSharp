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
//using Serializable = java.io.Serializable;
using java.util;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using Money = org.allbinary.business.user.commerce.money.Money;
using MoneyException = org.allbinary.business.user.commerce.money.MoneyException;
using InventoryEntity = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntity;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.business.user.commerce.inventory.basket;

public class Basket : BasketInterface, Serializable
{
    private HashMap items = StdUtil.getInstance().createHashMap();
    public Basket()
    {
    }

    public virtual void addItem(string id, string num)
    {
        if (this.items.containsKey(id)) {
            string oldNumStr = new string((((string) this.items.get(id))).ToCharArray());
            int? oldNumInt = (oldNumStr).ToString();
            int? numInt = (num).ToString();
            int? newNumInt = ((int) oldNumInt) + ((int) numInt);
            this.items.put(id, newNumInt.ToString());
        } else {
            this.items.put(id, num);
        }
    }

    public virtual void removeItem(string id)
    {
        this.items.remove(id);
    }

    public virtual void adjustItem(string id, string num)
    {
        if (((int) (num).ToString()) > 0) {
            this.items.put(id, num);
        } else {
            this.items.remove(id);
        }
    }

    public virtual string getTotalWeight()
    {
        HashMap itemsAndNumberInBasket = this.getItems();
        Money totalWeight = new Money();
        if (itemsAndNumberInBasket.size() > 0) {
            Set items = itemsAndNumberInBasket.keySet();
            string product = null;
            float? weightFloat = null;
            object[] itemArray = items.toArray();
            int size = itemArray.Length;
            for (int index = 0; index < size; index++) {
                product = new string((((string) itemArray[index])).ToCharArray());
                weightFloat = new InventoryEntity().getWeight(product);
                weightFloat = ((float) getNumberOf(product)) * ((float) weightFloat);
                totalWeight.add(weightFloat.ToString());
            }
        }
        return totalWeight.ToString();
    }

    public virtual int? getNumberOfItems()
    {
        return this.items.size();
    }

    public virtual Set getIds()
    {
        Set set = this.items.keySet();
        return set;
    }

    public virtual HashMap getItems()
    {
        return this.items;
    }

    public virtual int? getNumberOf(string product)
    {
        string numStr = ((string) this.items.get(product));
        return (numStr).ToString();
    }

    // throws MoneyException
    public virtual Money getSubTotal()
    {
        HashMap itemsAndNumberInBasket = this.getItems();
        Money subTotal = new Money();
        if (itemsAndNumberInBasket.size() > 0) {
            Set items = itemsAndNumberInBasket.keySet();
            InventoryEntityFactory inventoryEntityFactory = InventoryEntityFactory.getInstance();
            InventoryEntity inventoryEntity = ((InventoryEntity) inventoryEntityFactory.getInventoryEntityInstance());
            object[] itemArray = items.toArray();
            int size = itemArray.Length;
            for (int index = 0; index < size; index++) {
                string product = new string((((string) itemArray[index])).ToCharArray());
                ItemInterface itemInterface = inventoryEntity.getItem(product);
                Money productTotal = itemInterface.getPrice();
                productTotal.multiply(((int) getNumberOf(product)));
                subTotal.add(productTotal.ToString());
            }
        }
        return subTotal;
    }

}

