   M S B A M L   `   `   `  ����T  PClicker Heroes Calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Clicker_Heroes_Calculator.ViewModels$Clicker_Heroes_Calculator.ViewModels  5      Q-clr-namespace:Clicker_Heroes_Calculator.ViewsClicker_Heroes_Calculator.Views  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35P7clr-namespace:System.Windows.Input;assembly=WindowsBaseSystem.Windows.Input 5      W0clr-namespace:Clicker_Heroes_Calculator.Controls"Clicker_Heroes_Calculator.Controls  5	      .    (Clicker_Heroes_Calculator.Views.HeroView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Avm2clr-namespace:Clicker_Heroes_Calculator.ViewModels     5      ;v-clr-namespace:Clicker_Heroes_Calculator.Views     5      Iinput7clr-namespace:System.Windows.Input;assembly=WindowsBase     5      Econtrols0clr-namespace:Clicker_Heroes_Calculator.Controls     5	        � 	Resources  5         HeroUpgrades �� Source �� Path  UpgradeView1   +Clicker_Heroes_Calculator.Views.UpgradeView � DataContext  LevelUpButton �� 
TargetType �� Property �� Value  LevelUpCost �� 
TargetType ��Name	 �� DataType8   2Clicker_Heroes_Calculator.ViewModels.HeroViewModel
 �� Orientation  OutlinedText  LevelUpButtonImage !� Visual6   0Clicker_Heroes_Calculator.Controls.NineGridImage   Source   Offsets �� ElementName  HeroPanelBackground  LevelUpButtonPopupStyle �� Triggers �� Binding �� Value  LevelTextBoxStyle J� SnapsToDevicePixels 	 Key T� X T� Y3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   
BlurRadius   Color 
 Up  Down  Left 	 Right  DropShadowEffect J� Effect �� Triggers P� Property P� Value �� 
TargetName  	EmptyText��%  &	        &	 3     &	 i     &	 �    &	 y    &	 O    &	     &	 �    7 
 7  7  7  7  &	 �    �� 5   
    5      �� $ HeroUpgrades��� 5   
   .R�5         6   �� 5      �� 5   
   " ��6&   .�5      ��  � �� 6(   �� �� 5       � ��# �  60   �� 5       � �� 6(   �� $ LevelUpCommand��� 5       � ��$
 72px��6'   �� 5       � ��$ 128px��6&   �� 5       � ��$ 0q�60   �� 5       � ��$ 10q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5       �� $ Border��6!   $��0q�5!      #��z��5"      #��z��5#      ._�5$      �� $��Center=�6/   $��Center=�5%   %   ��. 5&   %   5'      5(      5*      5+      �� 5-   
   "	  6+   .R�5.      �� $
 Vertical=�6   $��Center=�60   $��Center=�6M   .+�5/      �� $
��20px(�6!   $��Center=�6W   
��� ���#���  6�   ��61   �� *LevelUpButtonText+6�   �� 50      $
 
Horizontal=�6   $��Center=�66   .+�51      �� $&�� ..\Resources\Images\goldicon.png��6   $��25��6F   $��25��6R   �� 52      $
��Cost��6%   $
��18px(�61   
��� ���#���  6u   ��6A   �� *LevelUpCost+6u   53      54      55      !� 57   
    58        59      $+ %..\Resources\Images\levelupbutton.png��6)   $ 10 10q�6�   ��6X   �� $ LevelUpButton��$ Width���6�   �� $ LevelUpButton��$ Height�6�   5;      !� 5=   
    5>        5?      $, &..\Resources\Images\herobackground.png��6)   $ 10 10q�6�   ��6Y   �� $ 	HeroPanel��$ Width���6�   �� $ 	HeroPanel��$ Height�6�   5A      �� 5C   
   " �60    5D      �� 5E       6   �� $ LevelUpButton��$ IsMouseOver� True5G   "   .a�5H      ��  � �� . 6/   5I      5K      �� 5M   
   " ��6*   .�5N      ��  � ��
 ���� 6,   �� 5O       � ��$	 0.5q�60   �� 5P       � ��
 ���� 6+   �� 5Q       � �� 5R      �� 5S      " ��6&   .R�5T      �� $��border��5W      #��z��5T   !   #��z��5U      #��z��5V       . ._�5Y      �   5Z   "   ��T� 5[   &   Up	 $ 2Q�6D   $ 1Q�6J   T� 5\   &   Down	 $ 2Q�6F   $ -1Q�6L   T� 5]   &   Left	 $ 3Q�6F   $ 0Q�6L   T� 5^   &   	Right	 $ 1Q�6G   $ 0Q�6M     5_   &   DropShadowEffect	 $ 0Q�6P   $ 3Q�6`   $ 	#FF666666��6o   5`   #   .+�5a   "   �� 8z�  ���	#FF666666#��z��6i   �� 5b   "   8z� ���	#FF666666#��z��6k   �� 5c   "   8z� ���	#FF666666#��z��6k   �� 5d   "   8z� ���	#FF666666#��z��6l   �� 5e   "   $��PART_ContentHost��5g       $��Hidden=�5e   /   8  $��Hidden=�5f       |�.  5h       5i      5j       5l      P� 5m       �@J�IsMouseOver . . �5n   "   �� $ border��6G    � ��
 �   �6[   �� 5o   "   $ border��6F    � ��
 �����6Z   5p      P� 5q       �@J�IsKeyboardFocused . . �5r   "   �� $ border��6G    � ��
 �   �6[   �� 5s   "   $ border��6F    � ��
 �����6Z   5t      5v      5x      5y      �� 5{   
   " ��6"   .�5|      ��  � ��$ 	0,0,10,10q�6'    5}      P� 5~       � ��$  ��6*   . �5      ��  � y�$ 	Collapsed=�63   5�      5�      5�      .��5�      � -   5        $��	HeroPanel��5�      #��[ 6   $��510px��6N   $��102px��6\   $��5q�6k    � ColumnDefinitions 5�   
   �� 5�      $
��Auto �6   �� 5�      $
��Auto �6    z� SharedSizeGroup$ A��6,   �� 5�      $
��Auto �6   .+�5�   
   � -   5        $��LevelUpButtonPopup��5�      $	��300��6*   $��Right=�66    � AllowsTransparency . #��[ 6b   .��5�      �� ���	#D5000000
�������$��5q�6A     �� CornerRadius$  8,8,3,3��6U   ._�5�      �� $
 Vertical=�6   $��5q�64     5�      ��%   '��       �� 5�      " ��6    .�5�      ��  � ��$ 	0,0,10,10q�67   �� 5�       � ��
 �����6;   5�      5�      .+�5�      �� $��14(�6;   ��6    �� $
 Name�6;   �� 5�      
�������#��[ 6Y   ��6    �� $ CurrentDPSPopup�6Y   �� 5�      
��� � ���6    �� $ NextLevelDPS�6C   �� 5�      
�������#��[ 6_   ��6    �� $ LevelMultipliersPopup�6_   �� 5�      $
��Wrap=�6B   
��� �����6    �� $ Description�6V   �� 5�      $6��0Hold Shift for x10, 'Z' for x25, 'Ctrl' for x100��6    
��� � �6X   �� 5�      
��� ���#��[ 6T   ��6    �� $ GildedPopup�6T   5�      5�      5�      �� 5�   
   -   5        $��LevelUpButton��5�   !   $��0��6   $��2��66   #��[ 6C   #��[ 6t   � 5�   
   $��1��6   $��Center=�6   ! � RowDefinitions! 5�      �� 5�      $
��Auto �6    �� 5�      $
��Auto �6    �� 5�      $
��Auto �6    .+�5�      �� $��0��6   $
��14px(�6*   $��Right=�6X   
�������#���  6�   ��6:   �� $
 Name�6�   � 5�      $��1��6    5�      �� 5�      $	��50* �6'   �� 5�      $	��50* �6'   .+�5�      �� $��0��6!   $
��20px(�61   $
��Left=�6A   $��Center=�6\   
�������#���  6�   ��6w   �� $ 
CurrentDPS�6�   �� 5�      $
 
Horizontal=�6   $��1��66   $��Right=�6F   .+�5�      �� $
��20px(�6%   $
��Lvl ��65   $��Center=�6D   
�������#���  6r   �� 5�      $
��20px(�6_   $��Center=�6o   
�������$��20��6�   " �� 	MaxLength$" 4��6�   #��[ 6�   ��6   �� $ Level�# �� UpdateSourceTrigger$# PropertyChanged=�6�   5�      5�      �� 5�      -   5        $��Upgrades��5�      $��2��6+   # [  68   #��[ 6|   ��6d   �� ��5�      �� 5�      .R�5�      � 5�      5�      5�      �� 5�   
   $��2��6   $
��None=�6B   ��6    �� $ 	HeroImage�6B   5�      5�      