using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WPFFuctionExample.ViewModel
{
    /// <summary>
    /// 绑定的样例
    /// </summary>
    public class BindingExample:INotifyPropertyChanged
    {
        #region 属性

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value;RaisePropertyChanged(); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;RaisePropertyChanged(); }
        }

        private int height;
      
        public int Height
        {
            get { return height; }
            set { height = value; RaisePropertyChanged(); }
        }
        #endregion

        #region 触发器
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void RaisePropertyChanged([CallerMemberName]string propertyName=null)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
