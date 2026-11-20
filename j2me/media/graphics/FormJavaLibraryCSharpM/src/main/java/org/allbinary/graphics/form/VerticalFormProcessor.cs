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
using Processor = org.allbinary.canvas.Processor;

namespace org.allbinary.graphics.form;

public class VerticalFormProcessor : Processor
{
    private readonly ScrollCurrentSelectionForm scrollCurrentSelectionForm;
    public VerticalFormProcessor(ScrollCurrentSelectionForm scrollCurrentSelectionForm)
    {
        this.scrollCurrentSelectionForm = scrollCurrentSelectionForm;
    }

    // throws Exception
    public override void process()
    {
        this.scrollCurrentSelectionForm.processVerticalForm();
        this.scrollCurrentSelectionForm.processor = Processor.getInstance();
    }

}

