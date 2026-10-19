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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CategoryInterface = org.allbinary.business.category.CategoryInterface;
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;
using ThemeValidation = org.allbinary.logic.visual.theme.ThemeValidation;
using CompositeTransformInfoInterface = org.allbinary.logic.visual.transform.info.CompositeTransformInfoInterface;

namespace org.allbinary.business.category.store.theme;

public interface StoreThemeCategoryInterface : CategoryInterface, TableMappingInterface, ValidationInterface, CompositeTransformInfoInterface
{
    void addTheme(ThemeValidation themeValidation);

    BasicArrayList getThemes();

}

