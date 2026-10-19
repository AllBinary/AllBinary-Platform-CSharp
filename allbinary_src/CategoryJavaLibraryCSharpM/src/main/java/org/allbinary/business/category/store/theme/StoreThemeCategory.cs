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
using Category = org.allbinary.business.category.Category;
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using CategoryPropertiesFactoryInterface = org.allbinary.business.category.properties.CategoryPropertiesFactoryInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using ThemeData = org.allbinary.logic.visual.theme.ThemeData;
using ThemeValidation = org.allbinary.logic.visual.theme.ThemeValidation;
using ThemesData = org.allbinary.logic.visual.theme.ThemesData;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.business.category.store.theme;

public class StoreThemeCategory : Category, StoreThemeCategoryInterface
{
    private TransformInfoInterface transformInfoInterface;
    private BasicArrayList themeVector;
    public StoreThemeCategory(TransformInfoInterface transformInfoInterface, CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface, int level) : base(categoryPropertiesFactoryInterface, level)
    {
        // base(categoryPropertiesFactoryInterface, level) is called from the constructor declaration
        this.transformInfoInterface = transformInfoInterface;
        this.themeVector = new BasicArrayListD();
    }

    public StoreThemeCategory(TransformInfoInterface transformInfoInterface, CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface) : base(rootCategoryInterface, parentCategoryInterface, categoryPropertiesFactoryInterface)
    {
        // base(rootCategoryInterface, parentCategoryInterface, categoryPropertiesFactoryInterface) is called from the constructor declaration
        this.transformInfoInterface = transformInfoInterface;
        this.themeVector = new BasicArrayListD();
    }

    public StoreThemeCategory(TransformInfoInterface transformInfoInterface, Node node, CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface, int level) : base(categoryPropertiesFactoryInterface, level)
    {
        // base(categoryPropertiesFactoryInterface, level) is called from the constructor declaration
        this.transformInfoInterface = transformInfoInterface;
        this.themeVector = new BasicArrayListD();
        this.addThemes(node);
    }

    public StoreThemeCategory(TransformInfoInterface transformInfoInterface, Node node, CategoryInterface rootCategoryInterface, CategoryInterface parentCategoryInterface, CategoryPropertiesFactoryInterface categoryPropertiesFactoryInterface) : base(rootCategoryInterface, parentCategoryInterface, categoryPropertiesFactoryInterface)
    {
        // base(rootCategoryInterface, parentCategoryInterface, categoryPropertiesFactoryInterface) is called from the constructor declaration
        this.transformInfoInterface = transformInfoInterface;
        this.themeVector = new BasicArrayListD();
        this.addThemes(node);
    }

    public virtual TransformInfoInterface getTransformInfoInterface()
    {
        return this.transformInfoInterface;
    }

    // throws Exception
    public virtual void addThemes(Node node)
    {
        Node themesNode = DomSearchHelper.getNode(ThemesData.getInstance().NAME, node.getChildNodes());
        NodeList nodeList = themesNode.getChildNodes();
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node themeNode = nodeList.item(index);
            if (themeNode.getNodeName().compareTo(ThemeData.getInstance().NAME) == 0) {
                this.themeVector.add(new ThemeValidation(this, themeNode));
            }
        }
    }

    public virtual void addTheme(ThemeValidation themeValidation)
    {
        this.themeVector.add(themeValidation);
    }

    public virtual BasicArrayList getThemes()
    {
        return this.themeVector;
    }

    // throws Exception
    public virtual bool? isValid()
    {
        if (!base.isValid()) {
            return false;
        }
        return true;
    }

    // throws Exception
    public virtual HashMap toHashMap()
    {
        HashMap categoryHashMap = base.toHashMap();
        categoryHashMap.put(ThemesData.getInstance().NAME, this.themeVector);
        return categoryHashMap;
    }

    // throws Exception
    public virtual BasicArrayList toVector()
    {
        BasicArrayList categoryVector = base.toVector();
        return categoryVector;
    }

}

