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

namespace org.allbinary.logic.control.workflow;

public class WorkFlowData
{
    private static readonly WorkFlowData instance = new WorkFlowData();
    public static WorkFlowData getInstance()
    {
        return WorkFlowData.instance;
    }

    private WorkFlowData()
    {
    }

    public string WORKFLOWS = "WORKFLOWS";
    public string WORKFLOW = "WORKFLOW";
    public string NAME = "WORKFLOW_NAME";
    public string DATA = "WORKFLOW_DATA";
}

