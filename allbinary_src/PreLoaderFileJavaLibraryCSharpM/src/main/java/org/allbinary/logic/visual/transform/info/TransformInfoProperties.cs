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

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoProperties
{
    private string name;
    private string label;
    private string description;
    private string objectFileName;
    private string objectConfigFileName;
    private string templateFileName;
    public TransformInfoProperties(string name, string label, string description, string objectFileName, string objectConfigFileName, string templateFileName)
    {
        this.name = name;
        this.label = label;
        this.description = description;
        this.objectFileName = objectFileName;
        this.templateFileName = templateFileName;
        this.objectConfigFileName = objectConfigFileName;
    }

    public virtual void setName(string value)
    {
        this.name = value;
    }

    public virtual void setDescription(string value)
    {
        this.description = value;
    }

    public virtual void setViewFile(string value)
    {
        this.objectFileName = value;
    }

    public virtual void setTemplateFile(string value)
    {
        this.templateFileName = value;
    }

    public virtual void setObjectConfigFile(string value)
    {
        this.objectConfigFileName = value;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getLabel()
    {
        return this.label;
    }

    public virtual string getDescription()
    {
        return this.description;
    }

    public virtual string getViewFile()
    {
        return this.objectFileName;
    }

    public virtual string getTemplateFile()
    {
        return this.templateFileName;
    }

    public virtual string getObjectConfigFile()
    {
        return this.objectConfigFileName;
    }

}

