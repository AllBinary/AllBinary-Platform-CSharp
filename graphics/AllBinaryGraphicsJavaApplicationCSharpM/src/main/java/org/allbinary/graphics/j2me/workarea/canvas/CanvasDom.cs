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
using VectorCenterGenerator = org.allbinary.animation.vector.VectorCenterGenerator;
using DomHelper = org.allbinary.dom.DomHelper;
using GPoint = org.allbinary.graphics.GPoint;
using GraphicsStrings = org.allbinary.graphics.GraphicsStrings;
using PointFactory = org.allbinary.graphics.PointFactory;
using WorkAreaJPanel = org.allbinary.graphics.j2me.workarea.WorkAreaJPanel;
using GraphicItemFactory = org.allbinary.graphics.j2me.workarea.tools.GraphicItemFactory;
using GraphicItemInterface = org.allbinary.graphics.j2me.workarea.tools.GraphicItemInterface;
using LinesGraphicItem = org.allbinary.graphics.j2me.workarea.tools.LinesGraphicItem;
using StdUtil = org.allbinary.logic.StdUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Node = org.w3c.dom.Node;
using Document = org.w3c.dom.Document;

namespace org.allbinary.graphics.j2me.workarea.canvas;

public class CanvasDom
{
    private readonly GraphicsStrings graphicsStrings = GraphicsStrings.getInstance();
    public const string FRAME = "frame";
    public const string ROTATE = "rotate";
    public const string SIZE = "size";
    public const string X = "X";
    public const string Y = "Y";
    public const string ZOOM = "zoom";
    public const string GRID = "grid";
    public const string ENABLED = "enabled";
    public const string POSSIBLE = "possible";
    public const string GRAPHICITEMS = "graphicItems";
    public const string REAL_SIZE = "realSize";
    private HashMap<object, object> graphicItemHashMap;
    private double angle;
    private IntegerDimension dimension;
    private readonly Grid grid;
    public CanvasDom(Node canvasNode)
    {
        this.grid = new Grid();
        this.grid.grid = PointFactory.getInstance().createXY(0, 0);
        this.dimension = new IntegerDimension(0, 0);
        string name = canvasNode.getNodeName();
        if (string.CompareOrdinal(name, CanvasDom.FRAME) == 0) {
            this.graphicItemHashMap = StdUtil.getInstance().createHashMap();
            Node angleNode = DomHelper.getInstance().searchNodeList(CanvasDom.ROTATE, canvasNode.getChildNodes());
            Node angleTextNode = angleNode.getFirstChild();
            double angle = global::java.lang.JavaNumber.doubleValue(((double)(angleTextNode.getNodeValue())));
            this.setAngle(angle);
            Node sizeNode = DomHelper.getInstance().searchNodeList(CanvasDom.SIZE, canvasNode.getChildNodes());
            Node xNode = DomHelper.getInstance().searchNodeList(CanvasDom.X, sizeNode.getChildNodes());
            Node xTextNode = xNode.getFirstChild();
            int x = global::java.lang.JavaNumber.intValue(((int)(xTextNode.getNodeValue())));
            Node yNode = DomHelper.getInstance().searchNodeList(CanvasDom.Y, sizeNode.getChildNodes());
            Node yTextNode = yNode.getFirstChild();
            int y = global::java.lang.JavaNumber.intValue(((int)(yTextNode.getNodeValue())));
            this.setWorkArea(x, y);
            Node zoomNode = DomHelper.getInstance().searchNodeList(CanvasDom.ZOOM, canvasNode.getChildNodes());
            Node zoomTextNode = zoomNode.getFirstChild();
            this.grid.setZoom(global::java.lang.JavaNumber.intValue(((int)(zoomTextNode.getNodeValue()))));
            Node gridNode = DomHelper.getInstance().searchNodeList(CanvasDom.GRID, canvasNode.getChildNodes());
            Node gridSizeNode = DomHelper.getInstance().searchNodeList(CanvasDom.SIZE, gridNode.getChildNodes());
            Node gridXNode = DomHelper.getInstance().searchNodeList(CanvasDom.X, gridSizeNode.getChildNodes());
            Node gridXTextNode = gridXNode.getFirstChild();
            int gridX = global::java.lang.JavaNumber.intValue(((int)(gridXTextNode.getNodeValue())));
            Node gridYNode = DomHelper.getInstance().searchNodeList(CanvasDom.Y, gridSizeNode.getChildNodes());
            Node gridYTextNode = gridYNode.getFirstChild();
            int gridY = global::java.lang.JavaNumber.intValue(((int)(gridYTextNode.getNodeValue())));
            this.setGrid(gridX, gridY);
            Node enableNode = DomHelper.getInstance().searchNodeList(CanvasDom.ENABLED, gridNode.getChildNodes());
            Node enableTextNode = enableNode.getFirstChild();
            this.grid.showGrid(((bool) (((bool)(enableTextNode.getNodeValue())))));
            Node possibleNode = DomHelper.getInstance().searchNodeList(CanvasDom.POSSIBLE, gridNode.getChildNodes());
            Node possibleTextNode = possibleNode.getFirstChild();
            this.grid.isGridPossible = ((bool) (((bool)(possibleTextNode.getNodeValue()))));
            BasicArrayList graphicItemNodeList = DomHelper.getInstance().getChildrenWithoutTextNodes(CanvasDom.GRAPHICITEMS, canvasNode.getChildNodes());
            if (graphicItemNodeList != null) {
                this.graphicItemHashMap = GraphicItemFactory.getInstance().getInstance(graphicItemNodeList);
            }
        } else {
            throw new Exception("Frame Element Not Found but Found: " + name);
        }
    }

