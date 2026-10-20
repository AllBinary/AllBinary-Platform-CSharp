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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using Validation = org.allbinary.logic.control.validate.Validation;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.theme;

public class ThemesValidation : Validation, DomNodeInterface
{
    private BasicArrayList themeVector;
    public ThemesValidation()
    {
        this.themeVector = new BasicArrayListD();
    }

    public ThemesValidation(Node node)
    {
    }

    public ThemesValidation(HashMap<object, object> hashMap)
    {
    }

    public virtual bool? isValid()
    {
        return true;
    }

    public virtual string validationInfo()
    {
        return null;
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(ThemesData.getInstance().NAME);
        int size = this.themeVector.size();
        for (int i = 0; i < size; i++) {
            DomNodeInterface themeDomNodeInterface = ((DomNodeInterface) this.themeVector.get(i));
            node.appendChild(themeDomNodeInterface.toXmlNode(document));
        }
        return node;
    }

}

