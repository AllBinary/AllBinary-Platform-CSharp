/*
 * 
 * To change this license header, choose License Headers in Project Properties. 
 * To change this template file, choose Tools | Templates 
 * and open the template in the editor.  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;

namespace org.allbinary.input.automation.actions.script;

public class JTreeInterfaceFactory
{
    private static readonly JTreeInterfaceFactory instance = new JTreeInterfaceFactory();
    public static JTreeInterfaceFactory getInstance()
    {
        return JTreeInterfaceFactory.instance;
    }

    private JTreeInterface jTreeInterface = null;
    public virtual void set(JTreeInterface jTreeInterface)
    {
        this.jTreeInterface = jTreeInterface;
    }

    public virtual JTreeInterface getJTreeInterface()
    {
        return this.jTreeInterface;
    }

}

