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
//using File = java.io.File;
//using FileFilter = javax.swing.filechooser.FileFilter;

namespace org.allbinary.media.image.filter;

//TWB - replace with file visitor version
public class ImageFileFilter : FileFilter
{
    public virtual bool accept(File f)
    {
        if (f.isDirectory()) {
            return true;
        }
        string s = f.getName();
        int i = s.LastIndexOf('.');
        if (i > 0 && i < s.Length - 1) {
            string ext = s.Substring(i + 1).ToLower();
            if (ext.Equals("jpg") || ext.Equals("jpeg")) {
                return true;
            }
        }
        return false;
    }

    public virtual string getDescription()
    {
        return "Accepts .jpg and .jpeg files";
    }

}

