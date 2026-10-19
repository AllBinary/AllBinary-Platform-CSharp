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
//using java.awt;
using java.util;
//using MutableTreeNode = javax.swing.tree.MutableTreeNode;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using CanvasDom = org.allbinary.graphics.j2me.workarea.canvas.CanvasDom;
using CanvasJPanel = org.allbinary.graphics.j2me.workarea.canvas.CanvasJPanel;
using IntegerDimension = org.allbinary.graphics.j2me.workarea.canvas.IntegerDimension;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using RectangleCollisionPointUtil = org.allbinary.math.RectangleCollisionPointUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Node = org.w3c.dom.Node;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class SelectionTool : GraphicItemInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CanvasJPanel canvasJPanel;
    private bool active = true;
    public SelectionTool(CanvasJPanel canvasJPanel)
    {
        this.endPoint = this.startPoint;
        this.canvasJPanel = canvasJPanel;
    }

    public virtual void setColor(Color color)
    {
    }

    public virtual MutableTreeNode getTreeNode()
    {
        return null;
    }

    public virtual Points getPointsInterface()
    {
        return null;
    }

    public virtual void setPointsInterface(Points points)
    {
    }

    public virtual bool isValid()
    {
        return true;
    }

    public virtual bool isActive()
    {
        return this.active;
    }

    public virtual void deactivate()
    {
    }

    public virtual void activate()
    {
    }

    public virtual void setFulcrumPoint(GPoint point)
    {
    }

    // throws Exception
    public virtual void translate(int x, int y)
    {
    }

    public virtual void setRotate(double theta)
    {
    }

    public virtual void addRotate(double theta)
    {
    }

    public virtual void setAngle(double angle)
    {
    }

    public virtual void addAngle(double angle)
    {
    }

    public virtual double getAngle()
    {
        return 0.0;
    }

    private bool controlIdDown = false;
    private void makeSelection()
    {
        int xRect = this.getXRect();
        int xRect2 = Math.Abs(this.endPoint.getX() - this.startPoint.getX()) + xRect;
        int yRect = this.getYRect();
        int yRect2 = Math.Abs(this.endPoint.getY() - this.startPoint.getY()) + yRect;
        HashMap hashMap = this.canvasJPanel.getGraphicItemHashMap();
        object[] graphicItemArray = hashMap.keySet().toArray();
        int size = graphicItemArray.Length;
        for (int index = 0; index < size; index++) {
            GraphicItemInterface item = ((GraphicItemInterface) hashMap.get(graphicItemArray[index]));
            if (item.getName() == LinesGraphicItem.getStaticName()) {
                if (RectangleCollisionPointUtil.allPointsInsideCell(xRect, yRect, xRect2, yRect2, item.getPointsInterface().getPoints(), this.canvasJPanel.getXPixelsPerWorkAreaPixel(), this.canvasJPanel.getYPixelsPerWorkAreaPixel())) {
                    item.setColor(Color.YELLOW);
                    item.activate();
                } else if (!this.controlIdDown) {
                    item.setColor(Color.WHITE);
                    item.deactivate();
                }
            }
        }
    }

    private readonly Color rectColor = new Color(((int) BasicColorFactory.getInstance().RED));
    public virtual int getXRect()
    {
        int xDiff = this.endPoint.getX() - this.startPoint.getX();
        int xRect = this.startPoint.getX();
        if (xDiff < 0) {
            xRect = this.endPoint.getX();
        }
        return xRect;
    }

    public virtual int getYRect()
    {
        int yDiff = this.endPoint.getY() - this.startPoint.getY();
        int yRect = this.startPoint.getY();
        if (yDiff < 0) {
            yRect = this.endPoint.getY();
        }
        return yRect;
    }

    public virtual void paint(Graphics g, double? canvasAngle, IntegerDimension dimension, int x, int y)
    {
        g.setColor(this.rectColor);
        int xRect = this.getXRect();
        int width = Math.Abs(this.endPoint.getX() - this.startPoint.getX());
        int yRect = this.getYRect();
        int height = Math.Abs(this.endPoint.getY() - this.startPoint.getY());
        g.drawRect(xRect, yRect, width, height);
    }

    // throws Exception
    public virtual Node toDom(CanvasDom canvasDom)
    {
        return null;
    }

    public virtual GPoint removePoint()
    {
        return null;
    }

    public virtual void addPoint(GPoint point)
    {
    }

    private static readonly string NAME = "Selection Tool";
    public virtual string getName()
    {
        return SelectionTool.NAME;
    }

    public static string getStaticName()
    {
        return SelectionTool.NAME;
    }

    private GPoint startPoint = PointFactory.getInstance().ZERO_ZERO;
    private GPoint endPoint;
    public virtual void mouseClicked(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell)
    {
    }

    public virtual void mouseMoved(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell)
    {
    }

    public virtual void mouseEntered(java.awt.event.MouseEvent mouseEvent)
    {
    }

    public virtual void mouseExited(java.awt.event.MouseEvent mouseEvent)
    {
    }

    public virtual void mousePressed(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell)
    {
        this.logUtil.putF(this.commonStrings.START, this, MouseStrings.getInstance().MOUSE_PRESSED);
        this.startPoint = PointFactory.getInstance().createXY(mouseEvent.getX(), mouseEvent.getY());
        this.endPoint = this.startPoint;
    }

    public virtual void mouseReleased(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell)
    {
        this.logUtil.putF(this.commonStrings.START, this, MouseStrings.getInstance().MOUSE_RELEASED);
        this.endPoint = PointFactory.getInstance().createXY(mouseEvent.getX(), mouseEvent.getY());
        this.active = false;
        this.makeSelection();
    }

    public virtual void mouseDragged(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell)
    {
        this.endPoint = PointFactory.getInstance().createXY(mouseEvent.getX(), mouseEvent.getY());
    }

    public virtual void keyPressed(java.awt.event.KeyEvent keyEvent)
    {
        if (keyEvent.getKeyCode() == keyEvent.VK_CONTROL) {
            this.controlIdDown = true;
        }
    }

    public virtual void keyReleased(java.awt.event.KeyEvent keyEvent)
    {
        if (keyEvent.getKeyCode() == keyEvent.VK_CONTROL) {
            this.controlIdDown = false;
        }
    }

    public virtual void keyTyped(java.awt.event.KeyEvent keyEvent)
    {
    }

    // throws Exception
    public virtual GraphicItemInterface duplicate()
    {
        return null;
    }

}

