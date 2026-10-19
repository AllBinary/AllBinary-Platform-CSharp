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

namespace views.admin.inventory.listings;

public interface InventoryViewSearchInterface
{
    // throws Exception
    string searchSingleStaticPage();

    // throws Exception
    string searchSingleDynamicPage();

    // throws Exception
    string[] search();

    // throws Exception
    string getProduct(string product);

}