    public CanvasDom(CanvasJPanel canvasJPanel)
    {
        this.angle = canvasJPanel.getAngle();
        this.graphicItemHashMap = canvasJPanel.getGraphicItemHashMap();
        this.dimension = canvasJPanel.getCanvasDimension();
        this.grid = new Grid(canvasJPanel.getGrid());
        this.angle = canvasJPanel.getAngle();
    }

    public virtual double getAngle()
    {
        return this.angle;
    }

    public virtual HashMap<object, object> getGraphicItemHashMap()
    {
        return this.graphicItemHashMap;
    }

    public virtual void setAngle(double angle)
    {
        this.angle = angle;
    }

    // throws Exception
    public virtual void setWorkArea(int x, int y)
    {
        this.setDimension(new IntegerDimension(x, y));
    }

    // throws Exception
    public virtual void setGrid(int gridX, int gridY)
    {
        this.grid.grid = PointFactory.getInstance().createXY(gridX, gridY);
    }

    private Node getPointNode(GPoint point, string pointName)
    {
        Document document = WorkAreaJPanel.getDocument();
        Node pointNode = ((Node) document.createElement(pointName));
        Node xNode = ((Node) document.createElement(CanvasDom.X));
        Node xTextNode = ((Node) document.createTextNode((point.getX()).ToString()));
        xNode.appendChild(xTextNode);
        Node yNode = ((Node) document.createElement(CanvasDom.Y));
        Node yTextNode = ((Node) document.createTextNode((point.getY()).ToString()));
        yNode.appendChild(yTextNode);
        pointNode.appendChild(xNode);
        pointNode.appendChild(yNode);
        return pointNode;
    }

    // throws Exception
    public virtual Node toDom()
    {
        Document document = WorkAreaJPanel.getDocument();
        Node frameNode = ((Node) document.createElement(CanvasDom.FRAME));
        Node angleNode = ((Node) document.createElement(CanvasDom.ROTATE));
        Node angleTextNode = ((Node) document.createTextNode(((double)(this.getAngle())).ToString()));
        angleNode.appendChild(angleTextNode);
        Node sizeNode = ((Node) this.getPointNode(PointFactory.getInstance().createXY(this.getDimension().getWidth(), this.getDimension().getHeight()), CanvasDom.SIZE));
        Node zoomNode = ((Node) document.createElement(CanvasDom.ZOOM));
        Node zoomTextNode = ((Node) document.createTextNode(((int)(this.getGrid().getZoom())).ToString()));
        zoomNode.appendChild(zoomTextNode);
        Node gridNode = ((Node) document.createElement(CanvasDom.GRID));
        Node gridSizeNode = ((Node) this.getPointNode(this.getGrid().grid, CanvasDom.SIZE));
        gridNode.appendChild(gridSizeNode);
        Node enableNode = ((Node) document.createElement(CanvasDom.ENABLED));
        Node enableTextNode = ((Node) document.createTextNode(((bool)(this.getGrid().isGridOn())).ToString()));
        enableNode.appendChild(enableTextNode);
        gridNode.appendChild(enableNode);
        Node possibleNode = ((Node) document.createElement(CanvasDom.POSSIBLE));
        Node possibleTextNode = ((Node) document.createTextNode(((bool)(this.getGrid().isGridPossible())).ToString()));
        possibleNode.appendChild(possibleTextNode);
        gridNode.appendChild(possibleNode);
        Node realSizeNode = ((Node) document.createElement(REAL_SIZE));
        VectorCenterGenerator vectorCenterGenerator = new VectorCenterGenerator();
        vectorCenterGenerator.calculate(this.getGraphicItemHashMap());
        Node widthNode = ((Node) document.createElement(this.graphicsStrings.WIDTH));
        Node widthTextNode = ((Node) document.createTextNode((vectorCenterGenerator.getWidth()).ToString()));
        widthNode.appendChild(widthTextNode);
        realSizeNode.appendChild(widthNode);
        Node heightNode = ((Node) document.createElement(this.graphicsStrings.HEIGHT));
        Node heightTextNode = ((Node) document.createTextNode((vectorCenterGenerator.getHeight()).ToString()));
        heightNode.appendChild(heightTextNode);
        realSizeNode.appendChild(heightNode);
        frameNode.appendChild(angleNode);
        frameNode.appendChild(sizeNode);
        frameNode.appendChild(zoomNode);
        frameNode.appendChild(gridNode);
        frameNode.appendChild(realSizeNode);
        Node graphicItemNode = ((Node) document.createElement(CanvasDom.GRAPHICITEMS));
        object[] graphicItemArray = this.getGraphicItemHashMap().keySet().toArray();
        int size = graphicItemArray.Length;
        for (int index = 0; index < size; index++) {
            GraphicItemInterface item = ((GraphicItemInterface) this.graphicItemHashMap.get(graphicItemArray[index]));
            if (item.getName() == LinesGraphicItem.getStaticName()) {
                if (item.isValid()) {
                    graphicItemNode.appendChild(item.toDom(this));
                }
            }
        }
        frameNode.appendChild(graphicItemNode);
        return frameNode;
    }

    public virtual IntegerDimension getDimension()
    {
        return this.dimension;
    }

    public virtual void setDimension(IntegerDimension dimension)
    {
        this.dimension = dimension;
    }

    public virtual Grid getGrid()
    {
        return this.grid;
    }

}

