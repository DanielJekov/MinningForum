namespace MF.Models.Common
{
    public static class ModelValidation
    {
        public static class User
        {
            public const int UsernameMinlength = 4;
            public const int UsernameMaxLength = 25;
        }

        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;
        }

        public static class Topic
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;
        }

        public static class Reply
        {
            public const int ContentMinLength = 2;
            public const int ContentMaxLength = 1000;
        }
    }
}
