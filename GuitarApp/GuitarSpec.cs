
namespace GuitarApp
{
    public class GuitarSpec
    {
        public string Model { get; set; }
        public Builders Builder { get; set; }
        public Wood BackWood { get; set; }
        public Wood TopWood { get; set; }
        public Types Type { get; set; }

        public int NumStrings { get; set; }
        public GuitarSpec(string model, Builders builder, Wood backWood, Wood topWood, Types type, int numStrings)
        {
            Model = model;
            Builder = builder;
            BackWood = backWood;
            TopWood = topWood;
            Type = type;
            NumStrings = numStrings;
        }
        public override string ToString()
        {
            return $"{Builder.ToLowerCaseString()} " +
                   $"{Model} " +
                   $"{NumStrings}-string " +
                   $"{Type.ToLowerCaseString()} guitar:\n   " +
                   $"{BackWood.ToLowerCaseString()} back and sides,\n   " +
                   $"{TopWood.ToLowerCaseString()} top.\n   ";
        }
        public bool Matches(GuitarSpec otherSpec)
        {
            if (Builder.ToLowerCaseString() != otherSpec.Builder.ToLowerCaseString())
                return false;
            if (Model.ToLower() != otherSpec.Model.ToLower() &&
                Model != null &&
                !Model.Equals(""))
                return false;
            if (Type.ToLowerCaseString() != otherSpec.Type.ToLowerCaseString())
                return false;
            if (BackWood.ToLowerCaseString() != otherSpec.BackWood.ToLowerCaseString())
                return false;
            if (TopWood.ToLowerCaseString() != otherSpec.TopWood.ToLowerCaseString())
                return false;
            return true;
        }

    }
}
