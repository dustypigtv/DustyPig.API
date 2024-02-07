namespace DustyPig.API.v3.Models
{
    public class TitleRequestPermissionsValue
    {
        public TitleRequestPermissionsValue() { }

        public TitleRequestPermissionsValue(TitleRequestPermissions value) => Value = value;

        public TitleRequestPermissions Value { get; set; }
    }
}
