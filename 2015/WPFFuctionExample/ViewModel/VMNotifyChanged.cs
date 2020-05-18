using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFFuctionExample.ViewModel
{
    /// <summary>
    /// View Model NotifyPropertyChanged 基类
    /// </summary>
    public class VMNotifyChanged : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged 接口实现
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected void RaisePropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //简化设置
        protected bool Set<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            //比对2个类型是否一致
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
        #endregion

      
    }
}
