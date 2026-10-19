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
//using Arrays = java.util.Arrays;
using CategoryView = org.allbinary.business.category.CategoryView;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ThemeValidation = org.allbinary.logic.visual.theme.ThemeValidation;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.store.theme;

public class StoreThemeCategoryView : CategoryView, DomNodeInterface
{
    public StoreThemeCategoryView(StoreThemeCategoryInterface categoryInterface) : base(((StoreThemeCategoryInterface) categoryInterface))
    {
        // base(((StoreThemeCategoryInterface) categoryInterface)) is called from the constructor declaration
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = base.toXmlNode(document);
        StoreThemeCategoryInterface storeThemeCategoryInterface = ((StoreThemeCategoryInterface) this.getCategoryInterface());
        ThemeValidation[] themeValidationArray = ((ThemeValidation[]) storeThemeCategoryInterface.getThemes().toArray());
        Arrays.sort(themeValidationArray, new ThemeComparator());
        int size = themeValidationArray.Length;
        for (int index = 0; index < size; index++) {
            ThemeValidation themeValidation = ((ThemeValidation) themeValidationArray[index]);
            node.appendChild(themeValidation.toXmlNode(document));
        }
        return node;
    }

}

