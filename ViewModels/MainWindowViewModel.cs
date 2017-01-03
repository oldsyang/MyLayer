using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MyLayer.Views;
using MyWPFUI.Controls;
using MyWPFUI.Controls.Models;
using MyWPFUI.Extensiones;

namespace MyLayer.ViewModels
{
    public class MainWindowViewModel : MyPropertyChanged
    {
        #region Property
        public bool IsCandrag { get; set; }
        public bool HasShadow { get; set; }
        public Dictionary<AnimationType, string> AnimationTypeCollection { get; set; }
        public KeyValuePair<AnimationType, string> SelectedAnimationType { get; set; }
        public AnimationType AnimationType { get; set; }
        /// <summary>
        /// 用于关闭弹出窗口（做到可控制弹出窗体）
        /// </summary>
        private InteractionRequest ClosePopup;
        public ICommand OpenMyLayerWinCommand { get; set; }
        #endregion

        #region Constractor

        public MainWindowViewModel()
        {
            ClosePopup = new InteractionRequest();
            GetAnimationTypeDic();
            OpenMyLayerWinCommand = new DelegateCommand(OpenMyLayerWinCommandClick);
        }



        #endregion

        #region Command handlers
        private void OpenMyLayerWinCommandClick()
        {
            var dd = new Demo1();
            dd.Width = 500;
            dd.Height = 300;
            var vm = new Demo1ViewModel();
            //设置20秒后关闭弹出窗体
            MyTime.SetTimeout(10000, () =>
            {
                ClosePopup.Request();
            });
            MyLayerServices.ShowDialog("Demo1", dd, vm, OnDialogCloseCallBack, new MyLayerOptions()
            {
                MaskBrush = SolidColorBrushConverter.From16JinZhi("#4F000000"),
                CanDrag = IsCandrag,
                HasShadow = HasShadow,
                AnimationType = SelectedAnimationType.Key

            }, 
            delegate//窗体呈现完毕后执行的委托方法
            {
                vm.Load();
            },
            ClosePopup//后台要关闭弹出窗口，只需要执行此InteractionRequest的Request()方法
            );

        }


        #endregion

        #region Public

        #endregion

        #region Private

        private void GetAnimationTypeDic()
        {
            AnimationTypeCollection = this.AnimationType.EnumToDictionaryWithDescription<AnimationType>();
        }

        private void OnDialogCloseCallBack(Demo1ViewModel vm)
        {
            MessageBox.Show("被主窗体关闭了");
        }
        #endregion
    }
}
