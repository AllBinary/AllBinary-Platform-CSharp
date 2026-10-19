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
//using Color = java.awt.Color;
//using Point = java.awt.Point;
//using BufferedImage = java.awt.image.BufferedImage;
using java.util;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using ColorCacheFactory = org.allbinary.graphics.color.ColorCacheFactory;
using ColorCacheable = org.allbinary.graphics.color.ColorCacheable;
using CapturedBufferedImagesCacheSingleton = org.allbinary.input.media.image.capture.CapturedBufferedImagesCacheSingleton;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AutomaticCacheInterface = org.allbinary.logic.util.cache.AutomaticCacheInterface;
using ColorRange = org.allbinary.media.image.analysis.ColorRange;
using ColorRangeInterface = org.allbinary.media.image.analysis.ColorRangeInterface;
using BufferedImageFrameCacheable = org.allbinary.media.image.cache.BufferedImageFrameCacheable;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.actions.script.condition;

public class ColorAtActionScriptCondition : BasicProfileActionScriptCondition, ColorAtActionScriptConditionInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private ColorAtActionScriptConditionJPanel colorAtActionScriptConditionJPanel = null;
    private Point point;
    private ColorRangeInterface colorRangeInterface = ((ColorRangeInterface) new ColorRange());
    private static readonly string NAME = "If Color At";
    public ColorAtActionScriptCondition(Node node) : base(ColorAtActionScriptCondition.NAME, node)
    {
        // base(ColorAtActionScriptCondition.NAME, node) is called from the constructor declaration
        this.point = new Point(0, 0);
        Node actionNode = DomSearchHelper.getNode(ColorAtActionScriptConditionData.NAME, node.getChildNodes());
        if (actionNode != null) {
            NodeList nodeList = actionNode.getChildNodes();
            for (int index = 0; index < nodeList.getLength(); index++) {
                Node childNode = nodeList.item(index);
                if (childNode.getNodeName().compareTo(ColorAtActionScriptConditionData.LOCATION_X) == 0) {
                    string locationX = DomNodeHelper.getTextNodeValue(childNode);
                    this.point.x = (locationX).ToString();
                } else if (childNode.getNodeName().compareTo(ColorAtActionScriptConditionData.LOCATION_Y) == 0) {
                    string locationY = DomNodeHelper.getTextNodeValue(childNode);
                    this.point.y = (locationY).ToString();
                } else if (childNode.getNodeName().compareTo(ColorAtActionScriptConditionData.MIN_RED) == 0) {
                    string @string = DomNodeHelper.getTextNodeValue(childNode);
                    this.getColorRangeInterface().setMinRed((@string).ToString());
                } else if (childNode.getNodeName().compareTo(ColorAtActionScriptConditionData.MAX_RED) == 0) {
                    string @string = DomNodeHelper.getTextNodeValue(childNode);
                    this.getColorRangeInterface().setMaxRed((@string).ToString());
                } else if (childNode.getNodeName().compareTo(ColorAtActionScriptConditionData.MIN_GREEN) == 0) {
                    string @string = DomNodeHelper.getTextNodeValue(childNode);
                    this.getColorRangeInterface().setMinGreen((@string).ToString());
                } else if (childNode.getNodeName().compareTo(ColorAtActionScriptConditionData.MAX_GREEN) == 0) {
                    string @string = DomNodeHelper.getTextNodeValue(childNode);
                    this.getColorRangeInterface().setMaxGreen((@string).ToString());
                } else if (childNode.getNodeName().compareTo(ColorAtActionScriptConditionData.MIN_BLUE) == 0) {
                    string @string = DomNodeHelper.getTextNodeValue(childNode);
                    this.getColorRangeInterface().setMinBlue((@string).ToString());
                } else if (childNode.getNodeName().compareTo(ColorAtActionScriptConditionData.MAX_BLUE) == 0) {
                    string @string = DomNodeHelper.getTextNodeValue(childNode);
                    this.getColorRangeInterface().setMaxBlue((@string).ToString());
                }
            }
        } else {
            throw new Exception("Color At Action Script Condition Node Null");
        }
        this.init();
    }

    public ColorAtActionScriptCondition() : base(ColorAtActionScriptCondition.NAME)
    {
        // base(ColorAtActionScriptCondition.NAME) is called from the constructor declaration
        this.point = new Point(0, 0);
        this.init();
    }

    private void init()
    {
        this.colorAtActionScriptConditionJPanel = new ColorAtActionScriptConditionJPanel(this);
    }

    public virtual Point getPoint()
    {
        return this.point;
    }

    public virtual void setPoint(Point point)
    {
        this.point = point;
    }

    public virtual void showDialog()
    {
        this.colorAtActionScriptConditionJPanel.getColorAtActionJDialog().setVisible(true);
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(ColorAtActionScriptConditionData.LOCATION_X, (this.getPoint().x).ToString());
        hashMap.put(ColorAtActionScriptConditionData.LOCATION_Y, (this.getPoint().y).ToString());
        hashMap.put(ColorAtActionScriptConditionData.MIN_RED, (this.getColorRangeInterface().getMinRed()).ToString());
        hashMap.put(ColorAtActionScriptConditionData.MAX_RED, (this.getColorRangeInterface().getMaxRed()).ToString());
        hashMap.put(ColorAtActionScriptConditionData.MIN_GREEN, (this.getColorRangeInterface().getMinGreen()).ToString());
        hashMap.put(ColorAtActionScriptConditionData.MAX_GREEN, (this.getColorRangeInterface().getMaxGreen()).ToString());
        hashMap.put(ColorAtActionScriptConditionData.MIN_BLUE, (this.getColorRangeInterface().getMinBlue()).ToString());
        hashMap.put(ColorAtActionScriptConditionData.MAX_BLUE, (this.getColorRangeInterface().getMaxBlue()).ToString());
        this.logUtil.putF("HashMap: " + hashMap.ToString(), this, "toHashMap()");
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = base.toXmlNode(document);
        node.appendChild(ModDomHelper.createNodeWithValueNodes(document, ColorAtActionScriptConditionData.NAME, this.toHashMap()));
        return node;
    }

    // throws Exception
    public virtual bool shouldProcess(long frame)
    {
        BufferedImageFrameCacheable capturedBufferedImageCacheable = ((BufferedImageFrameCacheable) (((AutomaticCacheInterface) CapturedBufferedImagesCacheSingleton.getInstance())).get((frame).ToString()));
        BufferedImage bufferedImage = capturedBufferedImageCacheable.getBufferedImage();
        AutomaticCacheInterface automaticCacheInterface = ColorCacheFactory.getInstance();
        int? colorInteger = (bufferedImage.getRGB(this.getPoint().x, this.getPoint().y)).ToString();
        ColorCacheable colorCacheable = ((ColorCacheable) automaticCacheInterface.get(colorInteger));
        Color color = colorCacheable.getColor();
        if (this.colorRangeInterface.isInRange(color)) {
            return base.shouldProcess(frame);
        }
        return false;
    }

    public virtual void log()
    {
        string message = new StringMaker().append("getPoint(): ").append(this.getPoint().ToString()).append(CommonSeps.getInstance().NEW_LINE).append(this.getColorRangeInterface().ToString()).ToString();
        this.logUtil.putF(message, this, "log");
    }

    public virtual ColorRangeInterface getColorRangeInterface()
    {
        return this.colorRangeInterface;
    }

    public virtual void setColorRangeInterface(ColorRangeInterface colorRangeInterface)
    {
        this.colorRangeInterface = colorRangeInterface;
    }

}

