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
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
using AbFile = org.allbinary.logic.io.file.AbFile;
using FileUtil = org.allbinary.logic.io.file.FileUtil;
using Directory = org.allbinary.logic.io.file.directory.Directory;
using AbPath = org.allbinary.logic.io.path.AbPath;
using FileItem = org.apache.commons.fileupload.FileItem;

namespace org.allbinary.logic.visual.transform.template.customizer.widgets.logo;

public class LogoImageFileUtil
{
    private readonly Directory directory = Directory.getInstance();
    private readonly string fileName;
    private readonly AbPath imageFileAbPath;
    public LogoImageFileUtil(AbPath imageAbPath, string imageFile)
    {
        this.fileName = imageFile;
        this.imageFileAbPath = imageAbPath;
    }

    // throws Exception
    public virtual void saveFiles(FileItem fileItem)
    {
        if (this.fileName == null) {
            throw new Exception("Image File Name Was Null");
        }
        if (!this.directory.create(this.imageFileAbPath)) {
            throw new Exception("Unable to save file to non creatable directory");
        }
        AbFile originalImageFile = AbFile.createAbFile(this.imageFileAbPath.ToString() + this.fileName);
        originalImageFile.createNewFile();
        FileUtil.getInstance().write(new ByteArrayInputStream(fileItem.get()), originalImageFile);
    }

}

