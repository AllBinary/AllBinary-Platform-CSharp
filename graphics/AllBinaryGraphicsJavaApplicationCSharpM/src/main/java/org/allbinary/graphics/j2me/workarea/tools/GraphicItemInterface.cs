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
//using MutableTreeNode = javax.swing.tree.MutableTreeNode;
using GPoint = org.allbinary.graphics.GPoint;
using CanvasDom = org.allbinary.graphics.j2me.workarea.canvas.CanvasDom;
using IntegerDimension = org.allbinary.graphics.j2me.workarea.canvas.IntegerDimension;
using Node = org.w3c.dom.Node;

namespace org.allbinary.graphics.j2me.workarea.tools;

public interface GraphicItemInterface
{
    string getName();

    void setColor(Color color);

    MutableTreeNode getTreeNode();

    Points getPointsInterface();

    void setPointsInterface(Points points);

    bool isValid();

    bool isActive();

    void deactivate();

    void activate();

    void setFulcrumPoint(GPoint point);

    // throws Exception
    void translate(int x, int y);

    void setRotate(double theta);

    void addRotate(double theta);

    void setAngle(double angle);

    void addAngle(double angle);

    double getAngle();

    void paint(Graphics g, double? canvasAngle, IntegerDimension dimension, int x, int y);

    // throws Exception
    Node toDom(CanvasDom canvasDom);

    GPoint removePoint();

    void addPoint(GPoint point);

    void mouseClicked(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell);

    void mouseEntered(java.awt.event.MouseEvent mouseEvent);

    void mouseExited(java.awt.event.MouseEvent mouseEvent);

    void mousePressed(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell);

    void mouseReleased(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell);

    void mouseDragged(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell);

    void mouseMoved(java.awt.event.MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell);

    void keyPressed(java.awt.event.KeyEvent keyEvent);

    void keyReleased(java.awt.event.KeyEvent keyEvent);

    void keyTyped(java.awt.event.KeyEvent keyEvent);

    // throws Exception
    GraphicItemInterface duplicate();

}

