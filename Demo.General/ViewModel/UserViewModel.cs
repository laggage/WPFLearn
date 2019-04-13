using Demo.Share.Model.Models;
using GalaSoft.MvvmLight;

namespace Demo.General.ViewModel
{
    internal class UserViewModel:ObservableObject
    {
        public User User { get; }

        public UserViewModel()
        {
            User = new User();
        }
        public UserViewModel(string name,int age, Sex sex)
        {
            User = new User(name, age, sex);
        }
    }
}
