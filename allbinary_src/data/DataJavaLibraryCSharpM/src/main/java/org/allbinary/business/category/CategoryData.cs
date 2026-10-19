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
using CommonDataFileStrings = org.allbinary.logic.io.file.CommonDataFileStrings;

namespace org.allbinary.business.category;

public class CategoryData
{
    private static readonly CategoryData instance = new CategoryData();
    public static CategoryData getInstance()
    {
        return CategoryData.instance;
    }

    private CategoryData()
    {
    }

    public readonly string PARENT = "CATEGORY_PARENT";
    public readonly string NAME = "CATEGORY_NAME";
    public readonly string PATH = "CATEGORY_PATH";
    public readonly string LABEL = "CATEGORY_LABEL";
    public readonly string VIEW = "CATEGORY_VIEW_CATEGORY";
    public readonly string LEVEL = "CATEGORY_LEVEL";
    public readonly string REQUEST = "request";
    public readonly string ROOTCATEGORY = "Category";
    public readonly string UNCRYPTED_EXTENSION = CommonDataFileStrings.getInstance().UNCRYPTED_EXTENSION;
    public readonly string ENCRYPTED_EXTENSION = CommonDataFileStrings.getInstance().ENCRYPTED_EXTENSION;
}

