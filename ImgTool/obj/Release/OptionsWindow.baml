   M S B A M L   `   `   `  ���� S  OOne Team - Img Tool V5.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ImgToolImgTool  T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls     ImgTool.OptionsWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:ImgTool     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro       � Title$   �� � Icon$ Resources/oneteam.png��$��313.169��$��638.452�� � WindowStartupLocation$ CenterScreen=�(  "MahApps.Metro.Controls.MetroWindow   IsMinButtonEnabled .      IsMaxRestoreButtonEnabled .     ShowMaxRestoreButton .     ShowMinButton .     TitleAlignment$ Center=�   	TitleCaps .  	 � 
ResizeMode$	 NoResize=�.��� $��11,0,0,0q�$
��Left=�$	��617��$	��250��$	��Top=�
 � RowDefinitions
 �� $
��118* ���  � ColumnDefinitions �� .+��� -    ��Name$ image��$
��Left=�$��92��$��
120,26,0,0q�$	��Top=�$	��340��$ ��Resources/oneteam_logo.png��4  .MahApps.Metro.Controls.MetroAnimatedTabControl  -     Name$ metroAnimatedTabControl��$
��Left=�$��
10,123,0,0q�$	��Top=�$	��116��$	��597��$ �� IsSynchronizedWithCurrentItem$
 TrueY�-  'MahApps.Metro.Controls.TabControlHelper   IsUnderlined . .@��� -    ��Name$
 tab1��$
��tab1��+  %MahApps.Metro.Controls.ControlsHelper   HeaderFontSize$ 20Q� .  � UseLayoutRounding .   � Cursor$
 Hand��.��� ���	#FFFBFBFB$��	0,0,0,-12q� �� .+��� -    ��Name$
 btn1��$	��btn��$��Right=�$��
0,21,315,0q�$	��Top=�$	��250��$��41��   ContentCharacterCasing$ Normal=�)  #MahApps.Metro.Controls.ButtonHelper   CornerRadius$	 500�� 
  Brush2#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=�   PreserveTextCase . $
 Hand�� 
 Brush1#���  �� -   $
 btn2��$	��btn��$��Right=�$��	0,21,26,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -   $
 tab2��$
��tab2��$ 20Q� .  .  $
 Hand��.��� ���	#FFFBFBFB$��	0,0,0,-12q� �� .+��� -   $
 btn3��$	��btn��$��Right=�$��
0,21,315,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -   $
 btn4��$	��btn��$��Right=�$��	0,21,26,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -	   $
 tab3��$
��tab3��$ 20Q� .  .  $
 Hand��.��� ���	#FFFBFBFB$��	0,0,0,-12q� �� .+��� -
   $
 btn5��$	��btn��$��Right=�$��
0,21,315,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -   $
 btn6��$	��btn��$��Right=�$��	0,21,26,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -   $
 tab4��$
��tab4��$ 20Q� .  .  $
 Hand��.��� ���	#FFFBFBFB$��	0,0,0,-12q� �� .+��� -   $
 btn7��$	��btn��$��Right=�$��
0,21,315,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -   $
 btn8��$	��btn��$��Right=�$��	0,21,26,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -   $
 tab5��$
��tab5��$ 20Q� .  .  $
 Hand��.��� ���	#FFFBFBFB$��	0,0,0,-12q� �� .+��� -   $
 btn9��$	��btn��$��Right=�$��
0,21,315,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -   $ btn10��$	��btn��$��Right=�$��	0,21,26,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -   $
 tab6��$
��tab6��$ 20Q� .  .  $
 Hand��.��� ���	#FFFBFBFB$��	0,0,0,-12q� �� $
��329* ��� $
��268* �.+��� -   $ btn11��$	��btn��$��Right=�$��0,21,47.123,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -   $ btn12��$	��btn��$��Right=�$��	0,21,26,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  $��2���� -   $
 tab7��$
��tab6��$ 20Q� .  .  $
 Hand��.��� ���	#FFFBFBFB$��	0,0,0,-12q� �� .+��� -   $ btn13��$	��btn��$��Right=�$��
0,21,315,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -   $ btn14��$	��btn��$��Right=�$��	0,21,26,0q�$	��Top=�$	��250��$��41��$ Normal=�$	 500��#���   
�������$��14.667(�$��Roboto)�$��Normal"� .  $��Center=�$��Center=� . $
 Hand��#���  �� -    ��Name$ label��$��Label��$��	0,0,0,-29q�$	��Top=�$��31��$��Center=�$��Center=� .  $��16(����	#FF1CB3C3$��Roboto)�$
��Left=�$	��575��$��1��