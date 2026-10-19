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
using StdUtil = org.allbinary.logic.StdUtil;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.data.tree.dom;

public class DomNodeListHelper
{
    public static BasicArrayList getVector(NodeList nodeList)
    {
        BasicArrayList vector = new BasicArrayListD();
        int size = nodeList.getLength();
        for (int index = 0; index < size; index++) {
            vector.add(DomNodeHelper.getTextNodeValue(nodeList.item(index)));
        }
        return vector;
    }

}

