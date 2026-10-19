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
using StreetAddressData = org.allbinary.business.user.address.StreetAddressData;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LineReader = org.allbinary.logic.io.LineReader;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace views.generic.address;

public class StatesView : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public StatesView()
    {
    }

    public virtual Node toXmlNode(Document document)
    {
        try {
            Node node = document.createElement(StreetAddressData.STATES);
            string statesFile = URLGLOBALS.getMainPath() + FREEBLISKET_PATH_GLOBALS.getInstance().LINEDATAPATH + "states.txt";
            LineReader lineReader = new LineReader(statesFile);
            while (lineReader.hasNext()) {
                string option = lineReader.next();
                node.appendChild(ModDomHelper.createNameValueNodes(document, StreetAddressData.STATE, option));
            }
            return node;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "toXmlNode", e);
            }
            return null;
        }
    }

}

