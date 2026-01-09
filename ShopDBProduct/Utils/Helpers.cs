using System.Text;

namespace ShopDBProduct.Utils
{
    public static class Helpers
    {

        public static string ConvertSnakeCase(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            var sb = new StringBuilder();
            sb.Append(char.ToLower(value[0]));

            for (int i = 1; i < value.Length; ++i)
            {
                if (char.IsUpper(value[i]))
                {
                    sb.Append('_');
                }
                sb.Append(char.ToLower(value[i]));

            }

            return sb.ToString();
        }
    }
}
