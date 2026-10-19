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
using CategoryView = org.allbinary.business.category.CategoryView;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ThemeInterface = org.allbinary.logic.visual.theme.ThemeInterface;
using ThemePropertiesView = org.allbinary.logic.visual.theme.ThemePropertiesView;
using ThemeValidation = org.allbinary.logic.visual.theme.ThemeValidation;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.store.theme;

public class StoreThemeCategoryPathView : CategoryView, DomNodeInterface
{
    public StoreThemeCategoryPathView(StoreThemeCategoryInterface categoryInterface) : base(((StoreThemeCategoryInterface) categoryInterface))
    {
        // base(((StoreThemeCategoryInterface) categoryInterface)) is called from the constructor declaration
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = base.toXmlNode(document);
        StoreThemeCategoryInterface storeThemeCategoryInterface = ((StoreThemeCategoryInterface) this.getCategoryInterface());
        object[] themeArray = storeThemeCategoryInterface.getThemes().toArray();
        int size = themeArray.Length;
        for (int i = 0; i < size; i++) {
            ThemeValidation themeValidation = ((ThemeValidation) themeArray[i]);
            DomNodeInterface domNodeInterface = ((DomNodeInterface) new ThemePropertiesView(((ThemeInterface) themeValidation)));
            node.appendChild(domNodeInterface.toXmlNode(document));
        }
        return node;
    }

}

