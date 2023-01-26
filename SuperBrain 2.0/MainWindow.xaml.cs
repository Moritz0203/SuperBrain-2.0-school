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

        List<int>[] randomNumbers = new List<int>[2];

        List<int>[] PlayerNumbers = new List<int>[2];
        
        async void Main()
        {
            Random random = new();

            RandomNumbers(6);

            int count = 2;
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                TextBlockCount.Text = Convert.ToString(count--);

                for (int i2 = 0; i2 < randomNumbers[i].Count; i2++)
                {
                    Trace.WriteLine(randomNumbers[i][i2].ToString() + "---" + i);
                }
                
                Box1.Text = randomNumbers[i][0].ToString();
                Box2.Text = randomNumbers[i][1].ToString();
                Box3.Text = randomNumbers[i][2].ToString();
                Box4.Text = randomNumbers[i][3].ToString();
                Box5.Text = randomNumbers[i][4].ToString();
                Box6.Text = randomNumbers[i][5].ToString();

                await Task.Delay(random.Next(2000, 9000));

                StackPanelTextBoxen.IsEnabled = true;

                PlayerNumbers[i] = new List<int>();

                Box1.Clear();
                Box2.Clear();
                Box3.Clear();
                Box4.Clear();
                Box5.Clear();
                Box6.Clear();

                Box1.Focus();
                await Task.Delay(5000);
                
                PlayerNumbers[i].Add(Convert.ToInt32(Box1.Text));
                PlayerNumbers[i].Add(Convert.ToInt32(Box2.Text));
                PlayerNumbers[i].Add(Convert.ToInt32(Box3.Text));
                PlayerNumbers[i].Add(Convert.ToInt32(Box4.Text));
                PlayerNumbers[i].Add(Convert.ToInt32(Box5.Text));
                PlayerNumbers[i].Add(Convert.ToInt32(Box6.Text));

                StackPanelTextBoxen.IsEnabled = false;
            }

            TextBlockCount.Visibility= Visibility.Hidden;
            StackPanelTextBoxen.Visibility = Visibility.Hidden;
            ListBox.Visibility= Visibility.Visible;
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

                ListBox1.Items.Add(Convert.ToString(randomNumbers[i][0]) + Convert.ToString(randomNumbers[i][1]) + Convert.ToString(randomNumbers[i][2]) + Convert.ToString(randomNumbers[i][3]) + Convert.ToString(randomNumbers[i][4]) + Convert.ToString(randomNumbers[i][5]) + " ---- " + PlayerNumbers[i][0] + PlayerNumbers[i][1] + PlayerNumbers[i][2] + PlayerNumbers[i][3] + PlayerNumbers[i][4] + PlayerNumbers[i][5]);

                if (KeinFehler) {
                    int temp = i + 1;
                    ListBox.Items.Add(temp + " Versuch"  + " Win");
                }
                else {
                    int temp = i + 1;
                    ListBox.Items.Add(temp + " Versuch" + " Falsch");
                }
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
            Main();
        }



        private void Box1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Box2.Focus();
            if (Box1.Text.Length > 1)
            {
                Box1.Text = Box1.Text.Substring(0, 1);
                Box1.SelectionStart = 1; 
            }
        }

        private void Box2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Box3.Focus();
            if (Box2.Text.Length > 1)
            {
                Box2.Text = Box2.Text.Substring(0, 1);
                Box2.SelectionStart = 1;
            }
        }

        private void Box3_TextChanged(object sender, TextChangedEventArgs e)
        {
            Box4.Focus();
            if (Box3.Text.Length > 1)
            {
                Box3.Text = Box3.Text.Substring(0, 1);
                Box3.SelectionStart = 1;
            }
        }

        private void Box4_TextChanged(object sender, TextChangedEventArgs e)
        {
            Box5.Focus();
            if (Box4.Text.Length > 1)
            {
                Box4.Text = Box4.Text.Substring(0, 1);
                Box4.SelectionStart = 1;
            }
        }

        private void Box5_TextChanged(object sender, TextChangedEventArgs e)
        {
            Box6.Focus();
            if (Box5.Text.Length > 1)
            {
                Box5.Text = Box5.Text.Substring(0, 1);
                Box5.SelectionStart = 1;
            }
        }

        private void Box6_TextChanged(object sender, TextChangedEventArgs e)
        {
            lost.Focus();
            StackPanelTextBoxen.Focus();
            if (Box6.Text.Length > 1)
            {
                Box6.Text = Box6.Text.Substring(0, 1);
                Box6.SelectionStart = 1;
            }
        }
    }
}