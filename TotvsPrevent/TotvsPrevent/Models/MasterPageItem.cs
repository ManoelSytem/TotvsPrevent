using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TotvsPrevent.Models
{
    public class MasterPageItem
    {
        public string Title { get; set; }
        public ImageSource Icon { get; set; }
        public Type TargetType { get; set; }
    }
}
