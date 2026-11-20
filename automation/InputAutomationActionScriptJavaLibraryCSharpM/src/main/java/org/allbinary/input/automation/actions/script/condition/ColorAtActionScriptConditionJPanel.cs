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
//using Dimension = java.awt.Dimension;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JDialog = javax.swing.JDialog;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.input.automation.actions.script.condition;

public class ColorAtActionScriptConditionJPanel : JPanel
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
        colorRangeInterface.setMinRed(global::java.lang.JavaNumber.intValue(int.Parse((this.getMinRedJTextField().getText()).ToString())));
        colorRangeInterface.setMaxRed(global::java.lang.JavaNumber.intValue(int.Parse((this.getMaxRedJTextField().getText()).ToString())));
        colorRangeInterface.setMinGreen(global::java.lang.JavaNumber.intValue(int.Parse((this.getMinGreenJTextField().getText()).ToString())));
        colorRangeInterface.setMaxGreen(global::java.lang.JavaNumber.intValue(int.Parse((this.getMaxGreenJTextField().getText()).ToString())));
        colorRangeInterface.setMinBlue(global::java.lang.JavaNumber.intValue(int.Parse((this.getMinBlueJTextField().getText()).ToString())));
        colorRangeInterface.setMaxBlue(global::java.lang.JavaNumber.intValue(int.Parse((this.getMaxBlueJTextField().getText()).ToString())));
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

    public virtual JTextField getColorAtXJTextField()
    {
        return this.colorAtXJTextField;
    }

    public virtual void setColorAtXJTextField(JTextField colorAtXJTextField)
    {
        this.colorAtXJTextField = colorAtXJTextField;
    }

    public virtual JTextField getColorAtYJTextField()
    {
        return this.colorAtYJTextField;
    }

    public virtual void setColorAtYJTextField(JTextField colorAtYJTextField)
    {
        this.colorAtYJTextField = colorAtYJTextField;
    }

    public virtual JTextField getMaxBlueJTextField()
    {
        return this.maxBlueJTextField;
    }

    public virtual void setMaxBlueJTextField(JTextField maxBlueJTextField)
    {
        this.maxBlueJTextField = maxBlueJTextField;
    }

    public virtual JTextField getMaxGreenJTextField()
    {
        return this.maxGreenJTextField;
    }

    public virtual void setMaxGreenJTextField(JTextField maxGreenJTextField)
    {
        this.maxGreenJTextField = maxGreenJTextField;
    }

    public virtual JTextField getMaxRedJTextField()
    {
        return this.maxRedJTextField;
    }

    public virtual void setMaxRedJTextField(JTextField maxRedJTextField)
    {
        this.maxRedJTextField = maxRedJTextField;
    }

    public virtual JTextField getMinBlueJTextField()
    {
        return this.minBlueJTextField;
    }

    public virtual void setMinBlueJTextField(JTextField minBlueJTextField)
    {
        this.minBlueJTextField = minBlueJTextField;
    }

    public virtual JTextField getMinGreenJTextField()
    {
        return this.minGreenJTextField;
    }

    public virtual void setMinGreenJTextField(JTextField minGreenJTextField)
    {
        this.minGreenJTextField = minGreenJTextField;
    }

    public virtual JTextField getMinRedJTextField()
    {
        return this.minRedJTextField;
    }

    public virtual void setMinRedJTextField(JTextField minRedJTextField)
    {
        this.minRedJTextField = minRedJTextField;
    }

    public virtual JLabel getYJLabel()
    {
        return this.yJLabel;
    }

    public virtual void setYJLabel(JLabel yJLabel)
    {
        this.yJLabel = yJLabel;
    }

    public virtual JDialog getColorAtActionJDialog()
    {
        return this.colorAtActionJDialog;
    }

    public virtual void setColorAtActionJDialog(JDialog colorAtActionJDialog)
    {
        this.colorAtActionJDialog = colorAtActionJDialog;
    }

    private void initComponents()
    {
        this.colorAtActionJDialog = new JDialog();
        this.titleJLabel = new JLabel();
        this.locationJLabel = new JLabel();
        this.colorAtXJTextField = new JTextField();
        this.xJLabel = new JLabel();
        this.yJLabel = new JLabel();
        this.colorAtYJTextField = new JTextField();
        this.colorRangeJLabel = new JLabel();
        this.redJLabel = new JLabel();
        this.minJLabel = new JLabel();
        this.maxJLabel = new JLabel();
        this.greenJLabel = new JLabel();
        this.blueJLabel = new JLabel();
        this.minRedJTextField = new JTextField();
        this.maxRedJTextField = new JTextField();
        this.maxGreenJTextField = new JTextField();
        this.minBlueJTextField = new JTextField();
        this.maxBlueJTextField = new JTextField();
        this.okJButton = new JButton();
        this.minGreenJTextField = new JTextField();
        this.colorAtActionJButton = new JButton();
        this.jLabel1 = new JLabel();
        this.colorAtActionJDialog.setMinimumSize(new Dimension(350, 250));
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
        this.okJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        GroupLayout colorAtActionJDialogLayout = new GroupLayout(this.colorAtActionJDialog.getContentPane());
        this.colorAtActionJDialog.getContentPane().setLayout(colorAtActionJDialogLayout);
        colorAtActionJDialogLayout.setHorizontalGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addContainerGap().addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.TRAILING).addComponent(okJButton).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING, false).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(blueJLabel).addComponent(greenJLabel).addComponent(redJLabel).addComponent(colorRangeJLabel)).addGap(29, 29, 29)).addGroup(GroupLayout.Alignment.TRAILING, colorAtActionJDialogLayout.createSequentialGroup().addComponent(locationJLabel).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(xJLabel).addGap(18, 18, 18))).addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(minBlueJTextField, GroupLayout.DEFAULT_SIZE, 40, short.MaxValue).addComponent(minGreenJTextField, GroupLayout.DEFAULT_SIZE, 40, short.MaxValue).addComponent(minJLabel, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(minRedJTextField, GroupLayout.DEFAULT_SIZE, 40, short.MaxValue).addComponent(colorAtXJTextField, GroupLayout.DEFAULT_SIZE, 40, short.MaxValue)).addGap(16, 16, 16))).addGap(6, 6, 6).addComponent(yJLabel).addGap(24, 24, 24).addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.TRAILING).addComponent(maxJLabel, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue).addGroup(GroupLayout.Alignment.LEADING, colorAtActionJDialogLayout.createSequentialGroup().addGap(1, 1, 1).addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING, false).addComponent(maxBlueJTextField, GroupLayout.Alignment.TRAILING).addComponent(maxRedJTextField, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, 43, short.MaxValue).addComponent(maxGreenJTextField, GroupLayout.Alignment.TRAILING, GroupLayout.PREFERRED_SIZE, 43, GroupLayout.PREFERRED_SIZE))).addComponent(colorAtYJTextField, GroupLayout.Alignment.LEADING, GroupLayout.DEFAULT_SIZE, 44, short.MaxValue)).addGap(22, 22, 22)).addGroup(GroupLayout.Alignment.TRAILING, colorAtActionJDialogLayout.createSequentialGroup().addComponent(titleJLabel).addGap(33, 33, 33)))));
        colorAtActionJDialogLayout.setVerticalGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addContainerGap().addComponent(titleJLabel).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addGap(15, 15, 15).addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(xJLabel).addComponent(locationJLabel).addComponent(colorAtXJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(yJLabel)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(minJLabel).addComponent(colorRangeJLabel)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(minRedJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(redJLabel)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(greenJLabel).addComponent(minGreenJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(colorAtActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(blueJLabel).addComponent(minBlueJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 17, short.MaxValue).addComponent(okJButton)).addGroup(colorAtActionJDialogLayout.createSequentialGroup().addGap(14, 14, 14).addComponent(colorAtYJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(maxJLabel).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(maxRedJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(maxGreenJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(maxBlueJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))).addContainerGap()));
        setPreferredSize(new Dimension(100, 0));
        this.colorAtActionJButton.setText("Edit");
        this.colorAtActionJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                colorAtActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Color At:");
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 15, short.MaxValue).addComponent(colorAtActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(colorAtActionJButton)));
    }

    private void okJButtonActionPerformed(ActionEvent evt)
    {
        this.update();
        this.getColorAtActionJDialog().setVisible(false);
    }

    private void colorAtActionJButtonActionPerformed(ActionEvent evt)
    {
        this.getColorAtActionJDialog().setVisible(true);
    }

    private JLabel blueJLabel = null;
    private JButton colorAtActionJButton = null;
    private JDialog colorAtActionJDialog = null;
    private JTextField colorAtXJTextField = null;
    private JTextField colorAtYJTextField = null;
    private JLabel colorRangeJLabel = null;
    private JLabel greenJLabel = null;
    private JLabel jLabel1 = null;
    private JLabel locationJLabel = null;
    private JTextField maxBlueJTextField = null;
    private JTextField maxGreenJTextField = null;
    private JLabel maxJLabel = null;
    private JTextField maxRedJTextField = null;
    private JTextField minBlueJTextField = null;
    private JTextField minGreenJTextField = null;
    private JLabel minJLabel = null;
    private JTextField minRedJTextField = null;
    private JButton okJButton = null;
    private JLabel redJLabel = null;
    private JLabel titleJLabel = null;
    private JLabel xJLabel = null;
    private JLabel yJLabel = null;
}

