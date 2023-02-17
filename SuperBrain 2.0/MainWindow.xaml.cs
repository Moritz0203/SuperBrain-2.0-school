using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using System.ComponentModel.Design.Serialization;

namespace SuperBrain_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<int>[] randomNumbers = new List<int>[4];

        List<int>[] PlayerNumbers = new List<int>[4];

        List<TextBox> textBoxes = new List<TextBox>();

        async void Main()
        {
            Check();


            Random random = new();

            int speed = Convert.ToInt32(Convert.ToString(SliderSpeed.Value) + "000");
           
            int count = 10;
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                TextBlockCount.Text = Convert.ToString(count--);

                for (int i2 = 0; i2 < randomNumbers[i].Count; i2++)
                {
                    Trace.WriteLine(randomNumbers[i][i2].ToString() + "---" + i);
                }

                for (int i2 = 0; i2 < textBoxes.Count; i2++)
                {
                    textBoxes[i2].Text = randomNumbers[i][i2].ToString();
                }

                await Task.Delay(random.Next(4000, 4500));

                StackPanelTextBoxen.IsEnabled = true;

                PlayerNumbers[i] = new List<int>();

                for (int i2 = 0; i2 < textBoxes.Count; i2++)
                {
                    textBoxes[i2].Clear();
                }

                Box1.Focus();
                await Task.Delay(speed);

                for (int i2 = 0; i2 < textBoxes.Count; i2++)
                {
                    PlayerNumbers[i].Add(Convert.ToInt32(textBoxes[i2].Text));
                }

                StackPanelTextBoxen.IsEnabled = false;
            }

            TextBlockCount.Visibility= Visibility.Hidden;
            StackPanelTextBoxen.Visibility = Visibility.Hidden;
            ListWin.Visibility= Visibility.Visible;
            ListBox1.Visibility= Visibility.Visible;

            for (int i = 0; i < randomNumbers.Length; i++)
            {
                bool KeinFehler = true;
                for (int i1 = 0; i1 < randomNumbers[i].Count; i1++)
                {
                    if (randomNumbers[i][i1] != PlayerNumbers[i][i1])
                    {
                        KeinFehler = false;       
                    }
                }

                if (textBoxes.Count == 4)
                {
                    ListBox1.Items.Add(Convert.ToString(randomNumbers[i][0]) + Convert.ToString(randomNumbers[i][1]) + 
                        Convert.ToString(randomNumbers[i][2]) + Convert.ToString(randomNumbers[i][3]) + 
                        " ---- " + PlayerNumbers[i][0] + PlayerNumbers[i][1] + PlayerNumbers[i][2] + 
                        PlayerNumbers[i][3]);
                    ListWin.Margin = new Thickness(190, 71, 17, 0);
                }
                else if (textBoxes.Count == 6)
                {
                    ListBox1.Items.Add(Convert.ToString(randomNumbers[i][0]) + Convert.ToString(randomNumbers[i][1]) +
                        Convert.ToString(randomNumbers[i][2]) + Convert.ToString(randomNumbers[i][3]) + Convert.ToString(randomNumbers[i][4]) + Convert.ToString(randomNumbers[i][5]) +
                        " ---- " + PlayerNumbers[i][0] + PlayerNumbers[i][1] + PlayerNumbers[i][2] +
                        PlayerNumbers[i][3] + PlayerNumbers[i][4] + PlayerNumbers[i][5]);
                    ListWin.Margin = new Thickness(250, 71, 17, 0);
                }
                else if (textBoxes.Count == 8)
                {
                    ListBox1.Items.Add(Convert.ToString(randomNumbers[i][0]) + Convert.ToString(randomNumbers[i][1]) +
                        Convert.ToString(randomNumbers[i][2]) + Convert.ToString(randomNumbers[i][3]) + Convert.ToString(randomNumbers[i][4]) + Convert.ToString(randomNumbers[i][5]) + 
                        Convert.ToString(randomNumbers[i][6]) + Convert.ToString(randomNumbers[i][7]) +
                        " ---- " + PlayerNumbers[i][0] + PlayerNumbers[i][1] + PlayerNumbers[i][2] +
                        PlayerNumbers[i][3] + PlayerNumbers[i][4] + PlayerNumbers[i][5] + PlayerNumbers[i][6] + PlayerNumbers[i][7]);
                    ListWin.Margin = new Thickness(305, 71, 17, 0);
                }
                else if (textBoxes.Count == 10)
                {
                    ListBox1.Items.Add(Convert.ToString(randomNumbers[i][0]) + Convert.ToString(randomNumbers[i][1]) +
                        Convert.ToString(randomNumbers[i][2]) + Convert.ToString(randomNumbers[i][3]) + Convert.ToString(randomNumbers[i][4]) + Convert.ToString(randomNumbers[i][5]) +
                        Convert.ToString(randomNumbers[i][6]) + Convert.ToString(randomNumbers[i][7]) + Convert.ToString(randomNumbers[i][8]) + Convert.ToString(randomNumbers[i][9]) +
                        " ---- " + PlayerNumbers[i][0] + PlayerNumbers[i][1] + PlayerNumbers[i][2] +
                        PlayerNumbers[i][3] + PlayerNumbers[i][4] + PlayerNumbers[i][5] + PlayerNumbers[i][6] + PlayerNumbers[i][7] + PlayerNumbers[i][8] + PlayerNumbers[i][9]);
                    ListWin.Margin = new Thickness(380, 71, 17, 0);
                }

                if (KeinFehler) {
                    int temp = i + 1;
                    ListWin.Items.Add(temp + " Versuch" + " Win");
                }
                else {
                    int temp = i + 1;
                    ListWin.Items.Add(temp + " Versuch" + " Falsch");
                }
            }
        }
        

        void Check()
        {
            if (SliderBoxes.Value == 1)
            {
                StackPanelTextBoxen.Width = 194;
                StackPanelTextBoxen.Margin = new Thickness(403, 0, 0, 0);
                RandomNumbers(4);
                textBoxes.Add(Box1);
                textBoxes.Add(Box2);
                textBoxes.Add(Box3);
                textBoxes.Add(Box4);
            }
            else if (SliderBoxes.Value == 2)
            {
                StackPanelTextBoxen.Width = 294;
                StackPanelTextBoxen.Margin = new Thickness(353, 0, 0, 0);
                RandomNumbers(6);
                textBoxes.Add(Box1);
                textBoxes.Add(Box2);
                textBoxes.Add(Box3);
                textBoxes.Add(Box4);
                textBoxes.Add(Box5);
                textBoxes.Add(Box6);
            }
            else if (SliderBoxes.Value == 3)
            {
                StackPanelTextBoxen.Width = 394;
                StackPanelTextBoxen.Margin = new Thickness(303, 0, 0, 0);
                RandomNumbers(8);
                textBoxes.Add(Box1);
                textBoxes.Add(Box2);
                textBoxes.Add(Box3);
                textBoxes.Add(Box4);
                textBoxes.Add(Box5);
                textBoxes.Add(Box6);
                textBoxes.Add(Box7);
                textBoxes.Add(Box8);
            }
            else if (SliderBoxes.Value == 4)
            {
                StackPanelTextBoxen.Width = 494;
                StackPanelTextBoxen.Margin = new Thickness(253, 0, 0, 0);
                RandomNumbers(10);
                textBoxes.Add(Box1);
                textBoxes.Add(Box2);
                textBoxes.Add(Box3);
                textBoxes.Add(Box4);
                textBoxes.Add(Box5);
                textBoxes.Add(Box6);
                textBoxes.Add(Box7);
                textBoxes.Add(Box8);
                textBoxes.Add(Box9);
                textBoxes.Add(Box10);
            }
        }

        void RandomNumbers(int howmany)
        {
            Random random = new();
            for(int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = new List<int>();
                for (int i1 = 0; i1 < howmany; i1++)
                {
                    randomNumbers[i].Add(random.Next(0, 9));
                }
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StackPanelTextBoxen.Visibility = Visibility.Visible;

            Button1.Visibility = Visibility.Hidden;
            Welcom.Visibility = Visibility.Hidden;
            Label1.Visibility = Visibility.Hidden;
            Label2.Visibility = Visibility.Hidden;
            SliderBoxes.Visibility = Visibility.Hidden;
            SliderSpeed.Visibility = Visibility.Hidden;
            Main();
        }


        private void Box1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Box1.Text.Length >= 1)
            {
                Box2.Focus();
                Box1.Text = Box1.Text.Substring(0, 1);
                Box1.SelectionStart = 1; 
            }
        }

        private void Box2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Box2.Text.Length >= 1)
            {
                Box3.Focus();
                Box2.Text = Box2.Text.Substring(0, 1);
                Box2.SelectionStart = 1;
            }
        }

        private void Box3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Box3.Text.Length >= 1)
            {
                Box4.Focus();
                Box3.Text = Box3.Text.Substring(0, 1);
                Box3.SelectionStart = 1;
            }
        }

        private void Box4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Box4.Text.Length >= 1)
            {
                if (textBoxes.Count == 4)
                {
                    lost.Focus();
                }
                else
                {
                    Box5.Focus();
                }
                Box4.Text = Box4.Text.Substring(0, 1);
                Box4.SelectionStart = 1;
            }
        }

        private void Box5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Box5.Text.Length >= 1)
            {
                Box6.Focus();
                Box5.Text = Box5.Text.Substring(0, 1);
                Box5.SelectionStart = 1;
            }
        }

        private void Box6_TextChanged(object sender, TextChangedEventArgs e)
        {
            //StackPanelTextBoxen.Focus();
            if (Box6.Text.Length >= 1)
            {
                if (textBoxes.Count == 6)
                {
                    lost.Focus();
                }
                else
                {
                    Box7.Focus();
                }
                Box6.Text = Box6.Text.Substring(0, 1);
                Box6.SelectionStart = 1;
            }
        }
        private void Box7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Box7.Text.Length >= 1)
            {
                Box8.Focus();
                Box7.Text = Box7.Text.Substring(0, 1);
                Box7.SelectionStart = 1;
            }
        }

        private void Box8_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Box8.Text.Length >= 1)
            {
                if (textBoxes.Count == 8)
                {
                    lost.Focus();
                }
                else
                {
                    Box9.Focus();
                }
                Box8.Text = Box8.Text.Substring(0, 1);
                Box8.SelectionStart = 1;
            }
        }

        private void Box9_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Box9.Text.Length >= 1)
            {
                Box10.Focus();
                Box9.Text = Box9.Text.Substring(0, 1);
                Box9.SelectionStart = 1;
            }
        }

        private void Box10_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Box10.Text.Length >= 1)
            {
                lost.Focus();
                Box10.Text = Box10.Text.Substring(0, 1);
                Box10.SelectionStart = 1;
            }
        }

        private void Box2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Back)
            {
                Box1.Focus();
            }
        }

        private void Box3_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                Box2.Focus();
            }
        }

        private void Box4_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                Box3.Focus();
            }
        }

        private void Box5_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                Box4.Focus();
            }
        }

        private void Box6_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                Box5.Focus();
            }
        }

        private void Box7_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                Box6.Focus();
            }
        }

        private void Box8_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                Box7.Focus();
            }
        }

        private void Box9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                Box8.Focus();
            }
        }

        private void Box10_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                Box9.Focus();
            }
        }

        private void lost_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Back)
            {
                if(textBoxes.Count == 4)
                {
                    Box4.Focus();
                }else if (textBoxes.Count == 6)
                {
                    Box6.Focus();
                }else if (textBoxes.Count == 8)
                {
                    Box8.Focus();
                }else if (textBoxes.Count == 10)
                {
                    Box10.Focus();
                }
                
            }
        }
    }
}