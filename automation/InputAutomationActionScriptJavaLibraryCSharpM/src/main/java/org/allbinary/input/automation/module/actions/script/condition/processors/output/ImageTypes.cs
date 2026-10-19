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
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using InputImageType = org.allbinary.input.media.image.InputImageType;
using StdUtil = org.allbinary.logic.StdUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.module.actions.script.condition.processors.output;

public class ImageTypes
{
    private BasicArrayList vector = new BasicArrayListD();
    public ImageTypes()
    {
    }

    public ImageTypes(Node node)
    {
        NodeList nodeList = node.getChildNodes();
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node childNode = nodeList.item(index);
            if (childNode.getNodeName().compareTo(ImageActionScriptOutputData.TYPE) == 0) {
                string nextImageTypeString = DomNodeHelper.getTextNodeValue(childNode);
                this.getVector().add(InputImageType.getInstance(nextImageTypeString));
            } else {
                throw new Exception("ImageTypes Unknown Node");
            }
        }
    }

    public static ImageTypes valueOf(object[] anyType)
    {
        ImageTypes imageTypes = new ImageTypes();
        for (int index = 0; index < anyType.Length; index++) {
            InputImageType imageType = InputImageType.getInstance(((string) anyType[index]));
            imageTypes.getVector().add(imageType);
        }
        return imageTypes;
    }

    public virtual BasicArrayList getVector()
    {
        return this.vector;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node newNode = document.createElement(ImageActionScriptOutputData.TYPES);
        int size = this.vector.size();
        for (int index = 0; index < size; index++) {
            InputImageType imageType = ((InputImageType) this.vector.get(index));
            newNode.appendChild(ModDomHelper.createTextNode(document, ImageActionScriptOutputData.TYPE, imageType.getName()));
        }
        return newNode;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("ImageTypes: ");
        int size = this.vector.size();
        for (int index = 0; index < size; index++) {
            InputImageType imageType = ((InputImageType) this.vector.get(index));
            stringBuffer.append(imageType.getName());
            if (index < size - 1) {
                stringBuffer.append(", ");
            }
        }
        return stringBuffer.ToString();
    }

}

