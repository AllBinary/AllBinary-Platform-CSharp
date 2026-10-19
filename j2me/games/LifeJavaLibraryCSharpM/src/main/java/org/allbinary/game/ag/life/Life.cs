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

namespace org.allbinary.game.ag.life;

public class Life : LifeInterface
{
    public static Life createLife()
    {
        try {
            return new Life(((short) 0), ((short) 0));
        } catch (Exception e) {
            throw new SystemException();
        }
    }

    public static readonly Life NO_LIFE = Life.createLife();
    private short lives;
    private short startLives;
    private short maxlives;
    public Life(short lives, short maxlives)
    {
        this.maxlives = maxlives;
        if (lives > this.maxlives) {
            throw new Exception("To Many Lives");
        }
        this.lives = lives;
        this.startLives = lives;
    }

    public virtual short get()
    {
        return this.lives;
    }

    public virtual void set(short lives)
    {
        this.lives = lives;
    }

    public virtual void reset()
    {
        this.lives = this.startLives;
    }

    public virtual void add(short lives)
    {
        if (!this.reachedLimit()) {
            if (this.lives + lives <= ((int) this.getMaxlives())) {
                this.lives = ((short) (this.lives + lives));
            } else {
                this.lives = this.getMaxlives();
            }
        }
    }

    public virtual bool isAlive()
    {
        if (((int) this.lives) <= 0) {
            return false;
        } else {
            return true;
        }
    }

    public virtual short getMaxlives()
    {
        return this.maxlives;
    }

    private bool reachedLimit()
    {
        if (this.lives > this.maxlives || ((int) this.lives) < 0) {
            return true;
        } else {
            return false;
        }
    }

    public virtual void deaths(short lives)
    {
        if (!this.reachedLimit()) {
            if (this.lives - lives >= 0) {
                this.lives = ((short) (this.lives - lives));
            } else {
                this.lives = 0;
            }
        }
    }

    public virtual short getStartLives()
    {
        return this.startLives;
    }

    public virtual void setStartLives(short startLives)
    {
        this.startLives = startLives;
    }

}

