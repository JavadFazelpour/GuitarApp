
namespace GuitarApp
{
    public static class EnumExtentions
    {
        public static string ToLowerCaseString(this Types type)
        {
            return type.ToString().ToLower();
        }
        public static string ToLowerCaseString(this Builders builder)
        {
            return builder.ToString().ToLower();
        }
        public static string ToLowerCaseString(this Wood wood)
        {
            string output = "";
            switch (wood)
            {
                case Wood.INDIAN_ROSEWOOD:
                    output = "Indian Rosewood";
                    break;
                case Wood.BRAZILAN_ROSEWOOD:
                    output = "Brazilian Rosewood";
                    break;
                case Wood.MAHOGANY:
                    output = "Mahogany";
                    break;
                case Wood.MAPLE:
                    output = "Maple";
                    break;
                case Wood.COCOBOLO:
                    output = "Cocobolo";
                    break;
                case Wood.CEDAR:
                    output = "Cedar";
                    break;
                case Wood.ADIRONDACK:
                    output = "Adirondack";
                    break;
                case Wood.ALDER:
                    output = "Alder";
                    break;
                case Wood.SITKA:
                    output = "Sitka";
                    break;
            }
            return output;
        }
    }
}
