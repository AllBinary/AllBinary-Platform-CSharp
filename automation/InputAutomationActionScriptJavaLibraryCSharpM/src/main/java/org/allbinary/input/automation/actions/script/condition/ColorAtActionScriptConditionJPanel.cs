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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using ColorRangeInterface = org.allbinary.media.image.analysis.ColorRangeInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.actions.script.condition;

public class ColorAtActionScriptConditionJPanel : javax.swing.JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private ColorAtActionScriptConditionInterface colorAtActionScriptConditionInterface;
    public ColorAtActionScriptConditionJPanel(ColorAtActionScriptConditionInterface colorAtActionScriptConditionInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.initComponents();
        this.colorAtActionScriptConditionInterface = colorAtActionScriptConditionInterface;
        this.set();
    }

    private void set()
    {
        ColorRangeInterface colorRangeInterface = this.colorAtActionScriptConditionInterface.getColorRangeInterface();
        this.getMinRedJTextField().setText((colorRangeInterface.getMinRed()).ToString());
        this.getMaxRedJTextField().setText((colorRangeInterface.getMaxRed()).ToString());
        this.getMinGreenJTextField().setText((colorRangeInterface.getMinGreen()).ToString());
        this.getMaxGreenJTextField().setText((colorRangeInterface.getMaxGreen()).ToString());
        this.getMinBlueJTextField().setText((colorRangeInterface.getMinBlue()).ToString());
        this.getMaxBlueJTextField().setText((colorRangeInterface.getMaxBlue()).ToString());
        this.getColorAtXJTextField().setText((this.colorAtActionScriptConditionInterface.getPoint().x).ToString());
        this.getColorAtYJTextField().setText((this.colorAtActionScriptConditionInterface.getPoint().y).ToString());
        this.colorAtActionScriptConditionInterface.log();
    }

    private void update()
    {
        ColorRangeInterface colorRangeInterface = this.colorAtActionScriptConditionInterface.getColorRangeInterface();
        colorRangeInterface.setMinRed(((int) (this.getMinRedJTextField().getText()).ToString()));
        colorRangeInterface.setMaxRed(((int) (this.getMaxRedJTextField().getText()).ToString()));
        colorRangeInterface.setMinGreen(((int) (this.getMinGreenJTextField().getText()).ToString()));
        colorRangeInterface.setMaxGreen(((int) (this.getMaxGreenJTextField().getText()).ToString()));
        colorRangeInterface.setMinBlue(((int) (this.getMinBlueJTextField().getText()).ToString()));
        colorRangeInterface.setMaxBlue(((int) (this.getMaxBlueJTextField().getText()).ToString()));
        string xString = this.getColorAtXJTextField().getText();
        if (!StringValidationUtil.getInstance().isEmpty(xString) && StringValidationUtil.getInstance().isNumber(xString)) {
            this.colorAtActionScriptConditionInterface.getPoint().x = int.Parse(xString);
        }
        string yString = this.getColorAtYJTextField().getText();
        if (!StringValidationUtil.getInstance().isEmpty(yString) && StringValidationUtil.getInstance().isNumber(yString)) {
            this.colorAtActionScriptConditionInterface.getPoint().y = int.Parse(xString);
        }
        this.colorAtActionScriptConditionInterface.log();
    }

    public virtual javax.swing.JTextField getColorAtXJTextField()
    {
        return this.colorAtXJTextField;
    }

    public virtual void setColorAtXJTextField(javax.swing.JTextField colorAtXJTextField)
    {
        this.colorAtXJTextField = colorAtXJTextField;
    }

    public virtual javax.swing.JTextField getColorAtYJTextField()
    {
        return this.colorAtYJTextField;
    }

    public virtual void setColorAtYJTextField(javax.swing.JTextField colorAtYJTextField)
    {
        this.colorAtYJTextField = colorAtYJTextField;
    }

    public virtual javax.swing.JTextField getMaxBlueJTextField()
    {
        return this.maxBlueJTextField;
    }

    public virtual void setMaxBlueJTextField(javax.swing.JTextField maxBlueJTextField)
    {
        this.maxBlueJTextField = maxBlueJTextField;
    }

    public virtual javax.swing.JTextField getMaxGreenJTextField()
    {
        return this.maxGreenJTextField;
    }

    public virtual void setMaxGreenJTextField(javax.swing.JTextField maxGreenJTextField)
    {
        this.maxGreenJTextField = maxGreenJTextField;
    }

    public virtual javax.swing.JTextField getMaxRedJTextField()
    {
        return this.maxRedJTextField;
    }

    public virtual void setMaxRedJTextField(javax.swing.JTextField maxRedJTextField)
    {
        this.maxRedJTextField = maxRedJTextField;
    }

    public virtual javax.swing.JTextField getMinBlueJTextField()
    {
        return this.minBlueJTextField;
    }

    public virtual void setMinBlueJTextField(javax.swing.JTextField minBlueJTextField)
    {
        this.minBlueJTextField = minBlueJTextField;
    }

    public virtual javax.swing.JTextField getMinGreenJTextField()
    {
        return this.minGreenJTextField;
    }

    public virtual void setMinGreenJTextField(javax.swing.JTextField minGreenJTextField)
    {
        this.minGreenJTextField = minGreenJTextField;
    }

    public virtual javax.swing.JTextField getMinRedJTextField()
    {
        return this.minRedJTextField;
    }

    public virtual void setMinRedJTextField(javax.swing.JTextField minRedJTextField)
    {
        this.minRedJTextField = minRedJTextField;
    }

    public virtual javax.swing.JLabel getYJLabel()
    {
        return this.yJLabel;
    }

    public virtual void setYJLabel(javax.swing.JLabel yJLabel)
    {
        this.yJLabel = yJLabel;
    }

    public virtual javax.swing.JDialog getColorAtActionJDialog()
    {
        return this.colorAtActionJDialog;
    }

    public virtual void setColorAtActionJDialog(javax.swing.JDialog colorAtActionJDialog)
    {
        this.colorAtActionJDialog = colorAtActionJDialog;
    }

    private void initComponents()
    {
        this.colorAtActionJDialog = new javax.swing.JDialog();
        this.titleJLabel = new javax.swing.JLabel();
        this.locationJLabel = new javax.swing.JLabel();
        this.colorAtXJTextField = new javax.swing.JTextField();
        this.xJLabel = new javax.swing.JLabel();
        this.yJLabel = new javax.swing.JLabel();
        this.colorAtYJTextField = new javax.swing.JTextField();
        this.colorRangeJLabel = new javax.swing.JLabel();
        this.redJLabel = new javax.swing.JLabel();
        this.minJLabel = new javax.swing.JLabel();
        this.maxJLabel = new javax.swing.JLabel();
        this.greenJLabel = new javax.swing.JLabel();
        this.blueJLabel = new javax.swing.JLabel();
        this.minRedJTextField = new javax.swing.JTextField();
        this.maxRedJTextField = new javax.swing.JTextField();
        this.maxGreenJTextField = new javax.swing.JTextField();
        this.minBlueJTextField = new javax.swing.JTextField();
        this.maxBlueJTextField = new javax.swing.JTextField();
        this.okJButton = new javax.swing.JButton();
        this.minGreenJTextField = new javax.swing.JTextField();
        this.colorAtActionJButton = new javax.swing.JButton();
        this.jLabel1 = new javax.swing.JLabel();
        this.colorAtActionJDialog.setMinimumSize(new java.awt.Dimension(350, 250));
        this.titleJLabel.setText("              Color At Action Options            ");
        this.locationJLabel.setText("Location:");
        this.xJLabel.setText("X:");
        this.yJLabel.setText("Y:");
        this.colorRangeJLabel.setText("Color Range");
        this.redJLabel.setText("Red:");
        this.minJLabel.setText("Minimum");
        this.maxJLabel.setText("Maximum");
        this.greenJLabel.setText("Green:");
        this.blueJLabel.setText("Blue:");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        javax.swing.GroupLayout colorAtActionJDialogLayout = new javax.swing.GroupLayout(this.colorAtActionJDialog.getContentPane());
        this.colorAtActionJDialog.getContentPane().setLayout(colorAtActionJDialogLayout);
        colorAtActionJDialogLayout.setHorizontalGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addContainerGap().addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(okJButton).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(blueJLabel).addComponent(greenJLabel).addComponent(redJLabel).addComponent(colorRangeJLabel)).addGap(29, 29, 29)).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, colorAtActionJDialogLayout.createSequentialGroup().addComponent(locationJLabel).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(xJLabel).addGap(18, 18, 18))).addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(minBlueJTextField, javax.swing.GroupLayout.DEFAULT_SIZE, 40, short.MaxValue).addComponent(minGreenJTextField, javax.swing.GroupLayout.DEFAULT_SIZE, 40, short.MaxValue).addComponent(minJLabel, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(minRedJTextField, javax.swing.GroupLayout.DEFAULT_SIZE, 40, short.MaxValue).addComponent(colorAtXJTextField, javax.swing.GroupLayout.DEFAULT_SIZE, 40, short.MaxValue)).addGap(16, 16, 16))).addGap(6, 6, 6).addComponent(yJLabel).addGap(24, 24, 24).addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(maxJLabel, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue).addGroup(javax.swing.GroupLayout.Alignment.LEADING, colorAtActionJDialogLayout.createSequentialGroup().addGap(1, 1, 1).addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addComponent(maxBlueJTextField, javax.swing.GroupLayout.Alignment.TRAILING).addComponent(maxRedJTextField, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 43, short.MaxValue).addComponent(maxGreenJTextField, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, 43, javax.swing.GroupLayout.PREFERRED_SIZE))).addComponent(colorAtYJTextField, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 44, short.MaxValue)).addGap(22, 22, 22)).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, colorAtActionJDialogLayout.createSequentialGroup().addComponent(titleJLabel).addGap(33, 33, 33)))));
        colorAtActionJDialogLayout.setVerticalGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addContainerGap().addComponent(titleJLabel).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addGap(15, 15, 15).addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(xJLabel).addComponent(locationJLabel).addComponent(colorAtXJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(yJLabel)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(minJLabel).addComponent(colorRangeJLabel)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(minRedJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(redJLabel)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(greenJLabel).addComponent(minGreenJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(colorAtActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(blueJLabel).addComponent(minBlueJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 17, short.MaxValue).addComponent(okJButton)).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addGap(14, 14, 14).addComponent(colorAtYJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(maxJLabel).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(maxRedJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(maxGreenJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(maxBlueJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addContainerGap()));
        setPreferredSize(new java.awt.Dimension(100, 0));
        this.colorAtActionJButton.setText("Edit");
        this.colorAtActionJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                colorAtActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Color At:");
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 15, short.MaxValue).addComponent(colorAtActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(colorAtActionJButton)));
    }

    private void okJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.update();
        this.getColorAtActionJDialog().setVisible(false);
    }

    private void colorAtActionJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.getColorAtActionJDialog().setVisible(true);
    }

    private javax.swing.JLabel blueJLabel = null;
    private javax.swing.JButton colorAtActionJButton = null;
    private javax.swing.JDialog colorAtActionJDialog = null;
    private javax.swing.JTextField colorAtXJTextField = null;
    private javax.swing.JTextField colorAtYJTextField = null;
    private javax.swing.JLabel colorRangeJLabel = null;
    private javax.swing.JLabel greenJLabel = null;
    private javax.swing.JLabel jLabel1 = null;
    private javax.swing.JLabel locationJLabel = null;
    private javax.swing.JTextField maxBlueJTextField = null;
    private javax.swing.JTextField maxGreenJTextField = null;
    private javax.swing.JLabel maxJLabel = null;
    private javax.swing.JTextField maxRedJTextField = null;
    private javax.swing.JTextField minBlueJTextField = null;
    private javax.swing.JTextField minGreenJTextField = null;
    private javax.swing.JLabel minJLabel = null;
    private javax.swing.JTextField minRedJTextField = null;
    private javax.swing.JButton okJButton = null;
    private javax.swing.JLabel redJLabel = null;
    private javax.swing.JLabel titleJLabel = null;
    private javax.swing.JLabel xJLabel = null;
    private javax.swing.JLabel yJLabel = null;
}

