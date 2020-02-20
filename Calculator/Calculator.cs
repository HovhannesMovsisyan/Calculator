using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculator
{
    class MyCalculator
    {
        MainWindow w;
        double x;
        double y;
        string _action;

        public MyCalculator(MainWindow w)
        {
            this.w = w;
            

            foreach (UIElement elm in this.w.board.Children)
            {
                if (elm is Button)
                {
                    Button temp = elm as Button;
                    string t = temp.Tag.ToString();
                    if (t == "tiv")
                    {
                        temp.Click += Tiv_sexmel;
                    }
                    else if (t == "full")
                    {
                        temp.Click += Full;
                    }
                    else if (t == "gorc")
                    {
                        temp.Click += Gorcoxutyun;
                    }
                    else if(t== "havasar")
                    {
                        temp.Click += HashvelPatasxan;
                    }
                }
            }
        }

        private void HashvelPatasxan(object sender, RoutedEventArgs e)
        {
            y = double.Parse(this.w.label_result.Content.ToString());

            if (_action == "+")
            {
                this.w.label_result.Content = x + y;
            }
            else if (_action == "-")
            {
                this.w.label_result.Content = x - y;
            }
            else if (_action == "*")
            {
                this.w.label_result.Content = x * y;
            }
            else 
            {
                this.w.label_result.Content = x / y;

            }

        }
        private void ActivateButtons(bool what)
        {
            foreach (UIElement btn in this.w.board.Children)
            {
                if (btn is Button)
                {
                    Button temp = btn as Button;
                    if (temp.Tag.ToString() == "tiv")
                    {
                        int k = int.Parse(temp.Content.ToString());
                        if (k > 1)
                        {
                            temp.IsEnabled = what;
                        }
                    }
                }
            }
        }
        private void Gorcoxutyun(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if(b.Content.ToString() == "C")
            {
                this.w.label_result.Content = "0";
            }
            else if (b.Content.ToString() =="+/-" && double.Parse( this.w.label_result.Content.ToString())!=0)
            {
                this.w.label_result.Content = -double.Parse(this.w.label_result.Content.ToString());
            }
            else if (b.Content.ToString() == "back")
            {
                string tiv = this.w.label_result.Content.ToString();
              
                tiv = tiv.Substring(0, tiv.Length - 1);
                if (tiv.Length == 0)
                {
                    tiv = "0";
                }
                this.w.label_result.Content = tiv;

            }
            else if (b.Content.ToString() == ".")
            {
                //25
                string t = this.w.label_result.Content.ToString();
                if(t.IndexOf(",") != -1)
                {
                    return;
                }
                t += ",";
                this.w.label_result.Content = t;

            }
            else if (b.Content.ToString() == "BIN")
            {
               
                b.Foreground = Brushes.Red;
                b.Content = "DEC";
                int c = int.Parse(this.w.label_result.Content.ToString());
                int q;
                string tver = "";
                this.w.label_result.Content = "";
                while (c >= 1)
                {
                    q = c / 2;
                    tver += (c % 2).ToString();
                    c = q;
                }
                
                for (int i = tver.Length - 1; i >=0; i--)
                {
                    this.w.label_result.Content= this.w.label_result.Content.ToString() + tver[i];
                }
              
                this.ActivateButtons(false);
                


            }
            else if(b.Content.ToString() == "DEC")
            {
                b.Content = "BIN";
                b.Foreground = Brushes.Black;
                this.ActivateButtons(true);
               

                string bin = this.w.label_result.Content.ToString();
                double dec=0;
                int astichan=0;
                for (int i = bin.Length-1; i>=0; i--)
                {
                    astichan++;
                    dec += int.Parse(bin[i].ToString()) * Math.Pow(2, astichan);
                    this.w.label_result.Content = dec/2;
                }
                return;
            }


        }

        private void Full(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            _action = b.Content.ToString();
            x = double.Parse(this.w.label_result.Content.ToString());
            this.w.label_result.Content = "0";
        }

        private void Tiv_sexmel(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string current = this.w.label_result.Content.ToString();
            current += b.Content.ToString();
            if (current.StartsWith("0") && current.IndexOf(",") == -1)
            {
                current = current.Substring(1);
            }
            this.w.label_result.Content = current;

        }
    }

}
