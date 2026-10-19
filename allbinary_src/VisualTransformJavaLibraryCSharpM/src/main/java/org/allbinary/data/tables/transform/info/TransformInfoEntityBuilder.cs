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
using TransformInfoHttpStoreFactory = org.allbinary.logic.visual.transform.info.TransformInfoHttpStoreFactory;
using TransformInfoObjectConfigAndManipulatorFactory = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigAndManipulatorFactory;
using TransformInfoObjectConfigGeneratorFactory = org.allbinary.logic.visual.transform.info.objectConfig.generator.TransformInfoObjectConfigGeneratorFactory;

namespace org.allbinary.data.tables.transform.info;

public class TransformInfoEntityBuilder
{
    public static TransformInfoEntity getInstance()
    {
        return TransformInfoEntityFactory.getInstance(TransformInfoObjectConfigGeneratorFactory.getInstance(), TransformInfoObjectConfigAndManipulatorFactory.getInstance(), TransformInfoHttpStoreFactory.getInstance());
    }

}

