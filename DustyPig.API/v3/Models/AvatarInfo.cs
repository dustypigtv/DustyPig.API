namespace DustyPig.API.v3.Models;

public class AvatarInfo : UpdateAvatarInfo
{
    public string OriginalImage { get; set; }

    public string CroppedImage { get; set; }
}
