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

namespace org.allbinary.graphics.j2me.workarea.canvas;

public class CanvasDom
{
    private readonly GraphicsStrings graphicsStrings = GraphicsStrings.getInstance();
    public static readonly string FRAME = "frame";
    public static readonly string ROTATE = "rotate";
    public static readonly string SIZE = "size";
    public static readonly string X = "X";
    public static readonly string Y = "Y";
    public static readonly string ZOOM = "zoom";
    public static readonly string GRID = "grid";
    public static readonly string ENABLED = "enabled";
    public static readonly string POSSIBLE = "possible";
    public static readonly string GRAPHICITEMS = "graphicItems";
    public static readonly string REAL_SIZE = "realSize";
    private HashMap graphicItemHashMap;
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
            Node angleNode = DomHelper.getInstance().searchNodeList(this.ROTATE, canvasNode.getChildNodes());
            Node angleTextNode = angleNode.getFirstChild();
            double angle = ((double) angleTextNode.getNodeValue());
            this.setAngle(angle);
            Node sizeNode = DomHelper.getInstance().searchNodeList(this.SIZE, canvasNode.getChildNodes());
            Node xNode = DomHelper.getInstance().searchNodeList(this.X, sizeNode.getChildNodes());
            Node xTextNode = xNode.getFirstChild();
            int x = ((int) xTextNode.getNodeValue());
            Node yNode = DomHelper.getInstance().searchNodeList(this.Y, sizeNode.getChildNodes());
            Node yTextNode = yNode.getFirstChild();
            int y = ((int) yTextNode.getNodeValue());
            this.setWorkArea(x, y);
            Node zoomNode = DomHelper.getInstance().searchNodeList(this.ZOOM, canvasNode.getChildNodes());
            Node zoomTextNode = zoomNode.getFirstChild();
            this.grid.setZoom(((int) zoomTextNode.getNodeValue()));
            Node gridNode = DomHelper.getInstance().searchNodeList(this.GRID, canvasNode.getChildNodes());
            Node gridSizeNode = DomHelper.getInstance().searchNodeList(this.SIZE, gridNode.getChildNodes());
            Node gridXNode = DomHelper.getInstance().searchNodeList(this.X, gridSizeNode.getChildNodes());
            Node gridXTextNode = gridXNode.getFirstChild();
            int gridX = ((int) gridXTextNode.getNodeValue());
            Node gridYNode = DomHelper.getInstance().searchNodeList(this.Y, gridSizeNode.getChildNodes());
            Node gridYTextNode = gridYNode.getFirstChild();
            int gridY = ((int) gridYTextNode.getNodeValue());
            this.setGrid(gridX, gridY);
            Node enableNode = DomHelper.getInstance().searchNodeList(this.ENABLED, gridNode.getChildNodes());
            Node enableTextNode = enableNode.getFirstChild();
            this.grid.showGrid(enableTextNode.getNodeValue());
            Node possibleNode = DomHelper.getInstance().searchNodeList(this.POSSIBLE, gridNode.getChildNodes());
            Node possibleTextNode = possibleNode.getFirstChild();
            this.grid.isGridPossible = possibleTextNode.getNodeValue();
            BasicArrayList graphicItemNodeList = DomHelper.getInstance().getChildrenWithoutTextNodes(this.GRAPHICITEMS, canvasNode.getChildNodes());
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

    public virtual HashMap getGraphicItemHashMap()
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
        org.w3c.dom.Document document = WorkAreaJPanel.getDocument();
        Node pointNode = ((Node) document.createElement(pointName));
        Node xNode = ((Node) document.createElement(this.X));
        Node xTextNode = ((Node) document.createTextNode((point.getX()).ToString()));
        xNode.appendChild(xTextNode);
        Node yNode = ((Node) document.createElement(this.Y));
        Node yTextNode = ((Node) document.createTextNode((point.getY()).ToString()));
        yNode.appendChild(yTextNode);
        pointNode.appendChild(xNode);
        pointNode.appendChild(yNode);
        return pointNode;
    }

    // throws Exception
    public virtual Node toDom()
    {
        org.w3c.dom.Document document = WorkAreaJPanel.getDocument();
        Node frameNode = ((Node) document.createElement(this.FRAME));
        Node angleNode = ((Node) document.createElement(this.ROTATE));
        Node angleTextNode = ((Node) document.createTextNode(this.getAngle().ToString()));
        angleNode.appendChild(angleTextNode);
        Node sizeNode = ((Node) this.getPointNode(PointFactory.getInstance().createXY(this.getDimension().getWidth(), this.getDimension().getHeight()), this.SIZE));
        Node zoomNode = ((Node) document.createElement(this.ZOOM));
        Node zoomTextNode = ((Node) document.createTextNode(this.getGrid().getZoom().ToString()));
        zoomNode.appendChild(zoomTextNode);
        Node gridNode = ((Node) document.createElement(this.GRID));
        Node gridSizeNode = ((Node) this.getPointNode(this.getGrid().grid, this.SIZE));
        gridNode.appendChild(gridSizeNode);
        Node enableNode = ((Node) document.createElement(this.ENABLED));
        Node enableTextNode = ((Node) document.createTextNode(this.getGrid().isGridOn().ToString()));
        enableNode.appendChild(enableTextNode);
        gridNode.appendChild(enableNode);
        Node possibleNode = ((Node) document.createElement(this.POSSIBLE));
        Node possibleTextNode = ((Node) document.createTextNode(this.getGrid().isGridPossible().ToString()));
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
        Node graphicItemNode = ((Node) document.createElement(this.GRAPHICITEMS));
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

