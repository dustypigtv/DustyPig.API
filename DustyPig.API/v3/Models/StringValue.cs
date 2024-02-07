namespace DustyPig.API.v3.Models
{
    public class StringValue
    {
        public StringValue() { }

        public StringValue(string value) => Value = value;

        public string Value { get; set; }
    }
}
