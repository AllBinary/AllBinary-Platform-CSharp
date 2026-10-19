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
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using WorkAreaJPanel = org.allbinary.graphics.j2me.workarea.WorkAreaJPanel;
using CanvasDom = org.allbinary.graphics.j2me.workarea.canvas.CanvasDom;
using PositionStrings = org.allbinary.math.PositionStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Node = org.w3c.dom.Node;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class PointsDomUtil
{
    private static readonly PointsDomUtil instance = new PointsDomUtil();
    public static PointsDomUtil getInstance()
    {
        return PointsDomUtil.instance;
    }

    public readonly string LINES = "lines";
    public readonly string POINTONE = "pointOne";
    public readonly string POINTTWO = "pointTwo";
    private readonly string ROTATEDPOINTONE = "rotatedPointOne";
    private readonly string ROTATEDPOINTTWO = "rotatedPointTwo";
    private readonly string LINE = "line";
    // throws Exception
    public virtual Node toDom(CanvasDom canvasDom, BasicArrayList pointVector)
    {
        BasicArrayList tempPointVector = PointsUtil.getInstance().doTransforms(pointVector, canvasDom.getAngle(), PointFactory.getInstance().createXY(canvasDom.getDimension().getWidth(), canvasDom.getDimension().getHeight()));
        org.w3c.dom.Document document = WorkAreaJPanel.getDocument();
        Node linesNode = ((Node) document.createElement(this.LINES));
        int size2 = tempPointVector.size();
        int size = pointVector.size();
        GPoint firstPoint = null;
        GPoint rotatedFirstPoint = null;
        int index = 0;
        if (index < size && index < size2) {
            rotatedFirstPoint = ((GPoint) tempPointVector.get(index));
            firstPoint = ((GPoint) pointVector.get(index));
            index++;
        }
        while (index < size && index < size2) {
            Node lineNode = ((Node) document.createElement(this.LINE));
            GPoint rotatedSecondPoint = ((GPoint) tempPointVector.get(index));
            GPoint secondPoint = ((GPoint) pointVector.get(index));
            Node pointOneNode = this.getPointNode(firstPoint, this.POINTONE);
            Node pointTwoNode = this.getPointNode(secondPoint, this.POINTTWO);
            Node rotatedPointOneNode = this.getPointNode(rotatedFirstPoint, this.ROTATEDPOINTONE);
            Node rotatedPointTwoNode = this.getPointNode(rotatedSecondPoint, this.ROTATEDPOINTTWO);
            lineNode.appendChild(pointOneNode);
            lineNode.appendChild(pointTwoNode);
            lineNode.appendChild(rotatedPointOneNode);
            lineNode.appendChild(rotatedPointTwoNode);
            firstPoint = secondPoint;
            rotatedFirstPoint = rotatedSecondPoint;
            linesNode.appendChild(lineNode);
            index++;
        }
        return linesNode;
    }

    private Node getPointNode(GPoint point, string pointName)
    {
        org.w3c.dom.Document document = WorkAreaJPanel.getDocument();
        Node pointNode = ((Node) document.createElement(pointName));
        Node xNode = ((Node) document.createElement(PositionStrings.getInstance().X));
        Node xTextNode = ((Node) document.createTextNode((point.getX()).ToString()));
        xNode.appendChild(xTextNode);
        Node yNode = ((Node) document.createElement(PositionStrings.getInstance().Y));
        Node yTextNode = ((Node) document.createTextNode((point.getY()).ToString()));
        yNode.appendChild(yTextNode);
        pointNode.appendChild(xNode);
        pointNode.appendChild(yNode);
        return pointNode;
    }

}

