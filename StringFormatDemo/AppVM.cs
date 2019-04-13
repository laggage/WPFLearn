using Microsoft.Practices.Prism.ViewModel;

namespace StringFormatDemo
{
    class AppVM:NotificationObject
    {
        public AppVM()
        {
            User = new User
            {
                FirstName = "La",
                LastName = "Laggage",
                Sex = "男",
                Age = 20
            };
        }

        private User _user;
        public User User
        {
            get => _user;
            set
            {
                if (value == _user) return;
                _user = value;
                RaisePropertyChanged(nameof(User));
            }
        }

    }
}
