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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.dhtml.style.color;

public class ColorsView : DomNodeInterface
{
    private readonly CommonPhoneStrings commonPhoneStrings = CommonPhoneStrings.getInstance();
    private readonly int HEXRADIX = 16;
    private readonly int MAX = 255;
    public readonly int delta = 20;
    public ColorsView()
    {
    }

    // throws Exception
    public virtual Node getColorNode(Document document, int redIndex, int greenIndex, int blueIndex)
    {
        StringMaker hexColorStringBuffer = new StringMaker();
        if (redIndex < this.HEXRADIX) {
            hexColorStringBuffer.append(this.commonPhoneStrings.ZERO);
        }
        hexColorStringBuffer.append(Integer.toString(redIndex, HEXRADIX));
        if (greenIndex < this.HEXRADIX) {
            hexColorStringBuffer.append(this.commonPhoneStrings.ZERO);
        }
        hexColorStringBuffer.append(Integer.toString(greenIndex, HEXRADIX));
        if (blueIndex < this.HEXRADIX) {
            hexColorStringBuffer.append(this.commonPhoneStrings.ZERO);
        }
        hexColorStringBuffer.append(Integer.toString(blueIndex, HEXRADIX));
        Node colorNode = ModDomHelper.createNameValueNodes(document, ColorData.getInstance().NAME, hexColorStringBuffer.ToString());
        return colorNode;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = ModDomHelper.createNameValueNodes(document, ColorsData.getInstance().NAME, "RGB Colors In Hex");
        Node blackNode = ModDomHelper.createNameValueNodes(document, ColorData.getInstance().NAME, "000000");
        node.appendChild(blackNode);
        for (int index = 0; index < this.MAX; index += this.delta) {
            StringMaker hexColorStringBuffer = new StringMaker();
            if (index < this.HEXRADIX) {
                hexColorStringBuffer.append(this.commonPhoneStrings.ZERO);
            }
            hexColorStringBuffer.append(Integer.toString(index, HEXRADIX));
            if (index < this.HEXRADIX) {
                hexColorStringBuffer.append(this.commonPhoneStrings.ZERO);
            }
            hexColorStringBuffer.append(Integer.toString(index, HEXRADIX));
            if (index < this.HEXRADIX) {
                hexColorStringBuffer.append(this.commonPhoneStrings.ZERO);
            }
            hexColorStringBuffer.append(Integer.toString(index, HEXRADIX));
            Node colorNode = ModDomHelper.createNameValueNodes(document, ColorData.getInstance().NAME, hexColorStringBuffer.ToString());
            node.appendChild(colorNode);
        }
        Node whiteNode = ModDomHelper.createNameValueNodes(document, ColorData.getInstance().NAME, "FFFFFF");
        node.appendChild(whiteNode);
        for (int blueIndex = this.MAX / 2; blueIndex < this.MAX; blueIndex += this.delta) {
            for (int greenIndex = 0; greenIndex < this.MAX / 2; greenIndex += this.delta) {
                for (int redIndex = 0; redIndex < this.MAX / 2; redIndex += this.delta) {
                    node.appendChild(this.getColorNode(document, redIndex, greenIndex, blueIndex));
                }
            }
        }
        for (int redIndex = this.MAX / 2; redIndex < this.MAX; redIndex += this.delta) {
            for (int greenIndex = 0; greenIndex < this.MAX / 2; greenIndex += this.delta) {
                for (int blueIndex = 0; blueIndex < this.MAX / 2; blueIndex += this.delta) {
                    node.appendChild(this.getColorNode(document, redIndex, greenIndex, blueIndex));
                }
            }
        }
        for (int greenIndex = this.MAX / 2; greenIndex < this.MAX; greenIndex += this.delta) {
            for (int redIndex = 0; redIndex < this.MAX / 2; redIndex += this.delta) {
                for (int blueIndex = 0; blueIndex < this.MAX / 2; blueIndex += this.delta) {
                    node.appendChild(this.getColorNode(document, redIndex, greenIndex, blueIndex));
                }
            }
        }
        for (int greenIndex = 0; greenIndex < this.MAX; greenIndex += 2 * this.delta) {
            for (int redIndex = 0; redIndex < this.MAX; redIndex += 2 * this.delta) {
                for (int blueIndex = 0; blueIndex < this.MAX; blueIndex += 2 * this.delta) {
                    node.appendChild(this.getColorNode(document, redIndex, greenIndex, blueIndex));
                }
            }
        }
        return node;
    }

}

