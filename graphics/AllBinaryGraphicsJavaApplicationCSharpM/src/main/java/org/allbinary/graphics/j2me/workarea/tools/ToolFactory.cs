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
using StatusFactory = org.allbinary.graphics.j2me.StatusFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class ToolFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ToolFactory instance = new ToolFactory();
    public static ToolFactory getInstance()
    {
        return ToolFactory.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private GraphicsItemInterfaceFactoryInterface selectedTool = null;
    private string tool = null;
    private readonly string SELECTED_LABEL = "Selected: ";
    public virtual void setSelectedTool(string tool)
    {
        try {
            StatusFactory.getInstance().setStatus(this.SELECTED_LABEL + tool);
            this.tool = tool;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "setSelectionTool", e);
        }
    }

    public virtual GraphicsItemInterfaceFactoryInterface getSelectedToolFactory()
    {
        StatusFactory.getInstance().setStatus("Tool In Use: " + this.tool);
        if (this.tool != null) {
            this.selectedTool = GraphicItemFactory.getInstance().getInstance(this.tool);
            this.logUtil.putF("New Tool: " + this.selectedTool, this, "getSelectedToolFactory");
            return this.selectedTool;
        } else {
            return null;
        }
    }

}

