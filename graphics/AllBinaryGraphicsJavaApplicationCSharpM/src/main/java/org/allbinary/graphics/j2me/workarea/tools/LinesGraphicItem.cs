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
using System.Runtime.CompilerServices;
//using java.awt;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using DefaultMutableTreeNode = javax.swing.tree.DefaultMutableTreeNode;
//using MutableTreeNode = javax.swing.tree.MutableTreeNode;
using DomHelper = org.allbinary.dom.DomHelper;
using GameInputStrings = org.allbinary.game.input.GameInputStrings;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using StatusFactory = org.allbinary.graphics.j2me.StatusFactory;
using CanvasDom = org.allbinary.graphics.j2me.workarea.canvas.CanvasDom;
using IntegerDimension = org.allbinary.graphics.j2me.workarea.canvas.IntegerDimension;
using BasicGraphicsPipeline = org.allbinary.graphics.pipeline.BasicGraphicsPipeline;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PositionStrings = org.allbinary.math.PositionStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class LinesGraphicItem : GraphicItemInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly GameInputStrings gameInputStrings = GameInputStrings.getInstance();
    private DefaultMutableTreeNode treeNode = null;
    private BasicArrayList pointTreeNodeVector = null;
    private GPoint currentMousePoint = null;
    private GPoint fulcrumPoint = null;
    private bool active = false;
    private double theta = 0.0;
    private static readonly string RECT = "rect";
    private static readonly string ARC = "arc";
    private static readonly string STRING = "string";
    private static readonly string CHAR = "char";
    private static readonly string IMAGE = "image";
    private static int item = 0;
    private Color color = new Color(((int) BasicColorFactory.getInstance().WHITE));
    private Points points;
    public LinesGraphicItem()
    {
        this.points = new Points();
        try {
            this.init();
            this.active = true;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
        }
    }

    public LinesGraphicItem(Node linesNode)
    {
        this.points = new Points();
        this.init();
        this.active = false;
        BasicArrayList lineNodes = DomHelper.getInstance().getWithoutTextNodes(linesNode.getChildNodes());
        int numberOfLines = lineNodes.size();
        for (int index = 0; index < numberOfLines; index++) {
            Node lineNode = ((Node) lineNodes.get(index));
            BasicArrayList pointNodes = DomHelper.getInstance().getWithoutTextNodes(lineNode.getChildNodes());
            Node pointOneNode = DomHelper.getInstance().searchNodeList(PointsDomUtil.getInstance().POINTONE, pointNodes);
            this.addPoint(pointOneNode.getChildNodes());
            if (index == numberOfLines - 1) {
                Node pointTwoNode = DomHelper.getInstance().searchNodeList(PointsDomUtil.getInstance().POINTTWO, pointNodes);
                this.addPoint(pointTwoNode.getChildNodes());
            }
        }
        if (numberOfLines == 0) {
            throw new Exception("Lines node does not contain a line");
        }
    }

    // throws Exception
    public virtual void init()
    {
        this.treeNode = new DefaultMutableTreeNode(PointsDomUtil.getInstance().LINES + LinesGraphicItem.item);
        LinesGraphicItem.item++;
        this.points.init();
        this.pointTreeNodeVector = new BasicArrayListD();
        this.fulcrumPoint = PointFactory.getInstance().createXY(0, 0);
    }

    // throws Exception
    public virtual void translate(int x, int y)
    {
        StatusFactory.getInstance().setStatus("Translating: " + this.points.getPoints());
        BasicGraphicsPipeline basicGraphicsPipeline = new BasicGraphicsPipeline(this.points.getPoints());
        basicGraphicsPipeline.translate(x, y);
        this.points = new Points();
        this.points.addPoints(basicGraphicsPipeline.getMatrix());
    }

    public virtual void setRotate(double theta)
    {
        while (theta > 2 * Math.PI) {
            theta -= 2 * Math.PI;
        }
        while (theta < 0.0) {
            theta += 2 * Math.PI;
        }
        this.theta = theta;
    }

    public virtual void addRotate(double theta)
    {
        this.setRotate(this.theta + theta);
    }

    public virtual void setAngle(double angle)
    {
        this.setRotate(Math.ToRadians(angle));
    }

    public virtual void addAngle(double angle)
    {
        this.setRotate(this.theta + Math.ToRadians(angle));
    }

    public virtual MutableTreeNode getTreeNode()
    {
        return ((MutableTreeNode) this.treeNode);
    }

    private static readonly string NAME = "Line Tool";
    public virtual string getName()
    {
        return LinesGraphicItem.NAME;
    }

    public static string getStaticName()
    {
        return LinesGraphicItem.NAME;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void addPoint(NodeList pointNodes)
    {
        BasicArrayList list = DomHelper.getInstance().getWithoutTextNodes(pointNodes);
        Node xNode = DomHelper.getInstance().searchNodeList(PositionStrings.getInstance().X, list);
        Node xTextNode = xNode.getFirstChild();
        int? xInteger = xTextNode.getNodeValue();
        Node yNode = DomHelper.getInstance().searchNodeList(PositionStrings.getInstance().Y, list);
        Node yTextNode = yNode.getFirstChild();
        int? yInteger = yTextNode.getNodeValue();
        GPoint point = PointFactory.getInstance().createXY(((int) xInteger), ((int) yInteger));
        this.addPoint(point);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void addPoint(GPoint point)
    {
        this.points.getPoints().add(point);
        this.logUtil.putF(point.ToString(), this, "addPoint");
        this.pointTreeNodeVector.add(new DefaultMutableTreeNode(point.ToString()));
        this.treeNode.add(((DefaultMutableTreeNode) this.pointTreeNodeVector.get(this.pointTreeNodeVector.size() - 1)));
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual GPoint removePoint()
    {
        GPoint point = null;
        if (this.points.getSize() > 0) {
            int lastPoint = this.points.getSize() - 1;
            point = ((GPoint) this.points.getPoints().removeAt(lastPoint));
            int index = this.pointTreeNodeVector.size() - 1;
            if (index > 0) {
                this.treeNode.remove(((DefaultMutableTreeNode) this.pointTreeNodeVector.get(index)));
                this.pointTreeNodeVector.remove(index);
            }
        }
        return point;
    }

    public virtual bool isActive()
    {
        return this.active;
    }

    public virtual void deactivate()
    {
        this.active = false;
    }

    public virtual void activate()
    {
        this.active = true;
    }

    // throws Exception
    public virtual void duplicatePoints(BasicArrayList list)
    {
        int size = list.size();
        for (int index = 0; index < size; index++) {
            GPoint point = ((GPoint) list.get(index));
            if (point != null) {
                this.points.getPoints().add(PointFactory.getInstance().createXY(point.getX(), point.getY()));
                this.pointTreeNodeVector.add(new DefaultMutableTreeNode(point.ToString()));
                this.treeNode.add(((DefaultMutableTreeNode) this.pointTreeNodeVector.get(this.pointTreeNodeVector.size() - 1)));
            }
        }
    }

    // throws Exception
    public virtual GraphicItemInterface duplicate()
    {
        LinesGraphicItem linesGraphicItem = new LinesGraphicItem();
        linesGraphicItem.duplicatePoints(this.points.getPoints());
        linesGraphicItem.deactivate();
        return linesGraphicItem;
    }

    public virtual double getAngle()
    {
        return Math.ToDegrees(this.theta);
    }

    public virtual void setFulcrumPoint(GPoint point)
    {
        this.fulcrumPoint = point;
    }

    public virtual void paint(Graphics g, double? canvasAngle, IntegerDimension dimension, int x, int y)
    {
        try {
            Graphics2D graphics = ((Graphics2D) g);
            graphics.setColor(getColor());
            graphics.setStroke(new BasicStroke(x));
            if (this.isActive() && this.currentMousePoint != null) {
                this.points.getPoints().add(this.currentMousePoint);
            }
            BasicArrayList tempPointVector = PointsUtil.getInstance().doTransforms(this.points.getPoints(), canvasAngle, PointFactory.getInstance().createXY(dimension.getWidth(), dimension.getHeight()));
            if (this.isActive() && this.currentMousePoint != null) {
                this.currentMousePoint = ((GPoint) this.points.getPoints().removeAt(this.points.getSize() - 1));
            }
            int size = tempPointVector.size();
            GPoint firstPoint = null;
            if (size > 0) {
                firstPoint = ((GPoint) tempPointVector.get(0));
            }
            for (int index = 1; index < size; index++) {
                GPoint secondPoint = ((GPoint) tempPointVector.get(index));
                graphics.drawLine((firstPoint.getX() * x) - (x / 4), (firstPoint.getY() * y) - (y / 4), (secondPoint.getX() * x) - (x / 4), (secondPoint.getY() * y) - (y / 4));
                firstPoint = secondPoint;
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "mouseMoved", e);
        }
    }

    // throws Exception
    public virtual Node toDom(CanvasDom canvasDom)
    {
        return PointsDomUtil.getInstance().toDom(canvasDom, this.points.getPoints());
    }

    public virtual bool isValid()
    {
        return this.points.isValid();
    }

    public virtual Points getPointsInterface()
    {
        return this.points;
    }

    public virtual void setPointsInterface(Points points)
    {
        this.points = points;
    }

    public virtual Color getColor()
    {
        return this.color;
    }

    public virtual void setColor(Color color)
    {
        this.color = color;
    }

    public virtual void mouseClicked(java.awt.event.MouseEvent mouseEvent, int x, int y)
    {
        try {
            GPoint mousePoint = PointFactory.getInstance().createXY(mouseEvent.getPoint().x, mouseEvent.getPoint().y);
            if ((mouseEvent.getModifiers() & mouseEvent.BUTTON1_MASK) == mouseEvent.BUTTON1_MASK) {
                GPoint point = PointFactory.getInstance().createXY(mousePoint.getX() / x, mousePoint.getY() / y);
                StatusFactory.getInstance().setStatus("Line Point Added: " + point.ToString());
                this.addPoint(point);
            } else if ((mouseEvent.getModifiers() & mouseEvent.BUTTON3_MASK) == mouseEvent.BUTTON3_MASK) {
                StatusFactory.getInstance().setStatus("Line Point Removed");
                this.removePoint();
            }
            this.currentMousePoint = mousePoint;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "mouseMoved", e);
        }
    }

    public virtual void mouseEntered(java.awt.event.MouseEvent mouseEvent)
    {
    }

    public virtual void mouseExited(java.awt.event.MouseEvent mouseEvent)
    {
    }

    public virtual void mousePressed(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell)
    {
    }

    public virtual void mouseReleased(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell)
    {
    }

    public virtual void mouseDragged(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell)
    {
    }

    public virtual void mouseMoved(java.awt.event.MouseEvent mouseEvent, int x, int y)
    {
        try {
            GPoint mousePoint = PointFactory.getInstance().createXY(mouseEvent.getPoint().x, mouseEvent.getPoint().y);
            GPoint point = PointFactory.getInstance().createXY(mousePoint.getX() / x, mousePoint.getY() / y);
            this.currentMousePoint = point;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "mouseMoved", e);
        }
    }

    public virtual void keyPressed(java.awt.event.KeyEvent keyEvent)
    {
        try {
            int keyCode = keyEvent.getKeyCode();
            if (keyCode == keyEvent.VK_ESCAPE) {
                StatusFactory.getInstance().setStatus("Deactivated");
                this.deactivate();
            } else if (keyCode == keyEvent.VK_UP) {
                this.translate(0, -1);
            } else if (keyCode == keyEvent.VK_DOWN) {
                this.translate(0, 1);
            } else if (keyCode == keyEvent.VK_LEFT) {
                this.translate(-1, 0);
            } else if (keyCode == keyEvent.VK_RIGHT) {
                this.translate(1, 0);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, gameInputStrings.KEY_PRESSED, e);
        }
    }

    public virtual void keyReleased(java.awt.event.KeyEvent keyEvent)
    {
    }

    public virtual void keyTyped(java.awt.event.KeyEvent keyEvent)
    {
    }

}

