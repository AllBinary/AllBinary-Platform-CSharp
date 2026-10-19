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
using DomHelper = org.allbinary.dom.DomHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.graphics.j2me.workarea;

public class WorkAreaDom
{
    public static readonly string WORKAREA = "workArea";
    public static readonly string NAME = "name";
    public static readonly string FRAMES = "frames";
    private string name = null;
    private BasicArrayList canvasNodeList = null;
    public WorkAreaDom(Document document)
    {
        NodeList workAreaNodeList = document.getElementsByTagName(this.WORKAREA);
        if (workAreaNodeList != null) {
            int numberOfworkAreas = workAreaNodeList.getLength();
            if (numberOfworkAreas == 1) {
                int numberOfNodes = workAreaNodeList.getLength();
                Node nameNode = DomHelper.getInstance().searchNodeList(this.NAME, workAreaNodeList.item(0).getChildNodes());
                Node nameTextNode = nameNode.getFirstChild();
                this.name = nameTextNode.getNodeValue();
            } else {
                throw new Exception("Wrong Number of WorkAreas: " + numberOfworkAreas);
            }
            this.canvasNodeList = DomHelper.getInstance().getChildrenWithoutTextNodes(WorkAreaDom.FRAMES, workAreaNodeList.item(0).getChildNodes());
        } else {
            throw new Exception("workArea Node Not Found");
        }
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual BasicArrayList getCanvasNodes()
    {
        return this.canvasNodeList;
    }

}

