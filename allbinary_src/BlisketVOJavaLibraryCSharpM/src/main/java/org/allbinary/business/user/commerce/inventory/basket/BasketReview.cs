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
//using HashSet = java.util.HashSet;
//using Set = java.util.Set;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Item = org.allbinary.business.user.commerce.inventory.item.Item;
using ItemView = org.allbinary.business.user.commerce.inventory.item.ItemView;
using StdUtil = org.allbinary.logic.StdUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.commerce.inventory.basket;

public class BasketReview
{
    public BasicArrayList items = new BasicArrayListD();
    public BasketReview()
    {
    }

    public virtual bool? isValid()
    {
        return true;
    }

    public virtual void addItem(Item item)
    {
        this.items.add(item);
    }

    public virtual BasicArrayList getItems()
    {
        return this.items;
    }

    public virtual void removeItem(string id)
    {
        object[] itemArray = this.items.toArray();
        int size = itemArray.Length;
        for (int index = 0; index < size; index++) {
            Item item = ((Item) itemArray[index]);
            if (item.getId().compareTo(id) == 0) {
                this.items.remove(item);
            }
        }
    }

    public virtual void adjustItem(string id, string num)
    {
        object[] itemArray = this.items.toArray();
        int size = itemArray.Length;
        for (int index = 0; index < size; index++) {
            Item item = ((Item) itemArray[index]);
            if (item.getId().compareTo(id) == 0) {
                item.setNumber(num);
            }
        }
    }

    public virtual string getTotalWeight()
    {
        float weightFloat = 0f;
        object[] itemArray = this.items.toArray();
        int size = itemArray.Length;
        for (int index = 0; index < size; index++) {
            Item item = ((Item) itemArray[index]);
            weightFloat += ((float) item.getWeight());
        }
        return weightFloat.ToString();
    }

    public virtual int? getNumberOfItems()
    {
        return this.items.size();
    }

    public virtual Set getIds()
    {
        HashSet idSet = new HashSet();
        object[] itemArray = this.items.toArray();
        int size = itemArray.Length;
        for (int index = 0; index < size; index++) {
            Item item = ((Item) itemArray[index]);
            idSet.add(item.getId());
        }
        return ((Set) idSet);
    }

    public virtual int? getNumberOf(string id)
    {
        object[] itemArray = this.items.toArray();
        int size = itemArray.Length;
        for (int index = 0; index < size; index++) {
            Item item = ((Item) itemArray[index]);
            if (item.getId().compareTo(id) == 0) {
                return item.getNumber();
            }
        }
        return 0;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(BasketData.BASKET);
        object[] itemArray = this.items.toArray();
        int size = itemArray.Length;
        for (int index = 0; index < size; index++) {
            Item item = ((Item) itemArray[index]);
            node.appendChild(new ItemView(item, new BasicArrayListD()).toXmlNode(document));
        }
        return node;
    }

}

