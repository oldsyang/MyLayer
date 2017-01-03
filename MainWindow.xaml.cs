using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyLayer.Views;
using MyWPFUI.Controls;
using MyWPFUI.Controls.Models;

namespace MyLayer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private int countindex = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var dd = new Demo1();
            //dd.Width = 800;
            //dd.Height = 640;
            Console.WriteLine("开始触发");
            //var vm = new MyLayerDemo1ViewModel();
            //MyLayerServices.ShowDialog("这是MyLayerDemo1", dd, vm, onDialogCloseCallBack, null,vm.SetMessage);
            MyWPFUI.Controls.MyLayer.ShowDialog(null, dd, "弹窗DEMO1", new MyLayerOptions()
            {
                MaskBrush = SolidColorBrushConverter.From16JinZhi("#4F000000"),
                CanDrag = true,
                HasShadow = true,
                AnimationType = AnimationType.InFormDown
            });
        }

        private InteractionRequest CloseRequest;
        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            var dd = new Demo1();
            dd.Width = 800;
            dd.Height = 640;

            //MyLayer.ShowDialog(null, dd, "弹窗DEMO1");
            //var vm = new MyLayerDemo1ViewModel();
            MyLayerServices.ShowDialog("这是MyLayerDemo2", dd, this, onDialogCloseCallBack, new MyLayerOptions()
            {
                MaskBrush = SolidColorBrushConverter.From16JinZhi("#4F000000"),
                CanDrag = true,
                HasShadow = true,
                AnimationType = AnimationType.InFormDown

            }, delegate
            {
                MessageBox.Show("渲染数据");
            }, CloseRequest);
        }

        private void onDialogCloseCallBack(object o)
        {
            MessageBox.Show("关闭后的反馈");
        }



        private void IndexButton_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            countindex++;
            btn.Content = countindex;
        }

        private void DecresButton_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            countindex--;
            btn.Content = countindex;
        }
    }
}
