/*
 * 
 * To change this license header, choose License Headers in Project Properties. 
 * To change this template file, choose Tools | Templates 
 * and open the template in the editor.  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.logic.system.security.licensing;

public class InApplicationPurchaseFactory
{
    private static readonly InApplicationPurchaseFactory instance = new InApplicationPurchaseFactory();
    public static InApplicationPurchaseFactory getInstance()
    {
        return InApplicationPurchaseFactory.instance;
    }

    private InApplicationPurchaseFactory()
    {
    }

    public virtual void init(object anyType, object stateObject)
    {
    }

    public virtual void onCreate(object anyType, object stateObject)
    {
    }

    public virtual void onStart()
    {
    }

    public virtual void onResult(int requestCode, int resultCode, object data)
    {
    }

    public virtual void onSaveState(object anyType)
    {
    }

    public virtual void onStop()
    {
    }

    public virtual void onDestroy()
    {
    }

    public virtual void purchase(LockableFeature lockableFeature)
    {
    }

    public virtual bool isPurchased(LockableFeature lockableFeature)
    {
        return false;
    }

    public virtual void add(LockableFeature lockableFeature)
    {
    }

    public virtual string getUserName()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual bool isEnabled()
    {
        return false;
    }

}

