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
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using Document = org.w3c.dom.Document;

namespace org.allbinary.data.tree.category;

public interface CategoryLoaderInterface : CategoryModifierTreeInterface
{
    Document getDoc(CategoryInterface categoryInterface);

    CategoryInterface get(CategoryInterface categoryInterface);

    CategoryInterface getAll(CategoryInterface categoryInterface);

}

