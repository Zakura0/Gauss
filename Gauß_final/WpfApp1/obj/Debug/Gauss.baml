   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Gauss_UIGauss_UI  5   	       Gauss_UI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Gauss_UI     5   	     � Title$'  !Gaußsches Eliminierungsverfahren��5   	   $	��450��62   $	��800��6?    � 
ResizeMode$ NoResize=�6K   .��5      � .+�5   
   �� -   5         ��Name$ bEintrag��5   M   $y�Hidden=�6(    �� 	IsDefault . $��Nächster Eintrag��6_   $
��Left=�6z   $��
92,164,0,0q�6�   $��1��6�   $	��Top=�6�   $	��100��6�   �� 5   
   -   5        $ 
bBerechnen��5      $��	Berechnen��6%   $
��Left=�69   $	��Top=�6T   $	��160��6l   $��302,333,0,0q�6x    � Cursor$ Arrow��6�   $��30��6�   $��1��6�   $��16(�6�   $y�Hidden=�6�   ��5      �� 5      .��5      �  � Color$ LightSteelBlue��6#    � Offset$ 0Q�6:   � 5      $ White��6#   $ 2Q�61   5      5      �� 5   
   -   5        $
 bNeu��5      $��Neue Eingabe��6   $
��Left=�66   $	��Top=�6Q   $	��107��6i   $��327,373,0,0q�6u   $ Arrow��6�   $��20��6�   $��1��6�   ���	#FF57BFBF$y�Hidden=�6�   �� 5   
   ���	#FF06064B$��
0,-1,0,375q�6,   $��2��6@   .+�5      �� 
�������$��20(�6'   $��Center=�5      .��6+   %#Das Gaußsche Eliminierungverfahren6O   5      �� 5   
   -   5         ��Name$ spMatrix��5   .    �� Orientation$ 
Horizontal=�6   $y�Visible=�6@   $��10,42,432,289q�6V   $��1��6m   .+�5      �� $��5��6   �� 5      $��5��6   �� 5      -   5        	 ��Name$	 tbZeilen��5      $��23��6(   $��0,0,0,36q�63   $��20��6E   $��Bottom=�6Q   �� 5      $��54��6   $��16(�6   $��Zeilen��6-   $��0,10,0,0q�6>   �� 5      -   5        $	 	tbSpalten��5      $��23��6)   $��0,0,0,36q�64   $��20��6F   $��Bottom=�6R   �� 5       $��73��6   $��16(�6    $��Spalten��6.   $��0,10,0,0q�6@   �� 5!      -   5        $ tButton��5!      $��
10,16,5,38q�6&   $��35��6:   $	��✓��6E   6Q   5"      �� 5#   
   -   5        
 ��Name$
 lEintrag��5#   $   $y�Hidden=�6   $�� ��66   $
��Left=�6A   $��
10,123,0,0q�6\   $��1��6p   $	��Top=�6}   $��36��6�   $	��286��6�   $��16(�6�   �� 5$   
   -	   5        $
 lInfo��5$      $�� ��6   $
��Left=�6*   $��
10,189,0,0q�6E   $��1��6Y   $	��Top=�6f   $��80��6~   $	��286��6�   $��16(�6�   $y�Hidden=�6�   �� 5%   
   -
   5        $
 lInfo4��5%      $�� ��6    $
��Left=�6+   $��	10,99,0,0q�6F   $��1��6Y   $	��Top=�6f   $��80��6~   $	��286��6�   $��16(�6�   $y�Hidden=�6�   �� 5&   
   -   5        $
 lInfo3��5&      $�� ��6    $
��Left=�6+   $��
10,184,0,0q�6F   $��1��6Z   $	��Top=�6g   $��40��6   $	��772��6�   $��20(�6�   $
��Bold"�6�   ���	#FF092C5F$y�Hidden=�6�   �� 5'   
   -   5        $
 lInfo2��5'   $   $y�Hidden=�6   $-��'Das Gleichungssystem hat keine Lösung!��64   $
��Left=�6e   $��
16,292,0,0q�6�   $��1��6�   $	��Top=�6�   $��36��6�   $	��295��6�   $��16(�6�   �� 5(   
   -   5        $
 lEing��5(      $��Eigegebene Matrix:��6   $
��Left=�6<   $��
509,55,0,0q�6W   $��1��6k   $	��Top=�6x   $��45��6�   $	��273��6�   $��18(�6�   $y�Hidden=�6�   �� 5)   
   $��Eingabe der Matrix:��6   $
��Left=�6.   $��	14,30,0,0q�6I   $��1��6\   $	��Top=�6i   $	��276��6�   $��16(�6�   �� 5*   
   -   5        $
 llmenge��5*      $�� ��6!   $
��Left=�6,   $��	0,269,0,0q�6G   $��1��6Z   $	��Top=�6g   $	��794��6   $��20(�6�   $
��Bold"�6�   ���	#FF06064B
�������$y�Hidden=�6�   �� 5+   
   -   5        $
 llösg��5+      $��Gelöste Matrix:��6   $
��Left=�69   $��
511,55,0,0q�6T   $��1��6h   $	��Top=�6u   $��45��6�   $	��273��6�   $��18(�6�   $y�Hidden=�6�   �� 5,   
   -   5        $	 	tbEintrag��5,   &   $y�Hidden=�6   $
��Left=�69   $��20��6T   $��
16,164,0,0q�6`   $��1��6t    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $��56��6�   �� 5-   
   -   5         ��Name$ 	tblMatrix��5-      $
��Left=�6'   $	��276��6B   $��509,105,0,0q�6O   $��1��6d   $
��Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��273��6�   $��18(�6�   $
��Bold"�6�   �� 5.   
   -   5        $ 	tblJordan��5.      $
��Left=�6'   $	��210��6B   $��509,105,0,0q�6O   $��1��6d   $
��Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��273��6�   $��18(�6�   $
��Bold"�6�   �� 5/   
   -   5        $ tblbsp��5/      $y�Hidden=�6$   $
��Left=�68   $��
20,213,0,0q�6S   $��1��6g   $
��Wrap=�6t   $	��Top=�6�   $	��187��6�   $	��109��6�   $��14(�6�   �� 6�   $
�Bsp:��6�   �� 6�   �� 6�   �� 6�   �� 6�   $�    1 2 3 4 | 5��6�   �� 6  �� 6!  $�1  a b c d | e��6%  �� 6=  �� 6I  $�2  a b c d | e��6M  �� 6e  �� 6q  $�3  a b c d | e��6u  �� 6�  �� 6�  $�4  a b c d | e��6�  �� 6�  �� 6�  $�5  a b c d | e��6�  �� 6�  �� 6�  $� ��6�  �� 6�  �� 6  $�Mit (Zeile, Spalte��6  �� 6#  $�)��6'  63   � RowDefinitions 50   
   �� 51      $��7* �6   �� 52      $
��412* �6   54      56      