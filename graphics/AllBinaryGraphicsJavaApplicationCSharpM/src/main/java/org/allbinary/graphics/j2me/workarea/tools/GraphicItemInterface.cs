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
using java.awt;
//using MutableTreeNode = javax.swing.tree.MutableTreeNode;
using GPoint = org.allbinary.graphics.GPoint;
using CanvasDom = org.allbinary.graphics.j2me.workarea.canvas.CanvasDom;
using IntegerDimension = org.allbinary.graphics.j2me.workarea.canvas.IntegerDimension;
using Node = org.w3c.dom.Node;
using KeyEvent = java.awt.@event.KeyEvent;
//using MouseEvent = java.awt.@event.MouseEvent;

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

    void mouseClicked(MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell);

    void mouseEntered(MouseEvent mouseEvent);

    void mouseExited(MouseEvent mouseEvent);

    void mousePressed(MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell);

    void mouseReleased(MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell);

    void mouseDragged(MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell);

    void mouseMoved(MouseEvent mouseEvent, int xPixelsPerCell, int yPixelsPerCell);

    void keyPressed(KeyEvent keyEvent);

    void keyReleased(KeyEvent keyEvent);

    void keyTyped(KeyEvent keyEvent);

    // throws Exception
    GraphicItemInterface duplicate();

}

