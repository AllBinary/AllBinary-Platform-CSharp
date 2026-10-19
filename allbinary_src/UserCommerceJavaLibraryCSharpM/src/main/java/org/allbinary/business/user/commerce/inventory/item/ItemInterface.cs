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
using Money = org.allbinary.business.user.commerce.money.Money;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;

namespace org.allbinary.business.user.commerce.inventory.item;

public interface ItemInterface : TableMappingInterface
{
    void setId(string itemId);

    void setNumber(string number);

    void setInBaskets(string value);

    void setWeight(string value);

    void setEnabled(string value);

    void setNewOrUsed(string value);

    void setSummary(string value);

    void setDistributor(string value);

    void setIdUsedByDistributor(string value);

    void setProducedBy(string value);

    void setProductionDate(string value);

    void setStartProductionDate(string value);

    void setDescription(string value);

    void setKeywords(string value);

    void setCategory(string value);

    void setType(string value);

    void setSmallImage(string value);

    void setMediumImage(string value);

    void setLargeImage(string value);

    void setTimeEntered(string value);

    void setLastModified(string value);

    void setPrice(Money value);

    void setComment(string value);

    void setCustoms(string value);

    void setDownloads(string value);

    void setGroups(string value);

    void setOptions(string value);

    void setPermissions(string value);

    void setSpecials(string value);

    string getId();

    string getNumber();

    string getInBaskets();

    string getWeight();

    string getEnabled();

    string getNewOrUsed();

    string getSummary();

    string getDistributor();

    string getIdUsedByDistributor();

    string getProducedBy();

    string getProductionDate();

    string getStartProductionDate();

    string getDescription();

    string getKeywords();

    string getCategory();

    string getType();

    string getSmallImage();

    string getMediumImage();

    string getLargeImage();

    string getTimeEntered();

    string getLastModified();

    Money getPrice();

    string getComment();

    string getCustoms();

    string getDownloads();

    string getGroups();

    string getOptions();

    string getPermissions();

    string getSpecials();

    Money getTotal();

}

