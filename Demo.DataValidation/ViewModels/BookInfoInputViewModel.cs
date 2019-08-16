namespace Demo.DataValidation.ViewModels
{
    using System.Globalization;
    using System.Windows.Controls;
    using Demo.Share;

    public class BookInfoInputViewModel:ViewModelBase
    {
        private string _bookName;
        public string BookName { get => _bookName; set => Set(ref _bookName, value); }

        private string _bookAuthor;
        public string BookAuthor { get => _bookAuthor; set => Set(ref _bookAuthor, value); }

        private string _bookDescription;
        public string BookDescription { get => _bookDescription; set => Set(ref _bookDescription, value); }
    }

    public class StringLengthRule:ValidationRule
    {
        public uint MaxLength { get; set; }
        public uint MinLength { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool validate = false;
            if(value != null)
            {
                int len = (value as string).Length;
                validate = len > MinLength && len < MaxLength ? true : false;
            }
            //ValidationResult result = 
            return new ValidationResult(validate, validate?string.Empty:"字符串长度限制!");
        }
    }
}
