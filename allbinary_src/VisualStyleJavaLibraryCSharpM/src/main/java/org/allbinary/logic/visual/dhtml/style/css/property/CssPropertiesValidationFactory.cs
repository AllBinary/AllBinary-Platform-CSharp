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
using StdUtil = org.allbinary.logic.StdUtil;
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.visual.dhtml.style.css.property;

public class CssPropertiesValidationFactory
{
    private CssPropertiesValidationFactory()
    {
    }

    // throws Exception
    public static BasicArrayList getInstance(NodeList nodeList)
    {
        BasicArrayList propertiesVector = new BasicArrayListD();
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node node = nodeList.item(index);
            if (node.getNodeName().compareTo(CssPropertyData.getInstance().NAME) == 0) {
                ValidationInterface cssPropertyValidationInterface = ((ValidationInterface) CssPropertyValidationFactory.getInstance(node));
                propertiesVector.add(cssPropertyValidationInterface);
            }
        }
        return propertiesVector;
    }

    public static BasicArrayList getInstance(HashMap<object, object> hashMap)
    {
        BasicArrayList styles = new BasicArrayListD();
        return styles;
    }

}

