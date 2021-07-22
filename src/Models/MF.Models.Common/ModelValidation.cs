namespace MF.Models.Common
{
    public static class ModelValidation
    {
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
