   M S B A M L   `   `   `  ����T  PClicker Heroes Calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Clicker_Heroes_Calculator.ViewsClicker_Heroes_Calculator.Views  5      1    +Clicker_Heroes_Calculator.Views.UpgradeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;v-clr-namespace:Clicker_Heroes_Calculator.Views     5      .��5	      � -   5        $��UpgradePanel��5	      .+�5
   
   � -   5        $��LevelUpButtonPopup��5
      $	��300��5      $��Right=�5        � AllowsTransparency  . ��5      �� 5       �� 
TargetType" �6    �� Triggers 5      �� 5       �� Binding 6&   ��  �� ElementName$ UpgradePanel�� �� Path$ IsMouseOver� �� Value True5   "   .a�5      ��  �� Property � �� �� Value . 67   5      5      .��5      �� ���	#D5000000
�������$��5q�6A   	 �� CornerRadius$	 8,8,3,3��6U   ._�5      �� 
 �� Orientation$
 Vertical=�6   $��5q�64    � 	Resources 5      ��%   '��       �� 5      " ��6    .�5      ��  � ��$ 	0,0,10,10q�67   �� 5       � ��
 �����6;   5      5       .+�5!      �� $��14(�6;   $��0q�6I   ��6    �� $
 Name�6I   �� 5"      
��� ���$��0q�6T   ��6    �� $ 	PopupCost�6T   �� 5#      
���  ��$��0q�6�   ��6    �� $ HeroLevelRequired� �� StringFormat$ Requires hero level: {0}����5$      �� 5%      " ��6$    5&   "   �� 5'   &    62   �� $ 	IsBuyable� true6U   .a�5(   *   ��  � y�$ 	Collapsed=�6G   5)   '   5+      5-      �� 5.      $
��Wrap=�6=   
���������6    �� $ Effect�6Q   �� 5/      $
��Wrap=�6B   
��� �����6    �� $ Description�6V   50      51      52      �� 53   
   -   5        $��UpgradeButton��53      {�6&   �� $ 	IsBuyable���6K   �� $ 
BuyCommand���54      �� 55       �� 
TargetType" ��6"   .R�56      �  �Name$
 Grid��6   .+�57      �� $��
Background��6    $.��(../Resources/Images/Icons/background.png��62   $
��None=�6d    � LayoutTransform 58      �� 59   "    �� ScaleX$	 0.6Q�61    �� ScaleY$	 0.6Q�6>   5;      �� 5<      $
��None=�6D   ��6    �� $ UpgradeIcon� 5=      �� 5>   "   $	 0.6Q�61   $	 0.6Q�6>   5@      �� 5A      $*��$../Resources/Images/Icons/border.png��6    $
��None=�6N    5B      �� 5C   "   $	 0.6Q�61   $	 0.6Q�6>   5E      �� 5F      $)��#../Resources/Images/Icons/check.png��6    $	��Top=�6M   $
��Left=�6e   $
��None=�6�   ��5G      �� 5H   "   " ��6(    5I   &   �� 5J   *    66   �� $ Owned�	 false6U   .a�5K   .   ��  � y�$ Hidden=�6K   5L   +   5N   #    5P      �� 5Q   "   $	 0.8Q�61   $	 0.8Q�6>   z�5S      T� 5T   "    T� X$ 0Q�65    T� Y$ -4Q�6;   5V      �� 5W      ���	#BF000000��5X      �� 5Y   "   " ��6(    5Z   &   �� 5[   *    66   �� $ 	IsEnabled�$ UpgradeButton�� true6t   .a�5\   .   ��  � y�$ Hidden=�6K   5]   +   5_   #    J� OpacityMask 5a      !� 5b   "    !� Visual 6.   �� $ 
Background��5d      5e      5f      5h      5i      5j      