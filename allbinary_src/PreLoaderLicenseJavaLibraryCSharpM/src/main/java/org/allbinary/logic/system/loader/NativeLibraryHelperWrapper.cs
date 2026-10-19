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
//using Constructor = java.lang.reflect.Constructor;
//using Method = java.lang.reflect.Method;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.loader;

public class NativeLibraryHelperWrapper
{
    private string libraryName = null;
    private ClassLoader loader = null;
    private object anyType = null;
    public NativeLibraryHelperWrapper(string libraryName)
    {
        this.setLibraryName(libraryName);
    }

    // throws Exception
    public virtual void load()
    {
        object[] @params = new object[1];
        @params[0] = this.getLibraryName();
        Type[] classes = new Type[1];
        classes[0] = this.getLibraryName().GetType();
        this.loader = new NativeLibraryClassLoader(this.GetType().getClassLoader());
        Type myClass = this.loader.loadClass("dynamic.NativeLibraryHelper");
        Constructor constructor = myClass.getConstructor(classes);
        this.anyType = constructor.newInstance(@params);
        CommonStrings commonStrings = CommonStrings.getInstance();
        Method method = this.anyType.GetType().getMethod(commonStrings.LOAD, null);
        method.invoke(this.anyType, null);
    }

    public virtual void unload()
    {
        this.anyType = null;
        this.loader = null;
        GC.Collect();
        GC.Collect();
    }

    public override string ToString()
    {
        return "Library: " + this.getLibraryName();
    }

    public virtual string getLibraryName()
    {
        return this.libraryName;
    }

    public virtual void setLibraryName(string libraryName)
    {
        this.libraryName = libraryName;
    }

}

