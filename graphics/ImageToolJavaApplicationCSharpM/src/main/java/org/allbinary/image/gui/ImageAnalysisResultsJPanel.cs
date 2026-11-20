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
using ImageAnalysisResults = org.allbinary.media.image.analysis.ImageAnalysisResults;
using ImageColorRangeResults = org.allbinary.media.image.analysis.ImageColorRangeResults;
using ImageColorResults = org.allbinary.media.image.analysis.ImageColorResults;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
//using DefaultComboBoxModel = javax.swing.DefaultComboBoxModel;
//using GroupLayout = javax.swing.GroupLayout;
//using JComboBox = javax.swing.JComboBox;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.image.gui;

public class ImageAnalysisResultsJPanel : JPanel
{
    public ImageAnalysisResultsJPanel(ImageAnalysisResults[] imageAnalysisResultsArray)
    {
        this.initComponents();
        ImageAnalysisResults imageAnalysisResults = imageAnalysisResultsArray[0];
        this.updateImageColorRangeResults(imageAnalysisResults);
    }

    private void initComponents()
    {
        this.jLabel1 = new JLabel();
        this.jLabel2 = new JLabel();
        this.jLabel3 = new JLabel();
        this.percentMatchingJTextField = new JTextField();
        this.totalPixelsJTextField = new JTextField();
        this.matchingPixelsJTextField = new JTextField();
        this.jComboBox1 = new JComboBox();
        this.jLabel4 = new JLabel();
        this.jLabel5 = new JLabel();
        this.jLabel6 = new JLabel();
        this.jLabel7 = new JLabel();
        this.avgRedJTextField = new JTextField();
        this.avgGreenJTextField = new JTextField();
        this.avgBlueJTextField = new JTextField();
        this.minGreenJTextField = new JTextField();
        this.jLabel8 = new JLabel();
        this.jLabel9 = new JLabel();
        this.jLabel10 = new JLabel();
        this.minRedJTextField = new JTextField();
        this.minBlueJTextField = new JTextField();
        this.jLabel11 = new JLabel();
        this.jLabel12 = new JLabel();
        this.jLabel13 = new JLabel();
        this.maxRedJTextField = new JTextField();
        this.maxGreenJTextField = new JTextField();
        this.maxBlueJTextField = new JTextField();
        this.jLabel1.setText("Matching Pixels:");
        this.jLabel2.setText("Total Pixels:");
        this.jLabel3.setText("Percent Matching:");
        this.percentMatchingJTextField.setEditable(false);
        this.totalPixelsJTextField.setEditable(false);
        this.matchingPixelsJTextField.setEditable(false);
        this.jComboBox1.setModel(new DefaultComboBoxModel(new string[] { CommonPhoneStrings.getInstance().ONE }));
        this.jComboBox1.setEnabled(false);
        this.jLabel4.setText("Image:");
        this.jLabel5.setText("Average Red:");
        this.jLabel6.setText("Average Green:");
        this.jLabel7.setText("Average Blue:");
        this.avgRedJTextField.setEditable(false);
        this.avgGreenJTextField.setEditable(false);
        this.avgBlueJTextField.setEditable(false);
        this.minGreenJTextField.setEditable(false);
        this.jLabel8.setText("Min Red:");
        this.jLabel9.setText("Min Green:");
        this.jLabel10.setText("Min Blue:");
        this.minRedJTextField.setEditable(false);
        this.minBlueJTextField.setEditable(false);
        this.jLabel11.setText("Max Red:");
        this.jLabel12.setText("Max Green:");
        this.jLabel13.setText("Max Blue:");
        this.maxRedJTextField.setEditable(false);
        this.maxGreenJTextField.setEditable(false);
        this.maxBlueJTextField.setEditable(false);
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jLabel3).addComponent(jLabel2).addComponent(jLabel1).addComponent(jLabel5).addComponent(jLabel6).addComponent(jLabel7).addComponent(jLabel4)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jComboBox1, GroupLayout.PREFERRED_SIZE, 81, GroupLayout.PREFERRED_SIZE).addComponent(avgBlueJTextField, GroupLayout.DEFAULT_SIZE, 81, short.MaxValue).addComponent(avgGreenJTextField, GroupLayout.DEFAULT_SIZE, 81, short.MaxValue).addComponent(avgRedJTextField, GroupLayout.DEFAULT_SIZE, 81, short.MaxValue).addComponent(totalPixelsJTextField, GroupLayout.DEFAULT_SIZE, 81, short.MaxValue).addComponent(percentMatchingJTextField, GroupLayout.DEFAULT_SIZE, 81, short.MaxValue).addComponent(matchingPixelsJTextField, GroupLayout.DEFAULT_SIZE, 81, short.MaxValue)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jLabel12).addComponent(jLabel13).addComponent(jLabel8).addComponent(jLabel9).addComponent(jLabel10).addComponent(jLabel11)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(minRedJTextField, GroupLayout.PREFERRED_SIZE, 82, GroupLayout.PREFERRED_SIZE).addComponent(maxGreenJTextField, GroupLayout.PREFERRED_SIZE, 82, GroupLayout.PREFERRED_SIZE).addComponent(minGreenJTextField, GroupLayout.PREFERRED_SIZE, 82, GroupLayout.PREFERRED_SIZE).addComponent(minBlueJTextField, GroupLayout.PREFERRED_SIZE, 82, GroupLayout.PREFERRED_SIZE).addComponent(maxRedJTextField, GroupLayout.PREFERRED_SIZE, 82, GroupLayout.PREFERRED_SIZE).addComponent(maxBlueJTextField, GroupLayout.PREFERRED_SIZE, 82, GroupLayout.PREFERRED_SIZE)).addContainerGap(18, short.MaxValue)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel4).addComponent(jComboBox1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(matchingPixelsJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel8).addComponent(minRedJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel2).addComponent(totalPixelsJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel9).addComponent(minGreenJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel3).addComponent(percentMatchingJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel10).addComponent(minBlueJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel5).addComponent(avgRedJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel11).addComponent(maxRedJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel6).addComponent(avgGreenJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(maxGreenJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel12)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel7).addComponent(avgBlueJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel13).addComponent(maxBlueJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))));
    }

    private void updateImageColorRangeResults(ImageAnalysisResults imageAnalysisResults)
    {
        ImageColorRangeResults imageColorRangeResults = imageAnalysisResults.getImageColorRangeResults();
        this.matchingPixelsJTextField.setText(imageColorRangeResults.getMatchingPixelsChecked().ToString());
        this.totalPixelsJTextField.setText(imageColorRangeResults.getTotalPixelsChecked().ToString());
        this.percentMatchingJTextField.setText(imageColorRangeResults.getPercent().ToString());
        ImageColorResults imageColorResults = imageAnalysisResults.getImageColorResults();
        this.avgRedJTextField.setText(imageColorResults.getColorAverage().getAvgRed().ToString());
        this.avgGreenJTextField.setText(imageColorResults.getColorAverage().getAvgGreen().ToString());
        this.avgBlueJTextField.setText(imageColorResults.getColorAverage().getAvgBlue().ToString());
        this.minRedJTextField.setText(imageColorResults.getColorRange().getMinRed().ToString());
        this.minGreenJTextField.setText(imageColorResults.getColorRange().getMinGreen().ToString());
        this.minBlueJTextField.setText(imageColorResults.getColorRange().getMinBlue().ToString());
        this.maxRedJTextField.setText(imageColorResults.getColorRange().getMaxRed().ToString());
        this.maxGreenJTextField.setText(imageColorResults.getColorRange().getMaxGreen().ToString());
        this.maxBlueJTextField.setText(imageColorResults.getColorRange().getMaxBlue().ToString());
    }

    private JTextField avgBlueJTextField = null;
    private JTextField avgGreenJTextField = null;
    private JTextField avgRedJTextField = null;
    private JComboBox jComboBox1 = null;
    private JLabel jLabel1 = null;
    private JLabel jLabel10 = null;
    private JLabel jLabel11 = null;
    private JLabel jLabel12 = null;
    private JLabel jLabel13 = null;
    private JLabel jLabel2 = null;
    private JLabel jLabel3 = null;
    private JLabel jLabel4 = null;
    private JLabel jLabel5 = null;
    private JLabel jLabel6 = null;
    private JLabel jLabel7 = null;
    private JLabel jLabel8 = null;
    private JLabel jLabel9 = null;
    private JTextField matchingPixelsJTextField = null;
    private JTextField maxBlueJTextField = null;
    private JTextField maxGreenJTextField = null;
    private JTextField maxRedJTextField = null;
    private JTextField minBlueJTextField = null;
    private JTextField minGreenJTextField = null;
    private JTextField minRedJTextField = null;
    private JTextField percentMatchingJTextField = null;
    private JTextField totalPixelsJTextField = null;
}

