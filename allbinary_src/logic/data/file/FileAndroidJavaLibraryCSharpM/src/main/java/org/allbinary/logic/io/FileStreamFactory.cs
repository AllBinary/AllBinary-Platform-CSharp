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
using Context = android.content.Context;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.logic.io;

public class FileStreamFactory
{
    private static object SINGLETON = NullUtil.getInstance().NULL_OBJECT;
    public static FileStreamFactory getInstance()
    {
        if (FileStreamFactory.SINGLETON == NullUtil.getInstance().NULL_OBJECT) {
            FileStreamFactory.SINGLETON = new FileStreamFactory(ResourceUtil.getInstance().getContext());
        }
        return ((FileStreamFactory) FileStreamFactory.SINGLETON);
    }

    private object context;
    private FileStreamFactory(Context context)
    {
        this.context = context;
    }

    // throws Exception
    public virtual AbFileInputStream getFileInputStreamInstance(string path, string fileName)
    {
        return new AbFileInputStream(this.getContext().openFileInput(fileName));
    }

    // throws Exception
    public virtual AbFileOutputStream getFileOutputStreamInstance(string path, string fileName)
    {
        Context context = this.getContext();
        context.deleteFile(fileName);
        return new AbFileOutputStream(context.openFileOutput(fileName, 0));
    }

    // throws Exception
    public virtual void delete(string path, string fileName)
    {
        this.getContext().deleteFile(fileName);
    }

    private Context getContext()
    {
        return ((Context) this.context);
    }

}

