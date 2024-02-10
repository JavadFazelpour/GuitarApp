
namespace GuitarApp
{
    public class GuitarSpec
    {
        private string model;
        private Builder builder;
        private Wood backWood, topWood;
        private Type type;
        int numStrings;

        public GuitarSpec(string model, Builder builder, Wood backWood, Wood topWood, Type type, int numStrings)
        {
            this.model = model;
            this.builder = builder;
            this.backWood = backWood;
            this.topWood = topWood;
            this.type = type;
            this.numStrings = numStrings;
        }

        public Builder GetBuilder() => builder;
        public string GetModel() => model;
        public Type getType() => type;
        public Wood GetBackWood() => backWood;
        public Wood GetTopWood() => topWood;
        public int GetNumStrings() => numStrings;

        public bool Matches(GuitarSpec otherSpec)
        {
            if (builder.ToLowerCaseString() != otherSpec.builder.ToLowerCaseString())
                return false;
            if (model.ToLower() != otherSpec.model.ToLower() &&
                model!=null &&
                !model.Equals(""))
                return false;
            if (type.ToLowerCaseString() != otherSpec.type.ToLowerCaseString())
                return false;
            if (backWood.ToLowerCaseString() != otherSpec.backWood.ToLowerCaseString())
                return false;
            if (topWood.ToLowerCaseString() != otherSpec.topWood.ToLowerCaseString())
                return false;
            return true;
        }

    }
}
