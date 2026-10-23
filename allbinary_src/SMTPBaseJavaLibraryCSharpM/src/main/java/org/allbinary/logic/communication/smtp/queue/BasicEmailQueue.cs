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
using System.Runtime.CompilerServices;
//using Transport = javax.mail.Transport;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using EmailInterface = org.allbinary.logic.communication.smtp.EmailInterface;
using BasicQueue = org.allbinary.logic.util.queue.BasicQueue;

namespace org.allbinary.logic.communication.smtp.queue;

public class BasicEmailQueue : BasicQueue, EmailQueueInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly BasicEmailQueue instance = new BasicEmailQueue();
    private static BasicEmailQueue basicEmailQueue = null;
    private BasicEmailQueue()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static BasicEmailQueue getInstance()
    {
        if (BasicEmailQueue.basicEmailQueue == null) {
            BasicEmailQueue.basicEmailQueue = new BasicEmailQueue();
        }
        return BasicEmailQueue.basicEmailQueue;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool offer(EmailInterface emailInterface)
    {
        this.offer(((object) emailInterface));
        this.post(emailInterface);
        return true;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private void remove(EmailInterface emailInterface)
    {
        this.remove(((object) emailInterface));
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual EmailInterface remove()
    {
        return null;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void post(EmailInterface emailInterface)
    {
        if (this.send(emailInterface)) {
            this.remove(emailInterface);
            this.processAllUnsent();
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void processAllUnsent()
    {
        int size = queueVector.size();
        for (int index = 0; index < size; index++) {
            EmailInterface emailInterface = ((EmailInterface) queueVector.get(index));
            if (this.send(emailInterface)) {
                this.remove(emailInterface);
                this.processAllUnsent();
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private bool send(EmailInterface emailInterface)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
                this.logUtil.putF("Sending: " + emailInterface.log(), this, "send");
            }
            Transport.send(emailInterface.getMimeMessage());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
                this.logUtil.putF("Email Send Debug: " + emailInterface.getDebugInfo(), this, "send");
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
                this.logUtil.put("Failed Email Send Debug: " + emailInterface.getDebugInfo(), this, "send", e);
            }
            return false;
        }
    }

}

