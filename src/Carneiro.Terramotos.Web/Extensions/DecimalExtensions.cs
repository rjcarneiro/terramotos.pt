namespace Carneiro.Terramotos.Web.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToMagnitude(this decimal d) => $"{d:N1}";
    }
}
