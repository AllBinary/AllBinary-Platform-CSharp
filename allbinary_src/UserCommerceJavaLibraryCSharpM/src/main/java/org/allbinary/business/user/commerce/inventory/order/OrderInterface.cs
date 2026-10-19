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
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;

namespace org.allbinary.business.user.commerce.inventory.order;

public interface OrderInterface
{
    void setShippingMethod(string shippingType);

    void setPaymentMethod(string value);

    void setSpecial(string special);

    void setStoreName(string value);

    void setUserComments(string value);

    void setUserCancelComments(string value);

    void setStoreComments(string value);

    void setStoreCancelComments(string value);

    BasketInterface getBasket();

    string getShippingMethod();

    string getPaymentMethod();

    string getSpecial();

    string getId();

    string getStoreName();

    string getUserComments();

    string getUserCancelComments();

    string getStoreComments();

    string getStoreCancelComments();

}

