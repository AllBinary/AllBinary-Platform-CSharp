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
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using AbFile = org.allbinary.logic.io.file.AbFile;
using Directory = org.allbinary.logic.io.file.directory.Directory;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using TransformDocumentFactory = org.allbinary.logic.visual.transform.data.TransformDocumentFactory;
using TransformDocumentInterface = org.allbinary.logic.visual.transform.data.TransformDocumentInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.data.tree.dom;

public class DirectoryDataModel : DomNodeInterface, TransformInterface
{
    private readonly BasicArrayList fileBasicArrayList;
    private TransformDocumentInterface transformDocumentInterface;
    public DirectoryDataModel(AbFile file)
    {
        this.fileBasicArrayList = Directory.getInstance().search(file);
        this.transformDocumentInterface = ((TransformDocumentInterface) TransformDocumentFactory.getInstance());
    }

    public int NO_TYPE = 0;
    public virtual int getTypeId()
    {
        return this.NO_TYPE;
    }

    // throws Exception
    public virtual TransformInfoInterface getTransformInfoInterface()
    {
        return null;
    }

    public virtual void setTransformDocumentInterface(TransformDocumentInterface transformDocumentInterface)
    {
        this.transformDocumentInterface = transformDocumentInterface;
    }

    public virtual TransformDocumentInterface getTransformDocumentInterface()
    {
        return this.transformDocumentInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node dirNode = document.createElement("dir");
        int size = this.fileBasicArrayList.size();
        AbFile nextFile = null;
        Node fileNode = null;
        for (int index = 0; index < size; index++) {
            nextFile = ((AbFile) this.fileBasicArrayList.get(index));
            fileNode = new FileDomDataModel(nextFile).toXmlNode(document);
            dirNode.appendChild(fileNode);
        }
        return dirNode;
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        return this.getTransformDocumentInterface().getDoc();
    }

    // throws Exception
    public virtual string view()
    {
        Node node = this.toXmlNode(this.getTransformDocumentInterface().getDoc());
        this.getTransformDocumentInterface().getBaseNode().appendChild(node);
        return XmlDocumentHelper.toString(this.getTransformDocumentInterface().getDoc());
    }

}

