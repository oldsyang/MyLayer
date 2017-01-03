using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWPFUI.Controls;

namespace MyLayer.ViewModels
{
    public class Demo1ViewModel : MyPropertyChanged
    {
        #region Property

        public int CeshiText { get; set; }
        public int ClockText { get; set; }

        #endregion

        #region Constractor

        public Demo1ViewModel()
        {
            ClockText = 10;
            MyTime.SetInterval(1000, () =>
            {
                if (ClockText > 0)
                {
                    ClockText -= 1;
                    OnPropertyChanged("ClockText");
                }
            });
        }

        #endregion

        #region Command Handlers

        #endregion

        #region Public

        public void Load()
        {
            MyTime.SetInterval(5000, () =>
            {
                CeshiText += 5000;
                OnPropertyChanged("CeshiText");
            });
        }
        #endregion

        #region Private

        #endregion
    }
}
