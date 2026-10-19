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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;
using StyleData = org.allbinary.logic.visual.dhtml.style.StyleData;
using StylesData = org.allbinary.logic.visual.dhtml.style.StylesData;
using ColorsView = org.allbinary.logic.visual.dhtml.style.color.ColorsView;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.transform.template.customizer.includes.style.css.template.retail;

public class EditCssStyleValidation : CssStyleValidation, ValidationInterface, DomNodeInterface
{
    public EditCssStyleValidation()
    {
    }

    public EditCssStyleValidation(Document document) : base(document)
    {
        // base(document) is called from the constructor declaration
    }

    public EditCssStyleValidation(HashMap hashMap) : base(hashMap)
    {
        // base(hashMap) is called from the constructor declaration
    }

    public virtual bool? isValid()
    {
        return base.isValid();
    }

    public virtual string validationInfo()
    {
        return base.validationInfo();
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
        Node node = document.createElement(StylesData.getInstance().NAME);
        Node styleNode = document.createElement(StyleData.getInstance().NAME);
        node.appendChild(styleNode);
        styleNode.appendChild(new ColorsView().toXmlNode(document));
        int size = this.cssStyleElementVector.size();
        for (int i = 0; i < size; i++) {
            DomNodeInterface styleDomNodeInterface = ((DomNodeInterface) cssStyleElementVector.get(i));
            styleNode.appendChild(styleDomNodeInterface.toXmlNode(document));
        }
        return node;
    }

}

