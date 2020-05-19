using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo
{
    public partial class TodoCell : ViewCell
    {
        protected StackLayout MasterLayout => masterLayout;
        protected Label ItemCountLabel => itemCountLabel;
        public TodoCell()
        {
            InitializeComponent();
        }
    }
}
