   M S B A M L   `   `   `  ����   IdealAutomateExplorer3    -Hardcodet.Wpf.Samples.Help.ClickImageIfExists   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       N� Title$  ClickImageIfExists��.��-�  -� ViewingMode$ Scroll=�.��/�  /� FontSize$ 20(�.T�J� .*�.*��� $��/Images/help1.png��$	��190��$	��190��$��0,0,30,0q� �� $��30(� �� BaselineAlignment$ Center=�.�ClickImageIfExistsJ� .*�.*��� $��24(�.�	Examples:�� .<��� .9�J� .*�.*��� .�ClickImageIfExists��  �� CellSpacing$ 0�� �� BorderThickness$ 1q� �� BorderBrush
 �   �.��� .��� 
�������$
��Bold"�.���  �� BorderBrush
 �   � �� BorderThickness$ 1q�.�J� 	 �� TextAlignment$	 Center=�.*�Verb�� 
 �   �$ 1q�.�J� $	 Center=�.*�	Entity1�� 
 �   �$ 1q�.�J� $	 Center=�.*�Relationship�� 
 �   �$ 1q�.�J� $	 Center=�.*�	Entity2�� .��� .��� 
 �   �$ 1q�.�J� .*�ClickImageIfExists�� 
 �   �$ 1q�.�J� .*�imgFindButton�� 
 �   �$ 1q�.�J� �� 
 �   �$ 1q�.�J� J� .*�.*��� .�Explanation of example�� - This will do a left-click on the imgFindButton if it is found. imgFindButton is defined as an image in the images tab, and the Windows Snipping Tool was used to cut-n-paste a picture of the find button into that definition. If attempts, sleep, RelativeX, RelativeY, UseGrayScale, Tolerance, etc. were specified in the definition of the image, they will all be taken into account when looking for the image.�� J� .*�.*��� 
 �� Stretch$

 Fill=�
���   �	 �� X2$ 1��J� .*�.*��� $��24(�.�
Columns:J� .*�.*��� .�ClickImageIfExistsYW - provides you with a quick and dirty way to do a left-click on an image if it exists.J� $
��14pt(�.*�.*��� .�.��� .�1. SequenceJ� .*���Sequence is a decimal number with 4 digits after the decimal. It can be modified to allow you to insert rows anywhere in your script. Rows are executed in sequence number order.J� $
��14pt(�.*�.*��� .�.��� .�	2. VerbJ� .*�!The verb is ClickImageIfExists.J� $
��14pt(�.*�.*��� .�.��� .�
3. Entity1J� .*�JHEntity1 is the name of an image that has been defined in the images tab.J� $
��14pt(�.*�.*��� .�.��� .�4. RelationshipJ� .*�Relationship is not used.J� $
��14pt(�.*�.*��� .�.��� .�
5. Entity2J� .*�Entity2 is not used.