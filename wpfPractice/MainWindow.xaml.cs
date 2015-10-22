using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace wpfPractice
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxInput.Text!="")
            {
                FileStream fStream = new FileStream("BinaryTest.txt", FileMode.Create);
                BinaryWriter bWrite = new BinaryWriter(fStream,Encoding.ASCII);
                bWrite.Write(textBoxInput.Text);
                bWrite.Flush();
                bWrite.Close();
                fStream.Close();
                MessageBox.Show("保存成功");
            }
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("BinaryTest.txt"))
            {
                FileStream fStream = new FileStream("BinaryTest.txt", FileMode.Open);
                BinaryReader bReader = new BinaryReader(fStream);
                labShow.Content = bReader.ReadString();
                bReader.Close();
                fStream.Close();
            }

        }
    }
}
