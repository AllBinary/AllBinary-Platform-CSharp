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
        for (int blueIndex_1 = this.MAX / 2; blueIndex_1 < this.MAX; blueIndex_1 += this.delta) {
            for (int greenIndex_1 = 0; greenIndex_1 < this.MAX / 2; greenIndex_1 += this.delta) {
                for (int redIndex_1 = 0; redIndex_1 < this.MAX / 2; redIndex_1 += this.delta) {
                    node.appendChild(this.getColorNode(document, redIndex_1, greenIndex_1, blueIndex_1));
                }
            }
        }
        for (int redIndex_4 = this.MAX / 2; redIndex_4 < this.MAX; redIndex_4 += this.delta) {
            for (int greenIndex_4 = 0; greenIndex_4 < this.MAX / 2; greenIndex_4 += this.delta) {
                for (int blueIndex_4 = 0; blueIndex_4 < this.MAX / 2; blueIndex_4 += this.delta) {
                    node.appendChild(this.getColorNode(document, redIndex_4, greenIndex_4, blueIndex_4));
                }
            }
        }
        for (int greenIndex_7 = this.MAX / 2; greenIndex_7 < this.MAX; greenIndex_7 += this.delta) {
            for (int redIndex_7 = 0; redIndex_7 < this.MAX / 2; redIndex_7 += this.delta) {
                for (int blueIndex_7 = 0; blueIndex_7 < this.MAX / 2; blueIndex_7 += this.delta) {
                    node.appendChild(this.getColorNode(document, redIndex_7, greenIndex_7, blueIndex_7));
                }
            }
        }
        for (int greenIndex_10 = 0; greenIndex_10 < this.MAX; greenIndex_10 += 2 * this.delta) {
            for (int redIndex_10 = 0; redIndex_10 < this.MAX; redIndex_10 += 2 * this.delta) {
                for (int blueIndex_10 = 0; blueIndex_10 < this.MAX; blueIndex_10 += 2 * this.delta) {
                    node.appendChild(this.getColorNode(document, redIndex_10, greenIndex_10, blueIndex_10));
                }
            }
        }
        return node;
    }

}

