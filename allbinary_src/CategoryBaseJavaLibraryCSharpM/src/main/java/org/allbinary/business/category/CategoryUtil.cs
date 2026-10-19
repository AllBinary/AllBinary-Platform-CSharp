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
using System.Runtime.CompilerServices;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using AbPath = org.allbinary.logic.io.path.AbPath;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringUtils = org.apache.commons.lang3.StringUtils;
using Attr = org.w3c.dom.Attr;
using NamedNodeMap = org.w3c.dom.NamedNodeMap;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category;

public class CategoryUtil
{
    private CategoryUtil()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static int getPathLevel(AbPath categoryPath)
    {
        int count = StringUtils.countMatches(categoryPath.ToString(), AbPathData.getInstance().SEPARATOR);
        return count;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static string getNameFromNode(Node node)
    {
        NamedNodeMap attributes = node.getAttributes();
        Attr attrNode = ((Attr) attributes.getNamedItem(CategoryData.getInstance().LABEL));
        if (attrNode != null) {
            return attrNode.getValue();
        } else {
            Node labelNode = DomSearchHelper.getNodeNoThrow(CategoryData.getInstance().LABEL, node.getChildNodes());
            if (labelNode != null) {
                return DomNodeHelper.getTextNodeValue(labelNode);
            }
        }
        return StringUtil.getInstance().EMPTY_STRING;
    }

}

